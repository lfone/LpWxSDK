using System.Collections.Generic;
namespace WxApi.ReceiveEntity.Shop
{
    /// <summary>
    /// 分组列表实体
    /// </summary>
    public class GroupList : ErrorEntity
    {
        public List<GroupDetail> groups_detail { get; set; }
    }

    
}
