namespace WxApi.MsgEntity
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class LinkMsg : BaseMsg
    {
        /// <summary>
        /// 缩略图ID
        /// </summary>
        public string MsgId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }


    }
}
