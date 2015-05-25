using System;
using System.Collections.Generic;

namespace WxApi.ReceiveEntity.DataCube
{
    public class ArticleUserRead
    {
       /// <summary>
        /// 数据的日期，需在begin_date和end_date之间
       /// </summary>
        public DateTime ref_date { get; set; }
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
    /// <summary>
    /// 图文群发每日数据
    /// </summary>
    public class ArticleUserReads : ErrorEntity
    {
        public List<ArticleUserRead> list { get; set; }
    }
}
