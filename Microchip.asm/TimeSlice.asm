#INCLUDE<P16F877A.INC>
__CONFIG 3F32H
;四个数码管右边两个实现了一个秒表，四个红色按键按最右边的K20一个这两个数会减一，按K19会加一。按K18会切换秒表的停止和开始，按K17数字清零
;数码管左边两个数字会显示执行程序最多的那个时间片在程序执行完了之后TMR0计时器的计数值，16进制。注意TMR0的计数是从初值28开始的

;............初始化一些值..............;
K_TMR0_200us    EQU  d'28'       ;给TMR0赋初值的立即数，具体的根据实际来调整；在18.432M下，这个值设28，TMR0计时大约就是200μs
F_CNT1ms        EQU  020H        ;用来计数产生1ms时间块
F_CNT10ms       EQU  021H        ;用来计数产生10ms时间块
F_CNT100ms      EQU  022H        ;用来计数产生100ms时间块
F_CNT1s         EQU  023H        ;用来计数产生1s时间块
                                 
F_X200us        EQU  024H        ;用来设置进入第X个200us时间块
F_X1ms          EQU  025H        ;用来设置进入第X个1ms时间块
F_X10ms         EQU  026H        ;用来设置进入第X个10ms时间块
F_X100ms        EQU  027H        ;用来设置进入第X个100ms时间块
F_LED           EQU  028H        ;用于LED显示

F_NUM_SEL       EQU  029H        ;用于数码管位选
F_NUM0          EQU  02AH        ;数码管显示数值,0是最右边的那个
F_NUM1          EQU  02BH        ;
F_NUM2          EQU  02CH        ;
F_NUM3          EQU  02DH        ;
F_KEY0          EQU  02EH        ;用于移位寄存按键输入,进行按键检测
F_KEY1          EQU  02FH        ;
F_KEY2          EQU  030H        ;
F_KEY3          EQU  031H        ;
F_NUMCTRL       EQU  032H        ;第0位用于控制秒表的停止和开启
F_W             EQU  033H        ;用来暂存W
F_TMR0MAX       EQU  034H        ;缓存TMR0最大值，用来查看哪个时间片耗时最多，这个值会显示在数码管的左边两位，16进制


;............主  程  序..............;
   ORG				0000H		           ;定义程序存放区域的地址
MAIN                             
   NOP                           ;设置一条ICD必须的空操作指令
   CALL     PORT_INIT            ;调用端口初始化
   BSF      STATUS,RP0           ;设置文件寄存器为体1
   MOVLW    01H			             ;设置选项寄存器的值；00:2分频，01:4分频；
   MOVWF    OPTION_REG	         ;将00H赋值给选项寄存器 内部时钟源，4分频，将时钟分配给TMR0
   BCF      STATUS,RP0	         ;回到体0
   CLRF     INTCON               ;关中断，清溢出
   CALL     REG_INIT             ;调用各寄存器赋初值
   
LOOP_MAIN                        
   BCF			    INTCON,2         ;TMR0溢出清除
   MOVLW		    K_TMR0_200us     ;TMR0初值
   MOVWF		    TMR0	           ;给TMR0重新启动定时计数
   
;.....计数产生1ms时间块.....;      
   DECFSZ       F_CNT1ms,F       ;自减1，d为1，存回F,结果为零则跳一步
   GOTO         ELSE_1ms         ;
   MOVLW        d'5'             ;结果为零则赋回初值5，并执行下面的计数
   MOVWF        F_CNT1ms         
;.....计数产生10ms时间块....;    
   DECFSZ       F_CNT10ms,F      
   GOTO         ELSE_1ms         
   MOVLW        d'10'            ;结果为零则赋回初值10
   MOVWF        F_CNT10ms       
;.....计数产生100ms时间块...;    
   DECFSZ       F_CNT100ms,F     
   GOTO         ELSE_1ms         
   MOVLW        d'10'            ;结果为零则赋回初值10
   MOVWF        F_CNT100ms         
;.....计数产生1s时间块......;    
   DECFSZ       F_CNT1s,F        
   GOTO         ELSE_1ms         
   MOVLW        d'10'            ;结果为零则赋回初值10
   MOVWF        F_CNT1s
ELSE_1ms
;.....时间块产生结束.........;   

;.....选择某个时间片执行程序.;
  ;......5号200us时间片......; 
   MOVLW        05H
   XORWF        F_CNT1ms,W        ;比较是否相等
   BTFSS        STATUS,Z          ;如果相等就跳过   
   GOTO         END_IF200us_5
  ;是5号200us时间片就执行这些程序  
   MOVLW        d'10'                    
   MOVWF        F_X1ms	     
   MOVLW        d'10'                   
   MOVWF        F_X10ms	 
   MOVLW        d'5'                    
   MOVWF        F_X100ms      
   CALL         Enter_x100ms.x10ms.x1ms  ;进入5.10.10这个时间片
   BTFSS        STATUS,Z          
   GOTO         END_5_10_10              ;不是就跳到结束
   CALL         LED_RUN                  ;是5.10.10这个时间片就调用需要执行的程序，跑马灯，1秒灯走一次  
   CALL         TMR0MAX_DISPLAY          ;显示耗时最长时间片程序结束是TRM0的值
END_5_10_10   
   MOVLW        d'5'                    
   MOVWF        F_X1ms	     
   MOVLW        d'8'                   
   MOVWF        F_X10ms	 
   MOVF         F_CNT1s,W                            
   MOVWF        F_X100ms                 ;让这个参数等于现在的计数就相当于忽略这个计数
   CALL         Enter_x100ms.x10ms.x1ms  
   BTFSS        STATUS,Z          
   GOTO         END_x_8_8              
   CALL         NUM_RUN                  ;是x.9.9这个时间片就调用需要执行的程序  
END_x_8_8   
   
END_IF200us_5

;......4号200us时间片......; 
   MOVLW        04H
   XORWF        F_CNT1ms,W        ;比较是否相等
   BTFSS        STATUS,Z          ;如果相等就跳过   
   GOTO         END_IF200us_4
  ;是4号200us时间片就执行这些程序
   MOVLW        09H
   XORWF        F_CNT10ms,W       ;比较是否相等
   BTFSS        STATUS,Z          ;如果相等就跳过   
   GOTO         END_IF200us_4
  ;..进入9号1ms时间片
   CALL         KEY_DETECT        ;按键检测，10ms一次
  
END_IF200us_4

 ;......3号200us时间片......; 
   MOVLW        03H
   XORWF        F_CNT1ms,W        ;比较是否相等
   BTFSS        STATUS,Z          ;如果相等就跳过   
   GOTO         END_IF200us_3
  ;是3号200us时间片就执行这些程序
   BTFSS        F_CNT10ms,0       ;是偶数就去刷数码管，2ms刷一次
   CALL         DISPLAY_NUM                                                     

END_IF200us_3
     
         
;.....产生测试波形..........; 
   MOVLW        01H
   XORWF        F_CNT1ms,W       ;比较是否相等
   BTFSS        STATUS,Z           ;如果相等就跳过
   GOTO         ELSE1             
   BCF          PORTB,RB5   
   GOTO         END_IF1
ELSE1
   BSF			PORTB,RB5   
END_IF1

;...找出时间片最大占用率...;
   MOVF     TMR0,0
   SUBWF    F_TMR0MAX,W       ;MAX的值减去TMR0
   BTFSC    STATUS,C          
   GOTO     FINDMAX_ELSE
   MOVF     TMR0,W            ;小于就跳到这
   MOVWF    F_TMR0MAX           
   BCF		  PORTB,RB4
   GOTO     FINDMAX_END
FINDMAX_ELSE
   MOVF     TMR0,W
   SUBWF    F_TMR0MAX,W       
   BTFSC    STATUS,C
   GOTO     FINDMAX_ELSE
   BCF		PORTB,RB4
FINDMAX_END   
   
   BCF			PORTB,RB4             ;输出置0，从RB4端口输出波形用

;检测TMR0是否有溢出，移出就跳出LOOP_OF，跳回LOOP_MAIN
LOOP_OF                      
   BTFSS    INTCON,2              ;如果溢出，跳过GOTO LOOP_OF
   GOTO     LOOP_OF               
   BSF      PORTB,RB4             ;跳到这条了
   GOTO     LOOP_MAIN


;............主程序结束..............;
;.......................................这是一条主程序和子程序的分割线................................;
   
;......数码管查表子程序.........;
NUM_TABLE
   MOVWF     F_W
   SUBLW     d'16'               ;判断是否大于16，大于就不能查表，返回个-
   MOVF      F_W,W
   BTFSS     STATUS,C
   RETLW     03FH
   ADDWF     PCL,F
   RETLW     0C0H
   RETLW     0F9H
   RETLW     0A4H
   RETLW     0B0H
   RETLW     099H
   RETLW     092H
   RETLW     082H
   RETLW     0F8H
   RETLW     080H
   RETLW     090H
   RETLW     088H
   RETLW     083H
   RETLW     0C6H
   RETLW     0A1H
   RETLW     086H
   RETLW     08EH
   RETLW     0BFH
   
;....进入x100ms.x10ms.x1ms时间片子程序..;
Enter_x100ms.x10ms.x1ms
   MOVF     F_X1ms,W             ;把F_X1ms参数值送到W;
   XORWF    F_CNT10ms,W          ;比较是否相等,相等时结果为0，送到了W  
   BTFSS    STATUS,Z             ;如果相等就跳过下一条
   GOTO     END_Enter_xxx        ;不想等就直接结束，此时W中的值不为0
   MOVF     F_X10ms,W            ;把F_X10ms参数值送到W;               
   XORWF    F_CNT100ms,W         ;比较是否相等,相等时结果为0，送到了W  
   BTFSS    STATUS,Z             ;如果相等就跳过下一条
   GOTO     END_Enter_xxx        ;不想等就直接结束，此时W中的值不为0
   MOVF     F_X100ms,W           ;把F_X100ms参数值送到W;               
   XORWF    F_CNT1s,W            ;比较是否相等,相等时结果为0，送到了W              
          
END_Enter_xxx                    ;如果相等W就是0，标志位Z就是1
   return
;....把F_TMR0MAX的值给数码管....;
TMR0MAX_DISPLAY
  MOVF      F_TMR0MAX,W   
  ANDLW     b'00001111'
  MOVWF     F_NUM2
  MOVF      F_TMR0MAX,W
 ANDLW     b'11110000'
  MOVWF     F_NUM3
  SWAPF     F_NUM3     
  return
;.........跑马灯子程序..........;
LED_RUN
   BSF			PORTC,RC5            ;开启LED的锁存使能
   MOVF     F_LED,W
   MOVWF    PORTD
   BCF			PORTC,RC5            ;关闭LED的锁存使能
   ;循环左移F_LED
   BCF      STATUS,C             ;是0进位就设0
   BTFSC    F_LED,7              ;看最左边是0是1，是0则跳
   BSF      STATUS,C             ;是1进位就设1
   RLF      F_LED,1              ;移位产生跑马效果    
   return
   
;...........秒表子程序...........;
NUM_RUN
  BTFSC  F_NUMCTRL,0             ;控制第0位是0就不加秒表
  CALL   NUM_ADD
  return 
  
;..........秒表加...............;
NUM_ADD
   MOVLW     09H 
   XORWF     F_NUM0,W
   BTFSS     STATUS,Z               ;如果相等就跳过下一条
   GOTO      Add1_F_NUM0
   CLRF      F_NUM0                 ;加到9就清零
   MOVLW     09H
   XORWF     F_NUM1,W
   BTFSS     STATUS,Z             ;如果相等就跳过下一条
   GOTO      Add1_F_NUM1
   CLRF      F_NUM1
   GOTO      Add1_F_NUM1_END
  Add1_F_NUM1
     INCF      F_NUM1,F   
  Add1_F_NUM1_END   
   GOTO      Add1_F_NUM0_END  
Add1_F_NUM0
   INCF      F_NUM0,F
Add1_F_NUM0_END           
   return
;..........秒表减...............;
NUM_SUB
   MOVLW    09H
   MOVF     F_NUM0,F
   BTFSS    STATUS,Z                 ;等于0就去再设为9
   GOTO     SUB1_F_NUM0     
   MOVWF    F_NUM0                   ;设为9
   MOVF     F_NUM1,F
   BTFSS    STATUS,Z               ;等于0就去再设为9
   GOTO     SUB1_F_NUM1     
   MOVWF    F_NUM1                 ;设为9
   GOTO     SUB1_NUM1_END
   SUB1_F_NUM1
   DECF     F_NUM1,F
   SUB1_NUM1_END  
   GOTO     SUB1_NUM0_END
SUB1_F_NUM0
   DECF     F_NUM0,F
SUB1_NUM0_END
    
   return
;......数码管显示子程序.........;
DISPLAY_NUM
   MOVF     F_NUM_SEL,W
   BSF      PORTC,RC4            ;开启位选的锁存使能
   MOVWF    PORTD                ;输出位选
   BCF			PORTC,RC4            ;关闭位选的锁存使能
  ;....根据位选从寄存器中读出相应位的值
   BTFSC    F_NUM_SEL,0          ;为0跳过，继续判断其它位
   GOTO     DISPLAY0
   BTFSC    F_NUM_SEL,1          ;为0跳过，继续判断其它位
   GOTO     DISPLAY1
   BTFSC    F_NUM_SEL,2          ;为0跳过，继续判断其它位
   GOTO     DISPLAY2
   BTFSC    F_NUM_SEL,3          ;为0跳过，继续判断其它位
   GOTO     DISPLAY3

DISPLAY0
   MOVF     F_NUM0,W
   GOTO     END_NUM_SELECT  
DISPLAY1
   MOVF     F_NUM1,W
   GOTO     END_NUM_SELECT
DISPLAY2
   MOVF     F_NUM2,W
   GOTO     END_NUM_SELECT    
DISPLAY3
   MOVF     F_NUM3,W
   GOTO     END_NUM_SELECT  
   
END_NUM_SELECT     
  ;......把W里的数值查表转换成显示码
   CALL     NUM_TABLE            ;查表转码
   BSF      PORTC,RC3            ;开启段选的锁存使能
   MOVWF    PORTD                ;输出段选
   BCF      PORTC,RC3            ;关闭段选的锁存使能
   
   ;循环左移F_NUM_SEL
   BCF      STATUS,C             ;是0进位就设0
   BTFSC    F_NUM_SEL,7          ;看最左边是0是1，是0则跳
   BSF      STATUS,C             ;是1进位就设1    
   RLF      F_NUM_SEL,F          ;移位循环刷数码管
   return

;......按键检测子程序...........;
KEY_DETECT
  ;...检测按键K17，RB0...;  
  BCF      STATUS,C             ;先把进位清零
  BTFSC    PORTB,W              
  BSF      STATUS,C             ;按键输入是1就把进位设为1
  RLF      F_KEY0               ;每10毫秒把按键输入移位寄存到这个寄存器里面
  MOVLW    b'11110000'          ;这个序列检测开始按下
  XORWF    F_KEY0,W             
  BTFSS    STATUS,Z             ;如果相等就跳过下一条
  GOTO     END_KEY_DETECTK17_1
  CLRF     F_NUM0
  CLRF     F_NUM1
  CLRF     F_NUM2
  CLRF     F_NUM3
END_KEY_DETECTK17_1
  MOVLW    b'00000000'          ;这个序列检测一直按下
  XORWF    F_KEY0,W             
  BTFSS    STATUS,Z             ;如果相等就跳过下一条
  GOTO     END_KEY_DETECTK17_2
  CLRF     F_NUM0
  CLRF     F_NUM1
  CLRF     F_NUM2
  CLRF     F_NUM3
END_KEY_DETECTK17_2
  ;...检测按键K18，RB1...;  
  BCF      STATUS,C             ;先把进位清零
  BTFSC    PORTB,F              
  BSF      STATUS,C             ;按键输入是1就把进位设为1
  RLF      F_KEY1               ;每10毫秒把按键输入移位寄存到这个寄存器里面
  MOVLW    b'11110000'          ;这个序列检测开始按下
  XORWF    F_KEY1,W             
  BTFSS    STATUS,Z             ;如果相等就跳过下一条
  GOTO     END_KEY_DETECTK18_1
  COMF     F_NUMCTRL,1  
END_KEY_DETECTK18_1    
  ;...检测按键K19，RB2...;  
  BCF      STATUS,C             ;先把进位清零
  BTFSC    PORTB,2              
  BSF      STATUS,C             ;按键输入是1就把进位设为1
  RLF      F_KEY2               ;每10毫秒把按键输入移位寄存到这个寄存器里面
  MOVLW    b'11110000'          ;这个序列检测开始按下
  XORWF    F_KEY2,W             
  BTFSS    STATUS,Z             ;如果相等就跳过下一条
  GOTO     END_KEY_DETECTK19_1
  CALL     NUM_ADD 
END_KEY_DETECTK19_1    
 ;...检测按键K20，RB3...;  
  BCF      STATUS,C             ;先把进位清零
  BTFSC    PORTB,3              
  BSF      STATUS,C             ;按键输入是1就把进位设为1
  RLF      F_KEY3               ;每10毫秒把按键输入移位寄存到这个寄存器里面
  MOVLW    b'11110000'          ;这个序列检测开始按下
  XORWF    F_KEY3,W             
  BTFSS    STATUS,Z             ;如果相等就跳过下一条
  GOTO     END_KEY_DETECTK20_1
  CALL     NUM_SUB 
END_KEY_DETECTK20_1    
  return      
  
;.......端口初始化子程序........;
PORT_INIT
   CLRF 	STATUS                 ;选体0;Bank0 
   CLRF 	PORTA                  ;清空端口输出
   CLRF 	PORTB                  ;
   CLRF 	PORTC                  ;
   CLRF 	PORTD                  ;
   BSF   	STATUS,RP0	           ;设置文件寄存器为体1
   MOVLW	b'00000000'            ;把设置端口为输入还是输出，0是输出
   MOVWF	TRISA
   MOVLW	b'00001111'
   MOVWF	TRISB
   MOVLW	b'00000000'
   MOVWF	TRISC
   MOVLW	b'00000000'
   MOVWF	TRISD
   return		         

;.......各寄存器赋初值子程序.........;
REG_INIT   
   MOVLW    b'11111110'            
   MOVWF    F_LED                ;给LED寄存器赋初值，用于跑马灯  
   MOVLW    b'00010001'
   MOVWF    F_NUM_SEL
   MOVLW    d'0'
   MOVWF    F_NUM0              ;数码管上电时会显示“FF00”
   MOVLW    d'0'
   MOVWF    F_NUM1
   MOVLW    0FH
   MOVWF    F_NUM2
   MOVLW    0FH
   MOVWF    F_NUM3
   CLRF     F_TMR0MAX
  return

END   