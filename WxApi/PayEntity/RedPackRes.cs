namespace WxApi.PayEntity
{
    public class RedPackRes:BasePayRes
    {
        public string mch_billno{ get; set; }
        public string mch_id{ get; set; }
        public string wxappid{ get; set; }
        public string re_openid{ get; set; }
        public int total_amount{ get; set; }
        public string send_listid { get; set; }
        public string send_time { get; set; }
    }
}
