using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WxApi;
using WxApi.SendEntity;

namespace WxTest.CaseTwo
{
    public partial class index : System.Web.UI.Page
    {
        string accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = Request.QueryString["action"];
            switch (action)
            {
                case "loginqr": GetLoginQr(); break;
                case "checkscan": CheckLogin(); break;

            }
        }
        void GetLoginQr()
        {
            var key = Utils.ConvertDateTimeInt(DateTime.Now);
            var ticket = QrCode.CreateTemp(60, key, accessToken);

            WxLogin.Logins.Add(new WxLogin { key = key, exptime = DateTime.Now.AddMinutes(5) });
            Application.Lock();
            Application["logins"] = WxLogin.Logins;
            Application.UnLock();
            Response.Write(JsonConvert.SerializeObject(new { qrurl = QrCode.GetQrByTicket(ticket.ticket), key = key }));
            Response.End();
        }

        void CheckLogin()
        {
            var key = Request.QueryString["key"];
            var info = WxLogin.Logins.FirstOrDefault(l => l.key.ToString() == key && !string.IsNullOrEmpty(l.openid));
            if (info != null)
            {
                var userinfo = WxApi.UserManager.BaseUser.GetUserInfo(info.openid, accessToken);
                #region 发送模板消息

                var dic = new Dictionary<string, TemplateKey>();
                dic.Add("first", new TemplateKey { color = "#173177", value = "您进行了微信扫一扫登录操作" });
                dic.Add("keyword1", new TemplateKey { color = "#173177", value = userinfo.nickname });
                dic.Add("keyword2", new TemplateKey { color = "#173177", value = "微企卡微信测试系统" });
                dic.Add("keyword3", new TemplateKey { color = "#173177", value = DateTime.Now.ToString() });
                dic.Add("remark", new TemplateKey { color = "#173177", value = "如有疑问，请致电IT服务台400-888-8888或直接发送问题到公众号。谢谢。" });
                TemplateNotice.Send(userinfo.openid, "uht719E3riw32NmF418cpRKh8mLWqjNqj-bGFsmGSls", "#FF0000", dic, accessToken);
                #endregion
                Response.Write(JsonConvert.SerializeObject(new { status = 1, userinfo = userinfo }));
                Response.End();
            }
            else
            {
                Response.Write("{\"status\":0}");
                Response.End();
            }
        }
    }
}