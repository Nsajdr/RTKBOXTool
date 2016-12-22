namespace RTKBOXtool.View
{
    partial class FrmSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSet));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRTKrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxGNSStype = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxRTKmode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxRTKoutputrate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxOutputtype = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox0 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "定位频度：";
            // 
            // cbxRTKrate
            // 
            this.cbxRTKrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRTKrate.FormattingEnabled = true;
            this.cbxRTKrate.Location = new System.Drawing.Point(104, 28);
            this.cbxRTKrate.Name = "cbxRTKrate";
            this.cbxRTKrate.Size = new System.Drawing.Size(121, 24);
            this.cbxRTKrate.TabIndex = 2;
            this.cbxRTKrate.SelectionChangeCommitted += new System.EventHandler(this.cbxRTKrate_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "GNSS模式：";
            // 
            // cbxGNSStype
            // 
            this.cbxGNSStype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGNSStype.FormattingEnabled = true;
            this.cbxGNSStype.Location = new System.Drawing.Point(372, 28);
            this.cbxGNSStype.Name = "cbxGNSStype";
            this.cbxGNSStype.Size = new System.Drawing.Size(121, 24);
            this.cbxGNSStype.TabIndex = 4;
            this.cbxGNSStype.SelectionChangeCommitted += new System.EventHandler(this.cbxGNSStype_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "RTK模式：";
            // 
            // cbxRTKmode
            // 
            this.cbxRTKmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRTKmode.FormattingEnabled = true;
            this.cbxRTKmode.Location = new System.Drawing.Point(103, 79);
            this.cbxRTKmode.Name = "cbxRTKmode";
            this.cbxRTKmode.Size = new System.Drawing.Size(122, 24);
            this.cbxRTKmode.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "RTK输出波特率：";
            // 
            // cbxRTKoutputrate
            // 
            this.cbxRTKoutputrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRTKoutputrate.FormattingEnabled = true;
            this.cbxRTKoutputrate.Location = new System.Drawing.Point(372, 79);
            this.cbxRTKoutputrate.Name = "cbxRTKoutputrate";
            this.cbxRTKoutputrate.Size = new System.Drawing.Size(121, 24);
            this.cbxRTKoutputrate.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(19, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "传输协议：";
            // 
            // cbxOutputtype
            // 
            this.cbxOutputtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOutputtype.FormattingEnabled = true;
            this.cbxOutputtype.Location = new System.Drawing.Point(103, 123);
            this.cbxOutputtype.Name = "cbxOutputtype";
            this.cbxOutputtype.Size = new System.Drawing.Size(121, 24);
            this.cbxOutputtype.TabIndex = 11;
            this.cbxOutputtype.SelectionChangeCommitted += new System.EventHandler(this.cbxOutputtype_SelectionChangeCommitted);
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
            this.groupBox1.Location = new System.Drawing.Point(22, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 100);
            this.groupBox1.TabIndex = 12;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 267);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxOutputtype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxRTKoutputrate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxRTKmode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxGNSStype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxRTKrate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSet";
            this.Load += new System.EventHandler(this.FrmSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxRTKrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxGNSStype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxRTKmode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxRTKoutputrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxOutputtype;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox0;
        private System.Windows.Forms.Button button1;
    }
}