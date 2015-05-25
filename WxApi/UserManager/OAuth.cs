using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;

namespace WxApi.UserManager
{
    public class OAuth
    {
        /// <summary>
        /// 获取OAuthToken
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="secret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static OAuthToken GetAuthToken(string appid, string secret, string code)
        {
            var url =
                string.Format(
                    "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code"
                    , appid, secret, code);
            return Utils.GetResult<OAuthToken>(url);
        }
        /// <summary>
        /// 刷新OAuthToken
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="refresh_token"></param>
        /// <returns></returns>
        public static OAuthToken GetRefreshToken(string appid, string refresh_token)
        {
            var url =
                string.Format(
                    "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", appid, refresh_token);

            return Utils.GetResult<OAuthToken>(url);
        }
        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="authtoken"></param>
        /// <param name="openid"></param>
        /// <returns></returns>

        public static UserInfo GetUserInfo(string authtoken, string openid)
        {
            var url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", authtoken, openid);
            return Utils.GetResult<UserInfo>(url);
        }
        /// <summary>
        /// 检验授权凭证（access_token）是否有效
        /// </summary>
        /// <param name="authtoken"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static ErrorEntity CheckAuthToken(string authtoken, string openid)
        {
            var url = string.Format("https://api.weixin.qq.com/sns/auth?access_token={0}&openid={1}", authtoken, openid);
            return Utils.GetResult<ErrorEntity>(url);
        }

        public static string GetAuthUrl(string appid, string redirect_uri, string state, AuthType authType=AuthType.snsapi_base)
        {
            var url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect";
            return string.Format(url, appid, Utils.UrlEncode(redirect_uri), authType, state);
        }
    }
}
