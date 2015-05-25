namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 飞机票
    /// </summary>
    public class Boarding_Pass : BaseCard
    {
        /// <summary>
        /// 起点
        /// </summary>
        public string from { get; set; }
        /// <summary>
        /// 终点
        /// </summary>
        public string to { get; set; }
        /// <summary>
        /// 航班
        /// </summary>
        public string flight { get; set; }
        /// <summary>
        /// 起飞时间。 Unix时间戳格式
        /// </summary>
        public string departure_time { get; set; }
        /// <summary>
        /// 降落时间。 Unix时间戳格式
        /// </summary>
        public string landing_time { get; set; }

        /// <summary>
        /// 在线值机的链接
        /// </summary>
        public string check_in_url { get; set; }
        /// <summary>
        /// 登机口
        /// </summary>
        public string gate { get; set; }
        /// <summary>
        /// 登机时间，只显示“时分”不显示日期。按时间戳格式填写。如发生登记时间变更，建议商家实时调用本接口变更
        /// </summary>
        public string boarding_time{ get; set; }
        /// <summary>
        /// 机型。  不超过8个汉字
        /// </summary>
        public string air_model { get; set; }
    }
}
