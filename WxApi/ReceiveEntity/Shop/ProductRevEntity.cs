using WxApi.SendEntity.Shop;
namespace WxApi.ReceiveEntity.Shop
{
   /// <summary>
   /// 根据商品ID获取商品详细信息返回实体
   /// </summary>
   public class ProductRevEntity:ErrorEntity
    {
       /// <summary>
       /// 商品详细信息
       /// </summary>
       public ProductInfo product_info { get; set; }
    }
}
