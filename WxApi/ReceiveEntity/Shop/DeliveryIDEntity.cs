using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 增加邮费模版接口返回实体
    /// </summary>
   public class DeliveryIDEntity:ErrorEntity
    {
        public string template_id { get; set; }
    }
}
