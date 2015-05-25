namespace WxApi.PayEntity
{
    /// <summary>
    /// 微信支付接口请求实体。 包括查询、撤销
    /// </summary>
    public class QueryOrder:BasePay
    {
        /// <summary>
        /// 微信的订单号，优先使用
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// 商户系统内部的订单号,transaction_id、 out_trade_no 二选一，如果同时存在优先级：transaction_id> out_trade_no
        /// </summary>
        public string out_trade_no { get; set; }
        public string sign { get; set; }
    }
}
