namespace WxApi.PayEntity
{
    /// <summary>
    /// 查询订单状态，返回结果实体
    /// </summary>
    public class OrderQueryRes : OrderInfo
    {
        public string trade_state { get; set; }
        /// <summary>
        /// 交易状态描述 
        /// </summary>
        public string trade_state_desc { get; set; }
    }
}
