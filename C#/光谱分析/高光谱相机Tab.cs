using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace 光谱分析 {
    /// <summary>
    /// 用于显示高光谱相机采样图像和每个像素点对应光谱数据曲线的Tab页
    /// </summary>
    class 高光谱相机Tab : TabPage {
        static public Color[] 颜色8 = new Color[8] {Color.Red,Color.Green,Color.Blue,Color.Orange,Color.Cyan,Color.Purple,Color.Pink,Color.Brown};
        static Size 谱线图片框大小 = new Size(886, 555);
        static Rectangle 画线区域框 = new Rectangle(20, 20, 840, 510);
        static Color 背景色 = Color.FromArgb(200, 200, 200);
        高光谱RAW数据 RAW数据;
        /// <summary>
        /// 显示采样图片的图片框
        /// </summary>
        PictureBox 采样图片框左 = new PictureBox();
        Graphics g采样图片框;
        TabControl 所属tabControl;
        Form1 主窗体;
        /// <summary>
        /// 显示某个点光谱曲线的图片框
        /// </summary>
        PictureBox 谱线图片框右 = new PictureBox();
        Graphics g谱图框;
        /// <summary>
        /// 用来显示光谱曲线的位图
        /// </summary>
        Bitmap 谱线位图 = new Bitmap(谱线图片框大小.Width, 谱线图片框大小.Height, PixelFormat.Format24bppRgb);
        Graphics g谱线位图;
        List<Point> 点击采样点列表 = new List<Point>();
        int 红频点 = -1;
        int 绿频点 = -1;
        int 蓝频点 = -1;

        public 高光谱相机Tab(Form1 form, ContextMenuStrip 谱线图片框右键菜单, TabControl tabCtrl, ProgressBar 进度条, string 文件名) {
            RAW数据 = new 高光谱RAW数据(文件名, 进度条);
            if (RAW数据.灰度图 != null) {
                采样图片框左.SizeMode = PictureBoxSizeMode.AutoSize;
                Controls.Add(采样图片框左);
                采样图片框左.Image = RAW数据.灰度图;
                谱线图片框右.MouseMove += 谱线图片框_MouseMove;
                谱线图片框右.MouseClick += 谱线图片框_MouseClick;
                采样图片框左.MouseMove += 采样图片框_MouseMove;
                采样图片框左.MouseClick += 采样图片框_MouseClick;
                谱线图片框右.ContextMenuStrip = 谱线图片框右键菜单;
                Text = RAW数据.相机类型 + ":" + RAW数据.Raw文件名;
                tabCtrl.TabPages.Insert(0, this);
                tabCtrl.SelectedTab = this;
                所属tabControl = tabCtrl;
                主窗体 = form;
                谱线图片框右.Size = 谱线图片框大小;
                谱线图片框右.Location = new Point(RAW数据.灰度图.Width + 2, 0);
                谱线图片框右.Image = 谱线位图;
                g谱线位图 = Graphics.FromImage(谱线位图);
                初始化谱线位图();
                Controls.Add(谱线图片框右);
                g谱图框 = 谱线图片框右.CreateGraphics();
                g采样图片框 = 采样图片框左.CreateGraphics();
            }
        }

        private void 谱线图片框_MouseClick(object sender, MouseEventArgs e) {
            for (int i = 0; i < 点击采样点列表.Count; i++) {
                画点击采样点(g采样图片框, 点击采样点列表[i], 颜色8[i % 颜色8.Length]);
            }
        }

        internal void 设置伪彩色频点(Point 坐标, Color 颜色) {
            Point 当前点坐标 = 谱线图片框右.PointToClient(坐标);
            if (当前点坐标.X < 画线区域框.X || 当前点坐标.Y < 画线区域框.Y || 当前点坐标.X > 画线区域框.Width + 画线区域框.X || 当前点坐标.Y > 画线区域框.Height + 画线区域框.Y) return;
            float 横向间隔 = (float)画线区域框.Width / (RAW数据.数据[0, 0].幅值.Length - 1);
            int n = 0;
            Point 框内坐标 = new Point(当前点坐标.X - 画线区域框.X, 当前点坐标.Y - 画线区域框.Y);
            if (框内坐标.X > 横向间隔 / 2) 
                n = (int)(((float)框内坐标.X - 横向间隔 / 2) / 横向间隔) + 1;
            if (颜色 == Color.Red)
                红频点 = n;
            else if (颜色 == Color.Green)
                绿频点 = n;
            else
                蓝频点 = n;

            g谱线位图.FillRectangle(new SolidBrush(背景色), new Rectangle(0,0, 谱线图片框大小.Width, 画线区域框.Y));
            if(红频点 >= 0)
                g谱线位图.DrawLine(new Pen(Color.Red), new PointF(红频点 * 横向间隔 + 画线区域框.X, 画线区域框.Y - 1), new PointF(红频点 * 横向间隔 + 画线区域框.X, 0));
            if (绿频点 >= 0)
                g谱线位图.DrawLine(new Pen(Color.Green), new PointF(绿频点 * 横向间隔 + 画线区域框.X, 画线区域框.Y - 1), new PointF(绿频点 * 横向间隔 + 画线区域框.X, 0));
            if (蓝频点 >= 0)
                g谱线位图.DrawLine(new Pen(Color.Blue), new PointF(蓝频点 * 横向间隔 + 画线区域框.X, 画线区域框.Y - 1), new PointF(蓝频点 * 横向间隔 + 画线区域框.X, 0));
            //Pen 笔 = new Pen(颜色);
            //g谱线位图.DrawLine(笔, new PointF(n * 横向间隔 + 画线区域框.X, 画线区域框.Y - 1), new PointF(n * 横向间隔 + 画线区域框.X, 0));
            谱线图片框右.Refresh();
        }

        internal void 彩灰切换() {
            if(RAW数据.伪彩色图 == null) {
                MessageBox.Show("请先生成伪彩色图!");
                return;
            }
            if (采样图片框左.Image == RAW数据.伪彩色图)
                采样图片框左.Image = RAW数据.灰度图;
            else
                采样图片框左.Image = RAW数据.伪彩色图;
            采样图片框左.Refresh();
        }

        internal void 生成伪彩色图() {
            int 计数 = 0;
            计数 = 红频点 >= 0 ? 计数 + 1 : 计数;
            计数 = 绿频点 >= 0 ? 计数 + 1 : 计数;
            计数 = 蓝频点 >= 0 ? 计数 + 1 : 计数;
            if (计数 < 2) {
                MessageBox.Show("需先在右图点右键设置至少两个伪彩色频点!");
                return;
            }
            RAW数据.生成伪彩色图(红频点, 绿频点, 蓝频点);
            采样图片框左.Image = RAW数据.伪彩色图;
            采样图片框左.Refresh();
            
        }

        internal void 清空采样() {
            初始化谱线位图();
            采样图片框左.Refresh();
            谱线图片框右.Refresh();
            点击采样点列表.Clear();
            红频点 = -1;
            绿频点 = -1;
            蓝频点 = -1;
        }

        /// <summary>
        /// 鼠标点击高光谱采样图片时,会把该点的光谱曲线固定在右边的谱线框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 采样图片框_MouseClick(object sender, MouseEventArgs e) {
            Point 当前点坐标 = 采样图片框左.PointToClient(Cursor.Position);
            if (当前点坐标.X < 0 || 当前点坐标.Y < 0 || 当前点坐标.X > RAW数据.灰度图.Width || 当前点坐标.Y > RAW数据.灰度图.Height) return;
            if (e.Button != MouseButtons.Left) return;
            点击采样点列表.Add(当前点坐标);
            Color 颜色 = 颜色8[(点击采样点列表.Count - 1) % 颜色8.Length];
            画光谱曲线(RAW数据.数据[当前点坐标.Y, 当前点坐标.X].幅值, Math.Max(RAW数据.最大值, RAW数据.数据[当前点坐标.Y, 当前点坐标.X].最大幅值), g谱线位图, 画线区域框, 颜色);
            画点击采样点(g采样图片框, 当前点坐标, 颜色);
        }

        private void 画点击采样点(Graphics g,Point 坐标, Color 颜色) {
            g.FillRectangle(new SolidBrush(颜色), 坐标.X - 1, 坐标.Y - 1, 3, 3);
        }

        internal Bitmap 获取显示的位图() {
            return (Bitmap)采样图片框左.Image;
        }
       

        private void 谱线图片框_MouseMove(object sender, MouseEventArgs e) {
            Point 当前点坐标 = 谱线图片框右.PointToClient(Cursor.Position);
            if (当前点坐标.X < 画线区域框.X || 当前点坐标.Y < 画线区域框.Y || 当前点坐标.X > 画线区域框.Width + 画线区域框.X || 当前点坐标.Y > 画线区域框.Height + 画线区域框.Y) return;
            float 横向间隔 = (float)画线区域框.Width / (RAW数据.数据[0, 0].幅值.Length - 1);
            int n = 0;
            Point 框内坐标 = new Point(当前点坐标.X - 画线区域框.X, 当前点坐标.Y - 画线区域框.Y);

            谱线图片框右.Refresh();
           
            if (框内坐标.X > 横向间隔 / 2) {
                n = (int)(((float)框内坐标.X - 横向间隔 / 2) / 横向间隔) + 1;
            }

            PointF X位置 = new PointF(当前点坐标.X, 画线区域框.Height + 5);
            if (框内坐标.X > 画线区域框.Width - 55) X位置.X = 画线区域框.Width + 画线区域框.X - 55;

            g谱图框.DrawString(RAW数据.频点值[n].ToString(), Form1.TimesNR字体(11), new SolidBrush(Color.Black), X位置);  //显示频点值
            Color 笔颜色 = Color.DarkGray;
            if (n == 红频点)
                笔颜色 = Color.Red;
            if (n == 绿频点)
                笔颜色 = Color.Green;
            if (n == 蓝频点)
                笔颜色 = Color.Blue;

            Pen 笔 = new Pen(笔颜色);
            笔.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g谱图框.DrawLine(笔, new PointF(n * 横向间隔 + 画线区域框.X, 画线区域框.Y + 1), new PointF(n * 横向间隔 + 画线区域框.X, 画线区域框.Height + 画线区域框.Y));

        }

        private void 初始化谱线位图() {
            Color 框颜色 = Color.Black;
            g谱线位图.Clear(背景色);
            g谱线位图.DrawRectangle(new Pen(框颜色), 画线区域框);
            int 横轴显示频点个数 = 14;
            int 频点间隔 = RAW数据.频点值.Length / 横轴显示频点个数;
            Point 位置 = new Point(0, 画线区域框.Height + 画线区域框.Y);
            for (int i = 0; i <= RAW数据.频点值.Length; i += 频点间隔) { //显示横轴频点值
                位置.X = (int)((double)画线区域框.Width / 横轴显示频点个数 * (i/ 频点间隔) + 0.5);
                if(RAW数据.相机类型 == "FX10") //是可见光光谱就用字的颜色示意波长所对应的颜色
                    switch (i / 频点间隔) {
                        case 0:
                            框颜色 = Color.Purple; break;
                        case 1:
                            框颜色 = Color.Blue; break;
                        case 2:
                            框颜色 = Color.Cyan; break;
                        case 3:
                            框颜色 = Color.SpringGreen; break;
                        case 4:
                            框颜色 = Color.GreenYellow; break;
                        case 5:
                            框颜色 = Color.Yellow; break;
                        case 6:
                            框颜色 = Color.Orange; break;
                        case 7:
                            框颜色 = Color.Red; break;                       
                        default:
                            框颜色 = Color.DarkRed;
                            break;
                    }
                if(i == RAW数据.频点值.Length)
                    g谱线位图.DrawString(RAW数据.频点值[i - 1].ToString(), Form1.TimesNR字体(11), new SolidBrush(框颜色), 位置);
                else
                      g谱线位图.DrawString(RAW数据.频点值[i].ToString(), Form1.TimesNR字体(11), new SolidBrush(框颜色), 位置);
            }
            
        }

        /// <summary>
        /// 鼠标在采样图片上移动时在右边显示对应像素点的光谱数据曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 采样图片框_MouseMove(object sender, MouseEventArgs e) {
            Point 当前点坐标 = 采样图片框左.PointToClient(Cursor.Position);
            主窗体.显示图片信息(当前点坐标, (Bitmap)采样图片框左.Image);
            if (当前点坐标.X < 0 || 当前点坐标.Y < 0 || 当前点坐标.X > RAW数据.灰度图.Width || 当前点坐标.Y > RAW数据.灰度图.Height) return;
            谱线图片框右.Refresh();
            画光谱曲线(RAW数据.数据[当前点坐标.Y, 当前点坐标.X].幅值, Math.Max(RAW数据.最大值, RAW数据.数据[当前点坐标.Y, 当前点坐标.X].最大幅值), g谱图框, 画线区域框, Color.Black);

        }

        static public void 画光谱曲线(short[] 数据, int 最大值, Graphics g, Rectangle 绘图边框, Color 线条颜色) {
            Pen 笔 = new Pen(new SolidBrush(线条颜色));
            float X单位 = (float)绘图边框.Width / (数据.Length - 1); //线条比数据少一个
            float Y单位 = (float)绘图边框.Height / 最大值;
            for (int i = 0; i < 数据.Length - 1; i++)
                g.DrawLine(笔, i * X单位 + 绘图边框.X, 绘图边框.Height + 绘图边框.Y - 数据[i] * Y单位, (i + 1) * X单位 + 绘图边框.X, 绘图边框.Height + 绘图边框.Y - 数据[i + 1] * Y单位);
        }

        internal void 加倍亮度() {
            RAW数据.加倍亮度();
            采样图片框左.Refresh();
        }

        internal void 关闭() {
            RAW数据.关闭();
            RAW数据 = null;
            所属tabControl.TabPages.Remove(this);
            g采样图片框.Dispose();
            采样图片框左.Dispose();
            g谱图框.Dispose();
            g谱线位图.Dispose();
            谱线图片框右.Dispose();
            Dispose();
        }

    }
}
