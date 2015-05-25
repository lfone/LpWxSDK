namespace WxApi.PayEntity
{
    /// <summary>
    /// 撤销接口返回实体
    /// </summary>
    public class ReverseRes : BasePayRes
    {
        /// <summary>
        /// 是否需要继续调用撤销，Y-需要，N-不需要
        /// </summary>
        public string recall { get; set; }
    }
}
