using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTKBOXtool.Controller
{
    /// <summary>
    /// 坐标格式转换工具类
    /// </summary>
    class CoordinateConverter
    {
        public const double FE_WGS84 = 1.0 / 298.257223563;
        public const double RE_WGS84 = 6378137.0;
        /// <summary>
        /// ecef格式转换为经纬度WGS84
        /// </summary>
        /// <param name="r">输入ECEF格式x、y、z</param>
        /// <param name="pos">输出经纬度坐标lan,lot,h</param>
        public static double[] ecef2pos(double[] r, double[] pos)
        {
            double e2 = FE_WGS84 * (2.0 - FE_WGS84), r2 = dot(r, r, 2), z, zk, v = RE_WGS84, sinp;
            for (z = r[2], zk = 0.0; Math.Abs(z - zk) >= 1E-4;)
            {
                zk = z;
                sinp = z / Math.Sqrt(r2 + z * z);
                v = RE_WGS84 / Math.Sqrt(1.0 - e2 * sinp * sinp);
                z = r[2] + v * e2 * sinp;
            }
            pos[0] = r2 > 1E-12 ? Math.Atan(z / Math.Sqrt(r2)) : (r[2] > 0.0 ? Math.PI / 2.0 : -Math.PI / 2.0);
            pos[1] = r2 > 1E-12 ? Math.Atan2(r[1], r[0]) : 0.0;
            pos[2] = Math.Sqrt(r2 + z * z) - v;
            return pos;
        }
        /// <summary>
        /// 经纬度转ECEF坐标格式
        /// </summary>
        /// <param name="pos">经纬度 lan、lot、h</param>
        /// <param name="r">ECEF X、Y、Z</param>
        /// <returns></returns>
        public static double[] pos2ecef(double[] pos, double[] r)
        {
            double sinp = Math.Sin(pos[0]), cosp = Math.Cos(pos[0]), sin_1 = Math.Sin(pos[1]), cos_1 = Math.Cos(pos[1]);
            double e2 = FE_WGS84 * (2.0 - FE_WGS84), v = RE_WGS84 / Math.Sqrt(1.0 - e2 * sinp * sinp);
            r[0] = (v + pos[2]) * cosp * cos_1;
            r[1] = (v + pos[2]) * cosp * sin_1;
            r[2] = (v * (1.0 - e2) + pos[2]) * sinp;
            return r;
        }
        /// <summary>
        /// ECEF转站心坐标
        /// </summary>
        /// <param name="pos">经纬度 （弧度）</param>
        /// <param name="r">ecef坐标格式X、Y、Z值</param>
        /// <param name="e">本地正切坐标{e,n,u}</param>
        /// <returns></returns>
        public static double[] ecef2enu(double[] pos, double[] r, double[] e)
        {
            double[] E = new double[9];
            xyz2enu(pos, E);
            char[] cr = { 'N', 'N' };
            matmul(cr, 3, 1, 3, 1.0, E, r, 0.0, e);
            return e;
        }
        /// <summary>
        /// 获取流动站相对于基准站方位
        /// </summary>
        /// <param name="ReCEF">流动站ECEF</param>
        /// <param name="SeCEF">基准站ECEF</param>
        /// <param name="Renu">结果站心坐标</param>
        public static void EnuFormEcef(double[] ReCEF,double[] SeCEF,double[] Renu)
        {
            int i = 0;
            double[] vEcef = new double[3];
            double[] bPos = new double[3];
            for(i=0;i<3;i++)
            {
                vEcef[i] = ReCEF[i] - SeCEF[i];
            }
            ecef2pos(SeCEF, bPos);
            ecef2enu(bPos, vEcef, Renu);
        }
        public static void enu2ecef(double[] pos, double[] e, double[] r)
        {
            double[] E = new double[9];
            xyz2enu(pos, E);
            char[] cr = { 'T', 'N' };
            matmul(cr, 3, 1, 3, 1.0, E, e, 0.0, r);
        }
        public static void matmul(char[] tr, int n, int k, int m, double alpha,
                                    double[] A, double[] B, double beta, double[] C)
        {
            double d;
            int i, j, x, f = tr[0] == 'N' ? (tr[1] == 'N' ? 1 : 2) : (tr[1] == 'N' ? 3 : 4);
            for (i = 0; i < n; i++) for (j = 0; j < k; j++)
                {
                    d = 0.0;
                    switch (f)
                    {
                        case 1: for (x = 0; x < m; x++) d += A[i + x * n] * B[x + j * m]; break;
                        case 2: for (x = 0; x < m; x++) d += A[i + x * n] * B[j + x * k]; break;
                        case 3: for (x = 0; x < m; x++) d += A[x + i * m] * B[x + j * m]; break;
                        case 4: for (x = 0; x < m; x++) d += A[x + i * m] * B[j + x * k]; break;
                    }
                    if (beta == 0.0) C[i + j * n] = alpha * d; else C[i + j * n] = alpha * d;
                }
        }
        public static void xyz2enu(double[] pos, double[] E)
        {
            double sinp = Math.Sin(pos[0]), cosp = Math.Cos(pos[0]), sin_1 = Math.Sin(pos[1]), cos_1 = Math.Cos(pos[1]);
            E[0] = -sin_1; E[3] = cos_1; E[6] = 0.0;
            E[1] = -sinp * cos_1; E[4] = -sinp * sin_1; E[7] = cosp;
            E[2] = cosp * cos_1; E[5] = cosp * sin_1; E[8] = sinp;
        }
        public static double dot(double[] a, double[] b, int n)
        {
            double c = 0.0;
            while (--n >= 0) c += a[n] * b[n];
            return c;
        }
    }
}
