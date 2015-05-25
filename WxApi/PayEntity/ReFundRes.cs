namespace WxApi.PayEntity
{
    /// <summary>
    /// 退款请求返回的实体类
    /// </summary>
    public class ReFundRes:BasePayRes
    {
        /// <summary>
        /// 设备号 
        /// </summary>
        public string device_info { get; set; }
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
        /// 微信退款单号 
        /// </summary>
        public string refund_id { get; set; }
        /// <summary>
        /// 退款渠道  ORIGINAL—原路退款   BALANCE—退回到余额
        /// </summary>
        public string refund_channel{ get; set; }
        /// <summary>
        /// 退款金额 
        /// </summary>
        public int refund_fee { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 订单金额货币种类 
        /// </summary>
        public string fee_type{ get; set; }
        /// <summary>
        /// 现金支付金额 
        /// </summary>
        public int cash_fee { get; set; }
        /// <summary>
        /// 现金退款金额 
        /// </summary>
        public int cash_refund_fee { get; set; }
        /// <summary>
        /// 代金券或立减优惠退款金额 
        /// </summary>
        public int coupon_refund_fee { get; set; }
        /// <summary>
        /// 代金券或立减优惠使用数量 
        /// </summary>
        public int coupon_refund_count{ get; set; }
        /// <summary>
        /// 代金券或立减优惠ID 
        /// </summary>
        public string coupon_refund_id { get; set; }
    }
}
