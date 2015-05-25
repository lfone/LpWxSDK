using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxApi
{
    /// <summary>
    /// 处理菜单相关的类
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="menuEntity">菜单实体</param>
        /// <param name="accessToken">accessToken</param>
        /// <returns>错误信息实体</returns>
        public static ErrorEntity Create(MenuEntity menuEntity,string accessToken)
        {
            var url = string.Format(" https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", accessToken);
            return Utils.PostResult<ErrorEntity>(menuEntity, url);
        }
        /// <summary>
        /// 查询自定义菜单
        /// </summary>
        public static MenuEntity Query(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}",accessToken);
            var jobj = Utils.GetResult<JObject>(url);
            var menu = jobj["menu"].ToString();

            return JsonConvert.DeserializeObject<MenuEntity>(menu);
        }
        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        public static ErrorEntity Delete(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", accessToken);
            return Utils.GetResult<ErrorEntity>(url);
        }
    }
}
