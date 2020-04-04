using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DemoRealChart;
namespace DemoSharp
{
    public partial class RealChart : Form
    {
        private Queue<double> dataQueue = new Queue<double>(1000);

        private int curValue = 0;

        private int num = 5;//每次删除增加几个点

        public RealChart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            InitChart();
        }

        /// <summary>
        /// 开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        } 
        
        /// <summary>
        /// 停止事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateQueueValue();

            this.chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataQueue.Count; i++)
            {
                {
                    this.chart1.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                    //picdata1.AppendText( this.chart1.Series[0].Points.ToString());
                }
            }
        } 
        
        /// <summary>
        /// 初始化图表
        /// </summary>
        private void InitChart() {
            //定义图表区域
            this.chart1.ChartAreas.Clear();//清除区域
            ChartArea chartArea1 = new ChartArea("C4");//随便定义，只是一个名字，实例化对象
            this.chart1.ChartAreas.Add(chartArea1);//加载对象
            //定义存储和显示点的容器
            this.chart1.Series.Clear();//清除容器
            Series series1 = new Series("S1");//容器实例化
            series1.ChartArea = "C4";//加载区域
            this.chart1.Series.Add(series1);//加载对象
            //设置图表显示样式
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;
            this.chart1.ChartAreas[0].AxisY.Maximum =1000;
            this.chart1.ChartAreas[0].AxisX.Interval =1;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("S02");
            this.chart1.Titles[0].Text = "XXX显示";
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式
            this.chart1.Series[0].Color = Color.Red;
            if (rb1.Checked)
            {
                this.chart1.Titles[0].Text =string.Format( "XXX {0} 显示",rb1.Text);
                this.chart1.Series[0].ChartType = SeriesChartType.Line;//SeriesChartType.Line;
            }
            if (rb2.Checked) {
                this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", rb2.Text);
                this.chart1.Series[0].ChartType = SeriesChartType.Spline;
            }
            this.chart1.Series[0].Points.Clear();
        }
        
        //更新队列中的值
        private void UpdateQueueValue() {
            
            if (dataQueue.Count > 100) {
                //先出列
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }
            if (rb1.Checked)
            {
               // Random r = new Random();
                for (int i = 0; i < num; i++)
                {
                    //dataQueue.Enqueue(r.Next(0, 100));
                    dataQueue.Enqueue((int.Parse(Form1.picdata)));
                    txt数值1.Text = Form1.picdata;
                    txtrw aa = new txtrw();
                    aa.txtwrite("file.txt", Form1.picdata); 
                }
            }
            if (rb2.Checked) {
                for (int i = 0; i < num; i++)
                {
                    //对curValue只取[0,360]之间的值
                    curValue = curValue % 360;
                    //对得到的正玄值，放大50倍，并上移50
                    dataQueue.Enqueue((50*Math.Sin(curValue*Math.PI / 180))+50);
                    curValue=curValue+10;
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
