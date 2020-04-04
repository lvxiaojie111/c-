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
    class txtrw
    {
        //使用FileStream类进行文件的读取，并将它转换成char数组，然后输出
        byte[] byData = new byte[100];
        char[] charData = new char[1000];
        public void Read()
        {
            try
            {
                FileStream file = new FileStream("E:\\test.txt", FileMode.Open);
                file.Seek(0, SeekOrigin.Begin);
                file.Read(byData, 0, 100); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
                Decoder d = Encoding.Default.GetDecoder();
                d.GetChars(byData, 0, byData.Length, charData, 0);
                Console.WriteLine(charData);
                file.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        //使用StreamReader读取文件，然后一行一行的输出
        public void Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line.ToString());
            }
        }
        //使用FileStream类创建文件，然后将数据写入到文件里
        public void Write()
        {
            FileStream fs = new FileStream("E:\\ak.txt", FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes("Hello World!");
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
        //使用FileStream类创建文件，使用StreamWriter类，将数据写入到文件
        public void Write(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write("Hello World!!!!");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

      /*  // 如果文件不存在，创建文件； 如果存在，覆盖文件 
        StreamWriter sW1 = new StreamWriter(@"c:\temp\a.txt");

        // 也可以指定编码方式, true 是 Appendtext, false 为覆盖原文件 
        StreamWriter sW2 = new StreamWriter(@"c:\temp\a.txt", true, Encoding.UTF8);

        // FileMode.CreateNew: 如果文件不存在，创建文件；如果文件已经存在，抛出异常 
        FileStream fS = new FileStream(@"C:\temp\a.txt", FileMode.CreateNew, FileAccess.Write, FileShare.Read);
        StreamWriter sW3 = new StreamWriter(fS);
        StreamWriter sW4 = new StreamWriter(fS, Encoding.UTF8);

        // 如果文件不存在，创建文件； 如果存在，覆盖文件 
        FileInfo myFile = new FileInfo(@"C:\temp\a.txt");
        StreamWriter sW5 = myFile.CreateText(); 
        // 写一个字符            
        sw.Write('a');

        // 写一个字符数组 
        char[] charArray = new char[100]; 
        sw.Write(charArray);

        // 写一个字符数组的一部分(10~15)
        sw.Write(charArray, 10, 15); 
        */
        public void txtwrite(string path, string data)
        {
            //创建一个文件流，用以写入或者创建一个StreamWriter "C\\file.txt"
           /* FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.Flush();
            //使用StreamWriter来往文件中写入内容
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
            //把richTextBox1中的内容写入文件 
            m_streamWriter.WriteLine(data);
            //关闭此文件
            m_streamWriter.Flush();
            m_streamWriter.Close();*/
            FileStream fs = null;
            string filePath = path;
            //将待写的入数据从字符串转换为字节数组  
            Encoding encoder = Encoding.UTF8;
            byte[] bytes = encoder.GetBytes(data+"\r\n");
            try
            {
                /*
                 fs = File.OpenWrite(filePath);  
                //设定书写的开始位置为文件的末尾  
                fs.Position = fs.Length;  

                等效于

                fs = File.Open(filePath, FileMode.Append, FileAccess.ReadWrite); 
                 */
                fs = File.OpenWrite(filePath);
                //设定书写的开始位置为文件的末尾  
                fs.Position = fs.Length;
                //将待写入内容追加到文件末尾  
                fs.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件打开失败{0}", ex.ToString());
            }
            finally
            {
                fs.Close();
            }
           /* FileStream tempStream = new FileStream("xx.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(tempStream);
            writer.WriteLine(txtComID.Text);
            writer.WriteLine(txtComBps.Text);
            writer.Close();
            tempStream.Close();*/
        }
             static void AppendToFile()
             {
                 //StreamWriter SW = new StreamWriter(); ;
            // SW=File.AppendText("C:\MyTextFile.txt");
            // SW.WriteLine("This Line Is Appended");
            // SW.Close();
           //  Console.WriteLine("Text Appended Successfully");
             }
    }
}
