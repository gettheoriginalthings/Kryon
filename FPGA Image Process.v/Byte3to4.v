//三字节输入转四字节输出,可用于RGB数据转32位.
module Byte3to4(
  input             clk  ,
  input             EnIn ,
  input      [7: 0] Byte0,   //G  
  input      [7: 0] Byte1,   //B
  input      [7: 0] Byte2,   //R
  output reg        EnOut,
  output reg [31:0] Out32

);
  reg [7:0] Byte0_1,Byte1_1,Byte2_1,Out0,Out1,Out2;
  reg [1:0] Cnt = 0;
  reg EnIn_1;
  

  always@(posedge clk)
  begin
  	Byte0_1 <= Byte0;         //从芯片外进来的信号最好要先寄存一下.
  	Byte1_1 <= Byte1;
  	Byte2_1 <= Byte2;
  	EnIn_1 <= EnIn; 
  	if(EnIn_1)
  	  Cnt <= Cnt + 1;
  	else
  	  Cnt <= 0;
  	  
  	if(Cnt > 0)
  	  EnOut <= 1;
  	else
  	  EnOut <= 0;
  	
  	case(Cnt)
  		0: {Out2,Out1,Out0} <= {Byte2_1,Byte1_1,Byte0_1};
  		1: {Out2,Out1,Out0} <= {8'b0,Byte2_1,Byte1_1};
  		2: {Out2,Out1,Out0} <= {8'b0,8'b0,Byte2_1};
  		3: {Out2,Out1,Out0} <= 24'b0;
  		default:;
    endcase 	  
  	
  	case(Cnt)
  		0: Out32 <= 0;
  		1: Out32 <= {Byte0_1,Out2,Out1,Out0};
  		2: Out32 <= {Byte1_1,Byte0_1,Out1,Out0};
  		3: Out32 <= {Byte2_1,Byte1_1,Byte0_1,Out0};
  		default:;
    endcase  	   
  	
  end

endmodule