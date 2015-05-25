using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;

namespace WxTest
{
    public partial class StoreTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
            Response.Write(Store.UploadPic(MapPath("/wx.jpg"), accessToken).url);
        }
    }
}