using System;
using System.Collections.Generic;

namespace WxApi.ReceiveEntity.DataCube
{
    public class ArticleUserReadHour
    {
       /// <summary>
        /// 数据的日期，需在begin_date和end_date之间
       /// </summary>
        public DateTime ref_date { get; set; }
        /// <summary>
        /// 数据的小时，包括从000到2300，分别代表的是[000,100)到[2300,2400)，即每日的第1小时和最后1小时
        /// </summary>
        public int ref_hour { get; set; }
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
    /// 图文统计分时数据
    /// </summary>
    public class ArticleUserReadHours : ErrorEntity
    {
        public List<ArticleUserReadHour> list { get; set; }
    }
}
