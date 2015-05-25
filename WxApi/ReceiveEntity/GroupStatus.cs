namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 群发状态
    /// </summary>
    public class GroupStatus : ErrorEntity
    {
        /// <summary>
        /// 群发消息后返回的消息id
        /// </summary>
        public string msg_id { get; set; }
        /// <summary>
        /// 消息发送后的状态，SEND_SUCCESS表示发送成功
        /// </summary>
        public string msg_status { get; set; }
    }
}
