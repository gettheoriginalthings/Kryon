using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 光谱分析 {
    public partial class Form1 : Form {
        Point 右键点击坐标;
        UserActivityHook choosesc;
        public Form1() {
            InitializeComponent();
            说明();
            choosesc = new UserActivityHook();
            choosesc.OnMouseActivity += new MouseEventHandler(choose_OnMouseActivity);
            choosesc.KeyDown += new KeyEventHandler(MyKeyDown);
            choosesc.KeyPress += new KeyPressEventHandler(MyKeyPress);
            choosesc.KeyUp += new KeyEventHandler(MyKeyUp);

        }

        public void MyKeyDown(object sender, KeyEventArgs e) {
            Console.WriteLine(e.KeyCode + ", " + e.KeyData + ", " + e.KeyValue.ToString());
        }

        public void MyKeyPress(object sender, KeyPressEventArgs e) {
            
        }

        public void MyKeyUp(object sender, KeyEventArgs e) {
        }


        void choose_OnMouseActivity(object sender, MouseEventArgs e) {
            if (e.Clicks > 0) {
                if ((MouseButtons)(e.Button) == MouseButtons.Left) {
                    //point[0] = e.Location;
                }
                if ((MouseButtons)(e.Button) == MouseButtons.Right) {
                    //point[1] = e.Location;
                }
            }
            //throw new Exception("The method or operation is not implemented.");
        }


        private void 说明() {
            使用说明.Text = "本软件主要功能为打开并查看芬兰SPECIM高光谱相机FX10和FX17所采样的高光谱raw数据.也能顺便打开海洋红外光谱仪导出的txt光谱数据.\n\n" +
                "打开*.raw文件之后会在新打开的Tab页左侧显示采样数据的灰度图,此图是根据所有波段数据的平均值生成的.若此图很黑可点'加倍亮度'调到合适亮度,亮度加倍过头了无法恢复,需重新打开raw文件.\n\n" +
                "在左图移动鼠标时,右图会显示左图鼠标所在点的光谱曲线,此时单击鼠标可以将光谱曲线固定在右图上,同时左图单击处会出现一个小方点.如果这个小方点没了,在右图任意地方单击就会重新出现.\n\n" + 
                "在右边光谱曲线图上点右键可以设置伪彩色图RGB所对应的频点,设置频点之后点击'生成伪彩色图'即可看到伪彩色图.如果伪彩色图亮度不够,可以点'加倍亮度'增加灰度图的亮度,然后再重新点'生成伪彩色图'即可.";

        }
        
        static public Font TimesNR字体(int 字号) {
            return new Font(new FontFamily("Times New Roman"), 字号);
        }
        
        private void 打开光谱仪数据文本ToolStripMenuItem_Click(object sender, EventArgs e) {
            string[] 多个文件名 = 获取打开文件名("文本文件 | *.txt", "打开文本文件", true);
            if(多个文件名 != null) {
                光谱仪Tab 新Tab = new 光谱仪Tab(this, 数据tab, 多个文件名);
            }
        }

        private void 打开高光谱RAW数据ToolStripMenuItem_Click(object sender, EventArgs e) {
            string[] 文件名 = 获取打开文件名("raw文件 | *.raw", "打开raw文件", false);
            if (文件名 != null && 文件名[0] != null) {
                打开raw进度条.Visible = true;
                高光谱相机Tab 新Tab = new 高光谱相机Tab(this, 曲线图片框右键菜单,数据tab, 打开raw进度条, 文件名[0]);
                打开raw进度条.Visible = false;
            }
        }

        private string[] 获取打开文件名(string 后缀名过滤, string 对话框标题, bool 多选) {
            OpenFileDialog 打开文件对话框 = new OpenFileDialog();
            打开文件对话框.Filter = 后缀名过滤;
            打开文件对话框.Multiselect = 多选;
            打开文件对话框.Title = 对话框标题;
            打开文件对话框.RestoreDirectory = true;
            if (打开文件对话框.ShowDialog(this) == DialogResult.OK)
                return 打开文件对话框.FileNames;
            else return null;
        }

        private void 关闭Tab_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) 高光谱tab.关闭();
            光谱仪Tab tab = 数据tab.SelectedTab as 光谱仪Tab;
            if (tab != null) tab.关闭();
                
        }

        public void 显示图片信息(Point 当前点坐标, Bitmap 位图) {
            X坐标Label.Text = 当前点坐标.X.ToString() + ",";//鼠标移动时显示鼠标指针指向的图片上像素点的坐标
            Y坐标Label.Text = 当前点坐标.Y.ToString();
            Color 当前点颜色 = Color.Black;//在左上显示鼠标位置像素点的RGB值和HSI值
            if (当前点坐标.X < 位图.Width && 当前点坐标.Y < 位图.Height && 当前点坐标.X >= 0 && 当前点坐标.Y >= 0)
                当前点颜色 = 位图.GetPixel(当前点坐标.X, 当前点坐标.Y);
            int H = (int)(当前点颜色.GetHue() / 3 * 2 + 0.5); //0-360
            int S = (int)(当前点颜色.GetSaturation() * 240 + 0.5); //0-1
            int I = (int)(当前点颜色.GetBrightness() * 240 + 0.5); //0-1    
            红label.Text = 当前点颜色.R.ToString();
            绿label.Text = 当前点颜色.G.ToString();
            蓝label.Text = 当前点颜色.B.ToString();
            色度label.Text = H.ToString();
            饱和度label.Text = S.ToString();
            亮度label.Text = I.ToString();
            红label.Refresh(); 色度label.Refresh();
            绿label.Refresh(); 饱和度label.Refresh();
            蓝label.Refresh(); 亮度label.Refresh();
        }

        private void 加倍亮度按钮_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) 高光谱tab.加倍亮度();


        }

        private void 清空采样ToolStripMenuItem_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) 高光谱tab.清空采样();
        }

        private void 曲线图片框右键菜单_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            右键点击坐标 = Cursor.Position;
        }

        private void 设为红ToolStripMenuItem_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) 高光谱tab.设置伪彩色频点(右键点击坐标, Color.Red);
        }

        private void 设为绿ToolStripMenuItem_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) 高光谱tab.设置伪彩色频点(右键点击坐标, Color.Green);
        }

        private void 设为蓝ToolStripMenuItem_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) 高光谱tab.设置伪彩色频点(右键点击坐标, Color.Blue);
        }

        private void 生成伪彩色按钮_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) 高光谱tab.生成伪彩色图();
        }

        private void 彩灰切换按钮_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) 高光谱tab.彩灰切换();
        }

        private void 保存左边采样图ToolStripMenuItem_Click(object sender, EventArgs e) {
            高光谱相机Tab 高光谱tab = 数据tab.SelectedTab as 高光谱相机Tab;
            if (高光谱tab != null) {
                string 文件名 = 获取保存文件名("PNG文件(*.png) | *.png");
                try {
                    高光谱tab.获取显示的位图().Save(文件名, ImageFormat.Png);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("没有正在显示的高光谱Tab页!");
        }

        private string 获取保存文件名(string 后缀名过滤) {
            SaveFileDialog 保存文件对话框 = new SaveFileDialog();
            保存文件对话框.Filter = 后缀名过滤;
            保存文件对话框.Title = "另存图片文件";
            保存文件对话框.RestoreDirectory = true;
            保存文件对话框.OverwritePrompt = true;
            if (保存文件对话框.ShowDialog(this) == DialogResult.OK)
                return 保存文件对话框.FileName;
            else return null;
        }

        
    }
}
