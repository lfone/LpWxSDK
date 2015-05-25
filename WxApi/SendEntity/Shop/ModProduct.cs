namespace WxApi.SendEntity.Shop
{
    /// <summary>
    ///分组商品信息
    /// </summary>
    public class ModProduct
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string product_id { get; set; }
        /// <summary>
        /// 修改操作(0-删除, 1-增加)
        /// </summary>
        public int mod_action { get; set; }
    }
}
