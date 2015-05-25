using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi
{
    /// <summary>
    /// 消息类型枚举
    /// </summary>
    public enum MsgType
    {
        /// <summary>
        ///文本类型
        /// </summary>
        TEXT,
        /// <summary>
        /// 图片类型
        /// </summary>
        IMAGE,
        /// <summary>
        /// 语音类型
        /// </summary>
        VOICE,
        /// <summary>
        /// 视频类型
        /// </summary>
        VIDEO,
        /// <summary>
        /// 地理位置类型
        /// </summary>
        LOCATION,
        /// <summary>
        /// 链接类型
        /// </summary>
        LINK,
        /// <summary>
        /// 事件类型
        /// </summary>
        EVENT
    }
}
