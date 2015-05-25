namespace WxApi.SendEntity.Shop
{
    /// <summary>
    /// 货架实体
    /// </summary>
    public class Shelf
    {
        /// <summary>
        /// 货架ID
        /// </summary>
        public int shelf_id { get; set; }
        /// <summary>
        /// 货架信息
        /// </summary>
        public ShelfData shelf_data { get; set; }
        /// <summary>
        /// 货架招牌图片Url(图片需调用图片上传接口获得图片Url填写至此，否则添加货架失败，建议尺寸为640*120，仅控件1-4有banner，控件5没有banner)
        /// </summary>
        public string shelf_banner { get; set; }
        /// <summary>
        /// 货架名
        /// </summary>
        public string shelf_name { get; set; }
    }
}
