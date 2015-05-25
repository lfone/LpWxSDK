using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxTest
{
    public partial class TemplateTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("wxd7008116979a800d", "49523ae424f3d22b369c16f8738fecba");
            var dickKeys = new Dictionary<string, TemplateKey>();
            dickKeys.Add("first", new TemplateKey { value = "有一条新订单", color = "#cc0000" });
            dickKeys.Add("tradeDateTime", new TemplateKey { value = DateTime.Now.ToString(), color = "#cc0000" });
            dickKeys.Add("orderFrom", new TemplateKey { value = "微信端", color = "#cc0000" });
            dickKeys.Add("customerInfo", new TemplateKey { value = "张三 电话：110", color = "#cc0000" });
            dickKeys.Add("orderInfo", new TemplateKey { value = "卡迪拉克", color = "#cc0000" });
            dickKeys.Add("remark", new TemplateKey { value = "请及时确认", color = "#cc0000" });
            var d = TemplateNotice.Send("o8mXItyyhht1ubxsO9nidRzfMIOU", "nzrO9M_sIAZ7YueyilDct_TxztmYZl8qxgXdtuJ-xQI", "#cccccc",
                dickKeys, accessToken);
            if (d.ErrCode==0)
            {
                Response.Write("模板消息发送成功！消息ID为："+d.msgid);
            }
            else
            {
                Response.Write("模板消息发送失败！错误消息是："+d.ErrDescription);
            }
        }
    }
}