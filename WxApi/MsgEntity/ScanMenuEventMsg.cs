namespace WxApi.MsgEntity
{
    /// <summary>
    /// 扫码菜单实体
    /// </summary>
    public class ScanMenuEventMsg : BaseMenuEventMsg
    {
        /// <summary>
        /// 扫描类型，一般是qrcode
        /// </summary>
        public string ScanType { get; set; }
        /// <summary>
        /// 扫描结果，即二维码对应的字符串信息
        /// </summary>
        public string ScanResult { get; set; }
    }
}
