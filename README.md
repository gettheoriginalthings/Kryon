# Kryon
FPGA Image Process, Connected Component Analysis-Labeling

This repository contains some verilog codes for Image Process, like image filtering, image smoothing, edge detecting, binary image erosion, dilation, RGB to HSI convertion and Connected Component Analysis-Labeling. The codes are detail commented, read the comments and you will know how to use it.

The Connected Component Analysis-Labeling algorithm here is a FPGA based parallel, pipelined, real time Algorithm. It only need to buffer one line of image data, no DDR needed.

I have writen two articles about these codes, it's in 中文，but google translate is goood enough.

* [FPGA Image Processing basic skills - FPGA图像处理基本技巧](https://zhuanlan.zhihu.com/p/38946857)
 
* [Connected Component Analysis-Labeling algorithm upgrade - FPGA实现的连通域识别算法升级](https://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975657&idx=1&sn=358e6a7f88c7f76c126169951b274c47&chksm=8c0708e6bb7081f0dee73f12c00ca4d0aaeed1b5a9697937556af550c14aa92b930d25a3d06a&token=1486415084&lang=zh_CN#rd)

"**CCAL.py**" is the source code of the Connected Component Labeling algorithm animation that I made: 

* https://youtu.be/UVAxT60HppI
* [连通域识别算法动画演示](https://www.bilibili.com/video/av26067000)

"**C#**"里的"**加水印**"是一个可以批量给图片文件加很多水印的小软件

"**FPGA Ethernet Mac.py**" is a FPGA MAC and a simple GUI written in python use [MyHDL](http://docs.myhdl.org/en/stable/). It can run on ALINX黑金 AX516 Dev Board. PC can receive Raw Video transmited from FPGA through GBE.


Email: 94493824@qq.com
# B站频道：
* [无限次元B站首页！](https://space.bilibili.com/2139404925)
* [如何提升学习能力](https://www.bilibili.com/video/BV1BL4y187xP)
* [至简哲学零：哲学要学什么？最大难点在哪？学了有啥大用？又该如何学？](https://www.bilibili.com/video/BV1FA411A7ZR)
* [至简哲学七：如何破康德的二律背反？如何在哲学中除掉上帝？](https://www.bilibili.com/video/BV1zh411W7JF)
* [训练恢复腹式呼吸的方法，站桩、打坐姿势要领！能减肥瘦腰！](https://www.bilibili.com/video/BV1e3411q7oc)

# Youtube Chanel：[BecomeQuantum](https://www.youtube.com/channel/UCvJH-Cp7SypXvJ-e0KSOo1A)


Wechat:

![zan](微信赞赏码.png)
