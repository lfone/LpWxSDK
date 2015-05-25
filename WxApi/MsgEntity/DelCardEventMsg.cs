using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.MsgEntity
{
    public class DelCardEventMsg : EventMsg
    {
        public string card_id { get; set; }
        /// <summary>
        /// 商户自定义code值。非自定 code 推送为空串。
        /// </summary>
        public string UserCardCode { get; set; }

    }
}
