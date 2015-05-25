using System.Collections.Generic;
using WxApi.SendEntity;
namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 获取素材列表时，返回的实体
    /// </summary>
    public class MaterialList : ErrorEntity
    {
        public int total_count { get; set; }
        public int item_count { get; set; }
        public List<MaterialItem> item { get; set; }
    }

    public class MaterialItem
    {
        public string media_id { get; set; }
        /// <summary>
        /// 素材的最后更新时间
        /// </summary>
        public int update_time { get; set; }
        /// <summary>
        /// 请求类型为非图文时有效
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 图文内容（请求类型为news时有效）
        /// </summary>
        public MaterialItemNews content { get; set; }
       
    }
    public class MaterialItemNews
    {
        /// <summary>
        /// 多图文列表
        /// </summary>
        public List<Article> news_item { get; set; }
    }
}
