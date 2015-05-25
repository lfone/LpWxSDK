using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 客服会话列表
    /// </summary>
    public class KfSessionList:ErrorEntity
    {
        public List<SessionInfo> sessionlist { get; set; }
    }
    public class SessionInfo
    {
        /// <summary>
        /// 会话接入的时间，Unix时间戳
        /// </summary>
        public int createtime
        {
            get { return Utils.ConvertDateTimeInt(CreateTime); }
            set { CreateTime = Utils.UnixTimeToTime(value.ToString()); }
        }
        /// <summary>
        /// 会话接入的时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public string openid { get; set; }


    }
}
