using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WxApi;

namespace WxTest
{
    public partial class Semantic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("wxd7008116979a800d", "49523ae424f3d22b369c16f8738fecba");
            var json = new
            {
                query = "明天上午九点",
                category = "datetime",
                appid = "wxd7008116979a800d",
            };
           var ss = Utils.HttpPost("https://api.weixin.qq.com/semantic/semproxy/search?access_token=" + accessToken,JsonConvert.SerializeObject(json));

        }
    }
}