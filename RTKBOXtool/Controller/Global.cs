using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace RTKBOXtool.Controller
{
    /// <summary>
    /// RTKBoxTool通用工具类
    /// </summary>
    class Global
    {
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sp">串口类</param>
        /// <param name="name">串口名</param>
        /// <param name="BaudRate">波特率</param>
        public static void OpenPort(SerialPort sp, string COMname, int BaudRate)
        {
            if (sp.IsOpen)
            { sp.Close(); }
            sp.PortName = COMname;
            sp.BaudRate = BaudRate;
            sp.Open();
        }
        /// <summary>
        /// 输入串口特定指令
        /// </summary>
        /// <param name="sp">当前打开的串口</param>
        /// <param name="set">所需设置选项</param>
        /// <param name="choose">设置选项的状态</param>
        public static void Order(SerialPort sp,string set,int choose)
        {
            string instruction = string.Format("$ICERTK,{0},{1:d}*FF\r\n", set, choose);
            sp.WriteLine(instruction);
        }
        /// <summary>
        /// 输入串口设置指令
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="order"></param>
        public static void WriteCOM(SerialPort sp, string order)
        {
            if (sp.IsOpen)
            {
                switch (order)
                {
                    case "进入设置模式":
                        sp.WriteLine("$ICERTK,SET,1*FF\r\n");
                        break;
                    case "退出设置模式":
                        sp.WriteLine("$ICERTK,SET,0*FF\r\n");
                        break;
                    case "STATION-基准站":
                        sp.WriteLine("$ICERTK,STATION,0*FF\r\n");
                        break;
                    case "STATION-流动站":
                        sp.WriteLine("$ICERTK,STATION,1*FF\r\n");
                        break;
                    case "设置流动站输出数据类型NMEA":
                        sp.WriteLine("$ICERTK,OUT,0*FF\r\n");
                        break;
                    case "设置流动站输出数据类型UBX":
                        sp.WriteLine("$ICERTK,OUT,1*FF\r\n");
                        break;
                    case "设置流动站输出数据类型SPB":
                        sp.WriteLine("$ICERTK,OUT,2*FF\r\n");
                        break;
                    case "设置流动站输出数据类型PIX":
                        sp.WriteLine("$ICERTK,OUT,3*FF\r\n");
                        break;
                    case "设置流动站输出数据类型JIYI":
                        sp.WriteLine("$ICERTK,OUT,4*FF\r\n");
                        break;
                    case "设置流动站输出数据类型ZEROTECH":
                        sp.WriteLine("$ICERTK,OUT,5*FF\r\n");
                        break;
                    case "设置流动站输出数据类型DJI":
                        sp.WriteLine("$ICERTK,OUT,6*FF\r\n");
                        break;
                    case "设置输出频率1Hz":
                        sp.WriteLine("$ICERTK,RATE,0*FF\r\n");
                        break;
                    case "设置输出频率2Hz":
                        sp.WriteLine("$ICERTK,RATE,1*FF\r\n");
                        break;
                    case "设置输出频率4Hz":
                        sp.WriteLine("$ICERTK,RATE,2*FF\r\n");
                        break;
                    case "设置输出频率5Hz":
                        sp.WriteLine("$ICERTK,RATE,3*FF\r\n");
                        break;
                    case "设置输出频率10Hz":
                        sp.WriteLine("$ICERTK,RATE,4*FF\r\n");//卫星GPS
                        break;
                    case "设置卫星GPS":
                        sp.WriteLine("$ICERTK,GNSS,0*FF\r\n");
                        break;
                    case "设置卫星GPS+Beidou":
                        sp.WriteLine("$ICERTK,GNSS,1*FF\r\n");
                        break;
                    case "设置运算模式静态":
                        sp.WriteLine("$ICERTK,MODE,0*FF\r\n");
                        break;
                    case "设置运算模式动态":
                        sp.WriteLine("$ICERTK,MODE,1*FF\r\n");
                        break;
                    case "设置运算模式测向":
                        sp.WriteLine("$ICERTK,MODE,2*FF\r\n");
                        break;
                    case "设置输出波特率9600"://支持最高输出频率1Hz+GPS
                        sp.WriteLine("$ICERTK,BAUD,0*FF\r\n");
                        break;
                    case "设置输出波特率19200"://支持最高输出频率1HZ GPS+北斗，2HZ GPS
                        sp.WriteLine("$ICERTK,BAUD,1*FF\r\n");
                        break;
                    case "设置输出波特率38400":
                        sp.WriteLine("$ICERTK,BAUD,2*FF\r\n");//支持最高输出频率4Hz GPS+北斗，5hz GPS
                        break;
                    case "设置输出频率57600"://不建议使用10HZ
                        sp.WriteLine("$ICERTK,BAUD,3*FF\r\n");
                        break;
                    case "设置输出频率115200":
                        sp.WriteLine("$ICERTK,BAUD,4*FF\r\n");
                        break;
                }
                Thread.Sleep(300);
            }
        }
        /// <summary>
        /// 解析RTKBox配置信息协议
        /// </summary>
        /// <param name="sp">当前串口</param>
        /// <param name="IN19">19数据实体类</param>
        public static void ParseDataIN19(SerialPort sp, Model.INF_B562_0119 IN19)
        {
            byte[] Data = new byte[sp.BytesToRead];
            sp.Read(Data, 0, Data.Length);
            sp.DiscardInBuffer();
            string str = null;
            for (int i = 0; i < Data.Length; i++)
            {
                str += Data[i].ToString("X2");
            }
            System.Windows.Forms.MessageBox.Show(str);
            for (int i = 0; i < Data.Length - 6; i++)
            {
                if ((Data[i] == 0xB5) && (Data[i + 1] == 0x62))
                {
                    if ((Data[i + 2] == 0x01) && (Data[i + 3] == 0x19))
                    {
                        ushort len = BitConverter.ToUInt16(Data, i + 4);
                        if (Data.Length - i - 8 >= len)
                        {
                            byte[] buffer = Data.Skip(i + 2).Take(len + 6).ToArray();
                            if (Protocol_UBX.Checksum(buffer))
                            {
                                byte[] payload = buffer.Skip(4).Take(len).ToArray();
                                IN19 = Protocol_UBX.RTKBoxOptions(payload);
                                break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 数组协议解析基准站信息
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="IN01"></param>
        /// <param name="IN11"></param>
        public static void ParseBaseStation(byte[] Data, Model.INF_B562_0101 IN01,Model.INF_B562_0111 IN11)
        {
            for (int i = 0; i < Data.Length - 6; i++)
            {
                if ((Data[i] == 0xB5) && (Data[i + 1] == 0x62)&&(Data[i + 2] == 0x01))
                {
                    if (Data[i + 3] == 0x01)
                    {
                        ushort len = BitConverter.ToUInt16(Data, i + 4);
                        if (Data.Length - i - 8 >= len)
                        {
                            byte[] buffer = Data.Skip(i + 2).Take(len + 6).ToArray();
                            if (Protocol_UBX.Checksum(buffer))
                            {
                                byte[] payload = buffer.Skip(4).Take(len).ToArray();
                                IN01 = Protocol_UBX.BaseStation(payload);
                            }
                        }
                    }
                    else if (Data[i + 3] == 0x11)
                    {
                        ushort len = BitConverter.ToUInt16(Data, i + 4);
                        if (Data.Length - i - 8 >= len)
                        {
                            byte[] buffer = Data.Skip(i + 2).Take(len + 6).ToArray();
                            if (Protocol_UBX.Checksum(buffer))
                            {
                                byte[] payload = buffer.Skip(4).Take(len).ToArray();
                                IN11 = Protocol_UBX.UserBaseStation(payload);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// IN18流动站数据解析
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="IN18"></param>
        public static void ParseDataIN18(byte[] Data, Model.INF_B562_0118 IN18)
        {
            for (int i = 0; i < Data.Length - 6; i++)
            {
                if ((Data[i] == 0xB5) && (Data[i + 1] == 0x62))
                {
                    if ((Data[i + 2] == 0x01) && (Data[i + 3] == 0x18))
                    {
                        ushort len = BitConverter.ToUInt16(Data, i + 4);
                        if (Data.Length - i - 8 >= len)
                        {
                            byte[] buffer = Data.Skip(i + 2).Take(len + 6).ToArray();
                            if (Protocol_UBX.Checksum(buffer))
                            {
                                byte[] payload = buffer.Skip(4).Take(len).ToArray();
                                IN18 = Protocol_UBX.RoverStation(payload);
                                break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 基准站坐标ECEF转经纬度
        /// </summary>
        /// <param name="IN01"></param>
        /// <returns></returns>
        public static double[] Ecef2Pos01(Model.INF_B562_0101 IN01)
        {
            double[] r = { IN01.ecefX * 0.01, IN01.ecefY * 0.01, IN01.ecefZ * 0.01 };
            double[] pos = new double[3];
            CoordinateConverter.ecef2pos(r, pos);
            return pos;
        }
        /// <summary>
        /// 用户设置基准站坐标ECEF转经纬度
        /// </summary>
        /// <param name="IN11"></param>
        /// <returns></returns>
        public static double[] Ecef2Pos11(Model.INF_B562_0111 IN11)
        {
            double[] r = { IN11.SetX,IN11.SetY,IN11.SetZ };
            double[] pos = new double[3];
            CoordinateConverter.ecef2pos(r, pos);
            return pos;
        }
        /// <summary>
        /// 流动站坐标ECEF转经纬度
        /// </summary>
        /// <param name="IN18"></param>
        /// <returns></returns>
        public static double[] Ecef2Pos18(Model.INF_B562_0118 IN18)
        {
            double[] r = { IN18.Recefx, IN18.RecefY, IN18.Recefz };
            double[] pos = new double[3];
            CoordinateConverter.ecef2pos(r, pos);
            return pos;
        }
        public static double[] ENUspeed(Model.INF_B562_0118 IN18)
        {
            double[] m = new double[3];
            return m;
        }
        /// <summary>
        /// B5620111数据解析
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="IN11"></param>
        public static void ParseDataIN11(SerialPort sp, Model.INF_B562_0111 IN11)
        {
            byte[] Data = new byte[sp.BytesToRead];
            sp.Read(Data, 0, Data.Length);
            sp.DiscardInBuffer();
            for (int i = 0; i < Data.Length - 6; i++)
            {
                if ((Data[i] == 0xB5) && (Data[i + 1] == 0x62))
                {
                    if ((Data[i + 2] == 0x01) && (Data[i + 3] == 0x11))
                    {
                        ushort len = BitConverter.ToUInt16(Data, i + 4);
                        if (Data.Length - i - 8 >= len)
                        {
                            byte[] buffer = Data.Skip(i + 2).Take(len + 6).ToArray();
                            if (Protocol_UBX.Checksum(buffer))
                            {
                                byte[] payload = buffer.Skip(4).Take(len).ToArray();
                                IN11 = Protocol_UBX.UserBaseStation(payload);
                                break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 经纬度由弧度转角度
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        public static string[] BSsetdGV(double[] de)
        {
            string[] a = new string[2];
            if (de[0] >= 0)
            {
                a[0] = "N " + (de[0] / Math.PI * 180.0).ToString("f9") + "°";
            }
            else
            {
                a[0] = "S " + (de[0] / Math.PI * 180.0).ToString("f9") + "°";
            }
            if (de[1] < 0)
            {
                a[1] = "W " + (de[1] / Math.PI * 180.0).ToString("f9") + "°";
            }
            else
            {
                a[1] = "E " + (Math.Abs(de[1]) / Math.PI * 180.0).ToString("f9") + "°";
            }
            return a;
        }
        public static string[] IN18toSTR(Model.INF_B562_0118 IN18)
        {

        }
        /// <summary>
        /// 设置信息19协议数据转文本信息
        /// </summary>
        /// <param name="In19"></param>
        /// <param name="Stf"></param>
        public static void In19TOSetInf(Model.INF_B562_0119 In19, Model.SetInf Stf)
        {
            switch (In19.Stationtype)
            {
                case 0: Stf.Stationtype = "基准站";
                    break;
                case 1: Stf.Stationtype = "流动站";
                    break;
            }
            switch (In19.Outputtype)
            {
                case 0:Stf.Outputtype = "NMEA";
                    break;
                case 1:Stf.Outputtype = "UBX";
                    break;
                case 2:Stf.Outputtype = "SPB";
                    break;
                case 3:Stf.Outputtype = "PIX";
                    break;
                case 4:Stf.Outputtype = "JIY";
                    break;
                case 5:Stf.Outputtype = "ZEROTECH";
                    break;
                case 6:Stf.Outputtype = "DJI";
                    break;
            }
            switch (In19.Rtkrate)
            {
                case 0:Stf.Rtkrate = "1HZ";
                    break;
                case 1:
                    Stf.Rtkrate = "2HZ";
                    break;
                case 2:
                    Stf.Rtkrate = "4HZ";
                    break;
                case 3:
                    Stf.Rtkrate = "5HZ";
                    break;
                case 4:
                    Stf.Rtkrate = "10HZ";
                    break;
            }
            switch (In19.Gnsstype)
            {
                case 0:Stf.Gnsstype = "GPS";
                    break;
                case 1:Stf.Gnsstype = "GPS+北斗";
                    break;
            }
            switch (In19.Rtkmode)
            {
                case 0:Stf.Rtkmode = "静态";
                    break;
                case 1:Stf.Rtkmode = "动态";
                    break;
                case 2:Stf.Rtkmode = "测向";
                    break;
            }
            switch (In19.Rtkoutputrate)
            {
                case 0:Stf.Rtkoutputrate = "9600";
                    break;
                case 1:Stf.Rtkoutputrate = "19200";
                    break;
                case 2:
                    Stf.Rtkoutputrate = "38400";
                    break;
                case 3:
                    Stf.Rtkoutputrate = "57600";
                    break;
                case 4:
                    Stf.Rtkoutputrate = "115200";
                    break;
            }
            switch (In19.enableFlag)
            {
                case 0:Stf.enableFlag = "关闭";
                    break;
                case 1:
                    Stf.enableFlag = "打开";
                    break;
            }          
            Stf.NetID = In19.NetID.ToString();
            Stf.channels = In19.channels.ToString();

        }
    }
}
