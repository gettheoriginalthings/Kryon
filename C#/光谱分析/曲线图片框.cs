using System;
using System.Drawing;
using System.Windows.Forms;

namespace 光谱分析 {
    /// <summary>
    /// 用来显示海洋红外光谱数据图片的PictureBox
    /// </summary>
    class 曲线图片框 : PictureBox {
        海洋红外光谱数据 谱数据;
        public 曲线图片框(Point 位置, 海洋红外光谱数据 数据) {
            Size = new Size(数据.数据曲线图.Width, 数据.数据曲线图.Height);
            Location = 位置;            
            谱数据 = 数据;
            Image = 谱数据.数据曲线图;
            MouseMove += 曲线图片框_MouseMove;           
        }

        //显示海洋光谱仪光谱曲线的图片框鼠标移动时的行为
        private void 曲线图片框_MouseMove(object sender, MouseEventArgs e) {           
            Point 当前点坐标 = PointToClient(Cursor.Position);
            if (当前点坐标.X < 0 || 当前点坐标.Y < 0 || 当前点坐标.X > 谱数据.数据曲线图.Width || 当前点坐标.Y > 谱数据.数据曲线图.Height) return;
            PointF 点数据 = new PointF(); ////x为频点值,Y为百分比幅值
            PointF 点坐标 = new PointF();
            谱数据.返回数据信息(当前点坐标, ref 点数据, ref 点坐标);
            Graphics g = CreateGraphics();
            Refresh();
            PointF X位置 = new PointF(点坐标.X, 谱数据.数据曲线图.Height - 13);
            if (点坐标.X > 谱数据.数据曲线图.Width - 55) X位置.X = 谱数据.数据曲线图.Width - 55;
            
            //鼠标移动时显示光谱曲线上对应点的频点值和百分比幅值
            g.DrawString(点数据.X.ToString(), Form1.TimesNR字体(10), new SolidBrush(Color.Green), X位置);  //显示频点值
            g.DrawString(点数据.Y.ToString() + "%", Form1.TimesNR字体(10), new SolidBrush(Color.Green), new PointF(X位置.X, X位置.Y - 18)); //显示百分比幅值
            Pen 笔 = new Pen(Color.Green);
            笔.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.DrawLine(笔, 点坐标, new PointF(点坐标.X, 谱数据.数据曲线图.Height - 30));
            g.Dispose();
        }

        public void 关闭() {
            谱数据.关闭();
            谱数据 = null;
            Dispose();
        }
    }
}
