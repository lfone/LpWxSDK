using System;
using System.Collections.Generic;

namespace WxApi.ReceiveEntity.DataCube
{
    public class Details
    {
       /// <summary>
        /// 数据统计日期
       /// </summary>
        public DateTime stat_date { get; set; }
        /// <summary>
        /// 送达人数，一般约等于总粉丝数（需排除黑名单或其他异常情况下无法收到消息的粉丝）
        /// </summary>
        public int target_user { get; set; }
        /// <summary>
        /// 图文页（点击群发图文卡片进入的页面）的阅读人数
        /// </summary>
        public int int_page_read_user { get; set; }
        /// <summary>
        /// 图文页的阅读次数
        /// </summary>
        public int int_page_read_count { get; set; }
        /// <summary>
        /// 原文页（点击图文页“阅读原文”进入的页面）的阅读人数，无原文页时此处数据为0
        /// </summary>
        public int ori_page_read_user { get; set; }
        /// <summary>
        /// 原文页的阅读次数
        /// </summary>
        public int ori_page_read_count { get; set; }
        /// <summary>
        /// 分享的人数
        /// </summary>
        public int share_user { get; set; }
        /// <summary>
        /// 分享的次数
        /// </summary>
        public int share_count { get; set; }
        /// <summary>
        /// 收藏的人数
        /// </summary>
        public int add_to_fav_user { get; set; }
        /// <summary>
        /// 收藏的次数
        /// </summary>
        public int add_to_fav_count { get; set; }
    }

    public class ArticleTotal
    {
        public DateTime ref_date { get; set; }
        public string msgid { get; set; }
        public string title { get; set; }
        public List<Details> details { get; set; }
    }
    /// <summary>
    /// 图文群发每日数据
    /// </summary>
    public class ArticleTotals : ErrorEntity
    {
        public List<ArticleTotal> list { get; set; }
    }
}
