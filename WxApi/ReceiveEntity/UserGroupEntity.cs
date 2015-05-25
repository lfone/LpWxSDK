namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 用户分组实体
    /// </summary>
    public class UserGroupEntity : ErrorEntity
    {
        /// <summary>
        /// 分组ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 分组名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 分组内用户数量
        /// </summary>
        public int count { get; set; }
    }
}
