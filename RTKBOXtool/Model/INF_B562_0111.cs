namespace RTKBOXtool.Model
{
    /// <summary>
    /// B5620111用户设置基站站坐标信息实体类
    /// </summary>
    public class INF_B562_0111
    {
        private double _SetX;
        private double _SetY;
        private double _SetZ;
        /// <summary>
        /// 用户设置X坐标
        /// </summary>
        public double SetX
        {
            set { _SetX = value; }
            get { return _SetX; }
        }
        /// <summary>
        /// 用户设置Y坐标
        /// </summary>
        public double SetY
        {
            set { _SetY = value; }
            get { return _SetY; }
        }
        /// <summary>
        /// 用户设置Z坐标
        /// </summary>
        public double SetZ
        {
            set { _SetZ = value; }
            get { return _SetZ; }
        }
    }
}
