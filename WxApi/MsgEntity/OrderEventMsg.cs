namespace WxApi.MsgEntity
{
    /// <summary>
    /// 微信小店订单事件实体
    /// </summary>
    public class OrderEventMsg : EventMsg
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// SKU信息
        /// </summary>
        public string SkuInfo { get; set; }
    }
}
