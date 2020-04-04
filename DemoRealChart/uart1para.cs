using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Forms.form;
namespace DemoRealChart
{
    public partial class uart1para : Form
    {
        public uart1para()
        {
            InitializeComponent();
        }
        //Form1 form1 = new Form1();
        private void uart1para_Load(object sender, EventArgs e)
        {
            //串口
           // Form1 form1=new Form1();

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();//获取所有的端口号
            foreach (string port in ports)
            {
                cmbPort.Items.Add(port);
            }
            cmbPort.SelectedIndex = 0;

            //波特率
            cmbBaudRate.Items.Add("110");
            cmbBaudRate.Items.Add("300");
            cmbBaudRate.Items.Add("1200");
            cmbBaudRate.Items.Add("2400");
            cmbBaudRate.Items.Add("4800");
            cmbBaudRate.Items.Add("9600");
            cmbBaudRate.Items.Add("19200");
            cmbBaudRate.Items.Add("38400");
            cmbBaudRate.Items.Add("57600");
            cmbBaudRate.Items.Add("115200");
            cmbBaudRate.Items.Add("230400");
            cmbBaudRate.Items.Add("460800");
            cmbBaudRate.Items.Add("921600");
            cmbBaudRate.SelectedIndex = 5;

            //数据位
            cmbDataBits.Items.Add("5");
            cmbDataBits.Items.Add("6");
            cmbDataBits.Items.Add("7");
            cmbDataBits.Items.Add("8");
            cmbDataBits.SelectedIndex = 3;

            //停止位
            cmbStopBit.Items.Add("1");
            cmbStopBit.SelectedIndex = 0;

            //佼验位
            cmbParity.Items.Add("无");
            cmbParity.SelectedIndex = 0;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            //以下4个参数都是从窗体MainForm传入的

          //  form1.serialPort1.PortName=cmbPort.Text;
          //  form1.serialPort1.BaudRate=int.Parse(cmbBaudRate.Text);
          //  form1.serialPort1.DataBits=int.Parse(cmbDataBits.Text);
          //  form1.serialPort1.StopBits = System.IO.Ports.StopBits.One;
            Form1.strProtName = cmbPort.Text;
            Form1.strBaudRate = cmbBaudRate.Text;
            Form1.strDataBits = cmbDataBits.Text;
            Form1.strStopBits = cmbStopBit.Text;
            DialogResult = DialogResult.OK;
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }//串口参数设置
}
