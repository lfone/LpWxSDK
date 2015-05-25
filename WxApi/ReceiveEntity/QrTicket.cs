namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 创建二维码时，返回实体
    /// </summary>
   public class QrTicket:ErrorEntity
    {
       /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
       /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 二维码的有效时间，以秒为单位。最大不超过1800。
        /// </summary>
        public int expire_seconds { get; set; }
        /// <summary>
        /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片
        /// </summary>  
        public string url { get; set; }
    }
}
