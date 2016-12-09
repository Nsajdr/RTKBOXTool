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
    public partial class FrmOptions : Form
    {
        public SerialPort sp;
        public string[] Stationtype = { "基准站", "流动站" };
        public string[] Coorformat = { "Lat/Lon", "ECEF" };
        public string[] Outputtype = { "NMEA", "UBX", "SBP", "PIX", "JIYI", "ZEROTECH", "DJI" };
        public string[] RTKrate = { "1HZ", "2HZ", "4HZ", "5HZ", "10HZ(OnlyGPS)" };
        public string[] GNSStype = { "GPS", "GPS+Beidou" };
        public string[] RTKmode = { "静态", "动态", "测向" };
        public string[] RTKoutputrate = { "9600", "19200", "38400", "57600", "115200" };
        public string[] Enableflag = { "关闭", "打开" };
        public string[] NetID;
        public string[] Channels;
        public string[] RadioBaudrate = { "9600", "19200", "38400", "57600", "115200" };
        public Model.SetInf Inf;
        public Model.INF_B562_0119 In19;
        FrmStart frm = new FrmStart();
        public FrmOptions(FrmStart a)
        {
            frm = a;
            InitializeComponent();
        }
        private void FrmOptions_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            if (string.IsNullOrWhiteSpace(Inf.coordirateFormat)) { return; }
            NetID = new string[41];
            for (int i = 0; i < NetID.Length; i++)
            {
                NetID[i] = i.ToString();
            }
            Channels = new string[17];
            for(int i=0;i<Channels.Length;i++)
            {
                if (i < 16) { Channels[i] = (i + 5).ToString(); }
                else { Channels[i] = "30"; }
            }
            #region 设置选项
            cbxStationtype.DataSource = Stationtype;
            cbxCoorFormat.DataSource = Coorformat;
            cbxOutputtype.DataSource = Outputtype;
            cbxRTKrate.DataSource = RTKrate;
            cbxGNSStype.DataSource = GNSStype;
            cbxRTKmode.DataSource = RTKmode;
            cbxRTKoutputrate.DataSource = RTKoutputrate;
            cbxEnableflag.DataSource = Enableflag;
            cbxNetID.DataSource = NetID;
            cbxChannels.DataSource = Channels;
            cbxRadioBaudrate.DataSource = RadioBaudrate;
            #endregion
            //
            #region 读取配置
            cbxStationtype.Text = Inf.Stationtype;
            cbxCoorFormat.Text = Coorformat[frm.show];
            cbxOutputtype.Text = Inf.Outputtype;
            groupBox1.Text = Inf.Outputtype;
            cbxRTKrate.Text = Inf.Rtkrate;
            cbxGNSStype.Text = Inf.Gnsstype;
            cbxRTKmode.Text = Inf.Rtkmode;
            cbxRTKoutputrate.Text = Inf.Rtkoutputrate;
            cbxEnableflag.Text = Inf.enableFlag;
            cbxNetID.Text = Inf.NetID;
            cbxChannels.Text = Inf.channels;
            cbxRadioBaudrate.Text = Inf.RadioBaudrate;
            #endregion
            //
            ChargeEmableflag();
            Outchoose(groupBox1.Text,In19);
            SetOutputrate();
        }
        public void ChargeEmableflag()
        {
            if (cbxEnableflag.Text == Enableflag[0])
            {
                groupBox2.Enabled = false;
                cbxRadioBaudrate.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = true;
                cbxRadioBaudrate.Enabled = false;
            }
            
        }
        public void Outchoose(string m,Model.INF_B562_0119 IN19)
        {
            groupBox1.Text = m;
            string[] NMEA = { "RTK", "RMC", "VTG", "GGA", "GSA", "GSV" };
            string[] UBX = { "RTK", "SOL", "STATUS", "POSLIH", "DOP", "VELNED", "TIMEUTC" };
            string[] SBP = { "RTK", "GPSTIME", "VELENU", "POSLIH", "DOPS" };
            switch (m)
            {
                case "NMEA": Readchoose(NMEA);SetChoose(In19.NmeaOutchoose); groupBox1.Visible = true;
                    break;
                case "UBX": Readchoose(UBX);SetChoose(In19.UbxOutChoose); groupBox1.Visible = true;
                    break;
                case "SBP": Readchoose(SBP);SetChoose(In19.SbpOutchoose); groupBox1.Visible = true;
                    break;
                default : groupBox1.Visible = false;
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
            for(int i=0;i<a.Length;i++)
            {
                b[i].Text = a[i];
            }
            for(int i=a.Length;i<b.Length;i++)
            {
                b[i].Visible = false;
            }
        }
        public void SetChoose(byte a)
        {
            string b = Convert.ToString(a, 2);
            char[] c = b.Reverse().ToArray();
            CheckBox[] che = { checkBox0, checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            for(int i=0;i<che.Length;i++)
            {
                if(c[i]=='1')
                {
                    che[i].Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Inf.coordirateFormat)) { return; }
            frm.show = Array.IndexOf(Coorformat, cbxCoorFormat.Text);
            int uiStationtype = Array.IndexOf(Stationtype, cbxStationtype.Text);
            int uiOutputtype = Array.IndexOf(Outputtype, cbxOutputtype.Text);
            int uiRtkRate = Array.IndexOf(RTKrate, cbxRTKrate.Text);
            int uiGNSStype = Array.IndexOf(GNSStype, cbxGNSStype.Text);
            int uiRTKmode = Array.IndexOf(RTKmode, cbxRTKmode.Text);
            int uiRTKoutputBaudrate = Array.IndexOf(RTKoutputrate, cbxRTKoutputrate.Text);
            int enableFlag = Array.IndexOf(Enableflag, cbxEnableflag.Text);
            int Netid = Array.IndexOf(NetID, cbxNetID.Text);
            int channels = Array.IndexOf(Channels, cbxChannels.Text);
            int radioBaudrate = Array.IndexOf(RadioBaudrate, cbxRadioBaudrate.Text);
            int[] outchoose = OutChoose();
            string Oder = string.Format("$ICERTK,SETTINGS,{0:d},{1:d},{2:d},{3:d},{4:d},{5:d},{6:d},{7:d},{8:d},{9:d},{10:d},{11:d},{12:d},*FF\r\n",
                                        uiStationtype, uiOutputtype, uiRtkRate, uiGNSStype, uiRTKmode, uiRTKoutputBaudrate, enableFlag, Netid, channels, radioBaudrate, outchoose[0], outchoose[1], outchoose[2]);
            sp.WriteLine(Oder);
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

        private void cbxEnableflag_TextChanged(object sender, EventArgs e)
        {
            if (cbxEnableflag.Text == Enableflag[0])
            {
                groupBox2.Enabled = false;
                cbxRadioBaudrate.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = true;
                cbxRadioBaudrate.Enabled = false;
            }
        }

        private void cbxOutputtype_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Inf.coordirateFormat)) { return; }
            Outchoose(cbxOutputtype.Text, In19);
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
            if (string.IsNullOrWhiteSpace(Inf.coordirateFormat)) { return; }
            SetOutputrate();
        }

        private void cbxGNSStype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Inf.coordirateFormat)) { return; }
            SetOutputrate();
        }
    }
}
