namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 会员卡交易接口返回实体
    /// </summary>
    public class MemberCardResult : ErrorEntity
    {
        /// <summary>
        /// 当前用户积分总额
        /// </summary>
        public int result_bonus { get; set; }
        /// <summary>
        /// 当前用户预存总金额
        /// </summary>
        public int result_balance { get; set; }
        /// <summary>
        /// 用户 openid
        /// </summary>
        public int openid { get; set; }
    }
}
