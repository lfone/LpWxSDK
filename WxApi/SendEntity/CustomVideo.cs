namespace WxApi.SendEntity
{
    /// <summary>
    /// 客服视频消息实体
    /// </summary>
   public class CustomVideo
    {
       /// <summary>
       /// 媒体ID
       /// </summary>
        public string media_id { get; set; }
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
