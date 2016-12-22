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
    public partial class FrmInRF : Form
    {
        public SerialPort sp;
        public string[] Enableflag = { "关闭", "打开" };
        public string[] NetID;
        public string[] Channels;
        public Model.SetInf Inf;
        public Model.INF_B562_0119 In19;
        public int i;
        FrmRTK frm = new FrmRTK();
        public FrmInRF(FrmRTK a)
        {
            frm = a;
            InitializeComponent();
        }

        private void FrmInRF_Load(object sender, EventArgs e)
        {
            NetID = new string[41];
            for (int i = 0; i < NetID.Length; i++)
            {
                NetID[i] = i.ToString();
            }
            Channels = new string[17];
            for (int i = 0; i < Channels.Length; i++)
            {
                if (i < 16) { Channels[i] = (i + 5).ToString(); }
                else { Channels[i] = "30"; }
            }
            cbxEnableflag.DataSource = Enableflag;
            cbxNetID.DataSource = NetID;
            cbxChannels.DataSource = Channels;
            cbxEnableflag.Text = Inf.enableFlag;
            cbxNetID.Text = Inf.NetID;
            cbxChannels.Text = Inf.channels;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int enableFlag = Array.IndexOf(Enableflag, cbxEnableflag.Text);
            int Netid = Array.IndexOf(NetID, cbxNetID.Text);
            int channels = Array.IndexOf(Channels, cbxChannels.Text);
            sp.WriteLine(string.Format("$ICERTK,RADIO,{0},NETID,{1},CHANNELS,{2}*FF\r\n", enableFlag, Netid, Channels[channels]));
            i = enableFlag;
            frm.labBinRF.Text = cbxEnableflag.Text;
            frm.labNetID.Text = cbxNetID.Text;
            frm.labChannel.Text = cbxChannels.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
