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
    public partial class FrmPlot : Form
    {
        public int n = 40;//单元格间距默认40
        public double m = 1000;//比例尺默认1mm
        public string str = "1mm";
        public int wheel = 0;
        public double[] d = new double[4];
        public double[] Rover = new double[3];
        public Queue<double[]> q = new Queue<double[]>();
        public bool first = true;
        public string stat = null;
        public bool pl = false;
        public SerialPort sp;
        public FrmRTK frm = new FrmRTK();
        public System.Timers.Timer atimer = new System.Timers.Timer();
        public FrmPlot(FrmRTK a)
        {
            frm = a;
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Bitmap map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Graphics g = Graphics.FromImage(map);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Graphics g1 = pictureBox1.CreateGraphics();
            //g.Clear(pictureBox1.BackColor);
            //if (n > 4) { return; }
            Pen p = new Pen(Color.Black);
            float x = Convert.ToSingle(pictureBox1.Width / 2);
            float y = Convert.ToSingle(pictureBox1.Height / 2);
            PointF O = new PointF(x, y);
            double t = pictureBox1.Width / (2 * n);
            for(int i=0;i<=t;i++)
            {
                g.DrawLine(p, (float)(x - i * n), 0, (float)(x - i * n), y * 2);
                g.DrawLine(p, (float)(x + i * n), 0, (float)(x + i * n), y * 2);
            }
            double r = pictureBox1.Height / 2 / n;
            for (int i = 0; i <= r; i++)
            {
                g.DrawLine(p, 0, (float)(y - i * n), x * 2, (float)(y - i * n));
                g.DrawLine(p, 0, (float)(y + i * n), x * 2, (float)(y + i * n));
            }
            g.DrawEllipse(p, x - n / 10, y - n / 10, n / 5, n / 5);
            SolidBrush brush = new SolidBrush(Color.DarkRed);
            g.FillEllipse(brush, x - n / 10, y - n / 10, n / 5, n / 5);

            p.Color = Color.DarkRed;
            p.Width = 2;
            g.DrawLine(p, (float)(x + (t - 2) * n), (float)(y + (r - 2) * n), (float)(x + (t - 1) * n), (float)(y + (r - 2) * n));
            g.DrawLine(p, (float)(x + (t - 2) * n), (float)(y + (r - 2) * n - n/5), (float)(x + (t - 2) * n), (float)(y + (r - 2) * n + n/5));
            g.DrawLine(p, (float)(x + (t - 1) * n), (float)(y + (r - 2) * n - n / 5), (float)(x + (t - 1) * n), (float)(y + (r - 2) * n + n / 5));
            g.DrawString(str, new Font("宋体", 12), Brushes.Red, (float)(x + (t - 2) * n), (float)(y + (r - 2) * n + n / 5));
            //g1.DrawImage(map, 0, 0);
            //g.Dispose();                        
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            pl = true;            
        }

        private void FrmPlot_Load(object sender, EventArgs e)
        {
            if (sp == null) { return; }
            if (!sp.IsOpen) { return; }
            atimer.Elapsed += new System.Timers.ElapsedEventHandler(plot);
            atimer.Interval = 300;
            atimer.Enabled = true;
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
        }
        public void pictureBox1_MouseWheel(object sender,MouseEventArgs e)
        {
            atimer.Enabled = false;
            if (e.Delta > 0)
            {
                wheel = wheel < 11 ? wheel + 1 : 0;
            }
            else if (e.Delta < 0)
            {
                wheel = wheel == 0 ? 11 : wheel - 1;
            }
            switch (wheel)
            {
                case 0: n = 40;m = 1000;str = "1mm";
                    break;
                case 1:n = 50;m = 500;str = "2mm";
                    break;
                case 2:n = 60;m = 200;str = "5mm";
                    break;
                case 3:
                    n = 40; m = 100; str = "1cm";
                    break;
                case 4:
                    n = 50; m = 50; str = "2cm";
                    break;
                case 5:
                    n = 60; m = 20; str = "5cm";
                    break;
                case 6:
                    n = 40; m = 10; str = "1dm";
                    break;
                case 7:
                    n = 50; m = 5; str = "2dm";
                    break;
                case 8:
                    n = 60; m = 2; str = "5dm";
                    break;
                case 9:
                    n = 40; m = 1; str = "1m";
                    break;
                case 10:
                    n = 50; m = 0.5; str = "2m";
                    break;
                case 11:
                    n = 60; m = 0.2; str = "5m";
                    break;
            }
            pl = true;
            pictureBox1.Refresh();
            atimer.Enabled = true;
        }
        public void plot(object sender,System.Timers.ElapsedEventArgs e)
        {
            if (frm.IN19.Stationtype != 1) { return; }
            double[] co = { frm.IN18.Recefx, frm.IN18.RecefY, frm.IN18.Recefz, frm.IN18.stat };
            
            Controller.CoordinateConverter.EnuFormEcef(co, d, Rover);
            q.Enqueue(co);
            if (q.Count > 20000)
            {
                q.TrimExcess();
                q.Dequeue();
            }
            if (first) { d = co; stat = "start"; first = false; return; }
            this.BeginInvoke((EventHandler)(delegate {
                double[] kid = { 0,0};
                kid[0] = pictureBox1.Width / 2 + Rover[0] * n * m;
                kid[1] = pictureBox1.Height / 2 - Rover[1] * n * m;
                labLen.Text = frm.labRlen.Text;
                labLon.Text = frm.labRlon.Text;
                Graphics g = pictureBox1.CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen p = new Pen(Color.Brown);              
                SolidBrush brush = new SolidBrush(Color.DarkGreen);
                labState.Text = frm.labStatus.Text;
                switch (labState.Text)
                {
                    case "SINGLE":
                        p.Color = Color.Red;
                        brush.Color = Color.Red;
                        break;
                    default:
                        p.Color = Color.Brown;
                        brush.Color = Color.Brown;
                        break;
                    case "FIX":
                        p.Color = Color.DarkGreen;
                        brush.Color = Color.DarkGreen;
                        break;
                }
                try
                {
                    g.DrawEllipse(p, (float)(kid[0] - 2), (float)(kid[1] - 2), 4, 4);
                    g.FillEllipse(brush, (float)(kid[0] - 2), (float)(kid[1] - 2), 4, 4);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if ((labState.Text == "FIX") && (stat == "start"))
                {
                    stat = "end";
                    d = co;
                    pictureBox1.Refresh();
                    pl = true;
                }
                
                if (pl)
                {
                    pl = false;
                    if (q.Count > 0)
                    {
                        try
                        {
                            //double[][] a = new double[q.Count][];
                            //q.CopyTo(a, 0);
                            //Graphics g = pictureBox1.CreateGraphics();
                            //Pen p = new Pen(Color.Black);
                            //SolidBrush brush = new SolidBrush(Color.DarkGoldenrod);
                            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            double[] s = new double[2];
                            foreach (double[] po in q)
                            {
                                switch (Convert.ToUInt32(po[3]))
                                {
                                    case 5:
                                        p.Color = Color.Red;
                                        brush.Color = Color.Red;
                                        break;
                                    case 4:
                                    case 3:
                                    case 2:
                                        p.Color = Color.Brown;
                                        brush.Color = Color.Brown;
                                        break;
                                    case 1:
                                        p.Color = Color.DarkGreen;
                                        brush.Color = Color.DarkGreen;
                                        break;
                                    default:
                                        p.Color = Color.Black;
                                        brush.Color = Color.Black;
                                        break;
                                }
                                double[] chan = new double[3];
                                Controller.CoordinateConverter.EnuFormEcef(po, d, chan);
                                s[0] = pictureBox1.Width / 2 + chan[0] * n * m;
                                s[1] = pictureBox1.Height / 2 - chan[1] * n * m;
                                g.DrawEllipse(p, (float)(s[0] - 2), (float)(s[1] - 2), 4, 4);
                                g.FillEllipse(brush, (float)(s[0] - 2), (float)(s[1] - 2), 4, 4);
                            }
                        }
                        catch
                        { }
                    }
                }
            }));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            double a = (double)(e.X - pictureBox1.Width / 2) / n / m;
            double b = (double)(pictureBox1.Height / 2 - e.Y) / n / m;
            label5.Text = "E:" + a.ToString("f5") +"m "+ "N:" + b.ToString("f5")+"m";
        }
    }
}
