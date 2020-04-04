using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using DemoSharp;
using System.Text.RegularExpressions;//可以用字符匹配regex.replace
//using System.Threading;//可以用线程延时
namespace DemoRealChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread getRecevice;//创建线程
        protected Boolean stop = false;
        protected Boolean conState = false;
        private StreamReader sRead;
        string strRecieve;
        bool bAccpet = false;

        SerialPort sp = new SerialPort();//实例化串口通讯类
        //以下定义4个公有变量，用于参数传递
        public static string strProtName = "";
        public static string strBaudRate = "";
        public static string strDataBits = "";
        public static string strStopBits = "";

        public static string picdata="0";
        Int32 spRevnum = 0;//串口接收计数
        Int32 zijieshu = 0;//去除头文件后的有效字节数
        byte[]spbuf=new byte[500];//串口接收缓存
        byte[] spbuf1 = new byte[500];//串口接收缓存
        byte[] usefuldata= new byte[500];//串口接收缓存

        int title = 40;
        int name = 24;
        int page_turn = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
         
            //System.IO.Ports.SerialPort.GetPortNames()
            //System.IO.Ports.SerialPort.GetPortNames();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            this.toolStripLabel1.Text = "端口号：端口未打开 | ";
            this.toolStripLabel2.Text = "波特率：端口未打开 | ";
            this.toolStripLabel3.Text = "数据位：端口未打开 | ";
            this.toolStripLabel4.Text = "停止位：端口未打开 | ";
            this.toolStripLabel5.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //串口设计
        private void btnSetSp_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            sp.Close();
            uart1para dlg = new uart1para();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sp.PortName = strProtName;//串口号
                sp.BaudRate = int.Parse(strBaudRate);//波特率
                sp.DataBits = int.Parse(strDataBits);//数据位
                sp.StopBits = (StopBits)int.Parse(strStopBits);//停止位
                sp.ReadTimeout = 5000;//读取数据的超时时间，引发ReadExisting异常
            }
        }
        //打开/关闭串口
        private void bntSwitchSP_Click(object sender, EventArgs e)
        {
            if (bntSwitchSP.Text == "打开串口")
            {
                if (strProtName != "" && strBaudRate != "" && strDataBits != "" && strStopBits != "")
                {
                    try
                    {
                        if (sp.IsOpen)
                        {
                            sp.Close();
                            sp.Open();//打开串口
                        }
                        else
                        {
                            sp.Open();//打开串口
                        }
                        bntSwitchSP.Text = "关闭串口";
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = true;
                        this.toolStripLabel1.Text = "端口号：" + sp.PortName + " | ";
                        this.toolStripLabel2.Text = "波特率：" + sp.BaudRate + " | ";
                        this.toolStripLabel3.Text = "数据位：" + sp.DataBits + " | ";
                        this.toolStripLabel4.Text = "停止位：" + sp.StopBits + " | ";
                        this.toolStripLabel5.Text = "";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误：" + ex.Message, "C#串口通信");
                    }
                }
                else
                {
                    MessageBox.Show("请先设置串口！", "RS232串口通信");
                }
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                bntSwitchSP.Text = "打开串口";
                if (sp.IsOpen)
                    sp.Close();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                this.toolStripLabel1.Text = "端口号：端口未打开 | ";
                this.toolStripLabel2.Text = "波特率：端口未打开 | ";
                this.toolStripLabel3.Text = "数据位：端口未打开 | ";
                this.toolStripLabel4.Text = "停止位：端口未打开 | ";
                this.toolStripLabel5.Text = "";
            }
        }
         //发送数据
        private void bntSendData_Click(object sender, EventArgs e)
        {

          
/*
           if (sp.IsOpen)
            {
                try
                {
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    sp.Write(txtSend.Text);//发送数据
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请先打开串口！");
            }*/
        }
        //选择文件
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "c\\";
            open.RestoreDirectory = true;
            open.FilterIndex = 1;
            open.Filter = "txt文件(*.txt)|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (open.OpenFile() != null)
                    {
                        txtFileName.Text = open.FileName;
                    }
                }
                catch (Exception err1)
                {
                    MessageBox.Show("文件打开错误!  " + err1.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bntSendFile_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text.Trim();
            if (fileName == "")
            {
                MessageBox.Show("请选择要发送的文件！", "Error");
                return;
            }
            else
            {
                //sRead = new StreamReader(fileName);
                sRead = new StreamReader(fileName,Encoding.Default);//解决中文乱码问题
            }
            txtSend.Text = sRead.ReadLine();
            //timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string str1;
            str1 = sRead.ReadLine();
            if (str1 == null)
            {
                timer1.Stop();
                sRead.Close();
                MessageBox.Show("文件发送成功！", "C#串口通讯");
                this.toolStripLabel5.Text = "";
                return;
            }
            byte[] data = Encoding.Default.GetBytes(str1);
            sp.Write(data, 0, data.Length);
            this.toolStripLabel5.Text = "   文件发送中..."; 
        }

        private void btnReceiveData_Click(object sender, EventArgs e)
        {
            if (btnReceiveData.Text == "接收数据")
            {
                sp.Encoding = Encoding.GetEncoding("GB2312");
                if (sp.IsOpen)
                {
                    //timer2.Enabled = true; //使用主线程进行

                    //使用委托以及多线程进行
                    bAccpet = true;
                    getRecevice = new Thread(new ThreadStart(testDelegate));//创建多线程
                    //getRecevice.IsBackground = true;
                    getRecevice.Start();//运行多线程
                    btnReceiveData.Text = "停止接收";
                }
                else
                {
                    MessageBox.Show("请先打开串口");
                }
            }
            else
            {
                //timer2.Enabled = false;
                bAccpet = false;
                try
                {   //停止主监听线程
                    if (null != getRecevice)
                    {
                        if (getRecevice.IsAlive)
                        {
                            if (!getRecevice.Join(100))
                            {
                                //关闭线程
                                getRecevice.Abort();
                            }
                        }
                        getRecevice = null;
                    }
                }
                catch { }
                btnReceiveData.Text = "接收数据";
            }
        }

         private void testDelegate()
        {
            reaction r = new reaction(fun);
            r();//缺少这一句不工作
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           string str = sp.ReadExisting();
            string str2 = str.Replace("\r", "\r\n");
            txtReceiveData.AppendText(str2);
            txtReceiveData.ScrollToCaret();
         //   byte[] returnBytes = DemoRealChart.dataconver.strToToHexByte(str2);

          //  //  ////  foreach (int i in returnBytes)
         //   //{
        //        txtReceiveDataHex.AppendText(i.ToString());
        //    }
        }
        //下面用到了接收信息的代理功能，此为设计的要点之一
        delegate void DelegateAcceptData();
        void fun()
        {
            while (bAccpet)
            {
                AcceptData();
            }
        }

        delegate void reaction();
        void AcceptData()
        {
            string lightdata,timedata,statusdata;
            int int_lightdata, int_timedata, int_statusdata;
            if (txtReceiveData.InvokeRequired)
            {
                try
                {
                    DelegateAcceptData ddd = new DelegateAcceptData(AcceptData);
                    this.Invoke(ddd, new object[] { });
                }
                catch { }
            }
            else
            {
                try
                {
                   
                    byte[] spRevBytes = new byte[sp.BytesToRead];//读取一个字节
                    sp.Read(spRevBytes, 0, spRevBytes.Length);//读取到的是ASCII值  

                    for (int i = 0; i < spRevBytes.Length; i++)
                    {
                        txtReceiveData.AppendText(spRevBytes[i].ToString() + " ");
                        //spbuf[spRevnum] = spRevBytes[i];
                        //spRevnum++;
                        if (i + 12 < spRevBytes.Length)
                        {
                            if ((spbuf[i] == 0x5a) && (spbuf[i + 1] == 0xa5) && (spbuf[i + 11] == 0x0d) && (spbuf[i + 12] == 0x0a))
                            { 
                               usefuldata[0] = spbuf[i + 2] ;//时间数据
                               usefuldata[1] = spbuf[i + 3];
                               int_lightdata = usefuldata[0] * 256 + usefuldata[1];

                               usefuldata[2] = spbuf[i + 4];//光照数据
                               usefuldata[3] = spbuf[i + 5];
                               int_timedata = usefuldata[2] * 256 + usefuldata[3];


                               usefuldata[4] = spbuf[i + 6];//状态数据
                               int_statusdata = usefuldata[4];

                               usefuldata[5] = spbuf[i + 7];
                               usefuldata[6] = spbuf[i + 8];
                               usefuldata[7] = spbuf[i + 9];
                               usefuldata[8] = spbuf[i + 10];
                               picdata = usefuldata[0].ToString();
                            }
                        }
                    }
                   
                    /*  if (spRevnum > 100)
                    {
                        spRevnum = 0;
                        return;

                    }
                   // if()
                 if (spRevnum > 7)
                    {
                        for (int j = 0; j < spRevnum - 7; j++)
                            if (spRevBytes[j] == 97 && spRevBytes[j + 1] == 97 && spRevBytes[j + 2] == 53 && spRevBytes[j + 3] == 53)
                            {
                                zijieshu= int.Parse(dataconver.Chr(spRevBytes[j + 4]));
                                   // if (spRevnum > 5 + zijieshu)
                                    {
                                        int d;
                                        for(int jj=0;jj<zijieshu;jj++)
                                        spbuf[jj] = spRevBytes[jj + 5];
                                        d = int.Parse(dataconver.Chr(spbuf[0])) * 100
                                            + int.Parse(dataconver.Chr(spbuf[1])) * 10 
                                            + int.Parse(dataconver.Chr(spbuf[2])) * 1;
                                        picdata = Convert.ToString(d, 10).ToString();

                                        // spRevnum -= 7;
                                        txtReceiveDataDec.AppendText(picdata);
                                    }

                            }
                           
                    }*/
                   
                    /*txtReceiveDataHex.AppendText(spRevBytes.Length.ToString());
                    for (int i = 0; i < spRevBytes.Length - 4; i++)
                    {
                        txtReceiveData.AppendText(spRevBytes[i].ToString() + " ");
                       // txtReceiveDataHex.AppendText(dataconver.Chr(spRevBytes[i]));//ASCII转为字符
                        {
                            if (spRevBytes[0] == 0xaa && spRevBytes[1] == 0x55)
                            {
                                int a, b, c, d;
                                a = spRevBytes[2] * 256 + spRevBytes[3];
                                picdata = Convert.ToString(a, 10).ToString();
                                // spRevnum -= 7;
                                txtReceiveDataDec.AppendText(picdata);
                            }

                        }
                    }*/
                    
/*
                    for (int i = 0; i < spRevBytes.Length; i++)
                    {
                        txtReceiveData.AppendText(spRevBytes[i].ToString()  + " ");                       
                        spbuf[spRevnum] = spRevBytes[i];
                        spRevnum++;                  
                        
                    }  
                    txtReceiveDataHex.Text=spRevnum.ToString();
                     if (spRevnum > 10)
                        {
                            for (int j = 0; j < spRevnum-5; j++)
                            {
                                if (spRevBytes[j] == 97 && spRevBytes[j + 1] == 97 && spRevBytes[j + 2] == 53 && spRevBytes[j + 3] == 53)
                                {
                                    for (int i = 0; i < spRevBytes[j + 4]; i++)
                                     {
                                         spbuf1[i] = (byte)(int.Parse(dataconver.Chr(spRevBytes[j + 5 + i])));

                                     }
                                }

                            }
                        }

                     int a, b, c, d;
                    

                     d = spbuf1[0] * 1000 + spbuf1[1] * 100 + spbuf1[2] * 10 + spbuf1[3];
                     picdata = d.ToString();
                     txtReceiveDataDec.AppendText(picdata);*/
                   /* for (int i = 0; i < spRevnum; i++)
                    {
                        spbuf1[spRevnum+i] = spbuf[i];
                    }
                        for (int i = 0; i < spRevBytes.Length; i++)
                        {
                            //txtReceiveData.AppendText(spRevBytes[i].ToString() + " ");

                            txtReceiveDataHex.AppendText(dataconver.Chr(spRevBytes[i]));//ASCII转为字符

                            {
                                if (spRevBytes[0] == 97 && spRevBytes[1] == 97 && spRevBytes[2] == 53 && spRevBytes[3] == 53)
                                {
                                    int a, b, c, d;
                                    a = int.Parse(dataconver.Chr(spRevBytes[4]));
                                    b = int.Parse(dataconver.Chr(spRevBytes[5]));
                                    c = int.Parse(dataconver.Chr(spRevBytes[6]));
                                    d = a * 100 + b * 10 + c;
                                    picdata = d.ToString();
                                    // spRevnum -= 7;
                                    txtReceiveDataDec.AppendText(picdata);
                                }

                            }
                        }
                    
           
                  /*  strRecieve = sp.ReadExisting();
                    txtReceiveData.AppendText(strRecieve);
                    .......................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................
                    byte[] returnBytes1 = dataconver.strToToHexByte(istrRecieve);//字符串转换为16进制数组
                    for (int i = 0; i < returnBytes1.Length; i++)
                    {
                        string inpustring = returnBytes1[i].ToString();//dataconver.byteToHexStr(returnBytes)
                        txtReceiveDataHex.AppendText(inpustring + " ");
                    }

                    txtReceiveDataDec.AppendText(dataconver.StringToHexString(strRecieve, Encoding.UTF8));//16进制字符串，
                   // txtReceiveData255.AppendText(dataconver.StringToHexString(strRecieve, Encoding.UTF8));
                    byte[] returnBytes=dataconver.HexStringToBinary(dataconver.StringToHexString(strRecieve, Encoding.UTF8));//每一个字符串都转换为字节数
                    for (int i = 0; i < returnBytes.Length; i++)
                    {
                        string inpustring= returnBytes[i].ToString();//dataconver.byteToHexStr(returnBytes)
                        txtReceiveData255.AppendText(inpustring+" ");
                     // // // int i = Convert.ToInt32(dataconver.byteToHexStr(returnBytes), 16); 
                        //txtReceiveDataHex.AppendText(dataconver.Data_Hex_Asc(strRecieve));
                    }*/

                 


                    //txtReceiveDataHex.AppendText(" ");
                   // strRecieve = sp.ReadExisting();
                  //  txtReceiveDataHex.AppendText(strRecieve);//DemoRealChart.
                   // strRecieve = "Temp4:24.213947,592,0.008862PWM=1000";
                   // /**/
                  //  dataconver.StringToHexString(strRecieve, Encoding.UTF8);
                 //  // txtReceiveDataHex.AppendText(dataconver.Data_Hex_Asc(strRecieve));
                   // byte[] returnBytes = dataconver.strToToHexByte(strRecieve);//字符串转换为16进制数组
                   // txtReceiveDataHex.AppendText(dataconver.byteToHexStr(returnBytes));
                     
                    //System.Text.UnicodeEncoding converter = new System.Text.UnicodeEncoding();
                    //byte[] inputBytes = converter.GetBytes(inputString);
                 // //   // string inputString = converter.GetString(i);
                  
                  /*  foreach(int i in returnBytes)
                    {
                      // txtReceiveDataHex.AppendText(i.ToString("")); 
                       string inputString = converter.GetString(i);

                    }*/
                         
                    
                   
                   // txtReceiveDataHex.AppendText(inputString); 
                   /* foreach(int i in returnBytes)
                    {
                       txtReceiveDataHex.AppendText(i.ToString("")); 

                    }*/

                }
                catch (Exception ex) { }
            }
           // sp.DiscardInBuffer();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            txtReceiveData.Text = "";
            txtReceiveDataHex.Text = "";
            txtReceiveDataDec.Text = "";
            txtReceiveData255.Text = "";
 
        }

        private void btn导出数据_Click(object sender, EventArgs e)
        {
                 try
                    {
                        string path = Directory.GetCurrentDirectory() + @"\output.txt";
                        string content = this.txtReceiveData.Text;
                        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter write = new StreamWriter(fs);
                        write.Write(content);
                        write.Flush();
                        write.Close();
                        fs.Close();
                        MessageBox.Show("接收信息导出在:" + path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
        }

        private void btn实时曲线_Click(object sender, EventArgs e)
        {
            //RealChart pic = new RealChart();
            RealChart f=new RealChart();
            f.Show();
           // if (pic.ShowDialog() == DialogResult.OK)
            {
               
            }
        }

        private void btn历史曲线_Click(object sender, EventArgs e)
        {
            历史数据曲线 f = new 历史数据曲线();
            f.Show();
           
        }
        void usart1data_pro(uint num)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mynum=0;
            //if(comboBox1.Text==string.Empty)
            {
                 // MessageBox.Show("采样时间设置不能为空");  
            }
            mynum++;
            sp.Encoding = System.Text.Encoding.GetEncoding("GBK");
            sp.Write("CLS(0);\r\n");//发送数据
            Thread.Sleep(20); 
           // sp.Write("BOXF(0,100,480,320,6);\r\n");//发送数据
            Thread.Sleep(20);
            //sp.Write("PIC(0,0,30);\r\n");//发送数据
            Thread.Sleep(20);
            sp.Write("PIC(400,90,28);\r\n");//发送数据
            Thread.Sleep(20);
          
          
            if(mynum==1)
            {
                //timer3.Interval=int.Parse(comboBox1.Text);
                timer3.Enabled = true;
            }
            else if(mynum==2)
            {
                mynum=0;
                timer3.Enabled=false;
            
            }
            
        }
        private void sampleSendData()
        {
      
            byte[] Data1 = new byte[13];
            Data1[0] = 0x1a;//单字节发数据 
            Data1[1] = 0x2b;
            Data1[2] = 0x01;//
            Data1[3] = 0x02;
            Data1[4] = 0x03;//
            Data1[5] = 0x04;
            Data1[6] = 0x05;//
            Data1[7] = 0x06;
            Data1[8] = 0x07;// 
            Data1[9] = 0x08;
            Data1[10] = 0x09;//
            Data1[11] = 0x3c;
            Data1[12] = 0x4d;
            if (sp.IsOpen)//串口打开
            {
                try                                                                 //如果此时用户输入字符串中含有非法字符（字母，汉字，符号等等，try，catch块可以捕捉并提示）
                {
                    for (int i = 0; i < 1; i++)//发送13次
                    {
                        sp.Write(Data1, 0, 13);
                    }
                    //开始检测button4.Enabled = false;//按钮关闭,只有返回正确的数据后，才能打开
                }
                catch
                {
                    //MessageBox.Show("数据错误，请重新点击【开始检测】", "错误");//如果发送数据错误，会出现重复出现对话框
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
            //name-=24;
            //if (name == 24) name+=24;
            //if(name==)
            name = 70;
            sp.Write("DS32(40,0,'21IC第二届DIY电子设计大赛',5);\r\n");//发送数据
            Thread.Sleep(20);
            sp.Write("DS24("+name.ToString()+",35,'参赛选手ID:山东电子小菜鸟',4);\r\n");//发送数据
            Thread.Sleep(20);

            DirectoryInfo directory = new DirectoryInfo(@"f:\test");
            if (directory.Exists)//存在
            {
                try
                {
                    FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\Python\天气预报.txt", FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs, Encoding.Default);//加了这一句可以防止汉字乱码
                    string strLine;
                    string strmy;
                    int a = 80;
                    int b = 20;
                    /* strmy = "CLS(0);\r\n";
                     // DS16(10,2,'当前时间：	2018-08-12	周日	20:14',1);
                     sp.Encoding = System.Text.Encoding.GetEncoding("GBK");
                     sp.Write(strmy);//发送数据
                     Thread.Sleep(20);*/
                    string systime = DateTime.Now.ToString();
                    systime=systime+"  " +DateTime.Now.DayOfWeek.ToString();
                    string spdata = "DS16(100,60,'" + systime + "',2);\r\n";
                    sp.Write(spdata);//发送数据
                    Thread.Sleep(20);
                    //第一行
                    strLine = sr.ReadLine();
                    strLine = strLine + "济南";
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",1)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    //第二行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    //第3行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    //第4行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",1)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    strmy ="BOXF(0,"+a.ToString()+",480,320,0);\r\n";
                    sp.Write(strmy);//发送数据
                    //第四行
                    //strLine = sr.ReadLine();
                    //第五行
                

                    //
                    Thread.Sleep(20);
                    for (int scor_ini = 0; scor_ini < page_turn; scor_ini++)
                        {
                            strLine = sr.ReadLine();
                        }                   
                        for (int scor_ini = 0; scor_ini < 7; scor_ini++)
                        {
                            strLine = sr.ReadLine();
                            sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                            strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                            a += b;
                            sp.Write(strmy);//发送数据
                            Thread.Sleep(20);
                        }
                        
                        page_turn++;
                        if (page_turn == 8) page_turn = 0;
                    /*
                    //第6行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    //第7行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    //第8行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    //第9行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    //第10行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    //第11行
                    strLine = sr.ReadLine();
                    sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                    strmy = "DS16(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                    a += b;
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    strLine = sr.ReadLine();*/
                    strmy = "DS12(10,"+ "300" + "," + "'" + "-------------------------------------------------------------------------------" + "'" + ",3)\r\n";
                    sp.Write(strmy);//发送数据
                    Thread.Sleep(20);
                    /* while (sr.EndOfStream == false)
                     {
                         strLine = sr.ReadLine();
                         sp.Encoding = System.Text.Encoding.GetEncoding("GBK");//GB2312
                         strmy = "DS12(10," + a.ToString() + "," + "'" + strLine + "'" + ",3)\r\n";
                         // DS16(10,2,'当前时间：	2018-08-12	周日	20:14',1);
                         a += b;
                         sp.Write(strmy);//发送数据
                         Thread.Sleep(20);
                         // application.doevent();
                         // strLine = strLine.Replace("\t", "");//先清除空格。
                         //if(strLine==string.Empty)
                         //strLine = strLine.Replace("\r", "");//再清除空行，原理：空行是连续的
                         txtSend.Text = txtSend.Text + strLine + "\r\n";
                     }*/
                    // txtSend.Text = txtSend.Text.Replace(" ", "");
                    // txtSend.Text = txtSend.Text.Replace("\t", "");
                    //txtSend.Text = txtSend.Text.Replace("\r", "");
                    // txtSend.Text = Regex.Replace(txtSend.Text," ", "");
                    //  txtSend.Text = Regex.Replace(txtSend.Text, " ", " ");
                    sr.Dispose();
                    fs.Dispose();
                    //sampleSendData();
                }
                catch
                {

                }
            }
        }
     
        }
    }

