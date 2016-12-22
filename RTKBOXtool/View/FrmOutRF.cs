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
using System.Collections;

namespace RTKBOXtool.View
{
    public partial class FrmOutRF : Form
    {
        public SerialPort sp;
        public Model.SetInf Inf;
        public Model.INF_B562_0119 In19;
        public string[] RadioBaudrate = { "9600", "19200", "38400", "57600", "115200" };
        public FrmOutRF()
        {
            InitializeComponent();
        }

        private void FrmOutRF_Load(object sender, EventArgs e)
        {
            cbxRadioBaudrate.DataSource = RadioBaudrate;
            cbxRadioBaudrate.Text = Inf.RadioBaudrate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int radioBaudrate = Array.IndexOf(RadioBaudrate, cbxRadioBaudrate.Text);
            sp.WriteLine(string.Format("$ICERTK,EXTRADIO,{0}*FF\r\n", radioBaudrate));
            Close();
        }
    }
}
