using System.Web;
using WxApi;
using WxApi.ReceiveEntity;
using WxApi.UserManager;

namespace WxTest
{
    public class WxBasePage : System.Web.UI.Page
    {
        public const string appid = "appid";
        public const string appsecret = "appsecret";
        public string currenthost = Utils.GetCurrentFullHost();
        public string accessToken
        {
            get { return AccessTokenBox.GetTokenValue(appid, appsecret); }
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo currentinfo
        {
            get { return (UserInfo)Session["userinfo"]; }
        }
        public OAuthToken AuthToken
        {
            get { return (OAuthToken)Session["AuthToken"]; }
        }
        public WxBasePage()
        {
            this.Init += (s, e) =>
            {

                if (Session["userinfo"] == null)
                {
                    var code = Request.QueryString["code"];
                    if (string.IsNullOrEmpty(code))
                    {
                        Response.Redirect(OAuth.GetAuthUrl(appid, GetRawUrl(), "1", AuthType.snsapi_userinfo));
                    }
                    else
                    {
                        Session["AuthToken"] = OAuth.GetAuthToken(appid, appsecret, code);
                        Session["userinfo"] = OAuth.GetUserInfo(AuthToken.access_token, AuthToken.openid);
                    }
                }
            };
        }
        /// <summary>
        /// 获取当前请求的url
        /// </summary>
        /// <returns></returns>
        public string GetRawUrl()
        {
            return string.Format("http://{0}{1}", Utils.GetCurrentFullHost(), HttpContext.Current.Request.RawUrl);
        }
    }
}