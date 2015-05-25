using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi
{
    /// <summary>
    /// 卡券类型枚举
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// 通用券
        /// </summary>
        GENERAL_COUPON,
        /// <summary>
        /// 团购券
        /// </summary>
        GROUPON,
        /// <summary>
        /// 折扣券
        /// </summary>
        DISCOUNT,
        /// <summary>
        /// 礼品券
        /// </summary>
        GIFT,
        /// <summary>
        /// 代金券
        /// </summary>
        CASH,
        /// <summary>
        /// 会员卡
        /// </summary>
        MEMBER_CARD,
        /// <summary>
        /// 景点门票
        /// </summary>
        SCENIC_TICKET,
        /// <summary>
        /// 电影票
        /// </summary>
        MOVIE_TICKET,
        /// <summary>
        /// 飞机票
        /// </summary>
        BOARDING_PASS,
        /// <summary>
        /// 红包
        /// </summary>
        LUCKY_MONEY,
        /// <summary>
        /// 会议门票
        /// </summary>
        MEETING_TICKET
    }
}
