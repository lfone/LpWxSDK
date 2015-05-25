using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.ReceiveEntity
{
    public class KfSessionStatus : ErrorEntity
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
        /// 正在接待的客服，为空表示没有人在接待
        /// </summary>
        public string kf_account { get; set; }
        /// <summary>
        /// 会话接入的时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
