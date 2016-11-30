using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTKBOXtool.Model
{
    /// <summary>
    /// 设置信息文本类
    /// </summary>
    public class SetInf
    {
        private string _stationtype;
        private string _outputtype;
        private string _rtkrate;
        private string _gnsstype;
        private string _rtkmode;
        private string _rtkoutputbaudrate;
        private string _enableflag;
        private string _netID;
        private string _channels;
        private string _radiobaudrate;
        private string _nmeaoutchoose;
        private string _ubxoutchoose;
        private string _sbpoutchoose;
        private string _builddatetime;
        private string _coordirateFormat;
        /// <summary>
        /// 机器模式
        /// </summary>
        public string Stationtype
        {
            set { _stationtype = value; }
            get { return _stationtype; }
        }
        /// <summary>
        /// 输出协议
        /// </summary>
        public string Outputtype
        {
            set { _outputtype = value; }
            get { return _outputtype; }
        }
        /// <summary>
        /// 定位频度
        /// </summary>
        public string Rtkrate
        {
            set { _rtkrate = value; }
            get { return _rtkrate; }
        }
        /// <summary>
        /// GNSS模式
        /// </summary>
        public string Gnsstype
        {
            set { _gnsstype = value; }
            get { return _gnsstype; }
        }
        /// <summary>
        /// RTK模式
        /// </summary>
        public string Rtkmode
        {
            set { _rtkmode = value; }
            get { return _rtkmode; }
        }
        /// <summary>
        /// RTK输出波特率
        /// </summary>
        public string Rtkoutputrate
        {
            set { _rtkoutputbaudrate = value; }
            get { return _rtkoutputbaudrate; }
        }
        /// <summary>
        /// 内置数传是否打开
        /// </summary>
        public string enableFlag
        {
            set { _enableflag = value; }
            get { return _enableflag; }
        }
        /// <summary>
        /// 内置数传NetID
        /// </summary>
        public string NetID
        {
            set { _netID = value; }
            get { return _netID; }
        }
        /// <summary>
        /// 内置数传频道
        /// </summary>
        public string channels
        {
            set { _channels = value; }
            get { return _channels; }
        }
        /// <summary>
        /// 外置数传波特率
        /// </summary>
        public string RadioBaudrate
        {
            set { _radiobaudrate = value; }
            get { return _radiobaudrate; }
        }
        /// <summary>
        /// Nmea数据输出项
        /// </summary>
        public string NmeaOutchoose
        {
            set { _nmeaoutchoose = value; }
            get { return _nmeaoutchoose; }
        }
        /// <summary>
        /// Ubx数据输出项
        /// </summary>
        public string UbxOutChoose
        {
            set { _ubxoutchoose = value; }
            get { return _ubxoutchoose; }
        }
        /// <summary>
        /// Sbp数据输出项
        /// </summary>
        public string SbpOutchoose
        {
            set { _sbpoutchoose = value; }
            get { return _sbpoutchoose; }
        }
        /// <summary>
        /// 固件版本日期
        /// </summary>
        public string Builddatetime
        {
            set { _builddatetime = value; }
            get { return _builddatetime; }
        }
        public string coordirateFormat
        {
            set { _coordirateFormat = value; }
            get { return _coordirateFormat; }
        }
    }
}
