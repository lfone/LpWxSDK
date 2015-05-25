namespace WxApi.PayEntity
{
    /// <summary>
    ///native支付二维码生成参数
    /// </summary>
    public class NativeEntity:BasePay
    {
        
        /// <summary>
        /// 时间戳
        /// </summary>
        public string time_stamp { get; set; }
        
       /// <summary>
        ///  商品ID
       /// </summary>
        public string product_id { get; set; }
    }
}
