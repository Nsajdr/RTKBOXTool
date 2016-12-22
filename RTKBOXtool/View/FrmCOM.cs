using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace RTKBOXtool.View
{
    public partial class FrmCOM : Form
    {
        public string COMname;
        public int Baudrate;
        public SerialPort sp;
        public FrmCOM()
        {
            InitializeComponent();
        }

        private void FrmCOM_Load(object sender, EventArgs e)
        {
            sp = new SerialPort();
            cbxCOMname.DataSource = SerialPort.GetPortNames();
        }

        private void btnGET_Click(object sender, EventArgs e)
        {
            cbxCOMname.DataSource = SerialPort.GetPortNames();
        }

        private void btnOPEN_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(cbxCOMname.Text))
            {
                MessageBox.Show("串口号为空！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(string.IsNullOrWhiteSpace(cbxBaudrate.Text))
            {
                MessageBox.Show("波特率为空！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(int.TryParse(cbxBaudrate.Text,out Baudrate))
            {
                COMname = cbxCOMname.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请输入正确波特率！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
