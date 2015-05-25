using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi
{
    /// <summary>
    /// 素材类型枚举
    /// </summary>
    public enum MaterialType
    {
        /// <summary>
        /// 图片（image）: 2M，支持bmp/png/jpeg/jpg/gif格式
        /// </summary>
        image,
        /// <summary>
        /// 语音（voice）：5M，播放长度不超过60s，支持mp3/wma/wav/amr格式
        /// </summary>
        voice,
        /// <summary>
        /// 视频（video）：20MB，支持rm, rmvb, wmv, avi, mpg, mpeg, mp4格式
        /// </summary>
        video,
        /// <summary>
        /// 缩略图（thumb）：64KB，支持JPG格式
        /// </summary>
        thumb,
        /// <summary>
        /// 图文
        /// </summary>
        news
    }
}
