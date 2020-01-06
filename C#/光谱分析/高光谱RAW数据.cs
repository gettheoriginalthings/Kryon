using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace 光谱分析 {
    class 高光谱RAW数据 {
        private const int 红 = 2, 绿 = 1, 蓝 = 0; //Bitmap位图数据中,蓝色Blue的值存在低地址上
        int 每行像素点数;
        int 行数;
        int 频点数;
        /// <summary>
        /// FX10还是FX17
        /// </summary>
        public string 相机类型 = ""; 
        /// <summary>
        /// 存储所有像素点光谱数据的数组
        /// </summary>
        public 高光谱数据[,] 数据;
        public Bitmap 灰度图;
        public Bitmap 伪彩色图;
        public string Raw文件名;
        int 右移位数 = 4;
        public int 最大值 = 4096;
        /// <summary>
        /// 存储从hdr文件中读出来的采样频点值
        /// </summary>
        public float[] 频点值;

        public 高光谱RAW数据(string raw文件名, ProgressBar 进度条) {
            读高光谱RAW数据(raw文件名, 进度条);
            Raw文件名 = Path.GetFileName(raw文件名);
        }
        /// <summary>
        /// 读取hdr文件中"相机类型","每行像素点数","频点数","行数",频点值等信息
        /// </summary>
        /// <param name="hdr文件名"></param>
        /// <returns></returns>
        private bool 读hdr文件信息(string hdr文件名) {
            try {
                StreamReader hdr读取器 = File.OpenText(hdr文件名);
                string 一行文本 = hdr读取器.ReadLine();
                while (一行文本.IndexOf("sensor type") == -1)
                    一行文本 = hdr读取器.ReadLine();
                相机类型 = 一行文本.Substring("sensor type".Length + 3, 4);
                while (一行文本.IndexOf("samples") == -1)
                    一行文本 = hdr读取器.ReadLine();
                每行像素点数 = Convert.ToInt32(一行文本.Substring("samples".Length + 3));
                一行文本 = hdr读取器.ReadLine();
                频点数 = Convert.ToInt32(一行文本.Substring("bands".Length + 3));
                一行文本 = hdr读取器.ReadLine();
                行数 = Convert.ToInt32(一行文本.Substring("lines".Length + 3));
                频点值 = new float[频点数];
                while (一行文本.IndexOf("Wavelength") == -1)
                    一行文本 = hdr读取器.ReadLine();
                for (int i = 0; i < 频点值.Length; i++) {
                    一行文本 = hdr读取器.ReadLine();
                    频点值[i] = Convert.ToSingle(一行文本.Substring(0, 一行文本.Length).Replace(",",""));
                }                
                hdr读取器.Close();
            }
            catch (Exception) {
                MessageBox.Show(hdr文件名 + "读取出错!");
                return false;
            }
            return true;
        }

        private bool 读高光谱RAW数据(string 文件名, ProgressBar 进度条) {
            if (文件名 == null || !File.Exists(文件名))
                return false;
            string hdr文件名 = 文件名.Substring(0, 文件名.Length - 3) + "hdr";
            if (!File.Exists(hdr文件名)) {
                MessageBox.Show(文件名 + "对应的.hdr文件不存在!");
                return false;
            }
            if(!读hdr文件信息(hdr文件名)) return false;

            BinaryReader RAW读取器;
            FileStream 文件流;
            try {
                文件流 = new FileStream(文件名, FileMode.Open);
                RAW读取器 = new BinaryReader(文件流);
            }
            catch (IOException e) {
                MessageBox.Show(e.Message + "\n 打不开Raw文件.");
                return false;
            }

            数据 = new 高光谱数据[行数, 每行像素点数];
            灰度图 = new Bitmap(每行像素点数, 行数, PixelFormat.Format24bppRgb);

            try {
                进度条.Value = 0;
                for (int i = 0; i < 行数; i++) {
                    进度条.Value = (int)((double)i / 行数 * 进度条.Maximum);
                    byte[] 一行数据 = RAW读取器.ReadBytes(频点数 * 每行像素点数 *2);  //一个频点的n个数据一行
                    for (int j = 0; j < 每行像素点数; j++) {
                        byte[] 谱数据 = new byte[频点数 * 2];
                        for (int n = 0; n < 频点数; n++) {
                            谱数据[n * 2] = 一行数据[n * 每行像素点数 * 2 + j * 2];
                            谱数据[n * 2 + 1] = 一行数据[n * 每行像素点数 * 2 + j * 2 + 1];
                        }
                        数据[i, j] = new 高光谱数据(谱数据, new Point(j, i));
                        byte 灰度 = (byte)(数据[i, j].平均幅值 >> 右移位数);                 
                        灰度图.SetPixel(j, i, Color.FromArgb(灰度, 灰度, 灰度)); //用平均幅值生成用于显示的灰度图
                    }                    
                }


            }
            catch (IOException e) {
                MessageBox.Show(e.Message + "\n 无法从Raw文件中读取");
                灰度图.Dispose();
                return false;
            }
            RAW读取器.Close();
            文件流.Dispose();
            return true;

        }

        /// <summary>
        /// 采样位数是12位,开始取的是12位中的高8位用来显示灰度图,如果亮度低就逐步往下取8位数据,直到取到低8位
        /// </summary>
        public void 加倍亮度() {
            if(右移位数 == 0) {
                MessageBox.Show("已经取的是低8位!");
                return;
            }
            右移位数--;
            最大值 = 最大值 / 2;
            BitmapData 位图数据 = 灰度图.LockBits(new Rectangle(0, 0, 灰度图.Width, 灰度图.Height), ImageLockMode.ReadWrite, 灰度图.PixelFormat);
            unsafe {
                byte* 位图指针 = (byte*)(位图数据.Scan0);
                for (int i = 0; i < 行数; i++, 位图指针 += 位图数据.Stride - 位图数据.Width * 3)
                    for (int j = 0; j < 每行像素点数; j++, 位图指针 += 3) {
                        int 幅值 = 数据[i, j].平均幅值 >> 右移位数;
                        int 灰度 = (byte)幅值;
                        int 高位 = 幅值 >> 8;
                        if (高位 > 0) 灰度 = 255;
                        位图指针[红] = 位图指针[绿] = 位图指针[蓝] = (byte)灰度;
                    }
            }
            灰度图.UnlockBits(位图数据);

        }

        internal void 生成伪彩色图(int 红频点, int 绿频点, int 蓝频点) {
            if (伪彩色图 == null)
                伪彩色图 = new Bitmap(每行像素点数, 行数, PixelFormat.Format24bppRgb);
            BitmapData 位图数据 = 伪彩色图.LockBits(new Rectangle(0, 0, 伪彩色图.Width, 伪彩色图.Height), ImageLockMode.ReadWrite, 伪彩色图.PixelFormat);
            unsafe {
                byte* 位图指针 = (byte*)(位图数据.Scan0);
                for (int i = 0; i < 行数; i++, 位图指针 += 位图数据.Stride - 位图数据.Width * 3)
                    for (int j = 0; j < 每行像素点数; j++, 位图指针 += 3) {
                        byte R = 0, G = 0, B = 0;
                        if (红频点 >= 0) {
                            int 幅值 = 数据[i, j].幅值[红频点] >> 右移位数;
                            R = (幅值 >> 8) > 0 ? (byte)255 : (byte)幅值;
                        }
                        if (绿频点 >= 0) {
                            int 幅值 = 数据[i, j].幅值[绿频点] >> 右移位数;
                            G = (幅值 >> 8) > 0 ? (byte)255 : (byte)幅值;
                        }
                        if (蓝频点 >= 0) {
                            int 幅值 = 数据[i, j].幅值[蓝频点] >> 右移位数;
                            B = (幅值 >> 8) > 0 ? (byte)255 : (byte)幅值;
                        }
                        位图指针[红] = R;
                        位图指针[绿] = G;
                        位图指针[蓝] = B;
                    }
            }
            伪彩色图.UnlockBits(位图数据);
        }

        public void 关闭() {
            for (int i = 0; i < 行数; i++) 
                for (int j = 0; j < 每行像素点数; j++) {
                    数据[i, j].关闭();
                    数据[i, j] = null;
                }
            数据 = null;
            灰度图.Dispose();
            if (伪彩色图 != null)
                伪彩色图.Dispose();
        }

        
    }
}
