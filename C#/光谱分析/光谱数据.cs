using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace 光谱分析 {
    class 海洋红外光谱数据 {
        #region 频点值
        static float[] 海洋红外频点 = { 938.368F, 944.249F, 950.128F, 956.003F, 961.876F, 967.746F, 973.613F, 979.477F, 985.338F, 991.197F, 997.053F, 1002.906F, 1008.756F, 1014.604F, 1020.449F, 1026.291F, 1032.131F, 1037.967F, 1043.801F, 1049.633F, 1055.461F, 1061.287F, 1067.11F, 1072.931F, 1078.749F, 1084.564F, 1090.376F, 1096.186F, 1101.994F, 1107.798F, 1113.6F, 1119.4F, 1125.196F, 1130.991F, 1136.782F, 1142.571F, 1148.358F, 1154.142F, 1159.923F, 1165.702F, 1171.478F, 1177.252F, 1183.023F, 1188.791F, 1194.558F, 1200.321F, 1206.082F, 1211.841F, 1217.597F, 1223.351F, 1229.102F, 1234.85F, 1240.597F, 1246.341F, 1252.082F, 1257.821F, 1263.557F, 1269.291F, 1275.023F, 1280.752F, 1286.479F, 1292.204F, 1297.926F, 1303.645F, 1309.363F, 1315.078F, 1320.79F, 1326.501F, 1332.209F, 1337.914F, 1343.618F, 1349.319F, 1355.017F, 1360.714F, 1366.408F, 1372.1F, 1377.789F, 1383.476F, 1389.161F, 1394.844F, 1400.525F, 1406.203F, 1411.879F, 1417.553F, 1423.224F, 1428.894F, 1434.561F, 1440.226F, 1445.889F, 1451.549F, 1457.208F, 1462.864F, 1468.518F, 1474.17F, 1479.82F, 1485.468F, 1491.114F, 1496.757F, 1502.398F, 1508.038F, 1513.675F, 1519.31F, 1524.943F, 1530.574F, 1536.203F, 1541.83F, 1547.454F, 1553.077F, 1558.698F, 1564.316F, 1569.933F, 1575.548F, 1581.16F, 1586.771F, 1592.379F, 1597.986F, 1603.591F, 1609.193F, 1614.794F, 1620.393F, 1625.99F, 1631.585F, 1637.178F, 1642.769F, 1648.358F, 1653.945F, 1659.53F, 1665.114F};//128个
        #endregion

        float[] 频点;
        public short[] 幅值;
        float[] 百分比幅值;
        public short 平均幅值;
        PointF[] 数据曲线点坐标;
        float 纵轴最大值 = 110;
        public Bitmap 数据曲线图;
        string 文件名;


        public 海洋红外光谱数据(string 海洋红外光谱仪数据文件) {
            读海洋红外光谱仪数据文件(海洋红外光谱仪数据文件);
            文件名 = Path.GetFileName(海洋红外光谱仪数据文件);
            频点 = 海洋红外频点;
        }
        

        public bool 画曲线图(int 宽, int 高, Color 曲线颜色) {
            if (百分比幅值 == null) return false;
            if (数据曲线图 == null)
                数据曲线图 = new Bitmap(宽, 高, PixelFormat.Format24bppRgb);
            if (数据曲线点坐标 == null)
                数据曲线点坐标 = new PointF[百分比幅值.Length];
            Graphics g = Graphics.FromImage(数据曲线图);
            g.Clear(Color.FromArgb(222,222,222));
            画曲线(g, new Rectangle(0, 0, 数据曲线图.Width, 数据曲线图.Height), 曲线颜色);
            if (文件名 != null)//在曲线图的左上角显示对应的文件名
                g.DrawString(文件名, Form1.TimesNR字体(11), new SolidBrush(曲线颜色), new Point(0, 0));
            g.Dispose();
            return true;
        }

        public void 画曲线(Graphics g, Rectangle 边框, Color 曲线颜色) {
            int 宽 = 边框.Width;
            int 高 = 边框.Height;
            float 横向间隔 = (float)宽 / (百分比幅值.Length - 1);
            float 纵向间隔 = 高 / 纵轴最大值;
            for (int i = 0; i < 百分比幅值.Length; i++)
                数据曲线点坐标[i] = new PointF(i * 横向间隔, 高 - 百分比幅值[i] * 纵向间隔);
            for (int i = 0; i < 百分比幅值.Length - 1; i++) {
                g.DrawLine(new Pen(曲线颜色), 数据曲线点坐标[i], 数据曲线点坐标[i + 1]);
            }
            for (int i = 0; i < 百分比幅值.Length; i++)
                G画点(g, 数据曲线点坐标[i].X, 数据曲线点坐标[i].Y, Color.LightGreen);

        }


        static void G画点(Graphics g, float x, float y, Color 颜色) {
            g.DrawLine(new Pen(new SolidBrush(颜色)), (int)(x + 0.5), (int)(y + 0.5), (int)(x + 0.5), (float)((int)(y + 0.5) - 0.2));
        }//用这个方法可以只画一个点,GDI没有画点的函数
        public void 返回数据信息(Point 鼠标位置, ref PointF 点数据, ref PointF 点坐标) {
            float 横向间隔 = (float)数据曲线图.Width / (百分比幅值.Length - 1);
            int n = 0;
            if(鼠标位置.X > 横向间隔 / 2) {
                n = (int)(((float)鼠标位置.X - 横向间隔 / 2) / 横向间隔) + 1;
            }
            点数据 = new PointF(频点[n], 百分比幅值[n]);   //x为频点值,Y为百分比幅值        
            点坐标 = 数据曲线点坐标[n];
        }
        private bool 读海洋红外光谱仪数据文件(string 文件名) {
            if (文件名 == null || !File.Exists(文件名))
                return false;
            try {
                百分比幅值 = new float[海洋红外频点.Length];
                StreamReader 读取器 = File.OpenText(文件名);
                string 一行文本 = 读取器.ReadLine();
                while (一行文本.IndexOf("Begin Spectral Data") == -1) 
                    一行文本 = 读取器.ReadLine();
                for (int i = 0; i < 海洋红外频点.Length; i++) {
                    一行文本 = 读取器.ReadLine();
                    int 空格位置 = 一行文本.IndexOf("\t");
                    百分比幅值[i] = Convert.ToSingle(一行文本.Substring(空格位置 + 1));
                }
                读取器.Close();
                return true;
            }
            catch (Exception) {
                MessageBox.Show("读文本数据文件出错,可能是文件被占用或文本格式有问题!");
                return false;
            }
        }
        public override string ToString() {
            if (百分比幅值 == null) return null;
            string 显示文本 = "";
            for (int i = 0; i < 百分比幅值.Length; i++) 
                显示文本 += 频点[i].ToString() + " " + 百分比幅值[i].ToString() + "\n";
            return 显示文本;
        }

        public void 关闭() {
            频点 = null;
            幅值 = null;
            百分比幅值 = null;
            数据曲线点坐标 = null;
            if(数据曲线图!=null)
                数据曲线图.Dispose();

        }

    }

    /// <summary>
    /// 用于存储高光谱相机FX10和FX17每个像素点对应的光谱数据
    /// </summary>
    class 高光谱数据 {
        /// <summary>
        /// 这个幅值数组的长度对应于频点数,有多少个频点就有多少个幅值
        /// </summary>
        public short[] 幅值;
        /// <summary>
        /// 平均幅值用来形成灰度图
        /// </summary>
        public short 平均幅值;
        /// <summary>
        /// 该光谱数据对应的高光谱图片上的坐标
        /// </summary>
        Point 图上坐标;
        public short 最大幅值 = 0;

        public 高光谱数据(byte[] 字节数据, Point 坐标) {
            if (字节数据 != null) {
                幅值 = new short[字节数据.Length / 2];              
                int 和 = 0;
                for (int i = 0; i < 幅值.Length; i++) { //每个频点的幅值数据是12位的,由两个字节存放,低字节对应低8位
                    幅值[i] = (short)(字节数据[i * 2] + 字节数据[i * 2 + 1] * 256);
                    if (幅值[i] > 最大幅值)
                        最大幅值 = 幅值[i];





                    和 += 幅值[i];                   
                }
                平均幅值 = (short)(和 / 幅值.Length);
            }
            图上坐标 = 坐标;
        }

        public void 关闭() {
            幅值 = null;
            
        }
    }
}
