using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    public class CardInfo:ErrorEntity
    {
        public Dictionary<string, object> card { get; set; }
    }
}
