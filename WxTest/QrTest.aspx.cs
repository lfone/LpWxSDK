using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;

namespace WxTest
{
    public partial class QrTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("wxd7008116979a800d", "49523ae424f3d22b369c16f8738fecba");
            var qr = QrCode.CreateByStr("1", accessToken);
            Utils.GetQrCode(qr.url,200);
          //  Response.Write(qr.url);
           // Utils.DownLoadFile(QrCode.GetQrByTicket(qr.ticket),Utils.ConvertDateTimeInt(DateTime.Now).ToString()+".jpg");
        }
    }
}