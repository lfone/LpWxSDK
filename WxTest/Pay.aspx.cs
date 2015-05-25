using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;
using WxApi.PayEntity;
using WxApi.UserManager;

namespace WxTest
{
    public partial class Pay : System.Web.UI.Page
    {

        protected string timestamp;//时间戳
        protected string noncestr;//随机字符串
        protected string url;//当前url
        protected string sign;//签名
        private static WxApi.ReceiveEntity.JsApiTicket ticket;
        protected void Page_Load(object sender, EventArgs e)
        {
            var red = new RedPack
            {
                act_name = "五一促销",
                client_ip = Utils.GetIP(),
                max_value = 100,
                mch_billno = "1240050702" + DateTime.Now.ToString("yyyyMMdd") + (Utils.ConvertDateTimeInt(DateTime.Now).ToString()),
                mch_id = "1240050702",
                min_value = 100,
                nonce_str = Utils.GetGuid(),
                nick_name = "微企卡",
                re_openid = "oR19CsyUvziSlctqDmEoMwwph4Jk",
                remark = "猜越多得越多，快来抢！ ",
                send_name = "微企卡科技",
                total_amount = 100,
                total_num = 1,
                wishing = "五一快乐",
                wxappid = "appid"
            };
            WxApi.Pay.SendRePack(red, "c4115c3cbb9e4f64b3d0cfb726e06001", MapPath("/apiclient_cert.p12"), "1240050702");
            //var ss = WxApi.Pay.QueryReFund(new QueryRefund
            //{
            //    transaction_id = "1002070780201505190139134074",
            //    appid = "appid",
            //    mch_id = "1240050702",
            //    nonce_str = Utils.GetGuid(),
            //}, "c4115c3cbb9e4f64b3d0cfb726e06001");
            //var ss = WxApi.Pay.SendCoupon(new SendCoupon
            //{
            //    appid = "appid",
            //    coupon_stock_id = "154414",
            //    mch_id = "1240050702",
            //    nonce_str = string.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now),
            //    op_user_id = "1240050702",
            //    openid = "oR19CsyUvziSlctqDmEoMwwph4Jk",
            //    openid_count = 1,
            //    partner_trade_no = string.Format("1240050702{0:yyyyMMddHHmmssfff}", DateTime.Now)
            //}, "c4115c3cbb9e4f64b3d0cfb726e06001", @"C:\apiclient_cert.p12", "1240050702");
            //var ss = WxApi.Pay.EPayment(new EPayment
            //{
            //    mch_appid = "appid",
            //    amount = 1,
            //    check_name = CheckNameOption.FORCE_CHECK,
            //    nonce_str = string.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now),
            //    desc = "测试费用",
            //    openid = "oR19CsyUvziSlctqDmEoMwwph4Jk",
            //    mchid ="1240050702" ,
            //    partner_trade_no = string.Format("1240050702{0:yyyyMMddHHmmssfff}", DateTime.Now),
            //    re_user_name = "张思凯",
            //}, "c4115c3cbb9e4f64b3d0cfb726e06001", @"C:\apiclient_cert.p12", "1240050702");
            //return;
            timestamp = Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            noncestr = timestamp;//随机字符串也使用时间戳。
            url = "http://" + Utils.GetCurrentFullHost() + Request.RawUrl;
            var accessToken = AccessTokenBox.GetTokenValue("appid", "c4115c3cbb9e4f64b3d0cfb726e06001");

            if (ticket == null || ticket.expires_time < DateTime.Now)
            {
                ticket = JsApi.GetHsJsApiTicket(accessToken);
            }
            sign = JsApi.GetJsApiSign(noncestr, ticket.ticket, timestamp, url);
        }
    }


}