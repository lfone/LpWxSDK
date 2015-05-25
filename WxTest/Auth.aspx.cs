using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WxApi;
using WxApi.SendEntity;
using WxApi.UserManager;

namespace WxTest
{

    public partial class Auth : System.Web.UI.Page
    {
        protected string timestamp;//时间戳
        protected string noncestr;//随机字符串
        protected string url;//当前url
        protected string sign;//签名
        protected string appid;//签名
        protected void Page_Load(object sender, EventArgs e)
        {
            timestamp = Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            noncestr = timestamp;
            appid = "wxd7008116979a800d";
            url = Utils.GetCurrentFullHost() + Request.RawUrl;
            var code = Request.QueryString["code"];
            var state = Request.QueryString["state"];
            var at = OAuth.GetAuthToken(appid, "49523ae424f3d22b369c16f8738fecba", code);
            sign = BaseServices.GetEditAddressSign(new AddressSign
            {
                accesstoken = at.access_token,
                appid = appid,
                code = code,
                state = state,
                noncestr = noncestr,
                timestamp = timestamp,
                url=url
            });
            Response.Write(OAuth.GetAuthUrl("wxd7008116979a800d", "http://www.ypyle.com/a.aspx", "1", AuthType.snsapi_userinfo));
        }
    }
}