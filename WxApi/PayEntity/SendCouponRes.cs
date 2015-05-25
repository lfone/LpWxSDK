namespace WxApi.PayEntity
{
    public class SendCouponRes : BasePayRes
    {
        public string appid { get; set; }
        public string mch_id { get; set; }
        public string sub_mch_id { get; set; }
        public string device_info { get; set; }
        public string nonce_str { get; set; }
        public string coupon_stock_id { get; set; }
        public int resp_count { get; set; }
        public int success_count { get; set; }
        public int failed_count { get; set; }
        public string openid { get; set; }
        public string ret_code { get; set; }
        public string coupon_id { get; set; }
        public string ret_msg { get; set; }
    }
}
