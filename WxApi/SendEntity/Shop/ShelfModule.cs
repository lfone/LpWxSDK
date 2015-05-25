using System.Collections.Generic;

namespace WxApi.SendEntity.Shop
{
    #region 货架控件基类
    /// <summary>
    /// 货架控件基类
    /// </summary>
    public abstract class ShelfModule
    {
        public int eid { get; set; }
    }
    #endregion
    #region 控件一
    public class Filter
    {
        public int count { get; set; }
    }

    public class OneGroupInfo
    {
        /// <summary>
        /// 该控件展示商品个数信息
        /// </summary>
        public Filter filter { get; set; }
        public string group_id { get; set; }
    }
    /// <summary>
    /// 控件一实体。由一个分组组成，展示该分组指定数量的商品列表，可与除控件5之外的控件共用
    /// </summary>
    public class ShelfModuleOne : ShelfModule
    {
        public ShelfModuleOne() { eid = 1; }
        /// <summary>
        /// 分组信息
        /// </summary>
        public OneGroupInfo group_info { get; set; }
    }

    #endregion
    #region 控件二
    public class GroupIdEntity
    {
        public string group_id { get; set; }
    }
    public class GroupIds
    {
        /// <summary>
        /// 分组列表
        /// </summary>
        public List<GroupIdEntity> groups { get; set; }
    }
    /// <summary>
    /// 控件二实体。是由多个分组组成（最多有4个分组），展示指定分组的名称。可与除控件5之外的控件共用
    /// </summary>
    public class ShelfModuleTwo : ShelfModule
    {
        public ShelfModuleTwo() { eid = 2; }
        public GroupIds group_infos { get; set; }
    }
    #endregion
    #region 控件三
    public class GroupImg
    {
        /// <summary>
        /// 分组ID
        /// </summary>
        public string group_id { get; set; }
        /// <summary>
        /// 分组照片(图片需调用图片上传接口获得图片Url填写至此，否则添加货架失败，3个分组建议分辨率分别为: 350*350, 244*172, 244*172)
        /// </summary>
        public string img { get; set; }
    }
    /// <summary>
    /// 控件三实体。由一个分组组成，展示指定分组的分组图片。可与除控件5之外的控件共用
    /// </summary>
    public class ShelfModuleThree : ShelfModule
    {
        public ShelfModuleThree() { eid = 3; }
        public GroupImg group_info { get; set; }
    }

    #endregion
    #region 控件四

    public class GroupInfos
    {
        public List<GroupImg> groups { get; set; }
    }
    /// <summary>
    /// 控件四实体。由多个分组组成（最多3个分组），展示指定分组的分组图片。可与除控件5之外的控件共用
    /// </summary>
    public class ShelfModuleFour : ShelfModule
    {
        public ShelfModuleFour() { eid = 4; }
        public GroupInfos group_infos { get; set; }
    }
    #endregion
    #region 控件五
    public class FiveGroupInfo
    {
        public List<GroupIdEntity> groups { get; set; }
        public string img_background { get; set; }
    }
    /// <summary>
    /// 控件5实体。是由多个分组组成，展示指定分组的名称，不可与其他控件联合使用。
    /// </summary>
    public class ShelfModuleFive : ShelfModule
    {
        public ShelfModuleFive() { eid = 5; }
        public FiveGroupInfo group_infos { get; set; }
       
    }
    #endregion
}
