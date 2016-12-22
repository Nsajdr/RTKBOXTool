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
    public partial class FrmSet : Form
    {
        public SerialPort sp;
        public string[] Outputtype = { "NMEA", "UBX", "SBP", "PIX", "JIYI", "ZEROTECH", "DJI" };
        public string[] RTKrate = { "1HZ", "2HZ", "4HZ", "5HZ", "10HZ(OnlyGPS)" };
        public string[] GNSStype = { "GPS", "GPS+Beidou" };
        public string[] RTKmode = { "静态", "动态", "测向" };
        public string[] RTKoutputrate = { "9600", "19200", "38400", "57600", "115200" };
        public Model.INF_B562_0119 In19;
        public Model.SetInf Inf;
        FrmRTK frm = new FrmRTK();
        public FrmSet(FrmRTK a)
        {
            frm = a;
            InitializeComponent();
        }

        private void FrmSet_Load(object sender, EventArgs e)
        {
            cbxOutputtype.DataSource = Outputtype;
            cbxRTKrate.DataSource = RTKrate;
            cbxGNSStype.DataSource = GNSStype;
            cbxRTKmode.DataSource = RTKmode;
            cbxRTKoutputrate.DataSource = RTKoutputrate;
            
            cbxOutputtype.Text = Inf.Outputtype;
            groupBox1.Text = Inf.Outputtype;
            cbxRTKrate.Text = Inf.Rtkrate;
            cbxGNSStype.Text = Inf.Gnsstype;
            cbxRTKmode.Text = Inf.Rtkmode;
            cbxRTKoutputrate.Text = Inf.Rtkoutputrate;

            Outchoose(groupBox1.Text, In19);
            SetOutputrate();
        }
        public void Outchoose(string m, Model.INF_B562_0119 IN19)
        {
            groupBox1.Text = m;
            string[] NMEA = { "RTK", "RMC", "VTG", "GGA", "GSA", "GSV" };
            string[] UBX = { "RTK", "SOL", "STATUS", "POSLIH", "DOP", "VELNED", "TIMEUTC" };
            string[] SBP = { "RTK", "GPSTIME", "VELENU", "POSLIH", "DOPS" };
            switch (m)
            {
                case "NMEA":
                    Readchoose(NMEA); SetChoose(In19.NmeaOutchoose); groupBox1.Visible = true;
                    break;
                case "UBX":
                    Readchoose(UBX); SetChoose(In19.UbxOutChoose); groupBox1.Visible = true;
                    break;
                case "SBP":
                    Readchoose(SBP); SetChoose(In19.SbpOutchoose); groupBox1.Visible = true;
                    break;
                default:
                    groupBox1.Visible = false;
                    break;
            }
        }
        public void Readchoose(string[] a)
        {
            CheckBox[] b = { checkBox0, checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            foreach (CheckBox i in b)
            {
                i.Visible = true;
                i.Checked = false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                b[i].Text = a[i];
            }
            for (int i = a.Length; i < b.Length; i++)
            {
                b[i].Visible = false;
            }
        }
        public void SetChoose(byte a)
        {
            string b = Convert.ToString(a, 2);
            char[] c = b.Reverse().ToArray();
            CheckBox[] che = { checkBox0, checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            int d = c.Length >= che.Length ? che.Length : c.Length;
            for (int i = 0; i < d; i++)
            {
                if (c[i] == '1')
                {
                    che[i].Checked = true;
                }
            }
        }
        public void SetOutputrate()
        {
            ArrayList a = new ArrayList(RTKoutputrate);
            if (cbxGNSStype.Text == GNSStype[0])
            {
                switch (cbxRTKrate.Text)
                {
                    default:
                        cbxRTKoutputrate.DataSource = RTKoutputrate;
                        break;
                    case "1HZ":
                        cbxRTKoutputrate.DataSource = RTKoutputrate;
                        break;
                    case "2HZ":
                        a.RemoveAt(0);
                        cbxRTKoutputrate.DataSource = a;
                        if (Inf.Rtkoutputrate != RTKoutputrate[0]) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                    case "4HZ":
                        string[] m1 = { "38400", "572600", "115200" };
                        cbxRTKoutputrate.DataSource = m1;
                        if (Array.IndexOf(RTKoutputrate, Inf.Rtkoutputrate) > 1) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                    case "5HZ":
                        string[] m2 = { "38400", "572600", "115200" };
                        cbxRTKoutputrate.DataSource = m2;
                        if (Array.IndexOf(RTKoutputrate, Inf.Rtkoutputrate) > 1) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                    case "10HZ(OnlyGPS)":
                        string[] m3 = { "115200" };
                        cbxRTKoutputrate.DataSource = m3;
                        if (Array.IndexOf(RTKoutputrate, Inf.Rtkoutputrate) > 3) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                }
            }
            else
            {
                switch (cbxRTKrate.Text)
                {
                    default:
                        cbxRTKoutputrate.DataSource = RTKoutputrate;
                        break;
                    case "1HZ":
                        a.RemoveAt(0);
                        cbxRTKoutputrate.DataSource = a;
                        if (Inf.Rtkoutputrate != RTKoutputrate[0]) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                    case "2HZ":
                        string[] m1 = { "38400", "572600", "115200" };
                        cbxRTKoutputrate.DataSource = m1;
                        if (Array.IndexOf(RTKoutputrate, Inf.Rtkoutputrate) > 1) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                    case "4HZ":
                        string[] m2 = { "38400", "572600", "115200" };
                        cbxRTKoutputrate.DataSource = m2;
                        if (Array.IndexOf(RTKoutputrate, Inf.Rtkoutputrate) > 1) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                    case "5HZ":
                        string[] m3 = { "572600", "115200" };
                        cbxRTKoutputrate.DataSource = m3;
                        if (Array.IndexOf(RTKoutputrate, Inf.Rtkoutputrate) > 2) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                    case "10HZ(OnlyGPS)":
                        string[] m4 = { "115200" };
                        cbxRTKoutputrate.DataSource = m4;
                        if (Array.IndexOf(RTKoutputrate, Inf.Rtkoutputrate) > 3) { cbxRTKoutputrate.Text = Inf.Rtkoutputrate; }
                        break;
                }
            }
        }

        private void cbxRTKrate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetOutputrate();
        }

        private void cbxGNSStype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetOutputrate();
        }

        private void cbxOutputtype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Outchoose(cbxOutputtype.Text, In19);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int uiOutputtype = Array.IndexOf(Outputtype, cbxOutputtype.Text);
            int uiRtkRate = Array.IndexOf(RTKrate, cbxRTKrate.Text);
            int uiGNSStype = Array.IndexOf(GNSStype, cbxGNSStype.Text);
            int uiRTKmode = Array.IndexOf(RTKmode, cbxRTKmode.Text);
            int uiRTKoutputBaudrate = Array.IndexOf(RTKoutputrate, cbxRTKoutputrate.Text);
            int[] outchoose = OutChoose();
            sp.WriteLine(string.Format("$ICERTK,OUT,{0}*FF\r\n", uiOutputtype));
            sp.WriteLine(string.Format("$ICERTK,RATE,{0}*FF\r\n", uiRtkRate));
            sp.WriteLine(string.Format("$ICERTK,MODE,{0}*FF\r\n", uiRTKmode));
            sp.WriteLine(string.Format("$ICERTK,BAUD,{0}*FF\r\n", uiRTKoutputBaudrate));
            sp.WriteLine(string.Format("$ICERTK,GNSS,{0}*FF\r\n", uiGNSStype));
            sp.WriteLine(string.Format("$ICERTK,NMEA,{0}*FF\r\n", outchoose[0]));
            sp.WriteLine(string.Format("$ICERTK,UBX,{0}*FF\r\n", outchoose[1]));
            sp.WriteLine(string.Format("$ICERTK,SBP,{0}*FF\r\n", outchoose[2]));
            Close();
        }
        public int[] OutChoose()
        {
            int[] b = { In19.NmeaOutchoose, In19.UbxOutChoose, In19.SbpOutchoose };
            switch (cbxOutputtype.Text)
            {
                case "NMEA":
                    b[0] = setby();
                    break;
                case "UBX":
                    b[1] = setby();
                    break;
                case "SBP":
                    b[2] = setby();
                    break;
                default:
                    break;
            }
            return b;
        }
        public byte setby()
        {
            string str = null;
            CheckBox[] b = { checkBox0, checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Visible == true)
                {
                    if (b[i].Checked == true)
                    {
                        str += '1';
                    }
                    else
                    {
                        str += '0';
                    }
                }
            }
            char[] chr = str.PadRight(8).Replace(' ', '1').Reverse().ToArray();
            string x = new string(chr);
            byte y = Convert.ToByte(x, 2);
            return y;
        }
    }
}
