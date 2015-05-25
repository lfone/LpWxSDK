using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.SendEntity;

namespace WxApi.ReceiveEntity
{
    public class StoreInfo : BaseStoreInfo
    {
        /// <summary>
        /// 门店是否可用状态。1 表示系统错误、2 表示审核中、3 审核通过、4 审核驳回。当该字段为 1、2、4 状态时，poi_id 为空
        /// </summary>
        public int available_state { get; set; }
        /// <summary>
        /// 扩展字段是否正在更新中。1 表示扩展字段正在更新中，尚未生效，不允许再次更新； 0 表示扩展字段没有在更新中或更新已生效，可以再次更新
        /// </summary>
        public int update_status { get; set; }
    }

    public class BaseInfo
    {
        public StoreInfo base_info { get; set; }
    }
    /// <summary>
    /// 门店信息实体
    /// </summary>
    public class Business:ErrorEntity
    {
        public BaseInfo business { get; set; }
    }
}
