namespace WxApi.PayEntity
{
    /// <summary>
    /// 发放代金券实体
    /// </summary>
    public class SendCoupon : BasePay
    {

        /// <summary>
        /// 代金券批次ID
        /// </summary>
        public string coupon_stock_id { get; set; }
        /// <summary>
        /// openid记录数（目前支持num=1）
        /// </summary>
        public int openid_count { get; set; }
        /// <summary>
        /// 商户此次发放凭据号（格式：商户id+日期+流水号），商户侧需保持唯一性
        /// </summary>
        public string partner_trade_no { get; set; }
        public string openid { get; set; }
        /// <summary>
        /// 子商户号
        /// </summary>
        public string sub_mch_id { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string op_user_id { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string device_info { get; set; }

        public string sign { get; set; }
        /// <summary>
        /// 协议版本  默认1.0
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 协议类型 XML【目前仅支持默认XML】
        /// </summary>
        public string type { get; set; }
    }
}
