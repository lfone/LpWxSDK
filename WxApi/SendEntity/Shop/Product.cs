using System.Collections.Generic;

namespace WxApi.SendEntity.Shop
{
    /// <summary>
    /// 商品实体
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 商品基本信息
        /// </summary>
        public ProductBase product_base { get; set; }
        /// <summary>
        /// sku列表
        /// </summary>
        public List<ProductSku> sku_list { get; set; }
        /// <summary>
        /// 其他属性
        /// </summary>
        public AttrExt attrext { get; set; }
        /// <summary>
        /// 运费信息
        /// </summary>
        public DeliveryInfo delivery_info { get; set; }

    }

    #region 商品基本信息
    /// <summary>
    /// sku信息实体
    /// </summary>
    public class SkuInfo
    {
        public string id { get; set; }
        public List<string> vid { get; set; }
    }

    /// <summary>
    /// 属性键值实体
    /// </summary>
    public class Property
    {
        /// <summary>
        /// 属性ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string vid { get; set; }
    }
    /// <summary>
    ///  商品基本信息
    /// </summary>
    public class ProductBase
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 商品分类id
        /// </summary>
        public List<string> category_id { get; set; }
        /// <summary>
        /// 商品主图(图片需调用图片上传接口获得图片Url填写至此，否则无法添加商品。图片分辨率推荐尺寸为640×600)
        /// </summary>
        public string main_img { get; set; }
        /// <summary>
        /// 商品图片列表(图片需调用图片上传接口获得图片Url填写至此，否则无法添加商品。图片分辨率推荐尺寸为640×600)
        /// </summary>
        public List<string> img { get; set; }
        /// <summary>
        /// 商品详情列表，显示在客户端的商品详情页内
        /// </summary>
        public List<Detail> detail { get; set; }
        /// <summary>
        /// 商品属性列表
        /// </summary>
        public List<Property> property { get; set; }
        /// <summary>
        /// 商品sku定义。如需自定义sku。格式为"$xxx"。如id="$整件库存"  vid="$1000"
        /// </summary>
        public List<SkuInfo> sku_info { get; set; }
        /// <summary>
        /// 用户商品限购数量
        /// </summary>
        public int buy_limit { get; set; }

    }


    /// <summary>
    /// 商品详情
    /// </summary>
    public class Detail
    {
        /// <summary>
        /// 文字描述
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 图片(图片需调用图片上传接口获得图片Url填写至此，否则无法添加商品)
        /// </summary>
        public string img { get; set; }
    }
    #endregion

    #region SKU

    /// <summary>
    /// 商品SKU信息
    /// </summary>
    public class ProductSku
    {
        /// <summary>
        /// sku信息 规则 : id_info的组合个数必须与sku_table个数一致(若商品无sku信息, 即商品为统一规格，则此处赋值为空字符串即可)
        /// </summary>
        public string sku_id { get; set; }
        /// <summary>
        /// sku原价(单位 : 分)
        /// </summary>
        public int ori_price { get; set; }
        /// <summary>
        /// sku微信价(单位 : 分, 微信价必须比原价小, 否则添加商品失败)
        /// </summary>
        public int price { get; set; }
        /// <summary>
        /// sku iconurl(图片需调用图片上传接口获得图片Url)
        /// </summary>
        public string icon_url { get; set; }
        /// <summary>
        /// sku库存
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 商家商品编码
        /// </summary>
        public string product_code { get; set; }
    }
    #endregion

    #region 商品其他属性

    public class AttrExt
    {
        /// <summary>
        /// 是否包邮(0-否, 1-是), 如果包邮商品运费信息delivery_info字段可省略
        /// </summary>
        public int isPostFree { get; set; }
        /// <summary>
        /// 是否提供发票(0-否, 1-是)
        /// </summary>
        public int isHasReceipt { get; set; }
        /// <summary>
        /// 是否保修(0-否, 1-是)
        /// </summary>
        public int isUnderGuaranty { get; set; }
        /// <summary>
        /// 是否支持退换货(0-否, 1-是)
        /// </summary>
        public int isSupportReplace { get; set; }
        /// <summary>
        /// 商品所在地地址
        /// </summary>
        public Location Location { get; set; }
    }
    /// <summary>
    /// 商品所在地地址
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get; set; }
    }
    #endregion

    #region 运费相关实体
    /// <summary>
    /// 运费信息
    /// </summary>
    public class DeliveryInfo
    {
        /// <summary>
        /// 运费类型(0-使用express字段的默认模板, 1-使用template_id代表的邮费模板
        /// </summary>
        public int delivery_type { get; set; }
        /// <summary>
        /// 邮费模板ID
        /// </summary>
        public string template_id { get; set; }
    }
    /// <summary>
    /// 运费实体
    /// </summary>
    public class express
    {
        /// <summary>
        /// 快递ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 运费(单位 : 分)
        /// </summary>
        public string price { get; set; }
    }
    #endregion
}
