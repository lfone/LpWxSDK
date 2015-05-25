namespace WxApi.PayEntity
{
    /// <summary>
    /// 被扫支付接口
    /// </summary>
    public class ScanPayEntity:BasePay
    {
        public string device_info { get; set; }
        public string sign { get; set; }
        public string body { get; set; }
        public string detail { get; set; }
        public string attach { get; set; }
        public string out_trade_no { get; set; }
        public string total_fee { get; set; }
        public string fee_type { get; set; }
        public string spbill_create_ip { get; set; }
        public string time_start { get; set; }
        public string time_expire { get; set; }
        public string goods_tag { get; set; }
        public string auth_code { get; set; }
    }
}
