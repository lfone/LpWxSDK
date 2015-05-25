namespace WxApi.PayEntity
{
    /// <summary>
    /// 企业付款实体
    /// </summary>
    public class EPaymentRes : BasePayRes
    {
        public string mch_appid { get; set; }
        public string mchid { get; set; }
        public string device_info { get; set; }
        public string nonce_str { get; set; }
        public string partner_trade_no { get; set; }
        public string payment_no { get; set; }
        public string payment_time { get; set; }
    }
}
