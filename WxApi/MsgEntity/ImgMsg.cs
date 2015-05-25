namespace WxApi.MsgEntity
{
    public class ImgMsg : BaseMsg
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
        /// <summary>
        /// 媒体ID
        /// </summary>
        public string MediaId { get; set; }
    }
}
