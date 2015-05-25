namespace WxApi.MsgEntity
{
    /// <summary>
    /// 文本实体
    /// </summary>
    public class TextMsg : BaseMsg
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
    }
}
