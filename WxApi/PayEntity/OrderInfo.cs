using System.Collections.Generic;

namespace WxApi.PayEntity
{
    public class OrderInfo:BasePayRes
    {
      
        public string openid { get; set; }
        /// <summary>
        /// 是否订阅
        /// </summary>
        public string is_subscribe { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 付款银行
        /// </summary>
        public string bank_type { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 代金券或立减优惠金额 
        /// </summary>
        public string coupon_fee { get; set; }
        /// <summary>
        /// 代金券或立减优惠使用数量 
        /// </summary>
        public string coupon_count { get; set; }

        /// <summary>
        /// 货币种类
        /// </summary>
        public string fee_type { get; set; }
        /// <summary>
        /// 微信支付订单号
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商家数据包
        /// </summary>
        public string attach { get; set; }
        /// <summary>
        /// 支付完成时间
        /// </summary>
        public string time_end { get; set; }
        /// <summary>
        /// 现金支付金额 
        /// </summary>
        public int cash_fee { get; set; }

        public string cash_fee_type { get; set; }
        public List<CouponInfo> CouponInfo { get; set; }
    }
    /// <summary>
    /// 代金券或立减优惠实体
    /// </summary>
    public class CouponInfo
    {
        /// <summary>
        /// 代金券或立减优惠批次ID
        /// </summary>
        public string coupon_batch_id { get; set; }
        /// <summary>
        ///代金券或立减优惠ID
        /// </summary>
        public string coupon_id { get; set; }
        /// <summary>
        /// 单个代金券或立减优惠支付金额
        /// </summary>
        public int coupon_fee { get; set; }
    }
}
