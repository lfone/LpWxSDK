using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.SendEntity
{
    /// <summary>
    /// 基础菜单信息
    /// </summary>
    public class BaseMenu
    {
        /// <summary>
        /// 菜单的响应动作类型
        /// </summary>
        public MenuType type { get; set; }
        /// <summary>
        /// 菜单标题，不超过16个字节，子菜单不超过40个字节
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// click等点击类型必须 菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// view类型必须  网页链接，用户点击菜单可打开链接，不超过256字节
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<BaseMenu> sub_button { get; set; }

    }
    /// <summary>
    /// 自定义菜单实体
    /// </summary>
    public class MenuEntity
    {
        public List<BaseMenu> button { get; set; }
    }
}
