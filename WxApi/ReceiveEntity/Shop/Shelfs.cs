using System.Collections.Generic;
using WxApi.SendEntity.Shop;

namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 货架列表
    /// </summary>
    public class Shelfs:ErrorEntity
    {
        public List<Shelf> shelves { get; set; }
    }
}
