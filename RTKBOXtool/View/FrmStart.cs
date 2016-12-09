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
        public SerialPort sp = new SerialPort();
        public byte[] Data = new byte[20000];
        public int show = 0;
        public Model.INF_B562_0101 IN01 = new Model.INF_B562_0101();
        public Model.INF_B562_0111 IN11 = new Model.INF_B562_0111();
        public Model.INF_B562_0118 IN18 = new Model.INF_B562_0118();
        public Model.INF_B562_0119 IN19 = new Model.INF_B562_0119();
        public Model.SetInf Stf = new Model.SetInf();
        public Graphics g;
        Pen pen;
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
            int Baudrate;
            if ((!string.IsNullOrEmpty(comboBoxPort.Text)) && (int.TryParse(comboBoxBaudrate.Text, out Baudrate)))
            {
                sp.DataReceived += new SerialDataReceivedEventHandler(Interpret);
                Controller.Global.OpenPort(sp, comboBoxPort.Text, Baudrate);
                sp.WriteLine("$ICERTK,SET,1*FF\r\n");
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
            dGVStation.CurrentCell = dGVStation.Rows[2].Cells[0];
        }
        private void FrmStart_Load(object sender, EventArgs e)
        {
            btnBaseCoordinate.Visible = false;
            g = pcbCompass.CreateGraphics();
            pen = new Pen(Color.Red,6);
            //g.DrawLine(pen, 0, 0, pcbCompass.Width, pcbCompass.Height);
            //g.Dispose();
        }
        public void Interpret(object sender, SerialDataReceivedEventArgs e)
        {           
            if (sp != null)
            {
                if (sp.IsOpen)
                {
                    byte[] m = new byte[sp.BytesToRead];
                    sp.Read(m, 0, m.Length);
                    sp.DiscardInBuffer();               
                    Data = m;
                    if (IN19.Stationtype == 3)
                    {                       
                        Controller.Global.ParseDataIN19(Data, IN19);
                        Controller.Global.In19TOSetInf(IN19, Stf);
                        Stf.coordirateFormat = "Lat/Lon";
                        BeginInvoke((EventHandler)(delegate
                        {
                            labProtocol.Text = Stf.Outputtype;
                            labWoringband.Text = Stf.Rtkrate;
                            labPosFormat.Text = Stf.coordirateFormat; ;
                            labGNSSmode.Text = Stf.Gnsstype;
                            labRTKmode.Text = Stf.Rtkmode;
                            labRTKoutBdRate.Text = Stf.Rtkoutputrate;
                            labTFmode.Text = Stf.enableFlag;
                            labNetID.Text = Stf.NetID;
                            labchanel.Text = Stf.channels;
                            SetTable(IN19.Stationtype);
                            labradiooutputrate.Text = Stf.RadioBaudrate;
                        }));
                    }
                    if (IN19.Stationtype == 0)
                    {
                        Controller.Global.ParseBaseStation(Data, IN01, IN11);
                        double[] p = Controller.Global.Ecef2Pos01(IN01);
                        double[] q = Controller.Global.Ecef2Pos11(IN11);
                        BeginInvoke((EventHandler)(delegate
                        {
                            btnBaseCoordinate.Visible = true;
                            string[] P1 = Controller.Global.BSsetdGV(p);
                            string[] Q = Controller.Global.BSsetdGV(q);
                            dGVStation.Rows[2].Cells[1].Value = (IN01.pacc * 0.01).ToString();
                            dGVStation.Rows[3].Cells[1].Value = P1[0];
                            dGVStation.Rows[4].Cells[1].Value = P1[1];
                            dGVStation.Rows[5].Cells[1].Value = p[2].ToString("f3") + "m";                            
                            dGVStation.Rows[6].Cells[1].Value = Q[0];
                            dGVStation.Rows[7].Cells[1].Value = Q[1];
                            dGVStation.Rows[8].Cells[1].Value = q[2].ToString("f3") + "m";
                            Setformat();
                            if (show == 1)
                            {
                                dGVStation.Rows[3].Cells[1].Value = IN01.ecefX * 0.01;
                                dGVStation.Rows[4].Cells[1].Value = IN01.ecefY * 0.01;
                                dGVStation.Rows[5].Cells[1].Value = IN01.ecefZ * 0.01;
                                dGVStation.Rows[6].Cells[1].Value = IN11.SetX;
                                dGVStation.Rows[7].Cells[1].Value = IN11.SetY;
                                dGVStation.Rows[8].Cells[1].Value = IN11.SetZ;
                            }
                        }));
                    }
                    else if(IN19.Stationtype == 1)
                    {
                        Controller.Global.ParseDataIN18(Data, IN18);
                        double[] a = Controller.Global.Ecef2Pos18(IN18);//转经纬度
                        double[] b = Controller.Global.ENUspeed(IN18);
                        string[] A = Controller.Global.BSsetdGV(a);
                        string[] B = Controller.Global.IN18toSTR(IN18);
                        BeginInvoke((EventHandler)(delegate
                        {
                            dGVStation.Rows[2].Cells[1].Value = B[0];
                            dGVStation.Rows[3].Cells[1].Value = A[0];
                            dGVStation.Rows[4].Cells[1].Value = A[1];
                            dGVStation.Rows[5].Cells[1].Value = a[2].ToString("f3") + "m";
                            dGVStation.Rows[6].Cells[1].Value = b[0].ToString("f3");
                            dGVStation.Rows[7].Cells[1].Value = b[1].ToString("f3");
                            dGVStation.Rows[8].Cells[1].Value = b[2].ToString("f3");
                            dGVStation.Rows[9].Cells[1].Value = B[1];
                            Setformat();
                            if(show==1)
                            {
                                dGVStation.Rows[3].Cells[1].Value = IN18.Recefx;
                                dGVStation.Rows[4].Cells[1].Value = IN18.RecefY;
                                dGVStation.Rows[5].Cells[1].Value = IN18.Recefz;
                            }
                        }));
                    }
                }
            }
        }
        public void Setformat()
        {
            if (show == 1)
            {
                if (IN19.Stationtype == 0)
                {
                    dGVStation.Rows[3].Cells[0].Value = "ECEF-X";
                    dGVStation.Rows[4].Cells[0].Value = "ECEF-Y";
                    dGVStation.Rows[5].Cells[0].Value = "ECEF-Z";
                    dGVStation.Rows[6].Cells[0].Value = "用户设置ECEF-X";
                    dGVStation.Rows[7].Cells[0].Value = "用户设置ECEF-Y";
                    dGVStation.Rows[8].Cells[0].Value = "用户设置ECEF-Y";
                }
                else if (IN19.Stationtype == 1)
                {
                    dGVStation.Rows[3].Cells[0].Value = "ECEF-X";
                    dGVStation.Rows[4].Cells[0].Value = "ECEF-Y";
                    dGVStation.Rows[5].Cells[0].Value = "ECEF-Z";
                }
            }
            else
            {
                if (IN19.Stationtype == 0)
                {
                    dGVStation.Rows[3].Cells[0].Value = "经度";
                    dGVStation.Rows[4].Cells[0].Value = "纬度";
                    dGVStation.Rows[5].Cells[0].Value = "高程";
                    dGVStation.Rows[6].Cells[0].Value = "用户设置经度";
                    dGVStation.Rows[7].Cells[0].Value = "用户设置纬度";
                    dGVStation.Rows[8].Cells[0].Value = "用户设置高程";
                }
                else if (IN19.Stationtype == 1)
                {
                    dGVStation.Rows[3].Cells[0].Value = "经度";
                    dGVStation.Rows[4].Cells[0].Value = "纬度";
                    dGVStation.Rows[5].Cells[0].Value = "高程";
                }
            }
        }
        private void btnBaseCoordinate_Click(object sender, EventArgs e)
        {
            FrmSetCoordinate frm = new FrmSetCoordinate(this);
            frm.show = show;
            if(frm.ShowDialog()==DialogResult.OK)
            {
                dGVStation.Rows[6].Cells[1].Value = frm.X;
                dGVStation.Rows[7].Cells[1].Value = frm.Y;
                dGVStation.Rows[8].Cells[1].Value = frm.Z;
                sp.WriteLine(frm.str);
            }
        }

        private void pcbCompass_Paint(object sender, PaintEventArgs e)
        {
            //g = e.Graphics;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //g.DrawLine(pen, pcbCompass.Width / 2, pcbCompass.Height - 80, pcbCompass.Width / 2, 80);
            //Rectangle rect = new Rectangle(pcbCompass.Width / 2 - 5, pcbCompass.Height / 2 - 5, 10, 10);
            //Pen p = new Pen(Color.Red);
            //g.DrawEllipse(p, rect);
            //Brush b = new SolidBrush(Color.Red);
            //g.FillEllipse(b,rect);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            FrmOptions frm = new FrmOptions(this);
            frm.Inf = Stf;
            frm.In19 = IN19;
            frm.sp = sp;
            frm.ShowDialog();
        }
    }
}
