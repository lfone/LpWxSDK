namespace WxApi.PayEntity
{
    /// <summary>
    /// 模式一扫描二维码回调
    /// </summary>
    public class NativeNotify:BasePay
    {
        /// <summary>
        /// 公用户在商户appid下的唯一标识
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 是否关注公众号
        /// </summary>
        public string is_subscribe { get; set; }
       /// <summary>
        ///  商品ID
       /// </summary>
        public string product_id { get; set; }
        /// <summary>
        ///  签名
        /// </summary>
        public string sign { get; set; }
    }
}
