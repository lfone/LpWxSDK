using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 获取门店列表时的实体
    /// </summary>
    public class StoresEntity:ErrorEntity
    {
        /// <summary>
        /// 门店列表
        /// </summary>
        public List<Location> location_list { get; set; }
        /// <summary>
        /// 拉取门店数量
        /// </summary>
        public int count { get; set; }
    }
    /// <summary>
    /// 门店信息
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public string location_id { get; set; }
        /// <summary>
        /// 门店全称
        /// </summary>
        public string business_name { get; set; }
        /// <summary>
        /// 分店名
        /// </summary>
        public string branch_name { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string latitude { get; set; }
    }
}
