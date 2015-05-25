namespace WxApi.SendEntity
{
    /// <summary>
    /// 客服音乐消息实体
    /// </summary>
    public class CustomMusic
    {
        /// <summary>
        /// 音乐链接
        /// </summary>
        public string musicurl { get; set; }
        /// <summary>
        /// 高品质音乐链接，wifi环境优先使用该链接播放音乐
        /// </summary>
        public string hqmusicurl { get; set; }
        /// <summary>
        /// 缩略图ID
        /// </summary>
        public string thumb_media_id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
    }
}
