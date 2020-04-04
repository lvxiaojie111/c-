namespace DemoRealChart
{
    partial class 历史数据曲线
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn打开历史数据 = new System.Windows.Forms.Button();
            this.txt文件路径 = new System.Windows.Forms.TextBox();
            this.lbe文件路径 = new System.Windows.Forms.Label();
            this.txt数据信息 = new System.Windows.Forms.TextBox();
            this.lbe历史数据 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(268, 35);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "光照数据1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "光照数据2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(548, 376);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btn打开历史数据
            // 
            this.btn打开历史数据.Location = new System.Drawing.Point(84, 12);
            this.btn打开历史数据.Name = "btn打开历史数据";
            this.btn打开历史数据.Size = new System.Drawing.Size(90, 23);
            this.btn打开历史数据.TabIndex = 1;
            this.btn打开历史数据.Text = "打开历史数据";
            this.btn打开历史数据.UseVisualStyleBackColor = true;
            this.btn打开历史数据.Click += new System.EventHandler(this.btn打开历史数据_Click);
            // 
            // txt文件路径
            // 
            this.txt文件路径.Location = new System.Drawing.Point(6, 32);
            this.txt文件路径.Name = "txt文件路径";
            this.txt文件路径.Size = new System.Drawing.Size(243, 21);
            this.txt文件路径.TabIndex = 2;
            // 
            // lbe文件路径
            // 
            this.lbe文件路径.AutoSize = true;
            this.lbe文件路径.Location = new System.Drawing.Point(6, 17);
            this.lbe文件路径.Name = "lbe文件路径";
            this.lbe文件路径.Size = new System.Drawing.Size(65, 12);
            this.lbe文件路径.TabIndex = 3;
            this.lbe文件路径.Text = "文件路径：";
            this.lbe文件路径.Click += new System.EventHandler(this.lbe文件路径_Click);
            // 
            // txt数据信息
            // 
            this.txt数据信息.Location = new System.Drawing.Point(6, 71);
            this.txt数据信息.Multiline = true;
            this.txt数据信息.Name = "txt数据信息";
            this.txt数据信息.Size = new System.Drawing.Size(243, 292);
            this.txt数据信息.TabIndex = 4;
            // 
            // lbe历史数据
            // 
            this.lbe历史数据.AutoSize = true;
            this.lbe历史数据.Location = new System.Drawing.Point(6, 56);
            this.lbe历史数据.Name = "lbe历史数据";
            this.lbe历史数据.Size = new System.Drawing.Size(65, 12);
            this.lbe历史数据.TabIndex = 5;
            this.lbe历史数据.Text = "历史数据：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbe文件路径);
            this.groupBox1.Controls.Add(this.lbe历史数据);
            this.groupBox1.Controls.Add(this.txt文件路径);
            this.groupBox1.Controls.Add(this.txt数据信息);
            this.groupBox1.Location = new System.Drawing.Point(3, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 376);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // 历史数据曲线
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn打开历史数据);
            this.Controls.Add(this.chart1);
            this.Name = "历史数据曲线";
            this.Text = "历史数据曲线";
            this.Load += new System.EventHandler(this.历史数据曲线_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btn打开历史数据;
        private System.Windows.Forms.TextBox txt文件路径;
        private System.Windows.Forms.Label lbe文件路径;
        private System.Windows.Forms.TextBox txt数据信息;
        private System.Windows.Forms.Label lbe历史数据;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}