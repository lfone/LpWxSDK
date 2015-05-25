using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 卡ID列表
    /// </summary>
    public class CardIds:ErrorEntity
    {
        public List<string> card_id_list { get; set; }
        public int total_num { get; set; }
    }
}
