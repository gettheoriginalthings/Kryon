namespace 光谱分析 {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开光谱仪数据文本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开高光谱RAW数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.加倍亮度按钮 = new System.Windows.Forms.Button();
            this.Y坐标Label = new System.Windows.Forms.Label();
            this.X坐标Label = new System.Windows.Forms.Label();
            this.亮度label = new System.Windows.Forms.Label();
            this.饱和度label = new System.Windows.Forms.Label();
            this.色度label = new System.Windows.Forms.Label();
            this.蓝label = new System.Windows.Forms.Label();
            this.绿label = new System.Windows.Forms.Label();
            this.红label = new System.Windows.Forms.Label();
            this.关闭Tab = new System.Windows.Forms.Button();
            this.数据tab = new System.Windows.Forms.TabControl();
            this.打开raw进度条 = new System.Windows.Forms.ProgressBar();
            this.曲线图片框右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空采样ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设为红ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设为绿ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设为蓝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成伪彩色按钮 = new System.Windows.Forms.Button();
            this.彩灰切换按钮 = new System.Windows.Forms.Button();
            this.保存左边采样图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.使用说明 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.数据tab.SuspendLayout();
            this.曲线图片框右键菜单.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1394, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开高光谱RAW数据ToolStripMenuItem,
            this.打开光谱仪数据文本ToolStripMenuItem,
            this.保存左边采样图ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开光谱仪数据文本ToolStripMenuItem
            // 
            this.打开光谱仪数据文本ToolStripMenuItem.Name = "打开光谱仪数据文本ToolStripMenuItem";
            this.打开光谱仪数据文本ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.打开光谱仪数据文本ToolStripMenuItem.Text = "打开光谱仪数据文本(可多选)";
            this.打开光谱仪数据文本ToolStripMenuItem.Click += new System.EventHandler(this.打开光谱仪数据文本ToolStripMenuItem_Click);
            // 
            // 打开高光谱RAW数据ToolStripMenuItem
            // 
            this.打开高光谱RAW数据ToolStripMenuItem.Name = "打开高光谱RAW数据ToolStripMenuItem";
            this.打开高光谱RAW数据ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.打开高光谱RAW数据ToolStripMenuItem.Text = "打开高光谱RAW数据";
            this.打开高光谱RAW数据ToolStripMenuItem.Click += new System.EventHandler(this.打开高光谱RAW数据ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.彩灰切换按钮);
            this.splitContainer1.Panel1.Controls.Add(this.生成伪彩色按钮);
            this.splitContainer1.Panel1.Controls.Add(this.加倍亮度按钮);
            this.splitContainer1.Panel1.Controls.Add(this.Y坐标Label);
            this.splitContainer1.Panel1.Controls.Add(this.X坐标Label);
            this.splitContainer1.Panel1.Controls.Add(this.亮度label);
            this.splitContainer1.Panel1.Controls.Add(this.饱和度label);
            this.splitContainer1.Panel1.Controls.Add(this.色度label);
            this.splitContainer1.Panel1.Controls.Add(this.蓝label);
            this.splitContainer1.Panel1.Controls.Add(this.绿label);
            this.splitContainer1.Panel1.Controls.Add(this.红label);
            this.splitContainer1.Panel1.Controls.Add(this.关闭Tab);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.数据tab);
            this.splitContainer1.Size = new System.Drawing.Size(1394, 734);
            this.splitContainer1.SplitterDistance = 64;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // 加倍亮度按钮
            // 
            this.加倍亮度按钮.Location = new System.Drawing.Point(193, 36);
            this.加倍亮度按钮.Name = "加倍亮度按钮";
            this.加倍亮度按钮.Size = new System.Drawing.Size(63, 23);
            this.加倍亮度按钮.TabIndex = 23;
            this.加倍亮度按钮.Text = "加倍亮度";
            this.加倍亮度按钮.UseVisualStyleBackColor = true;
            this.加倍亮度按钮.Click += new System.EventHandler(this.加倍亮度按钮_Click);
            // 
            // Y坐标Label
            // 
            this.Y坐标Label.AutoSize = true;
            this.Y坐标Label.Location = new System.Drawing.Point(124, 10);
            this.Y坐标Label.Name = "Y坐标Label";
            this.Y坐标Label.Size = new System.Drawing.Size(11, 12);
            this.Y坐标Label.TabIndex = 22;
            this.Y坐标Label.Text = "Y";
            // 
            // X坐标Label
            // 
            this.X坐标Label.AutoSize = true;
            this.X坐标Label.Location = new System.Drawing.Point(98, 10);
            this.X坐标Label.Name = "X坐标Label";
            this.X坐标Label.Size = new System.Drawing.Size(11, 12);
            this.X坐标Label.TabIndex = 21;
            this.X坐标Label.Text = "X";
            // 
            // 亮度label
            // 
            this.亮度label.AutoSize = true;
            this.亮度label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.亮度label.ForeColor = System.Drawing.Color.Black;
            this.亮度label.Location = new System.Drawing.Point(55, 45);
            this.亮度label.Margin = new System.Windows.Forms.Padding(0);
            this.亮度label.Name = "亮度label";
            this.亮度label.Size = new System.Drawing.Size(35, 14);
            this.亮度label.TabIndex = 20;
            this.亮度label.Text = "亮度";
            // 
            // 饱和度label
            // 
            this.饱和度label.AutoSize = true;
            this.饱和度label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.饱和度label.ForeColor = System.Drawing.Color.Black;
            this.饱和度label.Location = new System.Drawing.Point(55, 27);
            this.饱和度label.Margin = new System.Windows.Forms.Padding(0);
            this.饱和度label.Name = "饱和度label";
            this.饱和度label.Size = new System.Drawing.Size(35, 14);
            this.饱和度label.TabIndex = 19;
            this.饱和度label.Text = "饱和";
            // 
            // 色度label
            // 
            this.色度label.AutoSize = true;
            this.色度label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.色度label.ForeColor = System.Drawing.Color.Black;
            this.色度label.Location = new System.Drawing.Point(55, 9);
            this.色度label.Margin = new System.Windows.Forms.Padding(0);
            this.色度label.Name = "色度label";
            this.色度label.Size = new System.Drawing.Size(35, 14);
            this.色度label.TabIndex = 18;
            this.色度label.Text = "色度";
            // 
            // 蓝label
            // 
            this.蓝label.AutoSize = true;
            this.蓝label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.蓝label.ForeColor = System.Drawing.Color.Blue;
            this.蓝label.Location = new System.Drawing.Point(10, 45);
            this.蓝label.Margin = new System.Windows.Forms.Padding(0);
            this.蓝label.Name = "蓝label";
            this.蓝label.Size = new System.Drawing.Size(21, 14);
            this.蓝label.TabIndex = 16;
            this.蓝label.Text = "蓝";
            // 
            // 绿label
            // 
            this.绿label.AutoSize = true;
            this.绿label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.绿label.ForeColor = System.Drawing.Color.Green;
            this.绿label.Location = new System.Drawing.Point(10, 27);
            this.绿label.Margin = new System.Windows.Forms.Padding(0);
            this.绿label.Name = "绿label";
            this.绿label.Size = new System.Drawing.Size(21, 14);
            this.绿label.TabIndex = 17;
            this.绿label.Text = "绿";
            // 
            // 红label
            // 
            this.红label.AutoSize = true;
            this.红label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.红label.ForeColor = System.Drawing.Color.Red;
            this.红label.Location = new System.Drawing.Point(10, 9);
            this.红label.Margin = new System.Windows.Forms.Padding(0);
            this.红label.Name = "红label";
            this.红label.Size = new System.Drawing.Size(21, 14);
            this.红label.TabIndex = 15;
            this.红label.Text = "红";
            // 
            // 关闭Tab
            // 
            this.关闭Tab.Location = new System.Drawing.Point(93, 36);
            this.关闭Tab.Name = "关闭Tab";
            this.关闭Tab.Size = new System.Drawing.Size(94, 23);
            this.关闭Tab.TabIndex = 0;
            this.关闭Tab.Text = "关闭当前Tab页";
            this.关闭Tab.UseVisualStyleBackColor = true;
            this.关闭Tab.Click += new System.EventHandler(this.关闭Tab_Click);
            // 
            // 数据tab
            // 
            this.数据tab.Controls.Add(this.tabPage1);
            this.数据tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.数据tab.Location = new System.Drawing.Point(0, 0);
            this.数据tab.Name = "数据tab";
            this.数据tab.SelectedIndex = 0;
            this.数据tab.Size = new System.Drawing.Size(1394, 668);
            this.数据tab.TabIndex = 0;
            // 
            // 打开raw进度条
            // 
            this.打开raw进度条.Location = new System.Drawing.Point(55, 1);
            this.打开raw进度条.Name = "打开raw进度条";
            this.打开raw进度条.Size = new System.Drawing.Size(100, 23);
            this.打开raw进度条.TabIndex = 0;
            this.打开raw进度条.Visible = false;
            // 
            // 曲线图片框右键菜单
            // 
            this.曲线图片框右键菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空采样ToolStripMenuItem,
            this.设为红ToolStripMenuItem,
            this.设为绿ToolStripMenuItem,
            this.设为蓝ToolStripMenuItem});
            this.曲线图片框右键菜单.Name = "曲线图片框右键菜单";
            this.曲线图片框右键菜单.Size = new System.Drawing.Size(125, 92);
            this.曲线图片框右键菜单.Opening += new System.ComponentModel.CancelEventHandler(this.曲线图片框右键菜单_Opening);
            // 
            // 清空采样ToolStripMenuItem
            // 
            this.清空采样ToolStripMenuItem.Name = "清空采样ToolStripMenuItem";
            this.清空采样ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.清空采样ToolStripMenuItem.Text = "清空采样";
            this.清空采样ToolStripMenuItem.Click += new System.EventHandler(this.清空采样ToolStripMenuItem_Click);
            // 
            // 设为红ToolStripMenuItem
            // 
            this.设为红ToolStripMenuItem.Name = "设为红ToolStripMenuItem";
            this.设为红ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设为红ToolStripMenuItem.Text = "设为红";
            this.设为红ToolStripMenuItem.Click += new System.EventHandler(this.设为红ToolStripMenuItem_Click);
            // 
            // 设为绿ToolStripMenuItem
            // 
            this.设为绿ToolStripMenuItem.Name = "设为绿ToolStripMenuItem";
            this.设为绿ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设为绿ToolStripMenuItem.Text = "设为绿";
            this.设为绿ToolStripMenuItem.Click += new System.EventHandler(this.设为绿ToolStripMenuItem_Click);
            // 
            // 设为蓝ToolStripMenuItem
            // 
            this.设为蓝ToolStripMenuItem.Name = "设为蓝ToolStripMenuItem";
            this.设为蓝ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设为蓝ToolStripMenuItem.Text = "设为蓝";
            this.设为蓝ToolStripMenuItem.Click += new System.EventHandler(this.设为蓝ToolStripMenuItem_Click);
            // 
            // 生成伪彩色按钮
            // 
            this.生成伪彩色按钮.Location = new System.Drawing.Point(263, 36);
            this.生成伪彩色按钮.Name = "生成伪彩色按钮";
            this.生成伪彩色按钮.Size = new System.Drawing.Size(86, 23);
            this.生成伪彩色按钮.TabIndex = 24;
            this.生成伪彩色按钮.Text = "生成伪彩色图";
            this.生成伪彩色按钮.UseVisualStyleBackColor = true;
            this.生成伪彩色按钮.Click += new System.EventHandler(this.生成伪彩色按钮_Click);
            // 
            // 彩灰切换按钮
            // 
            this.彩灰切换按钮.Location = new System.Drawing.Point(355, 36);
            this.彩灰切换按钮.Name = "彩灰切换按钮";
            this.彩灰切换按钮.Size = new System.Drawing.Size(75, 23);
            this.彩灰切换按钮.TabIndex = 25;
            this.彩灰切换按钮.Text = "彩|灰切换";
            this.彩灰切换按钮.UseVisualStyleBackColor = true;
            this.彩灰切换按钮.Click += new System.EventHandler(this.彩灰切换按钮_Click);
            // 
            // 保存左边采样图ToolStripMenuItem
            // 
            this.保存左边采样图ToolStripMenuItem.Name = "保存左边采样图ToolStripMenuItem";
            this.保存左边采样图ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.保存左边采样图ToolStripMenuItem.Text = "保存左边采样图";
            this.保存左边采样图ToolStripMenuItem.Click += new System.EventHandler(this.保存左边采样图ToolStripMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.使用说明);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1386, 642);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "说明";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // 使用说明
            // 
            this.使用说明.AutoSize = true;
            this.使用说明.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.使用说明.Location = new System.Drawing.Point(9, 9);
            this.使用说明.Name = "使用说明";
            this.使用说明.Size = new System.Drawing.Size(56, 16);
            this.使用说明.TabIndex = 0;
            this.使用说明.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 759);
            this.Controls.Add(this.打开raw进度条);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "光谱分析V0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.数据tab.ResumeLayout(false);
            this.曲线图片框右键菜单.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开光谱仪数据文本ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl 数据tab;
        private System.Windows.Forms.ToolStripMenuItem 打开高光谱RAW数据ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar 打开raw进度条;
        private System.Windows.Forms.Button 关闭Tab;
        private System.Windows.Forms.Label 亮度label;
        private System.Windows.Forms.Label 饱和度label;
        private System.Windows.Forms.Label 色度label;
        private System.Windows.Forms.Label 蓝label;
        private System.Windows.Forms.Label 绿label;
        private System.Windows.Forms.Label 红label;
        private System.Windows.Forms.Label Y坐标Label;
        private System.Windows.Forms.Label X坐标Label;
        private System.Windows.Forms.Button 加倍亮度按钮;
        private System.Windows.Forms.ContextMenuStrip 曲线图片框右键菜单;
        private System.Windows.Forms.ToolStripMenuItem 清空采样ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设为红ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设为绿ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设为蓝ToolStripMenuItem;
        private System.Windows.Forms.Button 生成伪彩色按钮;
        private System.Windows.Forms.Button 彩灰切换按钮;
        private System.Windows.Forms.ToolStripMenuItem 保存左边采样图ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label 使用说明;
    }
}

