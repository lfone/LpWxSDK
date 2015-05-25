using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;
using WxApi.SendEntity.Card;

namespace WxTest
{
    public partial class WxJs : System.Web.UI.Page
    {
        protected string timestamp;//时间戳
        protected string noncestr;//随机字符串
        protected string url;//当前url
        protected string sign;//签名
        private static WxApi.ReceiveEntity.JsApiTicket ticket;
        private static WxApi.ReceiveEntity.CardApiTicket cardticket;
        public ChooseCard CardSign = null;
        public CardExt cardext;
        public CardExt cardext1;
        protected void Page_Load(object sender, EventArgs e)
        {
            timestamp = Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            noncestr = timestamp;//随机字符串也使用时间戳。
            url =  "http://"+Utils.GetCurrentFullHost() + Request.RawUrl;
            var accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
          
            if (ticket==null||ticket.expires_time<DateTime.Now)
            {
                ticket = JsApi.GetHsJsApiTicket(accessToken);
            }
            sign = JsApi.GetJsApiSign(noncestr, ticket.ticket, timestamp, url);
            if (cardticket == null || cardticket.ExpirationTime < DateTime.Now)
            {
                cardticket = CardVoucher.GetApiTicket(accessToken);
            }

            
            CardSign = new ChooseCard
            {
                app_id = "appid",
                nonce_str = timestamp,
                times_tamp = timestamp,
                api_ticket = cardticket.ticket,
                card_id = "pR19Cs8gPMGalMS3L7hvYcGzE9fY",
                location_id = "276634637"
               // card_type = CardType.CASH.ToString()

                
            };
            CardSign.signature = CardVoucher.GetChooseSign(CardSign);
            cardext = new CardExt { api_ticket = cardticket.ticket, timestamp = timestamp, card_id = "pR19Cs8gPMGalMS3L7hvYcGzE9fY" };
            cardext.signature = CardVoucher.GetJsApiSign(cardext);
            cardext1 = new CardExt { api_ticket = cardticket.ticket, timestamp = timestamp, card_id = "pR19Cs_ethJ_jYqR5CriJOavhQKA" };
            cardext1.signature = CardVoucher.GetJsApiSign(cardext1);
        }
    }
}