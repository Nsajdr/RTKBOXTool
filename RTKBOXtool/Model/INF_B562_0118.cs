using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTKBOXtool.Model
{
    /// <summary>
    /// B5620118流动站数据实体类
    /// </summary>
    public class INF_B562_0118
    {
        private int _BiGPSWeek;
        private double _BdRoverSecond;
        private double _ecefX;
        private double _ecefY;
        private double _ecefZ;
        private uint _Bn;
        private int _RiGpsWeek;
        private double _RdRoverSecond;
        private double _RecefX;
        private double _RecefY;
        private double _RecefZ;
        private double _speeedofRecefX;
        private double _speedofRecefY;
        private double _speeedofRecefZ;
        private float _age;
        private float _ratio;
        private byte _stat;
        private byte _Rsetn;
        private byte _Rusen;
        private ulong _usetime;
        /// <summary>
        /// 基准站Gps周
        /// </summary>
        public int BiGpsWeek
        {
            set { _BiGPSWeek = value; }
            get { return _BiGPSWeek; }
        }
        /// <summary>
        /// 流动站秒速
        /// </summary>
        public double BdRoverSencond
        {
            set { _BdRoverSecond = value; }
            get { return _BdRoverSecond; }
        }
        /// <summary>
        /// 基准站ECEFx坐标
        /// </summary>
        public double EcefX
        {
            set { _ecefX = value; }
            get { return _ecefX; }
        }
        /// <summary>
        /// 基准站ECEFy坐标
        /// </summary>
        public double EcefY
        {
            set { _ecefY = value; }
            get { return _ecefY; }
        }
        /// <summary>
        /// 基准站ecefZ坐标
        /// </summary>
        public double EcefZ
        {
            set { _ecefZ = value; }
            get { return _ecefZ; }
        }
        /// <summary>
        /// 基准站接收卫星数
        /// </summary>
        public uint Bn
        {
            set { _Bn = value; }
            get { return _Bn; }
        }
        /// <summary>
        /// 流动站GPS周
        /// </summary>
        public int RiGpsWeek
        {
            set { _RiGpsWeek = value; }
            get { return _RiGpsWeek; }
        }
        /// <summary>
        /// 流动站秒数
        /// </summary>
        public double RdRoverSecond
        {
            set { _RdRoverSecond = value; }
            get { return _RdRoverSecond;}
        }
        /// <summary>
        /// 流动站X坐标
        /// </summary>
        public double Recefx
        {
            set { _RecefX = value; }
            get { return _RecefX; }
        }
        /// <summary>
        /// 流动站Y坐标
        /// </summary>
        public double RecefY
        {
            set { _RecefY = value; }
            get { return _RecefY; }
        }
        /// <summary>
        /// 流动站Z坐标
        /// </summary>
        public double Recefz
        {
            set { _RecefZ = value; }
            get { return _RecefZ; }
        }
        /// <summary>
        ///  流动站Y速度
        /// </summary>
        public double speed0fRecefY
        {
            set { _speedofRecefY = value; }
            get { return _speedofRecefY; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float age
        {
            set { _age = value; }
            get { return _age; }
        }
        public float ratio
        {
            set { _ratio = value; }
            get { return _ratio; }
        }
        /// <summary>
        /// 流动站状态
        /// </summary>
        public byte stat
        {
            set { _stat = value; }
            get { return _stat; }
        }
        /// <summary>
        /// 接收卫星数
        /// </summary>
        public byte Rsetn
        {
            set { _Rsetn = value; }
            get { return _Rsetn; }
        }
        /// <summary>
        /// 使用卫星数
        /// </summary>
        public byte Rusen
        {
            set { _Rusen = value; }
            get { return _Rusen; }
        }
        /// <summary>
        /// 运算使用时间
        /// </summary>
        public ulong usetime
        {
            set { _usetime = value; }
            get { return _usetime; }
        }
        /// <summary>
        /// 流动站X速度
        /// </summary>
        public double SpeeedofRecefX
        {
            set { _speeedofRecefX = value; }
            get { return _speeedofRecefX; }
        }
        /// <summary>
        /// 流动站Z速度
        /// </summary>
        public double SpeeedofRecefZ
        {
            set { _speeedofRecefZ = value; }
            get { return _speeedofRecefZ; }
        }
    }
}
