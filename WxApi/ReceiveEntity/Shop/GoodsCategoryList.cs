using System.Collections.Generic;

namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 获取指定分类的所有子分类接口实体
    /// </summary>
    public class GoodsCategoryList : ErrorEntity
    {
        public List<BaseEntity> cate_list { get; set; }
    }

   
}
