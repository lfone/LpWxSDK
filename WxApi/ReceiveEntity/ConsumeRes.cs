namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 核销卡券响应实体
    /// </summary>
    public class ConsumeRes:ErrorEntity
    {
        public CardId card { get; set; }
        public string openid { get; set; }
    }

    public class CardId
    {
        public string card_id { get; set; }
    }
}
