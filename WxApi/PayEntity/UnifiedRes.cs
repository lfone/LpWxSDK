namespace WxApi.PayEntity
{
    /// <summary>
    /// 调用统一支付接口后，返回的实体
    /// </summary>
    public class UnifiedRes : BasePayRes
    {
        /// <summary>
        /// 设备号
        /// </summary>
        public string device_info { get; set; }
        /// <summary>
        /// 预支付ID
        /// </summary>
        public string prepay_id { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 二维码链接
        /// </summary>
        public string code_url { get; set; }
    }
}
