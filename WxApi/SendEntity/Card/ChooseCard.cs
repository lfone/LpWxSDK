namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 卡券签名cardSign参数实体
    /// </summary>
    public class ChooseCard
    {
        public string app_id { get; set; }
        public string location_id { get; set; }
        public string times_tamp { get; set; }
        public string nonce_str { get; set; }
        public string card_id { get; set; }
        public string card_type { get; set; }
        public string api_ticket { get; set; }
        public string signature { get; set; }
    }
}
