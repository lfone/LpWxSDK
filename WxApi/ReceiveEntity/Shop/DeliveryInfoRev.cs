using WxApi.SendEntity.Shop;
namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 运费模版信息
    /// </summary>
   public class DeliveryInfoRev:ErrorEntity
    {
       public DeliveryTemplateInfo template_info { get; set; }
    }
}
