namespace WxApi.MsgEntity
{
    /// <summary>
    /// 扫描带参数二维码事件数据实体
    /// </summary>
    public class ScanQrEventMsg:EventMsg
    {
        /// <summary>
        /// 事件KEY值
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
}
