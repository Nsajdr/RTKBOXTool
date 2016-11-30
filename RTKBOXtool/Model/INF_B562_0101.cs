namespace RTKBOXtool.Model
{
    /// <summary>
    /// B5620101基准站坐标信息实体类
    /// </summary>
    public class INF_B562_0101
    {
        private ulong _itow;
        private long _ecefX;
        private long _ecefY;
        private long _ecefZ;
        private ulong _pacc;
        /// <summary>
        /// 周时 GPS time of week of the navigation epoch
        /// </summary>
        public ulong iTOW
        {
            set { _itow = value; }
            get { return _itow; }
        }
        /// <summary>
        /// ECEF X 坐标
        /// </summary>
        public long ecefX
        {
            set { _ecefX = value; }
            get { return _ecefX; }
        }
        /// <summary>
        /// ECEF Y 坐标
        /// </summary>
        public long ecefY
        {
            set { _ecefY = value; }
            get { return _ecefY; }
        }
        /// <summary>
        /// ECEF Z 坐标
        /// </summary>
        public long ecefZ
        {
            set { _ecefZ = value; }
            get { return _ecefZ; }
        }
        /// <summary>
        /// 位置精度
        /// </summary>
        public ulong pacc
        {
            set { _pacc = value; }
            get { return _pacc; }
        }
    }
}
