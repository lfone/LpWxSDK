namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 会员卡
    /// </summary>
    public class Member_Card : BaseCard
    {
        /// <summary>
        /// 是否支持积分。如填写 true，积分相关字段均为必填。填写 false，积分字段无需填写。 储值字段处理方式相同。
        /// </summary>
        public bool supply_bonus { get; set; }
        /// <summary>
        /// 是否支持储值，填写 true 或false。
        /// </summary>
        public bool supply_balance { get; set; }
        /// <summary>
        /// 积分清零规则
        /// </summary>
        public string bonus_cleared { get; set; }
        /// <summary>
        /// 积分规则
        /// </summary>
        public string bonus_rules { get; set; }
        /// <summary>
        /// 储值说明
        /// </summary>
        public string balance_rules { get; set; }
        /// <summary>
        /// 特权说明
        /// </summary>
        public string prerogative { get; set; }
        /// <summary>
        /// 绑定旧卡的 url，与“activate_url”字段二选一必填。
        /// </summary>
        public string bind_old_card_url { get; set; }
        /// <summary>
        /// 激活会员卡的 url，与“bind_old_card_url”字段二选一必填。
        /// </summary>
        public string activate_url { get; set; }
        /// <summary>
        /// 用户点击进入会员卡时是否推送事件
        /// </summary>
        public bool need_push_on_view { get; set; }
    }
}
