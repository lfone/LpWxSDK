namespace WxApi.MsgEntity
{
    /// <summary>
    /// 群发消息推送
    /// </summary>
    public class GroupJobEventMsg:EventMsg
    {
        /// <summary>
        /// 群发的消息ID
        /// </summary>
        public string MsgID { get; set; }
        /// <summary>
        /// 发送状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// group_id下粉丝数；或者openid_list中的粉丝数
        /// </summary>
        public string TotalCount { get; set; }
        /// <summary>
        /// 过滤（过滤是指特定地区、性别的过滤、用户设置拒收的过滤，用户接收已超4条的过滤）后，准备发送的粉丝数，原则上，FilterCount = SentCount + ErrorCount
        /// </summary>
        public string FilterCount { get; set; }
        /// <summary>
        /// 发送成功的粉丝数
        /// </summary>
        public string SentCount { get; set; }
        /// <summary>
        /// 发送失败的粉丝数
        /// </summary>
        public string ErrorCount { get; set; }
    }
}
