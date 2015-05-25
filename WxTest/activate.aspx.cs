using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;

namespace WxTest
{
    public partial class activate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
            var code = CardVoucher.Decrypt(accessToken, Request.QueryString["encrypt_code"]);
            CardVoucher.ActivateMemberCard(accessToken,  "A0013", code.code);
        }
    }
}