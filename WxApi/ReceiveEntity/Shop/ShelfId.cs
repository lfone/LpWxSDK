using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.ReceiveEntity.Shop
{
   /// <summary>
   /// 增加货架时，返回的实体
   /// </summary>
   public class ShelfId:ErrorEntity
    {
       /// <summary>
        /// 货架ID
       /// </summary>
       public string shelf_id { get; set; }
    }
}
