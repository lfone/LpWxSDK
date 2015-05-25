using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 导入门店时的返回实体
    /// </summary>
    public class ImStoreEntity:ErrorEntity
    {
        /// <summary>
        /// 门店ID列表(为-1时，说明插入失败，请核查必填字段后单独调用接口导入)
        /// </summary>
        public List<string> location_id_list { get; set; }
    }
}
