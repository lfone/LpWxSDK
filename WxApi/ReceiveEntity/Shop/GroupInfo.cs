using System.Collections.Generic;
namespace WxApi.ReceiveEntity.Shop
{
   public class GroupInfo:ErrorEntity
    {
       public GroupDetail group_detail { get; set; }
    }
   public class GroupDetail
   {
       /// <summary>
       /// 分组ID
       /// </summary>
       public string group_id { get; set; }
       /// <summary>
       /// 分组名称
       /// </summary>
       public string group_name { get; set; }
       /// <summary>
       /// 商品ID列表
       /// </summary>
       public List<string> product_list { get; set; }
   }
}
