# Kryon
FPGA Image Process, Connected Component Analysis-Labeling

This repository contains some verilog codes for Image Process, like image filtering, image smoothing, edge detecting, binary image erosion, dilation, RGB to HSI convertion and Connected Component Analysis-Labeling. The codes are detail commented, read the comments and you will know how to use it.

The Connected Component Analysis-Labeling algorithm here is a FPGA based parallel, pipelined, real time Algorithm. It only need to buffer one line of image data, no DDR needed.

I have writen two articles about these codes, it's in 中文，but google translate is goood enough.

* [FPGA Image Processing basic skills - FPGA图像处理基本技巧](http://blog.sina.com.cn/s/blog_539ee1ae0102xtnz.html)
 
* [Connected Component Analysis-Labeling algorithm upgrade - FPGA实现的连通域识别算法升级](http://blog.sina.com.cn/s/blog_539ee1ae0102xtod.html)

"**CCAL.py**" is the source code of the Connected Component Labeling algorithm animation that I made: 

* https://youtu.be/UVAxT60HppI
* [连通域识别算法动画演示](https://www.bilibili.com/video/av26067000)

"**FPGA Ethernet Mac.py**" is a FPGA MAC and a simple GUI written in python use [MyHDL](http://docs.myhdl.org/en/stable/). It can run on ALINX黑金 AX516 Dev Board. PC can receive Raw Video transmited from FPGA through GBE.

My Photo Album: www.eyeem.com/becomequantum

Email: 3077686006@qq.com
# 文章推荐
* [简单的解释**什么是意识层次的提升和分裂？什么是扬升？**](https://mp.weixin.qq.com/s/pBZ0zBG-dXl5xoTQQVNn-A)
* [**《揭露宇宙》观后感**](https://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975557&idx=1&sn=99eb8b213507926af6ebc29104f76ae9&chksm=8c07080abb70811cba2ba80a97f9e417f231f6f444296d26590626da9c21e8de107f10d6c223&mpshare=1&scene=1&srcid=&key=96e286bf1fa90d3e94d8dbb44cc642dba6b3fdf27a3a31be1881c539a7e937760563b8e42fe5c5670ee7323d5a0928681879bab51cee913dc80473e2a01f05d51f796294cd4bfad26f8c163aaeb81b1e&ascene=1&uin=MjkwNDEzNzUzNQ%3D%3D&devicetype=Windows+7&version=62060739&lang=zh_CN&pass_ticket=LgfUliy0e8SiG2fE6TwEB4Dvt87dhnUAOm%2BGdF2DmSyh41lISnyXmhem9l3Jk467)
* [克里昂特别讯息——关于5G网络(**5G网络危害巨大**)](https://mp.weixin.qq.com/s?__biz=MzIwNDQ3ODYwMw==&mid=2247488083&idx=1&sn=3ea9eefbf68ec50de5bcf974ee97a56d&key=4290d854660b0174f814b08eca4355a01d77a32ff917387b3148c7576c83be458e20e5310b6f7f96d8d6a2ac7dde6ee4a25c150df48a0165fee2cdefa7b71ac374918bb89506f9945e41a81a7b19388f&ascene=1&uin=MjkwNDEzNzUzNQ%3D%3D&devicetype=Windows+7&version=62060739&lang=zh_CN&pass_ticket=7jOv7QYZ3wki7KroaOL%2B5DKUTSRPYTJjrdHCbGd%2Bb4JFLh63ReIxqAoW4BSAYFAF)
* [科普宇宙法则序言](http://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975182&idx=1&sn=b469c8edea5f4dd86ce5243e5274ea98&chksm=8c070e81bb70879715f2ab0bda1a04bcddea9c04cb64f9bbd57c5603a00211309dc3c14f52e7&scene=21#wechat_redirect)
* [科普宇宙法则-蠢人不知自己蠢](http://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975187&idx=1&sn=53bc4f511131456ae35cf77ceb193ce9&chksm=8c070e9cbb70878a8d08b14d8e1bf2d214504a21ea2b44b2d0122b23fe5d927ee46c0c1dbc78&scene=21#wechat_redirect)
* [科普宇宙法则-超越二元](http://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975276&idx=1&sn=91ed75f5f3bd4fefecfa1c087a2a13ec&chksm=8c070963bb7080755e19a460e64367ce8c5561986462f481ee6225759492fa4fa27da2ecc61a&scene=21#wechat_redirect)
* [全息分形宇宙一——重新审视维度](http://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650974806&idx=1&sn=bbe7c14cc7c4d8e414ff4c72a31b6227&chksm=8c070f19bb70860fd5c9d870e33b651c5d9f3c580d52e162062161821f06dcbdc2881e4cbc58&scene=21#wechat_redirect)
* [全息分形宇宙二——不需要建造更大的加速器](http://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650974815&idx=1&sn=82a294ea3d66c829564a9653ff73d6cc&chksm=8c070f10bb7086069bb8bc6e211d626122f46008c98406b303e8d17677f4e4a3d3b32bac6f45&scene=21#wechat_redirect)
* [全息分形宇宙十一——主流物理学中的错误](http://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650974946&idx=1&sn=aba1504e7c586c79c27a922a90f55799&chksm=8c070fadbb7086bbcb2e21822e658bf414114b01a1afbb54acfc0a1df549fbb552a65e85cbfb&scene=21#wechat_redirect)
* [Nassim Haramein-《The Connected Universe互连宇宙》纪录片](https://www.bilibili.com/video/av20714257)
* [克里昂信息汇总](http://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975511&idx=1&sn=2ae0a0b3bd4edcae0592e00c0650e40c&chksm=8c070858bb70814e81bdaee227489edf0265e022e0eeda45c6942d59c965502a787cd3bc1fdc&token=1586172304&lang=zh_CN#rd)

# Donation
My PayPal: ccpp123@sina.com

Wechat:

![zan](微信赞赏码.png)
