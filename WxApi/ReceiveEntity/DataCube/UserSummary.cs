using System;
using System.Collections.Generic;

namespace WxApi.ReceiveEntity.DataCube
{
    public class UserSummary
    {
        /// <summary>
        /// 数据的日期
        /// </summary>
        public DateTime ref_date { get; set; }
        /// <summary>
        /// 用户的渠道，数值代表的含义如下：0代表其他 30代表扫二维码 17代表名片分享 35代表搜号码（即微信添加朋友页的搜索） 39代表查询微信公众帐号 43代表图文页右上角菜单
        /// </summary>
        public int user_source { get; set; }
        /// <summary>
        /// 新增的用户数量
        /// </summary>
        public int new_user { get; set; }
        /// <summary>
        /// 取消关注的用户数量，new_user减去cancel_user即为净增用户数量
        /// </summary>
        public int cancel_user { get; set; }
    }
    /// <summary>
    /// 用户增减数据
    /// </summary>
    public class UserSummarys:ErrorEntity
    {
        public List<UserSummary> list { get; set; }
    }
}
