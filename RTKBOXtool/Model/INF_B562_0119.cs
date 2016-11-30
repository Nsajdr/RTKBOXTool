namespace RTKBOXtool.Model
{
    /// <summary>
    /// B5620119 RTKBox配置信息实体类
    /// </summary>
    public class INF_B562_0119
    {
        private byte _stationtype;
        private byte _outputtype;
        private byte _rtkrate;
        private byte _gnsstype;
        private byte _rtkmode;
        private byte _rtkoutputbaudrate;
        private byte _enableflag;
        private ushort _netID;
        private ushort _channels;
        private byte _radiobaudrate;
        private byte _nmeaoutchoose;
        private byte _ubxoutchoose;
        private byte _sbpoutchoose;
        private string _builddatetime;
        private string _coordirateFormat;
        /// <summary>
        /// 机器模式
        /// </summary>
        public byte Stationtype
        {
            set { _stationtype = value; }
            get { return _stationtype; }
        }
        /// <summary>
        /// 输出协议
        /// </summary>
        public byte Outputtype
        {
            set { _outputtype = value; }
            get { return _outputtype; }
        }
        /// <summary>
        /// 定位频度
        /// </summary>
        public byte Rtkrate
        {
            set { _rtkrate = value; }
            get { return _rtkrate; }
        }
        /// <summary>
        /// GNSS模式
        /// </summary>
        public byte Gnsstype
        {
            set { _gnsstype = value; }
            get { return _gnsstype; }
        }
        /// <summary>
        /// RTK模式
        /// </summary>
        public byte Rtkmode
        {
            set { _rtkmode = value; }
            get { return _rtkmode; }
        }
        /// <summary>
        /// RTK输出波特率
        /// </summary>
        public byte Rtkoutputrate
        {
            set { _rtkoutputbaudrate = value; }
            get { return _rtkoutputbaudrate; }
        }
        /// <summary>
        /// 内置数传是否打开
        /// </summary>
        public byte enableFlag
        {
            set { _enableflag = value; }
            get { return _enableflag; }
        }
        /// <summary>
        /// 内置数传NetID
        /// </summary>
        public ushort NetID
        {
            set { _netID = value; }
            get { return _netID; }
        }
        /// <summary>
        /// 内置数传频道
        /// </summary>
        public ushort channels
        {
            set { _channels = value; }
            get { return _channels; }
        }
        /// <summary>
        /// 外置数传波特率
        /// </summary>
        public byte RadioBaudrate
        {
            set { _radiobaudrate = value; }
            get { return _radiobaudrate; }
        }
        /// <summary>
        /// Nmea数据输出项
        /// </summary>
        public byte NmeaOutchoose
        {
            set { _nmeaoutchoose = value; }
            get { return _nmeaoutchoose; }
        }
        /// <summary>
        /// Ubx数据输出项
        /// </summary>
        public byte UbxOutChoose
        {
            set { _ubxoutchoose = value; }
            get { return _ubxoutchoose; }
        }
        /// <summary>
        /// Sbp数据输出项
        /// </summary>
        public byte SbpOutchoose
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
