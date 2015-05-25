using System;
using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 未接入会话列表
    /// </summary>
    public class WaitCaseList:ErrorEntity
    {
        public List<WaitCaseInfo> sessionlist { get; set; }
    }
    public class WaitCaseInfo
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
        /// 用户来访时间，UNIX时间戳
        /// </summary>
        public DateTime CreateTime { get; set; }
        public string openid { get; set; }
        /// <summary>
        /// 指定接待的客服，为空表示未指定客服
        /// </summary>
        public string kf_account { get; set; }


    }
}
