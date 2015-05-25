using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;
using WxApi.PayEntity;

namespace WxTest
{
    public partial class Cube : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WxApi.Pay.QueryReFund(new QueryRefund(), "");
        }
    }
}