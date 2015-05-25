namespace WxApi.SendEntity
{
    public class ResArticle
    {
        /// <summary>
        /// 消息的标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 消息的描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        public string Url { get; set; }
    }
}
