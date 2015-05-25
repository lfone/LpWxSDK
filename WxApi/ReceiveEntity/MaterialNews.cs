using System.Collections.Generic;
using WxApi.SendEntity;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 获取永久素材时，当请求的素材为图文消息时，返回的实体
    /// </summary>
   public class MaterialNews:ErrorEntity
    {
       /// <summary>
       /// 多图文列表
       /// </summary>
        public List<Article> news_item { get; set; }
    }
}
