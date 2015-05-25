namespace WxApi.SendEntity.Shop
{
    /// <summary>
    /// 商品的所有信息，包括商品ID
    /// </summary>
    public class ProductInfo:Product
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string product_id { get; set; }
        /// <summary>
        /// 商品状态(0-全部, 1-上架, 2-下架)
        /// </summary>
        public int status { get; set; }
    }
}
