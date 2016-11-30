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
using System.Threading;

namespace RTKBOXtool.View
{
    public partial class FrmStart : Form
    {
        public int choose = 1;
        public SerialPort sp;
        public Model.INF_B562_0101 IN01;
        public Model.INF_B562_0111 IN11;
        public Model.INF_B562_0118 IN18;
        public Model.INF_B562_0119 IN19;
        public Model.SetInf Stf;
        public FrmStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取当前串口名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetPort_Click(object sender, EventArgs e)
        {
            string[] name = SerialPort.GetPortNames();
            comboBoxPort.DataSource = name;
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            sp = new SerialPort();
            int Baudrate;
            if ((!string.IsNullOrEmpty(comboBoxPort.Text)) && (int.TryParse(comboBoxBaudrate.Text, out Baudrate)))
            {
                Controller.Global.OpenPort(sp, comboBoxPort.Text, Baudrate);
                Controller.Global.Order(sp, "SET", 1);//进入设置模式读取设置
                Thread.Sleep(400);
                ThreadStart ThS = new ThreadStart(delegate ()
                {
                    IN19 = new Model.INF_B562_0119();
                    Stf = new Model.SetInf();
                    Controller.Global.ParseDataIN19(sp, IN19);
                    Controller.Global.In19TOSetInf(IN19, Stf);
                    BeginInvoke((EventHandler)(delegate
                    {
                        labProtocol.Text = Stf.Outputtype;
                        labWoringband.Text = Stf.Rtkrate;
                        labPosFormat.Text = "经纬度";
                        labGNSSmode.Text = Stf.Gnsstype;
                        labRTKmode.Text = Stf.Rtkmode;
                        labRTKoutBdRate.Text = Stf.Rtkoutputrate;
                        labTFmode.Text = Stf.enableFlag;
                        labNetID.Text = Stf.NetID;
                        labchanel.Text = Stf.channels;
                        SetTable(IN19.Stationtype);
                    }));
                });
                Thread thd = new Thread(ThS);
                thd.Start();
                sp.DataReceived += new SerialDataReceivedEventHandler(Interpret);
            }
            else
            {
                MessageBox.Show("输入格式有误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetTable(int i)
        {
            dGVStation.Rows.Add(11);
            if (i == 0)
            {
                tabPageStation.Text = "基准站";
                dGVStation.Rows[2].Cells[0].Value = "定位精度";
                dGVStation.Rows[3].Cells[0].Value = "经度";
                dGVStation.Rows[4].Cells[0].Value = "纬度";
                dGVStation.Rows[5].Cells[0].Value = "高程";
                dGVStation.Rows[6].Cells[0].Value = "用户设置经度";
                dGVStation.Rows[7].Cells[0].Value = "用户设置纬度";
                dGVStation.Rows[8].Cells[0].Value = "用户设置高程";
            }
            else
            {
                tabPageStation.Text = "流动站";
                dGVStation.Rows[2].Cells[0].Value = "状态";
                dGVStation.Rows[3].Cells[0].Value = "经度";
                dGVStation.Rows[4].Cells[0].Value = "纬度";
                dGVStation.Rows[5].Cells[0].Value = "高程";
                dGVStation.Rows[6].Cells[0].Value = "向东速度";
                dGVStation.Rows[7].Cells[0].Value = "向北速度";
                dGVStation.Rows[8].Cells[0].Value = "对地速度";
                dGVStation.Rows[9].Cells[0].Value = "使用卫星数";
            }
        }
        private void FrmStart_Load(object sender, EventArgs e)
        {
            
        }
        public void Interpret(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp != null)
            {
                if (sp.IsOpen)
                {
                    byte[] Data = new byte[sp.BytesToRead];
                    sp.Read(Data, 0, Data.Length);
                    sp.DiscardInBuffer();
                    if (IN19.Stationtype == 0)
                    {
                        try
                        {
                            Controller.Global.ParseBaseStation(Data, IN01, IN11);
                            double[] p = Controller.Global.Ecef2Pos01(IN01);
                            double[] q = Controller.Global.Ecef2Pos11(IN11);
                            BeginInvoke((EventHandler)(delegate
                            {
                                string[] P1 = Controller.Global.BSsetdGV(p);
                                string[] Q = Controller.Global.BSsetdGV(q);
                                dGVStation.Rows[2].Cells[1].Value = (IN01.pacc * 0.01).ToString();
                                dGVStation.Rows[3].Cells[1].Value = P1[0];
                                dGVStation.Rows[4].Cells[1].Value = P1[1];
                                dGVStation.Rows[5].Cells[1].Value = p[2].ToString("f3");
                                dGVStation.Rows[6].Cells[1].Value = Q[0];
                                dGVStation.Rows[7].Cells[1].Value = Q[1];
                                dGVStation.Rows[8].Cells[1].Value = q[2].ToString("f3");
                            }));
                        }
                        catch (System.Exception ex)
                        { MessageBox.Show(ex.Message); }
                    }
                    else {
                        Controller.Global.ParseDataIN18(Data, IN18);
                        double[] a = Controller.Global.Ecef2Pos18(IN18);
                        double[] b = Controller.Global.ENUspeed(IN18);
                        string[] A = Controller.Global.BSsetdGV(a);

                    }
                }
            }
        }
    }
}
