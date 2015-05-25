using System;
using System.Collections.Generic;

namespace WxApi.ReceiveEntity.DataCube
{
    public class UserCumulate
    {
        /// <summary>
        /// 取消关注的用户数量，new_user减去cancel_user即为净增用户数量
        /// </summary>
        public DateTime ref_date { get; set; }
        /// <summary>
        /// 总用户量
        /// </summary>
        public int cumulate_user { get; set; }
    }
    /// <summary>
    /// 累计用户数据
    /// </summary>
    public class UserCumulates:ErrorEntity
    {
        public List<UserCumulate> list { get; set; }
    }
}
