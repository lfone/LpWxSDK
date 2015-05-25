using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using WxApi.ReceiveEntity;

namespace WxApi
{
    public class JsApi
    {
        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static JsApiTicket GetHsJsApiTicket(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", accessToken);
            return Utils.GetResult<JsApiTicket>(url);
        }
        /// <summary>
        /// 获取签名
        ///出于安全考虑，开发者必须在服务器端实现签名的逻辑。
        ///出于安全考虑，开发者必须在服务器端实现签名的逻辑。
        /// </summary>
        /// <param name="noncestr">必须与wx.config中的nonceStr相同</param>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="timestamp">必须与wx.config中的timestamp相同</param>
        /// <param name="url">url必须是调用JS接口页面的完整URL</param>
        /// <returns></returns>
        public static string GetJsApiSign(string noncestr, string jsapi_ticket, string timestamp, string url)
        {
            //将字段添加到列表中。
            string[] arr = new[]
            {
                string.Format("noncestr={0}",noncestr),
                string.Format("jsapi_ticket={0}",jsapi_ticket),
                string.Format("timestamp={0}",timestamp),
                string.Format("url={0}",url)
            };
            //字典排序
            Array.Sort(arr);
            //使用URL键值对的格式拼接成字符串
            var temp = string.Join("&", arr);
            return FormsAuthentication.HashPasswordForStoringInConfigFile(temp, "SHA1");
        }
    }
}
