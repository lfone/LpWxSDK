using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;
using WxApi.SendEntity.Card;

namespace WxTest.CaseFour
{
    public partial class Movie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
            var info = new Movie_Ticket
            {
                base_info = new BaseInfo
                {
                    bind_openid = false,
                    brand_name = "微企卡科技",
                    can_give_friend = true,
                    can_share = true,
                    color = "Color010",
                    code_type = CodeType.CODE_TYPE_QRCODE,
                    sku = new Sku { quantity = 50000000 },
                    date_info = new DateInfo
                    {
                        type = 2,
                        fixed_term = 30
                    },
                    description = "1.3米（含）以下儿童在成人陪同下可免费观看2D电影（3D影片无优惠，儿童单独观看2D影片无优惠），无座位，且每位成人限带1名儿童（以上仅供参考，具体以各门店为准），如遇动画片/儿童影片，优惠详情请咨询商家店面",
                    get_limit = 30,
                    logo_url = "http://mmbiz.qpic.cn/mmbiz/icIxxjVX9TaZe6jxWAQQ5ydyO79LGEfQYAvAzk4lN4VKKFmkD6P86ZvGFM3SmYlK0SNUAx9FS5GTicLfh3vfpm7A/0",
                    notice = "请出示二维码核销卡券",
                    promotion_url = "http://ypyle.xicp.net/CaseFour/Select.aspx",
                    promotion_url_sub_title = "点击进入",
                    promotion_url_name = "在线选座",
                    service_phone = "020-88888888",
                    title = "3D电影家庭套票",
                    use_custom_code = false,
                },
                detail = "免费提供3D眼镜，无需押金 ，有部分影院是需要顾客自行购买3D眼镜的（每幅加10元） 具体见店内公告"
            };
            var ss = CardVoucher.Create(info, accessToken);
            img.ImageUrl = QrCode.GetQrByTicket(CardVoucher.CreateCardQrTicket(ss.card_id, accessToken).ticket);
        }
    }
}