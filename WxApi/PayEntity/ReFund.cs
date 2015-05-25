namespace WxApi.PayEntity
{
    /// <summary>
    /// 退款请求实体
    /// </summary>
    public class ReFund:BasePay
    {
        /// <summary>
        /// 设备号
        /// </summary>
        public string device_info { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string out_refund_no { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public int refund_fee { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string op_user_id { get; set; }
        /// <summary>
        /// 货币种类 
        /// </summary>
        public string refund_fee_type { get; set; }
    }
}
