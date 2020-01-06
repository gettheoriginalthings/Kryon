using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace 光谱分析 {
    /// <summary>
    /// 用来显示海洋红外光谱曲线的Tab页
    /// </summary>
    class 光谱仪Tab : TabPage {
        int 图宽 = 630;
        int 图高 = 300; 
        List<海洋红外光谱数据> 光谱数据表 = new List<海洋红外光谱数据>();
        Form 主窗体;
        TabControl 所属tabControl;

        public 光谱仪Tab(Form1 form, TabControl tabCtrl, string [] 多个文件名) {
            foreach (string 文件名 in 多个文件名) {
                海洋红外光谱数据 数据 = new 海洋红外光谱数据(文件名);
                if (数据.画曲线图(图宽, 图高, Color.Black))
                    光谱数据表.Add(数据);
            }
            if (光谱数据表.Count > 0) {
                int 每行图片数 = 1900 / 图宽;
                for (int i = 0; i < 光谱数据表.Count; i++) {
                    曲线图片框 图片框 = new 曲线图片框(new Point((i % 每行图片数) * (图宽 + 2), (图高 + 2) * (i / 每行图片数)), 光谱数据表[i]);
                    Controls.Add(图片框);
                }
                主窗体 = form;
                Text = "海洋红外谱线" + 光谱数据表.Count + "个";
                AutoScroll = true;
                tabCtrl.TabPages.Insert(0, this);
                tabCtrl.SelectedTab = this;
                所属tabControl = tabCtrl;
            }
        }

        public void 关闭() {
            foreach (Control item in Controls) 
                ((曲线图片框)item).关闭();
            光谱数据表 = null;
            所属tabControl.TabPages.Remove(this);
            Dispose();
        }

    }
}
