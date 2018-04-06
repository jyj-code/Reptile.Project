namespace Reptile.Project
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPath = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.btnImmed = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFinacial = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvFinads = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.myIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.myMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinacial)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinads)).BeginInit();
            this.myMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(665, 363);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtPath);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.btnStart);
            this.tabPage3.Controls.Add(this.btnSavePath);
            this.tabPage3.Controls.Add(this.btnImmed);
            this.tabPage3.Controls.Add(this.txtTime);
            this.tabPage3.Controls.Add(this.txtDay);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(657, 337);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "爬出设置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.AutoSize = true;
            this.txtPath.Font = new System.Drawing.Font("宋体", 14F);
            this.txtPath.Location = new System.Drawing.Point(26, 299);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(142, 19);
            this.txtPath.TabIndex = 4;
            this.txtPath.Text = "毫秒后开始爬取";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F);
            this.label6.Location = new System.Drawing.Point(167, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "毫秒后开始爬取";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(26, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 18F);
            this.btnSave.Location = new System.Drawing.Point(493, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 37);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 18F);
            this.btnStart.Location = new System.Drawing.Point(493, 35);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(132, 37);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始抓取";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(235, 154);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(147, 53);
            this.btnSavePath.TabIndex = 2;
            this.btnSavePath.Text = "选择保存文件路径";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // btnImmed
            // 
            this.btnImmed.Location = new System.Drawing.Point(21, 149);
            this.btnImmed.Name = "btnImmed";
            this.btnImmed.Size = new System.Drawing.Size(147, 58);
            this.btnImmed.TabIndex = 2;
            this.btnImmed.Text = "立即爬取当天数据";
            this.btnImmed.UseVisualStyleBackColor = true;
            this.btnImmed.Click += new System.EventHandler(this.btnImmed_Click);
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("宋体", 18F);
            this.txtTime.Location = new System.Drawing.Point(235, 85);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(187, 35);
            this.txtTime.TabIndex = 1;
            this.txtTime.Text = "12";
            this.txtTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // txtDay
            // 
            this.txtDay.Font = new System.Drawing.Font("宋体", 18F);
            this.txtDay.Location = new System.Drawing.Point(235, 37);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(187, 35);
            this.txtDay.TabIndex = 1;
            this.txtDay.Text = "30";
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDay_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 18F);
            this.label4.Location = new System.Drawing.Point(428, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 35);
            this.label4.TabIndex = 0;
            this.label4.Text = "分钟";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 18F);
            this.label2.Location = new System.Drawing.Point(428, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "天数据";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 18F);
            this.label3.Location = new System.Drawing.Point(21, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 48);
            this.label3.TabIndex = 0;
            this.label3.Text = "定时抓取间隔时间：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 18F);
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "抓取最近";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(657, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "财经数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvFinacial);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 331);
            this.panel1.TabIndex = 0;
            // 
            // dgvFinacial
            // 
            this.dgvFinacial.AllowUserToAddRows = false;
            this.dgvFinacial.AllowUserToDeleteRows = false;
            this.dgvFinacial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFinacial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinacial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFinacial.Location = new System.Drawing.Point(0, 0);
            this.dgvFinacial.Name = "dgvFinacial";
            this.dgvFinacial.ReadOnly = true;
            this.dgvFinacial.RowTemplate.Height = 23;
            this.dgvFinacial.Size = new System.Drawing.Size(651, 331);
            this.dgvFinacial.TabIndex = 1;
            this.dgvFinacial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFinacial_CellContentClick);
            this.dgvFinacial.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvFinacial_CellPainting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvFinads);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(657, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "财经大事";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvFinads
            // 
            this.dgvFinads.AllowUserToAddRows = false;
            this.dgvFinads.AllowUserToDeleteRows = false;
            this.dgvFinads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFinads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFinads.Location = new System.Drawing.Point(3, 3);
            this.dgvFinads.Name = "dgvFinads";
            this.dgvFinads.ReadOnly = true;
            this.dgvFinads.RowTemplate.Height = 23;
            this.dgvFinads.Size = new System.Drawing.Size(651, 331);
            this.dgvFinads.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // myIcon
            // 
            this.myIcon.ContextMenuStrip = this.myMenu;
            this.myIcon.Text = "科布尔爬虫系统 演示版本";
            this.myIcon.Visible = true;
            this.myIcon.DoubleClick += new System.EventHandler(this.myIcon_DoubleClick);
            this.myIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.myIcon_MouseClick);
            // 
            // myMenu
            // 
            this.myMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.myMenu.Name = "myMenu";
            this.myMenu.Size = new System.Drawing.Size(123, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem1.Text = "退出系统";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 363);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "爬出程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinacial)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinads)).EndInit();
            this.myMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFinacial;
        private System.Windows.Forms.DataGridView dgvFinads;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnImmed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Label txtPath;
        private System.Windows.Forms.NotifyIcon myIcon;
        private System.Windows.Forms.ContextMenuStrip myMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

