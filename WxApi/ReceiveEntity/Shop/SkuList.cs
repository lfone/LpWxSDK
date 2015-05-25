using System.Collections.Generic;

namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 分类的SKU列表
    /// </summary>
    public class SkuList : ErrorEntity
    {
        public List<Sku> sku_table { get; set; }
    }

    public class Sku : BaseEntity
    {
        public List<BaseEntity> value_list { get; set; }
    }
}
