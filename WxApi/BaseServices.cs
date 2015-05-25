using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxApi
{
    /// <summary>
    /// 基础服务类
    /// </summary>
    public class BaseServices
    {
        /// <summary>
        /// 接入验证
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool ValidUrl(string token)
        {

            //获取参与校验的参数
            var signature = HttpContext.Current.Request.QueryString["signature"];
            var timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            var nonce = HttpContext.Current.Request.QueryString["nonce"];
            string[] temp = { token, timestamp, nonce };
            Array.Sort(temp);//字典序排序
            var tempstr = string.Join("", temp);//拼接字符串
            var tempsign = FormsAuthentication.HashPasswordForStoringInConfigFile(tempstr, "SHA1").ToLower();
            if (tempsign == signature)
            {
                var echostr = HttpContext.Current.Request.QueryString["echostr"];
                HttpContext.Current.Response.Write(echostr);
                return true;
            }
            return false;

        }
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static AccessToken GetAccessToken(string appid, string appSecret)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, appSecret);
            return Utils.GetResult<AccessToken>(url);
        }
        /// <summary>
        /// 获取微信服务器的ip列表
        /// </summary>
        public static IpEntity GetIpArray(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}", accessToken);
            return Utils.GetResult<IpEntity>(url);
        }

        /// <summary>
        /// 微信上传多媒体文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="accessToken">接口调用凭据</param>
        /// <param name="mediaType">媒体类型枚举</param>
        public static UpLoadInfo WxUpLoadMedia(string filePath, string accessToken, MaterialType mediaType)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] b = client.UploadFile(string.Format("http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", accessToken, mediaType.ToString()), filePath);
                    string retdata = Encoding.Default.GetString(b);
                    return JsonConvert.DeserializeObject<UpLoadInfo>(retdata);
                }
            }
            catch (Exception)
            {
                return new UpLoadInfo
                {
                    ErrCode = -2
                };
            }

        }
        /// <summary>
        /// 将一条长链接转成短链接
        /// </summary>
        /// <param name="longurl">长链接</param>
        /// <param name="accessToken">accessToken</param>
        /// <returns>包含短连接和错误代码的实体</returns>
        public static ShortUrl LongUrlToShortUrl(string longurl, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}", accessToken);
            var json = new { action = "long2short", long_url=longurl };
            return Utils.PostResult<ShortUrl>(json, url);
        }

        public static string GetEditAddressSign(AddressSign address)
        {
            string[] arr =
            {
                string.Format("appid={0}",address.appid),
                string.Format("accesstoken={0}",address.accesstoken),
                string.Format("code={0}",address.code),
                string.Format("noncestr={0}",address.noncestr),
                string.Format("state={0}",address.state),
                string.Format("timestamp={0}",address.timestamp),
                string.Format("url={0}",address.url),
            };
            Array.Sort(arr);
            var temp = string.Join("&", arr);
            return FormsAuthentication.HashPasswordForStoringInConfigFile(temp, "SHA1");
        }
    }
}
