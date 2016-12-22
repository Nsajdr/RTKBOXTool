namespace RTKBOXtool.View
{
    partial class FrmCOM
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
            this.cbxCOMname = new System.Windows.Forms.ComboBox();
            this.btnGET = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBaudrate = new System.Windows.Forms.ComboBox();
            this.btnOPEN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号：";
            // 
            // cbxCOMname
            // 
            this.cbxCOMname.FormattingEnabled = true;
            this.cbxCOMname.Location = new System.Drawing.Point(89, 27);
            this.cbxCOMname.Name = "cbxCOMname";
            this.cbxCOMname.Size = new System.Drawing.Size(96, 24);
            this.cbxCOMname.TabIndex = 1;
            // 
            // btnGET
            // 
            this.btnGET.Location = new System.Drawing.Point(191, 27);
            this.btnGET.Name = "btnGET";
            this.btnGET.Size = new System.Drawing.Size(88, 23);
            this.btnGET.TabIndex = 2;
            this.btnGET.Text = "获取串口";
            this.btnGET.UseVisualStyleBackColor = true;
            this.btnGET.Click += new System.EventHandler(this.btnGET_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率：";
            // 
            // cbxBaudrate
            // 
            this.cbxBaudrate.FormattingEnabled = true;
            this.cbxBaudrate.Items.AddRange(new object[] {
            "115200",
            "9600",
            "57600"});
            this.cbxBaudrate.Location = new System.Drawing.Point(89, 61);
            this.cbxBaudrate.Name = "cbxBaudrate";
            this.cbxBaudrate.Size = new System.Drawing.Size(96, 24);
            this.cbxBaudrate.TabIndex = 4;
            this.cbxBaudrate.Text = "115200";
            // 
            // btnOPEN
            // 
            this.btnOPEN.Location = new System.Drawing.Point(191, 60);
            this.btnOPEN.Name = "btnOPEN";
            this.btnOPEN.Size = new System.Drawing.Size(88, 24);
            this.btnOPEN.TabIndex = 5;
            this.btnOPEN.Text = "打开";
            this.btnOPEN.UseVisualStyleBackColor = true;
            this.btnOPEN.Click += new System.EventHandler(this.btnOPEN_Click);
            // 
            // FrmCOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 110);
            this.Controls.Add(this.btnOPEN);
            this.Controls.Add(this.cbxBaudrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGET);
            this.Controls.Add(this.cbxCOMname);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCOM";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打开串口";
            this.Load += new System.EventHandler(this.FrmCOM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCOMname;
        private System.Windows.Forms.Button btnGET;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBaudrate;
        private System.Windows.Forms.Button btnOPEN;
    }
}