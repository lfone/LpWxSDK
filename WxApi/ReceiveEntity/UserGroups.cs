using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 用户分组列表
    /// </summary>
    public class UserGroups:ErrorEntity
    {
        public List<UserGroupEntity> groups { get; set; }
    }
}
