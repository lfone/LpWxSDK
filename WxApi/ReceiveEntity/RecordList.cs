using System;
using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 客服聊天记录接口实体
    /// </summary>
    public class RecordList : ErrorEntity
    {
        public List<RecordInfo> recordlist { get; set; }
    }
    public class RecordInfo
    {
        /// <summary>
        /// 客服账号
        /// </summary>
        public string worker { get; set; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string openid { get; set; }

        private string _opercode;

        /// <summary>
        /// 操作ID（会话状态）
        /// </summary>
        public string opercode
        {
            get { return _opercode; }
            set
            {
                switch (value)
                {
                    case "1000": operstr = "创建未接入会话"; break;
                    case "1001": operstr = "接入会话"; break;
                    case "1002": operstr = "主动发起会话"; break;
                    case "1004": operstr = "抢接会话"; break;
                    case "1005": operstr = "抢接会话"; break;
                    case "2001": operstr = "公众号收到消息"; break;
                    case "2002": operstr = "客服发送消息"; break;
                    case "2003": operstr = "客服收到消息"; break;

                }
                _opercode = value;
            }
        }
        /// <summary>
        /// 会话状态描述
        /// </summary>
        public string operstr { get; set; }

        /// <summary>
        /// 操作时间，UNIX时间戳
        /// </summary>
        public int time
        {
            get { return Utils.ConvertDateTimeInt(Time); }
            set { Time = Utils.UnixTimeToTime(value.ToString()); }
        }
        public DateTime Time { get; set; }
        /// <summary>
        /// 聊天记录
        /// </summary>
        public string text { get; set; }
    }
}
