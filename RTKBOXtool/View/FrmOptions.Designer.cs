namespace RTKBOXtool.View
{
    partial class FrmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbxStationtype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxOutputtype = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox0 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxRTKrate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCoorFormat = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxRTKmode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxGNSStype = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxRTKoutputrate = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxEnableflag = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxChannels = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxNetID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxRadioBaudrate = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(312, 151);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "传输协议：";
            // 
            // cbxStationtype
            // 
            this.cbxStationtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStationtype.FormattingEnabled = true;
            this.cbxStationtype.Location = new System.Drawing.Point(154, 36);
            this.cbxStationtype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxStationtype.Name = "cbxStationtype";
            this.cbxStationtype.Size = new System.Drawing.Size(93, 24);
            this.cbxStationtype.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "机器模式：";
            // 
            // cbxOutputtype
            // 
            this.cbxOutputtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOutputtype.FormattingEnabled = true;
            this.cbxOutputtype.Location = new System.Drawing.Point(406, 148);
            this.cbxOutputtype.Name = "cbxOutputtype";
            this.cbxOutputtype.Size = new System.Drawing.Size(122, 24);
            this.cbxOutputtype.TabIndex = 3;
            this.cbxOutputtype.TextChanged += new System.EventHandler(this.cbxOutputtype_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox0);
            this.groupBox1.Location = new System.Drawing.Point(285, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NMEA";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(6, 74);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(51, 20);
            this.checkBox6.TabIndex = 9;
            this.checkBox6.Text = "RTK";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(164, 48);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(51, 20);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Text = "RTK";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 48);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(51, 20);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "RTK";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(86, 48);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(51, 20);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Text = "VTG";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(164, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(51, 20);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "VTG";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(87, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 20);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "RMC";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox0
            // 
            this.checkBox0.AutoSize = true;
            this.checkBox0.Location = new System.Drawing.Point(6, 19);
            this.checkBox0.Name = "checkBox0";
            this.checkBox0.Size = new System.Drawing.Size(51, 20);
            this.checkBox0.TabIndex = 0;
            this.checkBox0.Text = "RTK";
            this.checkBox0.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "定位频度：";
            // 
            // cbxRTKrate
            // 
            this.cbxRTKrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRTKrate.FormattingEnabled = true;
            this.cbxRTKrate.Location = new System.Drawing.Point(406, 36);
            this.cbxRTKrate.Name = "cbxRTKrate";
            this.cbxRTKrate.Size = new System.Drawing.Size(122, 24);
            this.cbxRTKrate.TabIndex = 6;
            this.cbxRTKrate.SelectionChangeCommitted += new System.EventHandler(this.cbxRTKrate_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "坐标格式：";
            // 
            // cbxCoorFormat
            // 
            this.cbxCoorFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCoorFormat.FormattingEnabled = true;
            this.cbxCoorFormat.Location = new System.Drawing.Point(154, 73);
            this.cbxCoorFormat.Name = "cbxCoorFormat";
            this.cbxCoorFormat.Size = new System.Drawing.Size(93, 24);
            this.cbxCoorFormat.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "GNSS模式：";
            // 
            // cbxRTKmode
            // 
            this.cbxRTKmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRTKmode.FormattingEnabled = true;
            this.cbxRTKmode.Location = new System.Drawing.Point(154, 111);
            this.cbxRTKmode.Name = "cbxRTKmode";
            this.cbxRTKmode.Size = new System.Drawing.Size(93, 24);
            this.cbxRTKmode.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "RTK模式：";
            // 
            // cbxGNSStype
            // 
            this.cbxGNSStype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGNSStype.FormattingEnabled = true;
            this.cbxGNSStype.Location = new System.Drawing.Point(406, 73);
            this.cbxGNSStype.Name = "cbxGNSStype";
            this.cbxGNSStype.Size = new System.Drawing.Size(122, 24);
            this.cbxGNSStype.TabIndex = 12;
            this.cbxGNSStype.SelectionChangeCommitted += new System.EventHandler(this.cbxGNSStype_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "RTK输出波特率：";
            // 
            // cbxRTKoutputrate
            // 
            this.cbxRTKoutputrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRTKoutputrate.FormattingEnabled = true;
            this.cbxRTKoutputrate.Location = new System.Drawing.Point(406, 111);
            this.cbxRTKoutputrate.Name = "cbxRTKoutputrate";
            this.cbxRTKoutputrate.Size = new System.Drawing.Size(122, 24);
            this.cbxRTKoutputrate.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "内置数传：";
            // 
            // cbxEnableflag
            // 
            this.cbxEnableflag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEnableflag.FormattingEnabled = true;
            this.cbxEnableflag.Location = new System.Drawing.Point(154, 190);
            this.cbxEnableflag.Name = "cbxEnableflag";
            this.cbxEnableflag.Size = new System.Drawing.Size(93, 24);
            this.cbxEnableflag.TabIndex = 18;
            this.cbxEnableflag.TextChanged += new System.EventHandler(this.cbxEnableflag_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxChannels);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbxNetID);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(63, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 78);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // cbxChannels
            // 
            this.cbxChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChannels.FormattingEnabled = true;
            this.cbxChannels.Location = new System.Drawing.Point(88, 47);
            this.cbxChannels.Name = "cbxChannels";
            this.cbxChannels.Size = new System.Drawing.Size(96, 24);
            this.cbxChannels.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "频道";
            // 
            // cbxNetID
            // 
            this.cbxNetID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNetID.FormattingEnabled = true;
            this.cbxNetID.Location = new System.Drawing.Point(88, 15);
            this.cbxNetID.Name = "cbxNetID";
            this.cbxNetID.Size = new System.Drawing.Size(96, 24);
            this.cbxNetID.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "NetID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "外置数传波特率：";
            // 
            // cbxRadioBaudrate
            // 
            this.cbxRadioBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRadioBaudrate.FormattingEnabled = true;
            this.cbxRadioBaudrate.Location = new System.Drawing.Point(154, 148);
            this.cbxRadioBaudrate.Name = "cbxRadioBaudrate";
            this.cbxRadioBaudrate.Size = new System.Drawing.Size(93, 24);
            this.cbxRadioBaudrate.TabIndex = 21;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 321);
            this.Controls.Add(this.cbxRadioBaudrate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbxEnableflag);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxRTKoutputrate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxGNSStype);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxRTKmode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxCoorFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxRTKrate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxOutputtype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxStationtype);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxStationtype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxOutputtype;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxRTKrate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCoorFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxRTKmode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ComboBox cbxGNSStype;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxRTKoutputrate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxEnableflag;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxChannels;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxNetID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxRadioBaudrate;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
    }
}