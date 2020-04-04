using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoRealChart
{
   public partial class  dataconver
    {
        public static string StringToHexString(string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符，以%隔开
            {
                result += " "+Convert.ToString(b[i], 16);
            }
            return result;
        }//字符串转换为16进制字符串
        public string HexStringToString(string hs, Encoding encode)
        {
            //以%分割字符串，并去掉空字符
            string[] chars = hs.Split(new char[]{'%'},StringSplitOptions.RemoveEmptyEntries);
            byte[] b = new byte[chars.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < chars.Length; i++)
            {
                b[i] = Convert.ToByte(chars[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }//16进制字符串转换为字符串
        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
       /// <param name=”hexString”></param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
             hexString = hexString.Replace(" ", "");   //去掉空格 有空格就不对,空格是俩字符
             hexString = hexString.Replace(":", "");
             hexString = hexString.Replace(".", "");
             hexString = hexString.Replace(",", "");
             hexString = hexString.Replace("\r", "");
             hexString = hexString.Replace("\n", ""); 
            hexString = hexString.Replace("=", "");
            hexString = hexString.Replace("PWM", "");
            hexString = hexString.Replace("Temp", "");
           /* string[] sArray = hexString.Split(new char[12] { 'j', 's' });
            string aaa="";
            foreach (string i in sArray)
                aaa += i;
            hexString = aaa;*/
               if ((hexString.Length % 2) != 0)
                  hexString+= "0";
               //hexString = hexString.PadLeft(hexString.Length + 1, '0');
            byte[] returnBytes = new byte[hexString.Length/2];//一个字节=两个字符
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes; 
            //一个byte得两个字符啊 00~FF           
            //那个 Convert.ToInt64 的话 byte[]默认长度是8
            //Convert.ToInt32 默认长度4
            //比如 ToInt32  字符串是"FF" ~ 最后结果就是 0，0，0，255
            /* byte[] bytes = BitConverter.GetBytes(Convert.ToInt64(hexString, 16));
            if (BitConverter.IsLittleEndian)
            {
                bytes = bytes.Reverse().ToArray();
            }
            return bytes;*/
        }
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name=”bytes”></param>
        /// <returns></returns>
        /// 
        public static string byteToHexStr(byte[] bytes)
       {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                     returnStr += bytes[i].ToString("X2");
                 }
             }
            return returnStr;
         }//
        /// <summary>
        /// 从汉字转换到16进制
        /// </summary>
        /// <param name=”s”></param>
        /// <param name=”charset”>编码,如”utf-8″,”gb2312″</param>
        /// <param name=”fenge”>是否每字符用逗号分隔</param>
       /// <returns></returns>
        public static string ToHex(string s, string charset, bool fenge)
        {
            if ((s.Length % 2) != 0)
            {
                 s += " ";//空格
                //throw new ArgumentException(“s is not valid chinese string!”);
             }
             System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            byte[] bytes = chs.GetBytes(s);
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X}", bytes[i]);
                if (fenge && (i != (bytes.Length-1)))
                {
                     str += string.Format("{0}", ",");
                 }
             }
            return str.ToLower();
         }//
        ///<summary>
        /// 从16进制转换成汉字
        /// </summary>
        /// <param name=”hex”></param>
        /// <param name=”charset”>编码,如”utf-8″,”gb2312″</param>
       /// <returns></returns>
        public static string UnHex(string hex, string charset)
        {
           if (hex == null)
                throw new ArgumentNullException("hex");
             hex = hex.Replace(",", "");
             hex = hex.Replace("\n", "");
             hex = hex.Replace("\\", "");
             hex = hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                 hex += "20";//空格
             }
            // 需要将 hex 转换成 byte 数组。 
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。 
                     bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                     System.Globalization.NumberStyles.HexNumber);
                 }
                catch
                {
                    // Rethrow an exception with custom message. 
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                 }
             }
             System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
         }//
        public static byte[] HexStringToBinary(string hexstring)
        {

            string[] tmpary = hexstring.Trim().Split(' ');
            byte[] buff = new byte[tmpary.Length];
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = Convert.ToByte(tmpary[i], 16);//转换
            }
            return buff;
        }//
        public static string Data_Hex_Asc(string Data)
        {


            string Data1 = "";


            string sData = "";


            while (Data.Length > 0)


            //first take two hex value using substring.


            //then convert Hex value into ascii.


            //then convert ascii value into character.
            {

                Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Data.Substring(0, 2), 16)).ToString();


                sData = sData + Data1;


                Data = Data.Substring(2, Data.Length - 2);


            }

            return sData;
        }
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }
    }
}
