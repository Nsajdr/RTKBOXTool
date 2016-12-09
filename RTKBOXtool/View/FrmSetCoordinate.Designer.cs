namespace RTKBOXtool.View
{
    partial class FrmSetCoordinate
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labX = new System.Windows.Forms.TextBox();
            this.labY = new System.Windows.Forms.TextBox();
            this.labZ = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "经度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "纬度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "高程：";
            // 
            // labX
            // 
            this.labX.Location = new System.Drawing.Point(101, 21);
            this.labX.Name = "labX";
            this.labX.Size = new System.Drawing.Size(135, 26);
            this.labX.TabIndex = 3;
            // 
            // labY
            // 
            this.labY.Location = new System.Drawing.Point(100, 61);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(136, 26);
            this.labY.TabIndex = 4;
            // 
            // labZ
            // 
            this.labZ.Location = new System.Drawing.Point(100, 101);
            this.labZ.Name = "labZ";
            this.labZ.Size = new System.Drawing.Size(136, 26);
            this.labZ.TabIndex = 5;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(12, 145);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(82, 29);
            this.btnGet.TabIndex = 6;
            this.btnGet.Text = "当前坐标";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(180, 145);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 29);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "发送坐标";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FrmSetCoordinate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 186);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.labZ);
            this.Controls.Add(this.labY);
            this.Controls.Add(this.labX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetCoordinate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置基准站坐标";
            this.Load += new System.EventHandler(this.FrmSetCoordinate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox labX;
        private System.Windows.Forms.TextBox labY;
        private System.Windows.Forms.TextBox labZ;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSend;
    }
}