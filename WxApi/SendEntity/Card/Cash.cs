namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 代金券
    /// </summary>
    public class Cash : BaseCard
    {
        /// <summary>
        /// 代金券专用，表示起用金额（单位为分）
        /// </summary>
        public int? least_cost { get; set; }
        /// <summary>
        /// 代金券专用，表示减免金额（单位为分）
        /// </summary>
        public int reduce_cost { get; set; }
    }
}
