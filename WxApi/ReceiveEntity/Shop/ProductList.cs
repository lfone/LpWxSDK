using System.Collections.Generic;
using WxApi.SendEntity.Shop;

namespace WxApi.ReceiveEntity.Shop
{
    public class ProductList:ErrorEntity
    {
        public List<ProductInfo> products_info { get; set; }
    }
}
