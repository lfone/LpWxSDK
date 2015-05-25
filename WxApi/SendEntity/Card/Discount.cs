namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 折扣券
    /// </summary>
    public class Discount : BaseCard
    {
        /// <summary>
        /// 表示打折额度（百分比）。填 30 就是七折
        /// </summary>
        public int discount { get; set; }
    }
}
