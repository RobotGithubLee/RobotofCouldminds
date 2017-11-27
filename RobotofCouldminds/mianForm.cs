using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace RobotofCouldminds
{
    public partial class mianForm : Form
    {
        private float X;
        private float Y; //Width and Height of MainForm


        System.DateTime startTime;   //Unix时间戳起点

        serialPortClass serialPortC;
        SerialPort serialPort = new SerialPort();  //

        List<byte> sendData = new List<byte>();  //发送的Buf

        bool isSendBufEnable = true;

        byte[] off = { 0x0 };
        byte[] on = { 0x1 };
        byte[] onf = { 0x2 };


        byte Seq = 0x1;
        byte State = 0x00;
        byte RobotNum = 0x0;
        byte[] AngleAndSpeed = new byte[3];





        public mianForm()
        {
            InitializeComponent();
            this.Resize += new EventHandler(mianForm_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
            mianForm_Resize(new object(), new EventArgs());


            //Initize SerialPort
            serialPortC = new serialPortClass(serialPort);

            for (int j = 0; j < serialPortC.getSerialPortCount(); j++)
            {
                SerialPortComboBox.Items.Add(serialPortC.getPorts()[j]);
            }

            startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区      
        }

        /*******************↓↓↓↓↓↓↓↓窗体Resize↓↓↓↓↓↓↓↓***********************/
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }
        void mianForm_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
        }
        /**********************↑↑↑↑↑↑↑窗体Resize↑↑↑↑↑↑↑↑***********************/




        private void Log(string txt)
        {
            textBoxLog.AppendText(DateTime.Now.ToString() + "\t\n");//"HH:mm:ss"
            textBoxLog.AppendText(txt + "\t\n");
        }

        private void SerialPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                serialPort.PortName = SerialPortComboBox.Text;
                serialPortC.Open(serialPort);

                if (serialPort.IsOpen)
                {
                    pictureBoxPort.BackColor = Color.Green;
                    Log(serialPort.PortName + " Open");
                    timer1.Enabled = true;
                }
                else
                {
                    pictureBoxPort.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBoxPort_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Close();
                SerialPortComboBox.Text = "COM0";
                pictureBoxPort.BackColor = Color.Red;
                timer1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool sendBuf(byte Seq, byte Cmd, byte State, byte[] Data)
        {

            List<byte> dataList = new List<byte>();
            dataList.Add(RobotNum);
            dataList.AddRange(getUnixTime());
            dataList.AddRange(Data);


            byte X = 0x0;
            int Len = dataList.Count;
            if (Len > 0)
            {
                X = dataList[0];
                for (int i = 1; i < Len; i++)
                {
                    X ^= dataList[i];
                }
            }

            sendData.Clear();
            sendData.Add(0xAA);        //Head
            sendData.Add(Seq);         //Seq
            sendData.Add(Cmd);         //Cmd            
            sendData.Add(State);       //State
            sendData.Add((byte)Len);         //Len
            sendData.AddRange(dataList);   //Data
            sendData.Add(X);           //异或校验位

            serialPortC.WriteBuf(serialPort, sendData.ToArray());
            //Log("发送：" + string.Join(" ", sendData.ToArray()));

            return true;
        }



        private byte[] getUnixTime()
        {
            uint timeStamp = (uint)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数
            return System.BitConverter.GetBytes(timeStamp);
        }

        private short byteToshort(byte H, byte L)
        {
            byte[] temp = { H, L };
            return BitConverter.ToInt16(temp, 0);
        }


        private void comboBoxRobotNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            RobotNum = (byte)(comboBoxTrackNum.SelectedIndex * 16 + comboBoxRobotNum.SelectedIndex);
        }

        private void comboBoxTrackNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            RobotNum = (byte)(comboBoxTrackNum.SelectedIndex * 16 + comboBoxRobotNum.SelectedIndex);
        }
        private void UpDownTurn_ValueChanged(object sender, EventArgs e)
        {
            if (UpDownTurn.Value >= 0)
                AngleAndSpeed[0] = (byte)(UpDownTurn.Value);
            else
                AngleAndSpeed[0] = (byte)(UpDownTurn.Value + 256);
        }

        private void UpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            byte[] speed = BitConverter.GetBytes((short)UpDownSpeed.Value);
            AngleAndSpeed[1] = speed[0];
            AngleAndSpeed[2] = speed[1];
        }


        private void myButtonCheckHeadlingt_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckHeadlingt.Checked)
            {
                sendBuf(Seq, 0x85, State, on);
            }
            else
            {
                sendBuf(Seq, 0x85, State, off);
            }
            isSendBufEnable = true;
        }

        private void myButtonCheckRearLight_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckRearLight.Checked)
            {
                sendBuf(Seq, 0x86, State, on);
            }
            else
            {
                sendBuf(Seq, 0x86, State, off);
            }
            isSendBufEnable = true;
        }

        private void myButtonCheckFrontFlashingLight_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckFrontFlashingLight.Checked)
            {
                sendBuf(Seq, 0x85, State, onf);
            }
            else if (myButtonCheckHeadlingt.Checked)
            {
                sendBuf(Seq, 0x85, State, on);
            }
            else
            {
                sendBuf(Seq, 0x85, State, off);
            }
            isSendBufEnable = true;
        }

        private void myButtonCheckBrake_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckBrake.Checked)
            {
                sendBuf(Seq, 0x87, State, on);
            }
            else
            {
                sendBuf(Seq, 0x87, State, off);
            }
            isSendBufEnable = true;
        }


        private void myButtonCheckTurnLeft_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckTurnLeft.Checked)
            {
                sendBuf(Seq, 0x88, State, on);
            }
            else
            {
                sendBuf(Seq, 0x88, State, off);
            }
            isSendBufEnable = true;
        }

        private void myButtonCheckTurnRight_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckTurnRight.Checked)
            {
                sendBuf(Seq, 0x89, State, on);
            }
            else
            {
                sendBuf(Seq, 0x89, State, off);
            }
            isSendBufEnable = true;
        }
        private void myButtonCheckArmLight_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckArmLight.Checked)
            {
                sendBuf(Seq, 0x8A, State, on);
            }
            else
            {
                sendBuf(Seq, 0x8A, State, off);
            }
            isSendBufEnable = true;
        }
        private void myButtonCheckHorn_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckHorn.Checked)
            {
                sendBuf(Seq, 0x8B, State, on);
            }
            else
            {
                sendBuf(Seq, 0x8B, State, off);
            }
            isSendBufEnable = true;
        }

        private void myButtonCheckVoice_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckVoice.Checked)
            {
                sendBuf(Seq, 0x8C, State, on);
            }
            else
            {
                sendBuf(Seq, 0x8C, State, off);
            }
            isSendBufEnable = true;
        }

        private void myButtonCheckModel_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckModel.Checked)
            {
                sendBuf(Seq, 0x8D, State, on);
            }
            else
            {
                sendBuf(Seq, 0x8D, State, off);
            }
            isSendBufEnable = true;
        }

        private void myButtonCheckCloudDown_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckCloudDown.Checked)
            {
                sendBuf(Seq, 0x8E, State, off);
                myButtonCheckCloudUp.Checked = false;
            }
            else
            {
                sendBuf(Seq, 0x8E, State, onf);
            }
            isSendBufEnable = true;
        }

        private void myButtonCheckCloudUp_Click(object sender, EventArgs e)
        {
            isSendBufEnable = false;
            if (myButtonCheckCloudUp.Checked)
            {
                sendBuf(Seq, 0x8E, State, on);
                myButtonCheckCloudDown.Checked = false;
            }
            else
            {
                sendBuf(Seq, 0x8E, State, onf);
            }
            isSendBufEnable = true;
        }

        private void buttonClearText_Click(object sender, EventArgs e)
        {
            textBoxLog.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isSendBufEnable)
            {
                sendBuf(Seq, 0x8F, State, AngleAndSpeed);
            }


            //读取反馈
            Thread.Sleep(25);
            byte[] rcvBuf = serialPortC.ReadBuf(serialPort);
            if (rcvBuf != null && rcvBuf.Length > 1)
            {
                //Log("接受：" + string.Join(" ", rcvBuf));
                Log("接受：" + BitConverter.ToString(rcvBuf));
            }
            if (rcvBuf != null)
            {
                if (rcvBuf.Length == 6)
                {
                    switch (rcvBuf[3])
                    {
                        case 0x00:
                            Log("执行成功，命令代码：" + rcvBuf[2]);
                            break;
                        case 0x80:
                            Log("数据包处理错误,命令代码：" + rcvBuf[2]);
                            break;
                        case 0x81:
                            Log("不支持此命令,命令代码：" + rcvBuf[2]);
                            break;
                        case 0x82:
                            Log("数据域校验错误,命令代码：" + rcvBuf[2]);
                            break;
                        case 0x83:
                            Log("命令操作失败,命令代码：" + rcvBuf[2]);
                            break;
                        default:
                            break;
                    }
                }
                else if (rcvBuf.Length == 40)
                {
                    string[] Sensor = (Convert.ToString(rcvBuf[25], 2)).Split();
                }
            }
        }

    }
}
