namespace WxApi.MsgEntity
{
    /// <summary>
    /// 上报地理位置
    /// </summary>
    public class LocationEventMsg:EventMsg
    {
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 地理位置精度
        /// </summary>
        public string Precision { get; set; }
    }
}
