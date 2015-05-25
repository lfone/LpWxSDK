namespace WxApi.MsgEntity
{
    public class TemplateJobEventMsg:BaseMsg
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgID { get; set; }
        /// <summary>
        /// 发送状态
        /// </summary>
        public string Status { get; set; }
    }
}
