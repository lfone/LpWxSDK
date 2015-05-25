using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;

namespace WxTest
{
    public partial class cardlink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
            var code = CardVoucher.Decrypt(accessToken, Request.QueryString["encrypt_code"]);
           // var ss = CardVoucher.CheckIn(accessToken, code.code, "张思凯", "头等舱", "789456789456", "A1", "123456789", false, Request.QueryString["card_id"]);
           // var ss = CardVoucher.UpdateMovieTicket(accessToken, code.code, "3D", Utils.ConvertDateTimeInt(DateTime.Now.AddHours(2)), 120, "5 号影厅", new[] { "5 排 14 号", "5 排 15 号", "5 排 16号", "5 排 17 号", "5 排 18 号" });
            var ss = CardVoucher.UpdateMeeting(accessToken, code.code, Utils.ConvertDateTimeInt(DateTime.Now.AddHours(2)),
                Utils.ConvertDateTimeInt(DateTime.Now.AddHours(4)), "C区", "东北门", "2 排 15 号");
        }
    }
}