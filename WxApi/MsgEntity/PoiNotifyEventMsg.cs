using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.MsgEntity
{
   public class PoiNotifyEventMsg:EventMsg
    {
        /// <summary>
        /// 商户自己内部 ID，即字段中的 sid
        /// </summary>
        public string UniqID { get; set; }
        /// <summary>
        /// 微信的门店 ID，微信内门店唯一标示 ID
        /// </summary>
        public string PoiId { get; set; }
        /// <summary>
        /// 审核结果，成功 succ 或失败 fail
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 成功的通知信息，或审核失败的驳回理由
        /// </summary>
        public string Msg { get; set; }
    }
}
