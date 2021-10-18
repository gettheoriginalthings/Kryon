* When you generate the Block Ram, please unchoose 'Primitives Output Register' in Vivado. Do not choose any Output Register!!
生成块所有Ram的时候AB口**不**要选“Primitives Output Register”等任何的输出寄存器，使能模式**要选**“Always Enabled”
* In CCAL.v make sure you choose 'Fill Remaining Memory Locations', and set the value to 0. These Rams' init value has to be 0. 
CCAL.v里面的几个Ram在生成时**需要把Ram的初值初始化为零**。
* Before run simulation, put the 'tb1.txt' to the right location, and you will find output .txt files in that right location.
* "RGBtoHSI" contains the verilog code for RGB to HSI convertion, the result is the same as in Winows Paint Edit Colors.

* [FPGA Image Processing basic skills - FPGA图像处理基本技巧](https://www.bilibili.com/read/cv13109706)
* [反思神经网络五：从图像上理解概率小信息量大，人工和真实视觉神经网络到底有啥不同？](https://www.bilibili.com/video/BV12Q4y1X74G)
