namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 根据openid查询分组ID返回的实体
    /// </summary>
    public class QueryGroupEntity:ErrorEntity
    {
        public int groupid { get; set; }
    }
}
