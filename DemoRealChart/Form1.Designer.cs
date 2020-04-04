namespace DemoRealChart
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSetSp = new System.Windows.Forms.Button();
            this.bntSwitchSP = new System.Windows.Forms.Button();
            this.btn导出数据 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bntSendFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.bntSendData = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceiveData255 = new System.Windows.Forms.TextBox();
            this.txtReceiveDataDec = new System.Windows.Forms.TextBox();
            this.txtReceiveDataHex = new System.Windows.Forms.TextBox();
            this.btnReceiveData = new System.Windows.Forms.Button();
            this.bntClear = new System.Windows.Forms.Button();
            this.txtReceiveData = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.btn实时曲线 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn历史曲线 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.运行时间 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetSp
            // 
            this.btnSetSp.Location = new System.Drawing.Point(6, 22);
            this.btnSetSp.Name = "btnSetSp";
            this.btnSetSp.Size = new System.Drawing.Size(75, 23);
            this.btnSetSp.TabIndex = 0;
            this.btnSetSp.Text = "设置串口";
            this.btnSetSp.UseVisualStyleBackColor = true;
            this.btnSetSp.Click += new System.EventHandler(this.btnSetSp_Click);
            // 
            // bntSwitchSP
            // 
            this.bntSwitchSP.Location = new System.Drawing.Point(80, 22);
            this.bntSwitchSP.Name = "bntSwitchSP";
            this.bntSwitchSP.Size = new System.Drawing.Size(75, 23);
            this.bntSwitchSP.TabIndex = 1;
            this.bntSwitchSP.Text = "关闭串口";
            this.bntSwitchSP.UseVisualStyleBackColor = true;
            this.bntSwitchSP.Click += new System.EventHandler(this.bntSwitchSP_Click);
            // 
            // btn导出数据
            // 
            this.btn导出数据.Location = new System.Drawing.Point(154, 22);
            this.btn导出数据.Name = "btn导出数据";
            this.btn导出数据.Size = new System.Drawing.Size(75, 23);
            this.btn导出数据.TabIndex = 2;
            this.btn导出数据.Text = "导出信息";
            this.btn导出数据.UseVisualStyleBackColor = true;
            this.btn导出数据.Click += new System.EventHandler(this.btn导出数据_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntSendFile);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Controls.Add(this.bntSendData);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 224);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送管理";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // bntSendFile
            // 
            this.bntSendFile.Location = new System.Drawing.Point(534, 187);
            this.bntSendFile.Name = "bntSendFile";
            this.bntSendFile.Size = new System.Drawing.Size(75, 23);
            this.bntSendFile.TabIndex = 4;
            this.bntSendFile.Text = "发送文件";
            this.bntSendFile.UseVisualStyleBackColor = true;
            this.bntSendFile.Click += new System.EventHandler(this.bntSendFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(37, 187);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(480, 21);
            this.txtFileName.TabIndex = 3;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(37, 153);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "文件浏览";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // bntSendData
            // 
            this.bntSendData.Location = new System.Drawing.Point(534, 69);
            this.bntSendData.Name = "bntSendData";
            this.bntSendData.Size = new System.Drawing.Size(75, 23);
            this.bntSendData.TabIndex = 1;
            this.bntSendData.Text = "发送数据";
            this.bntSendData.UseVisualStyleBackColor = true;
            this.bntSendData.Click += new System.EventHandler(this.bntSendData_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(37, 34);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSend.Size = new System.Drawing.Size(480, 102);
            this.txtSend.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReceiveData255);
            this.groupBox2.Controls.Add(this.txtReceiveDataDec);
            this.groupBox2.Controls.Add(this.txtReceiveDataHex);
            this.groupBox2.Controls.Add(this.btnReceiveData);
            this.groupBox2.Controls.Add(this.bntClear);
            this.groupBox2.Controls.Add(this.txtReceiveData);
            this.groupBox2.Location = new System.Drawing.Point(13, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 517);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收管理";
            // 
            // txtReceiveData255
            // 
            this.txtReceiveData255.Location = new System.Drawing.Point(36, 389);
            this.txtReceiveData255.Multiline = true;
            this.txtReceiveData255.Name = "txtReceiveData255";
            this.txtReceiveData255.Size = new System.Drawing.Size(480, 109);
            this.txtReceiveData255.TabIndex = 6;
            // 
            // txtReceiveDataDec
            // 
            this.txtReceiveDataDec.Location = new System.Drawing.Point(36, 268);
            this.txtReceiveDataDec.Multiline = true;
            this.txtReceiveDataDec.Name = "txtReceiveDataDec";
            this.txtReceiveDataDec.Size = new System.Drawing.Size(480, 106);
            this.txtReceiveDataDec.TabIndex = 5;
            // 
            // txtReceiveDataHex
            // 
            this.txtReceiveDataHex.Location = new System.Drawing.Point(36, 147);
            this.txtReceiveDataHex.Multiline = true;
            this.txtReceiveDataHex.Name = "txtReceiveDataHex";
            this.txtReceiveDataHex.Size = new System.Drawing.Size(480, 103);
            this.txtReceiveDataHex.TabIndex = 4;
            // 
            // btnReceiveData
            // 
            this.btnReceiveData.Location = new System.Drawing.Point(533, 49);
            this.btnReceiveData.Name = "btnReceiveData";
            this.btnReceiveData.Size = new System.Drawing.Size(75, 23);
            this.btnReceiveData.TabIndex = 3;
            this.btnReceiveData.Text = "接收数据";
            this.btnReceiveData.UseVisualStyleBackColor = true;
            this.btnReceiveData.Click += new System.EventHandler(this.btnReceiveData_Click);
            // 
            // bntClear
            // 
            this.bntClear.Location = new System.Drawing.Point(533, 94);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(75, 23);
            this.bntClear.TabIndex = 2;
            this.bntClear.Text = "清空内容";
            this.bntClear.UseVisualStyleBackColor = true;
            this.bntClear.Click += new System.EventHandler(this.bntClear_Click);
            // 
            // txtReceiveData
            // 
            this.txtReceiveData.Location = new System.Drawing.Point(36, 20);
            this.txtReceiveData.Multiline = true;
            this.txtReceiveData.Name = "txtReceiveData";
            this.txtReceiveData.Size = new System.Drawing.Size(480, 111);
            this.txtReceiveData.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.toolStripLabel5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 437);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel3.Text = "toolStripLabel3";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel4.Text = "toolStripLabel4";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel5.Text = "toolStripLabel5";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btn实时曲线
            // 
            this.btn实时曲线.Location = new System.Drawing.Point(228, 22);
            this.btn实时曲线.Name = "btn实时曲线";
            this.btn实时曲线.Size = new System.Drawing.Size(75, 23);
            this.btn实时曲线.TabIndex = 6;
            this.btn实时曲线.Text = "实时曲线";
            this.btn实时曲线.UseVisualStyleBackColor = true;
            this.btn实时曲线.Click += new System.EventHandler(this.btn实时曲线_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn历史曲线);
            this.groupBox3.Controls.Add(this.btn实时曲线);
            this.groupBox3.Controls.Add(this.btnSetSp);
            this.groupBox3.Controls.Add(this.bntSwitchSP);
            this.groupBox3.Controls.Add(this.btn导出数据);
            this.groupBox3.Location = new System.Drawing.Point(12, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(626, 53);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // btn历史曲线
            // 
            this.btn历史曲线.Location = new System.Drawing.Point(302, 22);
            this.btn历史曲线.Name = "btn历史曲线";
            this.btn历史曲线.Size = new System.Drawing.Size(75, 23);
            this.btn历史曲线.TabIndex = 7;
            this.btn历史曲线.Text = "历史曲线";
            this.btn历史曲线.UseVisualStyleBackColor = true;
            this.btn历史曲线.Click += new System.EventHandler(this.btn历史曲线_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.运行时间);
            this.groupBox4.Location = new System.Drawing.Point(656, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 260);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "参数";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "采样";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "采样开关：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1000",
            "500"});
            this.comboBox1.Location = new System.Drawing.Point(84, 170);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(57, 20);
            this.comboBox1.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "采样时间：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "亮/灭";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "生长灯2：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "亮/灭";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "生长灯1：\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "自动/手动";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "模式状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "-----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "光照数据：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "-----";
            // 
            // 运行时间
            // 
            this.运行时间.AutoSize = true;
            this.运行时间.Location = new System.Drawing.Point(7, 31);
            this.运行时间.Name = "运行时间";
            this.运行时间.Size = new System.Drawing.Size(65, 12);
            this.运行时间.TabIndex = 0;
            this.运行时间.Text = "运行时间：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(694, 301);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 64);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // timer3
            // 
            this.timer3.Interval = 3000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 462);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "通信管理终端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetSp;
        private System.Windows.Forms.Button bntSwitchSP;
        private System.Windows.Forms.Button btn导出数据;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bntSendFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button bntSendData;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bntClear;
        private System.Windows.Forms.TextBox txtReceiveData;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnReceiveData;
        private System.Windows.Forms.TextBox txtReceiveDataHex;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.TextBox txtReceiveDataDec;
        private System.Windows.Forms.TextBox txtReceiveData255;
        private System.Windows.Forms.Button btn实时曲线;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn历史曲线;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 运行时间;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer3;
    }
}

