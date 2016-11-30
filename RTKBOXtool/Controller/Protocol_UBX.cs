using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTKBOXtool.Model;

namespace RTKBOXtool.Controller
{
    /// <summary>
    /// UBX协议校验及解析方法类
    /// </summary>
    class Protocol_UBX
    {
        /// <summary>
        /// UBX校验规则
        /// </summary>
        /// <param name="Buffer">校验协议数组</param>
        /// <returns></returns>
        public static bool Checksum(byte[] Buffer)
        {
            int CK_A = 0, CK_B = 0;
            for (int m = 0; m < Buffer.Length - 2; m++)
            {
                CK_A = CK_A + Buffer[m];
                CK_B = CK_B + CK_A;
            }
            if (CK_A > 255)
            {
                CK_A = CK_A & 0x000000FF;
            }
            if (CK_B > 255)
            {
                CK_B = CK_B & 0x000000FF;
            }
            if ((CK_A == Buffer[Buffer.Length - 2]) && (CK_B == Buffer[Buffer.Length - 1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// B5620101基准站坐标协议解析
        /// </summary>
        /// <param name="payload">解析数组</param>
        /// <returns></returns>
        public static INF_B562_0101 BaseStation(byte[] payload)
        {
            INF_B562_0101 m = new INF_B562_0101();
            m.iTOW = BitConverter.ToUInt32(payload, 0);
            m.ecefX = BitConverter.ToInt32(payload, 4);
            m.ecefY = BitConverter.ToInt32(payload, 8);
            m.ecefZ = BitConverter.ToInt32(payload, 12);
            m.pacc = BitConverter.ToUInt32(payload, 16);
            return m;
        }
        /// <summary>
        /// B5620111用户设置基准站坐标协议解析
        /// </summary>
        /// <param name="payload">解析数组</param>
        /// <returns></returns>
        public static INF_B562_0111 UserBaseStation(byte[] payload)
        {
            INF_B562_0111 m = new INF_B562_0111();
            m.SetX = BitConverter.ToDouble(payload, 0);
            m.SetY = BitConverter.ToDouble(payload, 8);
            m.SetZ = BitConverter.ToDouble(payload, 16);
            return m;
        }
        /// <summary>
        /// B5620118流动站基本信息协议解析
        /// </summary>
        /// <param name="payload">解析数组</param>
        /// <returns></returns>
        public static INF_B562_0118 RoverStation(byte[] payload)
        {
            INF_B562_0118 m = new INF_B562_0118();
            m.BiGpsWeek = BitConverter.ToInt16(payload, 0);
            m.BdRoverSencond = BitConverter.ToSingle(payload, 2);
            m.EcefX = BitConverter.ToDouble(payload, 6);
            m.EcefY = BitConverter.ToDouble(payload, 14);
            m.EcefZ = BitConverter.ToDouble(payload, 22);
            m.Bn = payload[30];
            m.RiGpsWeek = BitConverter.ToInt16(payload, 31);
            m.RdRoverSecond = BitConverter.ToSingle(payload, 33);
            m.Recefx = BitConverter.ToDouble(payload, 37);
            m.RecefY = BitConverter.ToDouble(payload, 45);
            m.Recefz = BitConverter.ToDouble(payload, 53);
            m.SpeeedofRecefX = BitConverter.ToDouble(payload, 61);
            m.speed0fRecefY = BitConverter.ToDouble(payload, 69);
            m.SpeeedofRecefZ = BitConverter.ToDouble(payload, 77);
            m.age = BitConverter.ToSingle(payload, 85);
            m.ratio = BitConverter.ToSingle(payload, 89);
            m.stat = payload[93];
            m.Rsetn = payload[94];
            m.Rusen = payload[95];
            m.usetime = BitConverter.ToUInt32(payload, 96);
            return m;
        }
        /// <summary>
        /// B5620119RTKBox配置信息协议解析
        /// </summary>
        /// <param name="payload">解析数组</param>
        /// <returns></returns>
        public static INF_B562_0119 RTKBoxOptions(byte[] payload)
        {
            INF_B562_0119 m = new INF_B562_0119();
            m.Stationtype = payload[0];
            m.Outputtype = payload[1];
            m.Rtkrate = payload[2];
            m.Gnsstype = payload[3];
            m.Rtkmode = payload[4];
            m.Rtkoutputrate = payload[5];
            m.enableFlag = payload[6];
            m.NetID = BitConverter.ToUInt16(payload, 7);
            m.channels = BitConverter.ToUInt16(payload, 9);
            m.RadioBaudrate = payload[11];
            m.NmeaOutchoose = payload[12];
            m.UbxOutChoose = payload[13];
            m.SbpOutchoose = payload[14];
            m.Builddatetime = Encoding.Default.GetString(payload.Skip(15).Take(16).ToArray());
            return m;
        }
    }
}
