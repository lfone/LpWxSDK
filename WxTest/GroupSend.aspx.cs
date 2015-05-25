using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WxTest
{
    public partial class GroupSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("wxd7008116979a800d", "49523ae424f3d22b369c16f8738fecba");
            var ss = WxApi.GroupSend.SendArticleByOpenID("17384529530",
                accessToken, "o8mXItyyhht1ubxsO9nidRzfMIOU");//2351304536
        //    var ss = WxApi.GroupSend.Delete("2351304536", accessToken);
         
        }
    }
}