using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.MsgEntity
{
    public class ViewCardEventMsg : EventMsg
    {
        public string card_id { get; set; }
        public string UserCardCode { get; set; }
    }
}
