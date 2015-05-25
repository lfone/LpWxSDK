namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 群发时，上传媒体消息时的返回实体
    /// </summary>
    public class GroupUpLoadEntity:ErrorEntity
    {
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb）
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 媒体文件/图文消息上传后获取的唯一标识
        /// </summary>
        public string media_id { get; set; }
    }
}
