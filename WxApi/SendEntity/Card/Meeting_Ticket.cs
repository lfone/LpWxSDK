namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 会议门票
    /// </summary>
    public class Meeting_Ticket : BaseCard
    {
       /// <summary>
       /// 会议详情
       /// </summary>
        public string meeting_detail { get; set; }
       /// <summary>
       /// 会场导览图
       /// </summary>
        public string map_url { get; set; }
    }
}
