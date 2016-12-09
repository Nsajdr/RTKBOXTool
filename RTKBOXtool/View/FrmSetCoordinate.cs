using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTKBOXtool.View
{
    public partial class FrmSetCoordinate : Form
    {
        public string X;
        public string Y;
        public string Z;
        public double j, k, l;
        public int show;
        public string str;
        FrmStart frm = new FrmStart();
        public FrmSetCoordinate(FrmStart a)
        {
            InitializeComponent();
            frm = a;
        }

        private void FrmSetCoordinate_Load(object sender, EventArgs e)
        {
            if(show==1)
            {
                label1.Text = "ECEF-X";
                label2.Text = "ECEF-Y";
                label3.Text = "ECEF-Z";
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            labX.Text = frm.dGVStation.Rows[3].Cells[1].Value.ToString();
            labY.Text = frm.dGVStation.Rows[4].Cells[1].Value.ToString();
            labZ.Text = frm.dGVStation.Rows[5].Cells[1].Value.ToString();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (double.TryParse(labX.Text, out j) && double.TryParse(labY.Text, out k) && double.TryParse(labZ.Text, out l))
            {
                str = string.Format("$ICERTK,POS,{0:F3},{1:F3},{2:F3},1*FF\r\n", j, k, l);
            }
            else
            {
                try
                {
                    double a = double.Parse(labX.Text.Replace('°', '0').Substring(1));
                    double b = double.Parse(labY.Text.Replace('°', '0').Substring(1));
                    double c = double.Parse(labZ.Text.Replace('m', '0'));
                    double z = a * Math.PI / 180.0;
                    double x = b * Math.PI / 180.0;
                    double v = c;
                    double[] m = { z, x, v };
                    double[] n = new double[3];
                    Controller.CoordinateConverter.pos2ecef(m, n);
                    str = string.Format("$ICERTK,POS,{0:F6},{1:F6},{2:F6},1*FF\r\n", n[0], n[1], n[2]);                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            X = labX.Text;Y = labY.Text;Z = labZ.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
