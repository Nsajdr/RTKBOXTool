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
    public partial class FrmRTK : Form
    {
        public int choose = 1;
        public SerialPort sp;
        public byte[] Data = new byte[20000];
        public int show = 0;
        public Model.INF_B562_0101 IN01 = new Model.INF_B562_0101();
        public Model.INF_B562_0111 IN11 = new Model.INF_B562_0111();
        public Model.INF_B562_0118 IN18 = new Model.INF_B562_0118();
        public Model.INF_B562_0119 IN19 = new Model.INF_B562_0119();
        public Model.SetInf Stf = new Model.SetInf();
        public Bitmap bmp;
        public Bitmap back;
        public System.Timers.Timer atimer = new System.Timers.Timer();
        public FrmRTK()
        {
            InitializeComponent();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp != null) { if (sp.IsOpen) { MessageBox.Show("当前串口未关闭！", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);return; } }
            FrmCOM frm = new FrmCOM();
            if(frm.ShowDialog()==DialogResult.OK)
            {
                sp = frm.sp;
                sp.PortName = frm.COMname;
                tSSlabComname.Text = frm.COMname;
                sp.BaudRate = frm.Baudrate;
                sp.Open();
                sp.DataReceived += new SerialDataReceivedEventHandler(Interpret);
                sp.WriteLine("$ICERTK,SET,1*FF\r\n");
            }
        }

        private void FrmRTK_Load(object sender, EventArgs e)
        {
            //tbcDisplay.Visible = false;
            pictureBox1.Parent = pictureBox2;           
            atimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerEvent);
            atimer.Interval = 1000;
            atimer.Enabled = false;
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
                            tbcDisplay.Visible = true;
                            if (IN19.Stationtype == 0)
                            {
                                tbpStandard.Parent = tbcDisplay;
                                tbpRover.Parent = null;                                
                                基准站坐标ToolStripMenuItem.Enabled = true;                            
                            }
                            else
                            {
                                tbpRover.Parent = tbcDisplay;
                                tbpStandard.Parent = null;
                                基准站坐标ToolStripMenuItem.Enabled = false;
                            }
                            labBinRF.Text = Stf.enableFlag;
                            labNetID.Text = Stf.NetID;
                            labChannel.Text = Stf.channels;
                            labOutRate.Text = Stf.RadioBaudrate;
                            if (IN19.enableFlag == 1) { groupBox2.Enabled = false; }
                            else { groupBox3.Enabled = false; }
                        }));
                    }
                    if (IN19.Stationtype == 0)
                    {
                        Controller.Global.ParseBaseStation(Data, IN01, IN11);
                        double[] p = Controller.Global.Ecef2Pos01(IN01);
                        double[] q = Controller.Global.Ecef2Pos11(IN11);                        
                        BeginInvoke((EventHandler)(delegate
                        {
                            string[] P1 = Controller.Global.BSsetdGV(p);
                            string[] Q = Controller.Global.BSsetdGV(q);
                            labAccuracy.Text = (IN01.pacc * 0.01).ToString();
                            lablen.Text = P1[0];
                            lablon.Text = P1[1];
                            labhigh.Text = p[2].ToString("f3") + "m";
                            labUlen.Text = Q[0];
                            labUlon.Text = Q[1];
                            labUhigh.Text = q[2].ToString("f3") + "m";
                            if (show == 1)
                            {
                                lablen.Text = (IN01.ecefX * 0.01).ToString("f3");
                                lablon.Text = (IN01.ecefY * 0.01).ToString("f3");
                                labhigh.Text = (IN01.ecefZ * 0.01).ToString("f3");
                                labUlen.Text = IN11.SetX.ToString("f3");
                                labUlon.Text = IN11.SetY.ToString("f3");
                                labUhigh.Text = IN11.SetZ.ToString("f3");
                            }
                        }));
                    }
                    else if (IN19.Stationtype == 1)
                    {
                        Controller.Global.ParseDataIN18(Data, IN18);
                        double[] a = Controller.Global.Ecef2Pos18(IN18);//转经纬度
                        double[] b = Controller.Global.ENUspeed(IN18);
                        string[] A = Controller.Global.BSsetdGV(a);
                        string[] B = Controller.Global.IN18toSTR(IN18);
                        BeginInvoke((EventHandler)(delegate
                        {
                            labStatus.Text = B[0];
                            labRlen.Text = A[0];
                            labRlon.Text = A[1];
                            labRhigh.Text = a[2].ToString("f3") + "m";
                            labSdEast.Text = b[0].ToString("f3");
                            labSdNorth.Text = b[1].ToString("f3");
                            labSoGround.Text = b[2].ToString("f3");
                            labnuWsate.Text = IN18.Rsetn.ToString();
                            if (show == 1)
                            {
                                labRlen.Text = IN18.Recefx.ToString("f3");
                                labRlon.Text = IN18.RecefY.ToString("f3");
                                labRhigh.Text = IN18.Recefz.ToString("f3");
                            }
                            if (atimer.Enabled == false) { atimer.Enabled = true; }
                        }));
                    }
                }
            }
        }
        private void 关闭CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            if(sp.IsOpen)
            {
                sp.Close();
            }
            sp.Dispose();
            tSSlabComname.Text = "空";
            IN19.Stationtype = 3;
            atimer.Enabled = false;
            pictureBox1.Refresh();
        }

        private void 经纬度坐标LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            show = 0;
            label2.Text = "经度";
            label3.Text = "纬度";
            label4.Text = "高程";
            label5.Text = "用户设置经度";
            label6.Text = "用户设置纬度";
            label7.Text = "用户设置高程";
            label8.Text = "经度";
            label9.Text = "纬度";
            label11.Text = "高程";
        }

        private void eCEFEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            show = 1;
            label2.Text = "ECEF-X";
            label3.Text = "ECEF-Y";
            label4.Text = "ECEF-Z";
            label5.Text = "用户设置ECEF-X";
            label6.Text = "用户设置ECEF-Y";
            label7.Text = "用户设置ECEF-Z";
            label8.Text = "ECEF-X";
            label9.Text = "ECEF-Y";
            label11.Text = "ECEF-Z";
        }

        private void 基准站SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            if (!sp.IsOpen) { return; }
            sp.WriteLine("$ICERTK,STATION,0*FF\r\n");
        }

        private void 流动站RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            if (!sp.IsOpen) { return; }
            sp.WriteLine("$ICERTK,STATION,1*FF\r\n");
        }

        private void rTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            if (!sp.IsOpen) { return; }
            FrmSet frm = new FrmSet(this);
            frm.In19 = IN19;
            frm.Inf = Stf;
            frm.sp = sp;
            frm.ShowDialog();
        }

        private void 基准站坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            if (!sp.IsOpen) { return; }
            FrmSetCoordinate frm = new FrmSetCoordinate(this);
            frm.show = show;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lablen.Text = frm.X;
                lablon.Text = frm.Y;
                labhigh.Text = frm.Z;
                sp.WriteLine(frm.str);
            }
        }

        private void 内置数传IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            if (!sp.IsOpen) { return; }
            FrmInRF frm = new FrmInRF(this);
            frm.sp = sp;
            frm.In19 = IN19;
            frm.Inf = Stf;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.i == 0) { groupBox3.Enabled = false; groupBox2.Enabled = true; }
                else { groupBox3.Enabled = true; groupBox2.Enabled = false; }
            }
        }

        private void 外置数传OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            if (!sp.IsOpen) { return; }
            FrmOutRF frm = new FrmOutRF();
            frm.sp = sp;
            frm.In19 = IN19;
            frm.Inf = Stf;
            frm.ShowDialog();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen p1 = new Pen(Color.Black);
            Pen p2 = new Pen(Color.DarkRed,6);
            SolidBrush brush = new SolidBrush(Color.DarkRed);
            int d = pictureBox2.Width < pictureBox2.Height ? pictureBox2.Width : pictureBox2.Height;
            PointF O = new PointF();
            O.X = (float)(pictureBox2.Width / 2 - (d - 6) / 2);
            O.Y = (float)(pictureBox2.Height / 2 - (d - 6) / 2);
            g.DrawEllipse(p1, O.X, O.Y, d - 6, d - 6);
            g.DrawEllipse(p1, (float)(pictureBox2.Width / 2 - 3), (float)(pictureBox2.Height / 2 - 3), 6, 6);
            g.FillEllipse(brush, (float)(pictureBox2.Width / 2 - 3), (float)(pictureBox2.Height / 2 - 3), 6, 6);
            PointF pf1 = new PointF((float)(pictureBox2.Width / 2), O.Y);
            PointF pf2 = new PointF((float)(pictureBox2.Width / 2), O.Y + (d - 6) / 2 / 8);
            PointF pf3 = new PointF((float)(pictureBox2.Width / 2), O.Y + d - 6);
            PointF pf4 = new PointF((float)(pictureBox2.Width / 2), O.Y + (d - 6) - (d - 6) / 2 / 8);
            PointF pf5 = new PointF(O.X, (float)(pictureBox2.Height / 2));
            PointF pf6 = new PointF(O.X + (d - 6) / 2 / 8, (float)(pictureBox2.Height / 2));
            PointF pf7 = new PointF(O.X + (d - 6), (float)(pictureBox2.Height / 2));
            PointF pf8 = new PointF(O.X + (d - 6) - (d - 6) / 2 / 8, (float)(pictureBox2.Height / 2));
            g.DrawLine(p2, pf1, pf2);
            g.DrawLine(p2, pf3, pf4);
            g.DrawLine(p2, pf5, pf6);
            g.DrawLine(p2, pf7, pf8);
            g.DrawString("N", new Font("宋体", 24), brush, pf1);
            g.DrawString("S", new Font("宋体", 24), brush, pf4);
            g.DrawString("W", new Font("宋体", 24), brush, pf5);
            g.DrawString("E", new Font("宋体", 24), brush, pf8);
            float r = (float)((d - 6) / 2);
            float a = Convert.ToSingle(r * Math.Sin(Math.PI / 6));
            float b = Convert.ToSingle(r * Math.Cos(Math.PI / 6));

            PointF pf9 = new PointF(pictureBox2.Width / 2 + a, pictureBox2.Height / 2 - b);
            PointF pf10 = new PointF(pictureBox2.Width / 2 + a * 9 / 10, pictureBox2.Height / 2 - b * 9 / 10);

            PointF pf11 = new PointF(pictureBox2.Width / 2 + b, pictureBox2.Height / 2 - a);
            PointF pf12 = new PointF(pictureBox2.Width / 2 + b * 9 / 10, pictureBox2.Height / 2 - a * 9 / 10);

            PointF pf13 = new PointF(pictureBox2.Width / 2 + b, pictureBox2.Height / 2 + a);
            PointF pf14 = new PointF(pictureBox2.Width / 2 + b * 9 / 10, pictureBox2.Height / 2 + a * 9 / 10);

            PointF pf15 = new PointF(pictureBox2.Width / 2 + a, pictureBox2.Height / 2 + b);
            PointF pf16 = new PointF(pictureBox2.Width / 2 + a * 9 / 10, pictureBox2.Height / 2 + b * 9 / 10);

            PointF pf17 = new PointF(pictureBox2.Width / 2 - a, pictureBox2.Height / 2 + b);
            PointF pf18 = new PointF(pictureBox2.Width / 2 - a * 9 / 10, pictureBox2.Height / 2 + b * 9 / 10);

            PointF pf19 = new PointF(pictureBox2.Width / 2 - b, pictureBox2.Height / 2 + a);
            PointF pf20 = new PointF(pictureBox2.Width / 2 - b * 9 / 10, pictureBox2.Height / 2 + a * 9 / 10);

            PointF pf21 = new PointF(pictureBox2.Width / 2 - b, pictureBox2.Height / 2 - a);
            PointF pf22 = new PointF(pictureBox2.Width / 2 - b * 9 / 10, pictureBox2.Height / 2 - a * 9 / 10);

            PointF pf23 = new PointF(pictureBox2.Width / 2 - a, pictureBox2.Height / 2 - b);
            PointF pf24 = new PointF(pictureBox2.Width / 2 - a * 9 / 10, pictureBox2.Height / 2 - b * 9 / 10);

            g.DrawLine(p1, pf9, pf10);
            g.DrawLine(p1, pf11, pf12);
            g.DrawLine(p1, pf13, pf14);
            g.DrawLine(p1, pf15, pf16);
            g.DrawLine(p1, pf17, pf18);
            g.DrawLine(p1, pf19, pf20);
            g.DrawLine(p1, pf21, pf22);
            g.DrawLine(p1, pf23, pf24);
            e.Graphics.DrawImage(bmp, 0, 0);
            back = bmp;
            g.Dispose();         
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int d = pictureBox2.Width < pictureBox2.Height ? pictureBox2.Width : pictureBox2.Height;
            float r = (float)((d - 6) / 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen p = new Pen(Color.Black, 3);
            System.Drawing.Drawing2D.AdjustableArrowCap lineArrow = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
            p.CustomEndCap = lineArrow;
            PointF p1 = new PointF(pictureBox2.Width / 2, (pictureBox2.Height / 2 + r * 4 / 5));
            PointF p2 = new PointF(pictureBox2.Width / 2, (pictureBox2.Height / 2 - r * 4 / 5));
            g.DrawLine(p, p1, p2);
            //g.Dispose();
            //g.TranslateTransform(pictureBox2.Width / 2, pictureBox2.Height / 2);
            //Bitmap bmp1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            //Graphics g1 = Graphics.FromImage(bmp1);
            //g1.TranslateTransform(pictureBox2.Width / 2, pictureBox2.Height / 2);
            //g1.RotateTransform(-30);
            //g1.DrawLine(p, 0, 0, 0, -r * 4 / 5);
            //g.DrawImage(bmp1, 0, 0);
            //g1.ResetTransform();
            //g1.Dispose();
        }
        public void paint(Graphics g)
        {
            Pen p1 = new Pen(Color.Black);
            Pen p2 = new Pen(Color.DarkRed, 6);
            SolidBrush brush = new SolidBrush(Color.DarkRed);
            int d = pictureBox2.Width < pictureBox2.Height ? pictureBox2.Width : pictureBox2.Height;
            PointF O = new PointF();
            O.X = (float)(pictureBox2.Width / 2 - (d - 6) / 2);
            O.Y = (float)(pictureBox2.Height / 2 - (d - 6) / 2);
            g.DrawEllipse(p1, O.X, O.Y, d - 6, d - 6);
            g.DrawEllipse(p1, (float)(pictureBox2.Width / 2 - 3), (float)(pictureBox2.Height / 2 - 3), 6, 6);
            g.FillEllipse(brush, (float)(pictureBox2.Width / 2 - 3), (float)(pictureBox2.Height / 2 - 3), 6, 6);
            PointF pf1 = new PointF((float)(pictureBox2.Width / 2), O.Y);
            PointF pf2 = new PointF((float)(pictureBox2.Width / 2), O.Y + (d - 6) / 2 / 8);
            PointF pf3 = new PointF((float)(pictureBox2.Width / 2), O.Y + d - 6);
            PointF pf4 = new PointF((float)(pictureBox2.Width / 2), O.Y + (d - 6) - (d - 6) / 2 / 8);
            PointF pf5 = new PointF(O.X, (float)(pictureBox2.Height / 2));
            PointF pf6 = new PointF(O.X + (d - 6) / 2 / 8, (float)(pictureBox2.Height / 2));
            PointF pf7 = new PointF(O.X + (d - 6), (float)(pictureBox2.Height / 2));
            PointF pf8 = new PointF(O.X + (d - 6) - (d - 6) / 2 / 8, (float)(pictureBox2.Height / 2));
            g.DrawLine(p2, pf1, pf2);
            g.DrawLine(p2, pf3, pf4);
            g.DrawLine(p2, pf5, pf6);
            g.DrawLine(p2, pf7, pf8);
            g.DrawString("N", new Font("宋体", 24), brush, pf1);
            g.DrawString("S", new Font("宋体", 24), brush, pf4);
            g.DrawString("W", new Font("宋体", 24), brush, pf5);
            g.DrawString("E", new Font("宋体", 24), brush, pf8);
            float r = (float)((d - 6) / 2);
            float a = Convert.ToSingle(r * Math.Sin(Math.PI / 6));
            float b = Convert.ToSingle(r * Math.Cos(Math.PI / 6));

            PointF pf9 = new PointF(pictureBox2.Width / 2 + a, pictureBox2.Height / 2 - b);
            PointF pf10 = new PointF(pictureBox2.Width / 2 + a * 9 / 10, pictureBox2.Height / 2 - b * 9 / 10);

            PointF pf11 = new PointF(pictureBox2.Width / 2 + b, pictureBox2.Height / 2 - a);
            PointF pf12 = new PointF(pictureBox2.Width / 2 + b * 9 / 10, pictureBox2.Height / 2 - a * 9 / 10);

            PointF pf13 = new PointF(pictureBox2.Width / 2 + b, pictureBox2.Height / 2 + a);
            PointF pf14 = new PointF(pictureBox2.Width / 2 + b * 9 / 10, pictureBox2.Height / 2 + a * 9 / 10);

            PointF pf15 = new PointF(pictureBox2.Width / 2 + a, pictureBox2.Height / 2 + b);
            PointF pf16 = new PointF(pictureBox2.Width / 2 + a * 9 / 10, pictureBox2.Height / 2 + b * 9 / 10);

            PointF pf17 = new PointF(pictureBox2.Width / 2 - a, pictureBox2.Height / 2 + b);
            PointF pf18 = new PointF(pictureBox2.Width / 2 - a * 9 / 10, pictureBox2.Height / 2 + b * 9 / 10);

            PointF pf19 = new PointF(pictureBox2.Width / 2 - b, pictureBox2.Height / 2 + a);
            PointF pf20 = new PointF(pictureBox2.Width / 2 - b * 9 / 10, pictureBox2.Height / 2 + a * 9 / 10);

            PointF pf21 = new PointF(pictureBox2.Width / 2 - b, pictureBox2.Height / 2 - a);
            PointF pf22 = new PointF(pictureBox2.Width / 2 - b * 9 / 10, pictureBox2.Height / 2 - a * 9 / 10);

            PointF pf23 = new PointF(pictureBox2.Width / 2 - a, pictureBox2.Height / 2 - b);
            PointF pf24 = new PointF(pictureBox2.Width / 2 - a * 9 / 10, pictureBox2.Height / 2 - b * 9 / 10);

            g.DrawLine(p1, pf9, pf10);
            g.DrawLine(p1, pf11, pf12);
            g.DrawLine(p1, pf13, pf14);
            g.DrawLine(p1, pf15, pf16);
            g.DrawLine(p1, pf17, pf18);
            g.DrawLine(p1, pf19, pf20);
            g.DrawLine(p1, pf21, pf22);
            g.DrawLine(p1, pf23, pf24);
        }
        public void OnTimerEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            if (sp == null) { return; }
            double[] a = { IN18.EcefX, IN18.EcefY, IN18.EcefZ };
            double[] b = { IN18.Recefx, IN18.RecefY, IN18.Recefz };
            double[] c = new double[3];
            Controller.CoordinateConverter.EnuFormEcef(b, a, c);
            double m = c[0] / c[1];
            //double n = Math.Abs(c[1] / c[0]);
            double s = 0;
            s = Math.Atan2(c[0], c[1]); 
            //if((c[0]==0)&&(c[1]>0))
            //{
            //    s = Math.PI / 2;
            //}
            //else if((c[0]==0)&&(c[1]<0))
            //{
            //    s = Math.PI * 3 / 2;
            //}
            
            //double m = c[1] / Math.Sqrt(c[0] * c[0] + c[1] * c[1]);
            //s = Math.Acos(m);
            //if ((c[0] >= 0) || (c[1] >= 0))
            //{
            //    s = Math.Acos(m);
            //}
            //else if ((c[0] > 0 || c[1] < 0))
            //{
            //    s = Math.PI + Math.Acos(m);
            //}
            //else if ((c[0] < 0) || (c[1] < 0))
            //{
            //    s = Math.Acos(m) + Math.PI;
            //}
            //else if ((c[0] < 0) || (c[1] > 0))
            //{
            //    s = Math.PI * 2 - Math.Acos(m);
            //}
            double s1 = s / Math.PI * 180;
            BeginInvoke((EventHandler)(delegate
            {
                if (double.IsNaN(s1)) { return; }
                int d = pictureBox2.Width < pictureBox2.Height ? pictureBox2.Width : pictureBox2.Height;
                float r = (float)((d - 6) / 2);

                Graphics g = pictureBox1.CreateGraphics();
                Bitmap bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g1 = Graphics.FromImage(bmp2);
                g1.Clear(Color.White);
                #region aaaaaaa
                paint(g1);
                #endregion
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen p = new Pen(Color.Black, 3);
                System.Drawing.Drawing2D.AdjustableArrowCap lineArrow = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
                p.CustomEndCap = lineArrow;
                PointF p1 = new PointF(pictureBox2.Width / 2, (pictureBox2.Height / 2 + r * 4 / 5));
                PointF p2 = new PointF(pictureBox2.Width / 2, (pictureBox2.Height / 2 - r * 4 / 5));
                g1.TranslateTransform(pictureBox2.Width / 2, pictureBox2.Height / 2);
                g1.DrawString(s1.ToString("f3") + "°", new Font("仿宋", 12), p.Brush, 0, 0);
                g1.RotateTransform(Convert.ToSingle(s1));
                g1.DrawLine(p, 0, r*4/5, 0, -r * 4 / 5);
                g.DrawImage(bmp2, 0, 0);
                g1.ResetTransform();
                g1.Dispose();
                g.Dispose();
                labH.Text = c[2].ToString("f3") + "m";
                double k1 = c[0] * c[0];
                double k2 = c[1] * c[1];
                double k3 = c[2] * c[2];
                labD1.Text = Math.Sqrt(k1 + k2).ToString("f3") + "m";
                labSD1.Text = Math.Sqrt(k1 + k2 + k3).ToString("f3") + "m";
                labEA.Text = (Math.Atan2(c[2], Math.Sqrt(k1 + k2)) / Math.PI * 180).ToString("f3") + "°";
            }));
        }

        private void 坐标绘图DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlot frm = new FrmPlot(this);
            frm.sp = sp;
            frm.ShowDialog();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox2.Refresh();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frm = new FrmAbout();
            frm.ShowDialog();
        }
    }
}
