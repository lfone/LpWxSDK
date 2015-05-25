using System.Collections.Generic;
namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 分类属性列表
    /// </summary>
    public class PropertyList : ErrorEntity
    {
        public List<Properties> properties { get; set; }
    }
    public class Properties : BaseEntity
    {
        public List<BaseEntity> property_value { get; set; }
    }
}
