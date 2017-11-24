namespace RobotofCouldminds
{
    partial class mianForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mianForm));
            this.pictureBoxPort = new System.Windows.Forms.PictureBox();
            this.SerialPortComboBox = new System.Windows.Forms.ComboBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTrackNum = new System.Windows.Forms.ComboBox();
            this.comboBoxRobotNum = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UpDownTurn = new System.Windows.Forms.NumericUpDown();
            this.UpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.myButtonCheckCloudUp = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckBrake = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckCloudDown = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckModel = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckVoice = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckHorn = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckTurnRight = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckTurnLeft = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckArmLight = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckFrontFlashingLight = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckRearLight = new RobotofCouldminds.myButtonCheck();
            this.myButtonCheckHeadlingt = new RobotofCouldminds.myButtonCheck();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPort
            // 
            this.pictureBoxPort.BackColor = System.Drawing.Color.Red;
            this.pictureBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPort.Location = new System.Drawing.Point(8, 13);
            this.pictureBoxPort.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPort.Name = "pictureBoxPort";
            this.pictureBoxPort.Size = new System.Drawing.Size(40, 38);
            this.pictureBoxPort.TabIndex = 49;
            this.pictureBoxPort.TabStop = false;
            // 
            // SerialPortComboBox
            // 
            this.SerialPortComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SerialPortComboBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SerialPortComboBox.FormattingEnabled = true;
            this.SerialPortComboBox.Location = new System.Drawing.Point(56, 13);
            this.SerialPortComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.SerialPortComboBox.Name = "SerialPortComboBox";
            this.SerialPortComboBox.Size = new System.Drawing.Size(99, 38);
            this.SerialPortComboBox.TabIndex = 50;
            this.SerialPortComboBox.Text = "COM0";
            this.SerialPortComboBox.SelectedIndexChanged += new System.EventHandler(this.SerialPortComboBox_SelectedIndexChanged);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(13, 265);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(455, 109);
            this.textBoxLog.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 52;
            this.label1.Text = "轨迹编号";
            // 
            // comboBoxTrackNum
            // 
            this.comboBoxTrackNum.FormattingEnabled = true;
            this.comboBoxTrackNum.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBoxTrackNum.Location = new System.Drawing.Point(95, 117);
            this.comboBoxTrackNum.Name = "comboBoxTrackNum";
            this.comboBoxTrackNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxTrackNum.Size = new System.Drawing.Size(61, 26);
            this.comboBoxTrackNum.TabIndex = 53;
            this.comboBoxTrackNum.Text = "0";
            this.comboBoxTrackNum.SelectedIndexChanged += new System.EventHandler(this.comboBoxTrackNum_SelectedIndexChanged);
            // 
            // comboBoxRobotNum
            // 
            this.comboBoxRobotNum.FormattingEnabled = true;
            this.comboBoxRobotNum.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBoxRobotNum.Location = new System.Drawing.Point(95, 69);
            this.comboBoxRobotNum.Name = "comboBoxRobotNum";
            this.comboBoxRobotNum.Size = new System.Drawing.Size(61, 26);
            this.comboBoxRobotNum.TabIndex = 55;
            this.comboBoxRobotNum.Text = "0";
            this.comboBoxRobotNum.SelectedIndexChanged += new System.EventHandler(this.comboBoxRobotNum_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 54;
            this.label2.Text = "机器人号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 57;
            this.label3.Text = "转向角";
            // 
            // UpDownTurn
            // 
            this.UpDownTurn.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.UpDownTurn.Location = new System.Drawing.Point(87, 166);
            this.UpDownTurn.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.UpDownTurn.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.UpDownTurn.Name = "UpDownTurn";
            this.UpDownTurn.Size = new System.Drawing.Size(68, 28);
            this.UpDownTurn.TabIndex = 58;
            this.UpDownTurn.ValueChanged += new System.EventHandler(this.UpDownTurn_ValueChanged);
            // 
            // UpDownSpeed
            // 
            this.UpDownSpeed.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.UpDownSpeed.Location = new System.Drawing.Point(87, 211);
            this.UpDownSpeed.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.UpDownSpeed.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
            this.UpDownSpeed.Name = "UpDownSpeed";
            this.UpDownSpeed.Size = new System.Drawing.Size(68, 28);
            this.UpDownSpeed.TabIndex = 80;
            this.UpDownSpeed.ValueChanged += new System.EventHandler(this.UpDownSpeed_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 79;
            this.label4.Text = "速度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 92;
            this.label5.Text = "前灯";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 94;
            this.label6.Text = "后灯";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 98;
            this.label7.Text = "报警";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 18);
            this.label8.TabIndex = 96;
            this.label8.Text = "前闪";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(354, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 18);
            this.label9.TabIndex = 102;
            this.label9.Text = "右转";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(207, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 18);
            this.label10.TabIndex = 100;
            this.label10.Text = "左转";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(207, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 18);
            this.label11.TabIndex = 106;
            this.label11.Text = "语音";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(354, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 18);
            this.label12.TabIndex = 104;
            this.label12.Text = "喇叭";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(190, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 18);
            this.label13.TabIndex = 110;
            this.label13.Text = "云台降";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(354, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 18);
            this.label14.TabIndex = 108;
            this.label14.Text = "模式";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(354, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 18);
            this.label15.TabIndex = 98;
            this.label15.Text = "刹车";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(337, 226);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 18);
            this.label16.TabIndex = 113;
            this.label16.Text = "云台升";
            // 
            // myButtonCheckCloudUp
            // 
            this.myButtonCheckCloudUp.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckCloudUp.Checked = false;
            this.myButtonCheckCloudUp.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckCloudUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckCloudUp.Location = new System.Drawing.Point(398, 221);
            this.myButtonCheckCloudUp.Name = "myButtonCheckCloudUp";
            this.myButtonCheckCloudUp.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckCloudUp.TabIndex = 112;
            this.myButtonCheckCloudUp.Click += new System.EventHandler(this.myButtonCheckCloudUp_Click);
            // 
            // myButtonCheckBrake
            // 
            this.myButtonCheckBrake.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckBrake.Checked = false;
            this.myButtonCheckBrake.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckBrake.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckBrake.Location = new System.Drawing.Point(398, 50);
            this.myButtonCheckBrake.Name = "myButtonCheckBrake";
            this.myButtonCheckBrake.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckBrake.TabIndex = 111;
            this.myButtonCheckBrake.Click += new System.EventHandler(this.myButtonCheckBrake_Click);
            // 
            // myButtonCheckCloudDown
            // 
            this.myButtonCheckCloudDown.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckCloudDown.Checked = false;
            this.myButtonCheckCloudDown.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckCloudDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckCloudDown.Location = new System.Drawing.Point(251, 216);
            this.myButtonCheckCloudDown.Name = "myButtonCheckCloudDown";
            this.myButtonCheckCloudDown.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckCloudDown.TabIndex = 109;
            this.myButtonCheckCloudDown.Click += new System.EventHandler(this.myButtonCheckCloudDown_Click);
            // 
            // myButtonCheckModel
            // 
            this.myButtonCheckModel.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckModel.Checked = false;
            this.myButtonCheckModel.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckModel.Location = new System.Drawing.Point(398, 175);
            this.myButtonCheckModel.Name = "myButtonCheckModel";
            this.myButtonCheckModel.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckModel.TabIndex = 107;
            this.myButtonCheckModel.Click += new System.EventHandler(this.myButtonCheckModel_Click);
            // 
            // myButtonCheckVoice
            // 
            this.myButtonCheckVoice.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckVoice.Checked = false;
            this.myButtonCheckVoice.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckVoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckVoice.Location = new System.Drawing.Point(251, 171);
            this.myButtonCheckVoice.Name = "myButtonCheckVoice";
            this.myButtonCheckVoice.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckVoice.TabIndex = 105;
            this.myButtonCheckVoice.Click += new System.EventHandler(this.myButtonCheckVoice_Click);
            // 
            // myButtonCheckHorn
            // 
            this.myButtonCheckHorn.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckHorn.Checked = false;
            this.myButtonCheckHorn.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckHorn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckHorn.Location = new System.Drawing.Point(398, 132);
            this.myButtonCheckHorn.Name = "myButtonCheckHorn";
            this.myButtonCheckHorn.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckHorn.TabIndex = 103;
            this.myButtonCheckHorn.Click += new System.EventHandler(this.myButtonCheckHorn_Click);
            // 
            // myButtonCheckTurnRight
            // 
            this.myButtonCheckTurnRight.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckTurnRight.Checked = false;
            this.myButtonCheckTurnRight.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckTurnRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckTurnRight.Location = new System.Drawing.Point(398, 89);
            this.myButtonCheckTurnRight.Name = "myButtonCheckTurnRight";
            this.myButtonCheckTurnRight.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckTurnRight.TabIndex = 101;
            this.myButtonCheckTurnRight.Click += new System.EventHandler(this.myButtonCheckTurnRight_Click);
            // 
            // myButtonCheckTurnLeft
            // 
            this.myButtonCheckTurnLeft.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckTurnLeft.Checked = false;
            this.myButtonCheckTurnLeft.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckTurnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckTurnLeft.Location = new System.Drawing.Point(251, 90);
            this.myButtonCheckTurnLeft.Name = "myButtonCheckTurnLeft";
            this.myButtonCheckTurnLeft.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckTurnLeft.TabIndex = 99;
            this.myButtonCheckTurnLeft.Click += new System.EventHandler(this.myButtonCheckTurnLeft_Click);
            // 
            // myButtonCheckArmLight
            // 
            this.myButtonCheckArmLight.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckArmLight.Checked = false;
            this.myButtonCheckArmLight.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckArmLight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckArmLight.Location = new System.Drawing.Point(251, 132);
            this.myButtonCheckArmLight.Name = "myButtonCheckArmLight";
            this.myButtonCheckArmLight.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckArmLight.TabIndex = 97;
            this.myButtonCheckArmLight.Click += new System.EventHandler(this.myButtonCheckArmLight_Click);
            // 
            // myButtonCheckFrontFlashingLight
            // 
            this.myButtonCheckFrontFlashingLight.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckFrontFlashingLight.Checked = false;
            this.myButtonCheckFrontFlashingLight.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckFrontFlashingLight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckFrontFlashingLight.Location = new System.Drawing.Point(251, 50);
            this.myButtonCheckFrontFlashingLight.Name = "myButtonCheckFrontFlashingLight";
            this.myButtonCheckFrontFlashingLight.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckFrontFlashingLight.TabIndex = 95;
            this.myButtonCheckFrontFlashingLight.Click += new System.EventHandler(this.myButtonCheckFrontFlashingLight_Click);
            // 
            // myButtonCheckRearLight
            // 
            this.myButtonCheckRearLight.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckRearLight.Checked = false;
            this.myButtonCheckRearLight.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckRearLight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckRearLight.Location = new System.Drawing.Point(398, 7);
            this.myButtonCheckRearLight.Name = "myButtonCheckRearLight";
            this.myButtonCheckRearLight.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckRearLight.TabIndex = 93;
            this.myButtonCheckRearLight.Click += new System.EventHandler(this.myButtonCheckRearLight_Click);
            // 
            // myButtonCheckHeadlingt
            // 
            this.myButtonCheckHeadlingt.BackColor = System.Drawing.Color.Transparent;
            this.myButtonCheckHeadlingt.Checked = false;
            this.myButtonCheckHeadlingt.CheckStyleX = RobotofCouldminds.myButtonCheck.CheckStyle.style1;
            this.myButtonCheckHeadlingt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButtonCheckHeadlingt.Location = new System.Drawing.Point(251, 8);
            this.myButtonCheckHeadlingt.Name = "myButtonCheckHeadlingt";
            this.myButtonCheckHeadlingt.Size = new System.Drawing.Size(70, 27);
            this.myButtonCheckHeadlingt.TabIndex = 91;
            this.myButtonCheckHeadlingt.Click += new System.EventHandler(this.myButtonCheckHeadlingt_Click);
            // 
            // mianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 384);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.myButtonCheckCloudUp);
            this.Controls.Add(this.myButtonCheckBrake);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.myButtonCheckCloudDown);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.myButtonCheckModel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.myButtonCheckVoice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.myButtonCheckHorn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.myButtonCheckTurnRight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.myButtonCheckTurnLeft);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.myButtonCheckArmLight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.myButtonCheckFrontFlashingLight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.myButtonCheckRearLight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.myButtonCheckHeadlingt);
            this.Controls.Add(this.UpDownSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UpDownTurn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxRobotNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTrackNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.SerialPortComboBox);
            this.Controls.Add(this.pictureBoxPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mianForm";
            this.Text = "Robot";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPort;
        private System.Windows.Forms.ComboBox SerialPortComboBox;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTrackNum;
        private System.Windows.Forms.ComboBox comboBoxRobotNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown UpDownTurn;
        private System.Windows.Forms.NumericUpDown UpDownSpeed;
        private System.Windows.Forms.Label label4;
        private myButtonCheck myButtonCheckHeadlingt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private myButtonCheck myButtonCheckRearLight;
        private System.Windows.Forms.Label label7;
        private myButtonCheck myButtonCheckArmLight;
        private System.Windows.Forms.Label label8;
        private myButtonCheck myButtonCheckFrontFlashingLight;
        private System.Windows.Forms.Label label9;
        private myButtonCheck myButtonCheckTurnRight;
        private System.Windows.Forms.Label label10;
        private myButtonCheck myButtonCheckTurnLeft;
        private System.Windows.Forms.Label label11;
        private myButtonCheck myButtonCheckVoice;
        private System.Windows.Forms.Label label12;
        private myButtonCheck myButtonCheckHorn;
        private System.Windows.Forms.Label label13;
        private myButtonCheck myButtonCheckCloudDown;
        private System.Windows.Forms.Label label14;
        private myButtonCheck myButtonCheckModel;
        private System.Windows.Forms.Label label15;
        private myButtonCheck myButtonCheckBrake;
        private System.Windows.Forms.Label label16;
        private myButtonCheck myButtonCheckCloudUp;
    }
}

