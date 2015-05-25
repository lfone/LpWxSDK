namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 获取二维码ticket时返回的实体
    /// </summary>
    public class CardQrTicket:ErrorEntity
    {
        /// <summary>
        /// 获取二维码的ticket。凭借此ticket可以在有效时间内换取二维码
        /// </summary>
        public string ticket { get; set; }
    }
}
