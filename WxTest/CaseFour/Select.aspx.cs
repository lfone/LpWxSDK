using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WxApi;

namespace WxTest.CaseFour
{
    public partial class Select : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToLower() == "post")
            {
                var accessToken = AccessTokenBox.GetTokenValue("wx891ee9903ba8d74e", "dd93fb224cc735086a6c24fea55a7dbc");
                //解码获取code
                var code = CardVoucher.Decrypt(accessToken, Request.QueryString["encrypt_code"]);
                var v = CardVoucher.UpdateMovieTicket(accessToken, code.code, "3D", 
                    Utils.ConvertDateTimeInt(DateTime.Now.AddHours(2)), 
                    120, "5 号影厅", Request["data"].Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
                Response.Write(JsonConvert.SerializeObject(v));
                Response.End();
            }
        }
    }
}