namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 基础实体，映射只包含ID，和Name两个属性的对象
    /// </summary>
    public class BaseEntity
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
