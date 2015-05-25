namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 群发接口返回值
    /// </summary>
    public class GroupSendEntity : ErrorEntity
    {
        /// <summary>
        ///消息ID
        /// </summary>
        public string msg_id { get; set; }
    }
}
