using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace RobotofCouldminds
{
   public class serialPortClass
    {
        private string[] ports;
        private int serialPortCount; //总串口数量
        private string OpenName;  //打开的串口名

 
        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public serialPortClass(SerialPort com)
        {
            try
            {
                ports = SerialPort.GetPortNames();
                serialPortCount = ports.Length;
                Array.Sort(ports);
                com.BaudRate = 38400;
                com.DataBits = 8;
                com.Parity = (Parity)2;
                com.StopBits = (StopBits)1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
            }
          
        }

        /// <summary>
        /// 获得串口的数量
        /// </summary>
        /// <returns></returns>
        public int getSerialPortCount()
        {
            return serialPortCount;
        }

        public string getOpenName()
        {
            return OpenName;
        }

        public string[] getPorts()
        {
            return ports;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public  short Open(SerialPort com)
        {
            try
            {
                com.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 发送Buf
        /// </summary>
        /// <param name="com"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public short WriteBuf(SerialPort com, byte[] buf)
        {
            try
            {               
                com.Write(buf, 0, buf.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }

        /// <summary>
        ///  读串口 
        /// </summary>
        /// <param name="com"></param>
        /// <param name="recBuf"></param>
        /// <returns></returns>
        public byte[] ReadBuf(SerialPort com)
        {
            byte[] recBuf= { };
            try
            {
                int n = com.BytesToRead;
                recBuf = new byte[n];
                com.Read(recBuf, 0, n);//读取缓冲数据 
              //  com.DiscardOutBuffer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return recBuf;
        }
    }
}
