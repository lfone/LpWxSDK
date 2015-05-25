namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 卡券扩展字段
    /// </summary>
   public class CardExt
    {
        public string code { get; set; }
        public string openid { get; set; }
        public string timestamp { get; set; }
        public string signature { get; set; }
        /// <summary>
        /// 红包余额，以分为单位。红包类型必填（LUCKY_MONEY），其他卡券类型不填。
        /// </summary>
        public string balance { get; set; }

        public string api_ticket { get; set; }
        public string card_id { get; set; }
    }
}
