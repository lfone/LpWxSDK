using System.Collections.Generic;
using WxApi.SendEntity.Shop;

namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 运费模版列表
    /// </summary>
    public class DeliveryList:ErrorEntity
    {
        public List<DeliveryTemplateInfo> templates_info { get; set; }
    }
}
