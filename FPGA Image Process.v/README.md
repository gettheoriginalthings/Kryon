* When you generate the Block Ram, please unchoose 'Primitives Output Register' in Vivado. Do not choose any Output Register!!
生成块所有Ram的时候AB口**不**要选“Primitives Output Register”等任何的输出寄存器，使能模式**要选**“Always Enabled”
* In CCAL.v make sure you choose 'Fill Remaining Memory Locations', and set the value to 0. These Rams' init value has to be 0. 
CCAL.v里面的几个Ram在生成时**需要把Ram的初值初始化为零**。
* Before run simulation, put the 'tb1.txt' to the right location, and you will find output .txt files in that right location.
* "RGBtoHSI" contains the verilog code for RGB to HSI convertion, the result is the same as in Winows Paint Edit Colors.

* [FPGA Image Processing basic skills - FPGA图像处理基本技巧](https://zhuanlan.zhihu.com/p/38946857)
 
* [Connected Component Analysis-Labeling algorithm upgrade - FPGA实现的连通域识别算法升级](https://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975657&idx=1&sn=358e6a7f88c7f76c126169951b274c47&chksm=8c0708e6bb7081f0dee73f12c00ca4d0aaeed1b5a9697937556af550c14aa92b930d25a3d06a&token=1486415084&lang=zh_CN#rd)

# 文章推荐
* [**地球是圆的，外星人到处都有，永动机已经造出来了**](https://mp.weixin.qq.com/s/NjJCZ-cLZF2RH9POkPTqwg "地球是圆的，外星人到处都有，永动机已经造出来了")
* [简单的解释**什么是意识层次的提升和分裂？什么是扬升？**](https://mp.weixin.qq.com/s/pBZ0zBG-dXl5xoTQQVNn-A)
* [**《揭露宇宙》观后感**](https://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975557&idx=1&sn=99eb8b213507926af6ebc29104f76ae9&chksm=8c07080abb70811cba2ba80a97f9e417f231f6f444296d26590626da9c21e8de107f10d6c223&mpshare=1&scene=1&srcid=&key=96e286bf1fa90d3e94d8dbb44cc642dba6b3fdf27a3a31be1881c539a7e937760563b8e42fe5c5670ee7323d5a0928681879bab51cee913dc80473e2a01f05d51f796294cd4bfad26f8c163aaeb81b1e&ascene=1&uin=MjkwNDEzNzUzNQ%3D%3D&devicetype=Windows+7&version=62060739&lang=zh_CN&pass_ticket=LgfUliy0e8SiG2fE6TwEB4Dvt87dhnUAOm%2BGdF2DmSyh41lISnyXmhem9l3Jk467)
* [克里昂特别讯息——关于5G网络](https://mp.weixin.qq.com/s?__biz=MzIwNDQ3ODYwMw==&mid=2247488083&idx=1&sn=3ea9eefbf68ec50de5bcf974ee97a56d&key=4290d854660b0174f814b08eca4355a01d77a32ff917387b3148c7576c83be458e20e5310b6f7f96d8d6a2ac7dde6ee4a25c150df48a0165fee2cdefa7b71ac374918bb89506f9945e41a81a7b19388f&ascene=1&uin=MjkwNDEzNzUzNQ%3D%3D&devicetype=Windows+7&version=62060739&lang=zh_CN&pass_ticket=7jOv7QYZ3wki7KroaOL%2B5DKUTSRPYTJjrdHCbGd%2Bb4JFLh63ReIxqAoW4BSAYFAF)
* [科普宇宙法则-蠢人不知自己蠢](http://mp.weixin.qq.com/s?__biz=MzIxODAxMDY1Ng==&mid=2650975187&idx=1&sn=53bc4f511131456ae35cf77ceb193ce9&chksm=8c070e9cbb70878a8d08b14d8e1bf2d214504a21ea2b44b2d0122b23fe5d927ee46c0c1dbc78&scene=21#wechat_redirect)


