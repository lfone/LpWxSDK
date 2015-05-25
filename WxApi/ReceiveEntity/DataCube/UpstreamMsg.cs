using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.ReceiveEntity.DataCube
{
    public class UpstreamMsg
    {
        public DateTime ref_date { get; set; }
        /// <summary>
        /// 消息类型，代表含义如下：1代表文字 2代表图片 3代表语音 4代表视频 6代表第三方应用消息（链接消息）
        /// </summary>
        public int msg_type { get; set; }
        /// <summary>
        /// 上行发送了（向公众号发送了）消息的用户数
        /// </summary>
        public int msg_user { get; set; }
        /// <summary>
        /// 上行发送了消息的消息总数
        /// </summary>
        public int msg_count { get; set; }
    }
    /// <summary>
    /// 消息发送概况数据
    /// </summary>
    public class UpstreamMsgs
    {
        public List<UpstreamMsg> list { get; set; }
    }
}
