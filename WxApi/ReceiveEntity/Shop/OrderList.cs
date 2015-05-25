using System.Collections.Generic;

namespace WxApi.ReceiveEntity.Shop
{
   public class OrderList:ErrorEntity
    {
       public List<OrderInfo> order_list { get; set; }
    }
}
