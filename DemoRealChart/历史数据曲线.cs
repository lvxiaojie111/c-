using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace DemoRealChart
{
    public partial class 历史数据曲线 : Form
    {
        public 历史数据曲线()
        {
            InitializeComponent();
        }

        private void 历史数据曲线_Load(object sender, EventArgs e)
        {

        }

        private void btn打开历史数据_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open File";
            ofd.Filter = "txt文件|*.txt|所有文件|*.*";
            double[] temp = new double[1000000];
            int Len = 0;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt文件路径.Text = ofd.FileName;
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string strLine;

                while (sr.EndOfStream == false)
                {
                    strLine = sr.ReadLine();
                    txt数据信息.Text = txt数据信息.Text + strLine + "\r\n";
                    temp[Len] = Convert.ToDouble(strLine);
                    Len++;
                    if (Len >1000000) Len = 0;
                }
                sr.Dispose();
                fs.Dispose();
            }
            for (int pointIndex = 0; pointIndex < Len; pointIndex++)
            {
                chart1.Series[0].Points.AddY(temp[pointIndex]);
                chart1.Series[1].Points.AddY(temp[pointIndex]);
            } 
        }

        private void lbe文件路径_Click(object sender, EventArgs e)
        {

        }
    }
}
