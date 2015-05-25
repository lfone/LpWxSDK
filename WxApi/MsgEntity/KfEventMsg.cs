namespace WxApi.MsgEntity
{
    /// <summary>
    /// 客服会话状态消息推送
    /// </summary>
    public class KfEventMsg:EventMsg
    {
        /// <summary>
        /// 客服工号
        /// </summary>
        public string KfAccount { get; set; }
    }
}
