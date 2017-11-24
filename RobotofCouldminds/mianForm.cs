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

        List<byte> sendData= new List<byte>();  //发送的Buf

        byte[] off = { 0x0 };
        byte[] on = { 0x1 };
        byte[] onf = { 0x2 };


        byte Seq = 0x1;
        byte Cmd = 0x80;
        byte State = 0x00;

        byte RobotNum = 0x0;
        byte sData = 0x0;
        byte []ForntAngle = { 0x0 };
        short speed = 0;
        int Led = 0x0;



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
            textBoxLog.AppendText(DateTime.Now.ToString()+"\t\n");//"HH:mm:ss"
            textBoxLog.AppendText(txt + "\t\n\t\n");
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

        private bool sendBuf(byte Seq,byte Cmd, byte State, byte[] Data)
        {

            List<byte> dataList = new List<byte>();
            dataList.Add(RobotNum);
            dataList.AddRange(getUnixTime());
            dataList.AddRange(Data);


            byte X=0x0;
            int Len =dataList.Count;
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

            Log("发送：" + string.Join(" ", sendData.ToArray()));
            return true;
            serialPortC.WriteBuf(serialPort,sendData.ToArray());

            //读取反馈
            Thread.Sleep(25);
            byte[] rcvBuf =  serialPortC.ReadBuf(serialPort);
            if (rcvBuf != null && rcvBuf.Length > 5 && rcvBuf[2] == Cmd)
            {
                switch (rcvBuf[3])
                {
                    case 0x00:
                        Log("执行成功，命令代码：" + Cmd);
                        return true;
                    case 0x80:
                        Log("数据包处理错误,命令代码："+Cmd);
                        break;
                    case 0x81:
                        Log("不支持此命令,命令代码：" + Cmd);
                        break;
                    case 0x82:
                        Log("数据域校验错误,命令代码：" + Cmd);
                        break;
                    case 0x83:
                        Log("命令操作失败,命令代码：" + Cmd);
                        break;
                    default:
                        break;
                }
            }
            return false;          
        }

        

        private byte[] getUnixTime()
        {
            uint timeStamp = (uint)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数
            return System.BitConverter.GetBytes(timeStamp);
        }

     


        private void comboBoxRobotNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            RobotNum = (byte)(comboBoxTrackNum.SelectedIndex * 16 + comboBoxRobotNum.SelectedIndex);
        }

        private void comboBoxTrackNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            RobotNum =(byte)(comboBoxTrackNum.SelectedIndex * 16 + comboBoxRobotNum.SelectedIndex);
        }
        private void UpDownTurn_ValueChanged(object sender, EventArgs e)
        {
            if(UpDownTurn.Value>=0)
                ForntAngle[0] = (byte)(UpDownTurn.Value);
            else
                ForntAngle[0] = (byte)(UpDownTurn.Value+256);
            if (sendBuf(Seq, 0x83, State, ForntAngle))
            {
                Log("方向设定成功");
            }
            else
            {
                Log("方向设定失败");
            }
        }

        private void UpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
           // speed = (short)UpDownSpeed.Value;
            if (sendBuf(Seq, 0x84, State, BitConverter.GetBytes((short)UpDownSpeed.Value)))
            {
                Log("速度设定成功");
            }
            else
            {
                Log("速度设定失败");
            }
        }


        private void myButtonCheckHeadlingt_Click(object sender, EventArgs e)
        {
            if (myButtonCheckHeadlingt.Checked)
            {
                myButtonCheckHeadlingt.Checked = sendBuf(Seq, 0x85, State, on);
            }
            else
            {
                myButtonCheckHeadlingt.Checked = !sendBuf(Seq, 0x85, State, off);
            }         

        }

        private void myButtonCheckRearLight_Click(object sender, EventArgs e)
        {
            if (myButtonCheckRearLight.Checked)
            {
                myButtonCheckRearLight.Checked = sendBuf(Seq, 0x86, State, on);
            }
            else
            {
                myButtonCheckRearLight.Checked = !sendBuf(Seq, 0x86, State, off);
            }
        }

        private void myButtonCheckFrontFlashingLight_Click(object sender, EventArgs e)
        {
            if (myButtonCheckFrontFlashingLight.Checked)
            {
                myButtonCheckFrontFlashingLight.Checked = sendBuf(Seq, 0x85, State, onf);
            }
            else if(myButtonCheckHeadlingt.Checked)
            {
                myButtonCheckFrontFlashingLight.Checked = !sendBuf(Seq, 0x85, State, on);
            }
            else
            {
                myButtonCheckFrontFlashingLight.Checked = !sendBuf(Seq, 0x85, State, off);
            }
        }

        private void myButtonCheckBrake_Click(object sender, EventArgs e)
        {
            if (myButtonCheckBrake.Checked)
            {
                myButtonCheckBrake.Checked = sendBuf(Seq, 0x87, State, on);
            }
            else
            {
                myButtonCheckBrake.Checked = !sendBuf(Seq, 0x87, State, off);
            }
        }
       

        private void myButtonCheckTurnLeft_Click(object sender, EventArgs e)
        {
            if (myButtonCheckTurnLeft.Checked)
            {
                myButtonCheckTurnLeft.Checked = sendBuf(Seq, 0x88, State, on);
            }
            else
            {
                myButtonCheckTurnLeft.Checked = !sendBuf(Seq, 0x88, State, off);
            }
        }

        private void myButtonCheckTurnRight_Click(object sender, EventArgs e)
        {
            if (myButtonCheckTurnRight.Checked)
            {
                myButtonCheckTurnRight.Checked = sendBuf(Seq, 0x89, State, on);
            }
            else
            {
                myButtonCheckTurnRight.Checked = !sendBuf(Seq, 0x89, State, off);
            }
        }
        private void myButtonCheckArmLight_Click(object sender, EventArgs e)
        {
            if (myButtonCheckArmLight.Checked)
            {
                myButtonCheckArmLight.Checked = sendBuf(Seq, 0x8A, State, on);
            }
            else
            {
                myButtonCheckArmLight.Checked = !sendBuf(Seq, 0x8A, State, off);
            }
        }
        private void myButtonCheckHorn_Click(object sender, EventArgs e)
        {
            if (myButtonCheckHorn.Checked)
            {
                myButtonCheckHorn.Checked = sendBuf(Seq, 0x8B, State, on);
            }
            else
            {
                myButtonCheckHorn.Checked = !sendBuf(Seq, 0x8B, State, off);
            }
        }

        private void myButtonCheckVoice_Click(object sender, EventArgs e)
        {
            if (myButtonCheckVoice.Checked)
            {
                myButtonCheckVoice.Checked = sendBuf(Seq, 0x8C, State, on);
            }
            else
            {
                myButtonCheckVoice.Checked = !sendBuf(Seq, 0x8C, State, off);
            }
        }

        private void myButtonCheckModel_Click(object sender, EventArgs e)
        {
            if (myButtonCheckModel.Checked)
            {
                myButtonCheckModel.Checked = sendBuf(Seq, 0x8D, State, on);
            }
            else
            {
                myButtonCheckModel.Checked = !sendBuf(Seq, 0x8D, State, off);
            }
        }

        private void myButtonCheckCloudDown_Click(object sender, EventArgs e)
        {
            if (myButtonCheckCloudDown.Checked)
            {
                myButtonCheckCloudDown.Checked = sendBuf(Seq, 0x8E, State, off);
                if (myButtonCheckCloudDown.Checked)
                {
                    myButtonCheckCloudUp.Checked = false;
                }
            }
            else
            {
                myButtonCheckCloudDown.Checked = !sendBuf(Seq, 0x8E, State, onf);             
            }         
        }

        private void myButtonCheckCloudUp_Click(object sender, EventArgs e)
        {
            if (myButtonCheckCloudUp.Checked)
            {
                myButtonCheckCloudUp.Checked = sendBuf(Seq, 0x8E, State, on);
                if (myButtonCheckCloudUp.Checked)
                {
                    myButtonCheckCloudDown.Checked = false;
                }
            }
            else
            {
                myButtonCheckCloudUp.Checked = !sendBuf(Seq, 0x8E, State, onf);
                myButtonCheckCloudDown.Checked = myButtonCheckCloudUp.Checked;
            }
        }
    }
}
