using System.Collections.Generic;

namespace WxApi.SendEntity
{
    public class BaseStoreInfo
    {
        /// <summary>
        /// 商户自定义id。
        /// </summary>
        public string sid { get; set; } 
        /// <summary>
        /// 门店名称.仅为商户名，如：国美.不应包含地区、店号等信息，错误示例：北京国美
        /// </summary>
        public string business_name { get; set; }
        /// <summary>
        /// 分店名称（不应包含地区信息、不应与门店名重复，错误示例：北京王府井店）
        /// </summary>
        public string branch_name { get; set; }
        /// <summary>
        /// 门店所在的省份（直辖市填城市名,如：北京市）
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 门店所在的城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 门店所在地区
        /// </summary>
        public string district { get; set; }
        /// <summary>
        /// 门店所在的详细街道地址（不要填写省市信息）
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 门店的电话（纯数字，区号、分机号均由“-”隔开）
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// 门店的类型不同级分类用“,”隔开，如：美食，川菜，火锅
        /// </summary>
        public string categories { get; set; }
        /// <summary>
        /// 坐标类型，1 为火星坐标（目前只能选 1） 
        /// </summary>
        public int offset_type { get; set; }
        /// <summary>
        /// 门店所在地理位置的经度 
        /// </summary>
        public string longitude { get; set; }
        /// <summary>
        /// 门店所在地理位置的纬度
        /// </summary>
        public string latitude { get; set; }
        /// <summary>
        /// 图片列表，url 形式，可以有多张图片，尺寸为640*340px。
        /// </summary>
        public List<PhotoUrl> photo_list { get; set; }
        /// <summary>
        /// 推荐品，餐厅可为推荐菜；酒店为推荐套房；景点为推荐游玩景点等，针对自己行业的推荐内容
        /// </summary>
        public string recommend { get; set; }
        /// <summary>
        /// 特色服务，如免费 wifi，免费停车，送货上门等商户能提供的特色功能或服务
        /// </summary>
        public string special { get; set; }
        /// <summary>
        /// 商户简介，主要介绍商户信息等
        /// </summary>
        public string introduction { get; set; }
        /// <summary>
        /// 营业时间，24 小时制表示，用“-”连接，如8:00-20:00
        /// </summary>
        public string open_time { get; set; }
        /// <summary>
        /// 人均价格，大于 0 的整数
        /// </summary>
        public int avg_price { get; set; }
    }

    public class PhotoUrl
    {
        public string photo_url { get; set; }
    }
}
