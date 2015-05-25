namespace WxApi.PayEntity
{
    public class NativeRes:BasePayRes
    {
        /// <summary>
        /// 调用统一支付接口生成的预支付 ID
        /// </summary>
        public string prepay_id { get; set; }
    }
}
