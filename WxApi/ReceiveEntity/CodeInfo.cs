using System;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// code信息
    /// </summary>
    public class CodeInfo
    {
        public CardValid card { get; set; }
        public string openid { get; set; }
    }

    public class CardValid
    {
        public string card_id { get; set; }
        public int begin_time { get; set; }

        public DateTime BeginTime
        {
            get { return Utils.UnixTimeToTime(begin_time.ToString()); }

        }
        public DateTime EndTime
        {
            get { return Utils.UnixTimeToTime(end_time.ToString()); }

        }
        public int end_time { get; set; }
    }
}
