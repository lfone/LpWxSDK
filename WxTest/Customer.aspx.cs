using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;

namespace WxTest
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("wx3ec966b865f1f8c6", "9674718f3a149de79e47ad90e0483c41");
            var ss = CustomerServices.KfSession("003@jkcy2014618", "oxb7QsvLzXJTK6nBI9A8nz38gWxM", "vip客户，请认真对待。", KfSessionType.create, accessToken);
        }
    }
}