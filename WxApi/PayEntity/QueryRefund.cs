namespace WxApi.PayEntity
{
   public class QueryRefund:BasePay
    {
        public string transaction_id { get; set; }
        public string out_trade_no { get; set; }
        public string device_info { get; set; }
        public string out_refund_no { get; set; }
        public string refund_id { get; set; }
        public string sign { get; set; }
    }
}
