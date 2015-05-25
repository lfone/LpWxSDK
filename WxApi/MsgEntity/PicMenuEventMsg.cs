using System.Collections.Generic;

namespace WxApi.MsgEntity
{
    /// <summary>
    /// 菜单发送图片实体
    /// </summary>
    public class PicMenuEventMsg : BaseMenuEventMsg
    {
        /// <summary>
        /// 发送的图片数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 图片的MD5集合
        /// </summary>
        public List<string> PicMd5SumList { get; set; }
    }
}
