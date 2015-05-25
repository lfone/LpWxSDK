namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 景点门票
    /// </summary>
    public class Scenic_Ticket : BaseCard
    {
       /// <summary>
        /// 票类型， 例如平日全票， 套票等。
       /// </summary>
        public string ticket_class { get; set; }
       /// <summary>
        /// 导览图 url 
       /// </summary>
        public string guide_url { get; set; }
    }
}
