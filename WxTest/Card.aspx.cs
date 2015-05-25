using System;
using System.Collections.Generic;
using System.Linq;
using WxApi;
using WxApi.SendEntity.Card;

namespace WxTest
{
    public partial class Card : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
            #region 上传logo

            //var colors = CardVoucher.GetCardColors(accessToken);
            //var card = CardVoucher.GetCardInfo(accessToken, "pR19Cs8gPMGalMS3L7hvYcGzE9fY");
            //var cash = card.card["CASH"] as Cash;
            //cash.base_info.color =colors.colors.FirstOrDefault(m=>m.value==cash.base_info.color.ToLower()).name;
            //cash.base_info.notice = "请出示此页面给前台";
            //cash.least_cost = 1;
            //cash.reduce_cost = 8000;
            //CardVoucher.UpdateCard(accessToken, "pR19Cs8gPMGalMS3L7hvYcGzE9fY", cash);
            // var logo = CardVoucher.UploadLogo(MapPath("/logo.png"), accessToken);
            //Response.Write(logo.url);
            #endregion

            #region 导入门店

            //var stores = new List<Store>();
            //stores.Add(new Store
            //{
            //    address = "武汉市洪山区街道口群光广场",
            //    branch_name = "群光店",
            //    business_name = "金康快餐群光店",
            //    category = "餐饮",
            //    city = "武汉",
            //    district = "洪山区",
            //    telephone = "02778457854",
            //    latitude = "30.524990",
            //    longitude = "114.354270",
            //    province = "湖北"
            //});
            //var storelist = CardVoucher.ImportStore(stores, accessToken);

            #endregion

            #region 获取门店

            //  var stores = CardVoucher.GetStoreList(0, 2, accessToken);

            #endregion

            #region 获取颜色列表

            // var colors = CardVoucher.GetCardColors(accessToken);

            #endregion

            #region 创建卡券
            //var info = new Member_Card
            //{
            //    base_info = new BaseInfo
            //    {
            //        bind_openid = false,
            //        brand_name = "微企卡科技",
            //        can_give_friend = false,
            //        can_share = false,
            //        color = "Color010",
            //        custom_url = "http://ypyle.xicp.net/member_center.aspx",
            //        code_type = CodeType.CODE_TYPE_TEXT,
            //        custom_url_name = "会员中心",
            //        custom_url_sub_title = "查看更多优惠",
            //        sku = new Sku { quantity = 50000000 },
            //        date_info = new DateInfo
            //        {
            //            type = 2,
            //            fixed_term = 30
            //        },
            //        description = "微企卡科技会员",
            //        get_limit = 30,
            //        logo_url = "http://mmbiz.qpic.cn/mmbiz/icIxxjVX9TaZe6jxWAQQ5ydyO79LGEfQYAvAzk4lN4VKKFmkD6P86ZvGFM3SmYlK0SNUAx9FS5GTicLfh3vfpm7A/0",
            //        notice = "加入vip，尊享贵宾身份",
            //        promotion_url = "http://ypyle.xicp.net/cardlink.aspx",
            //        promotion_url_sub_title = "点击进入",
            //        promotion_url_name = "查看更多",
            //        service_phone = "020-88888888",
            //        title = "微企卡科技会员",
            //        use_custom_code = false,
            //    },
            //    activate_url = "http://ypyle.xicp.net/activate.aspx",
            //    balance_rules = "暂不支持储值",
            //    bonus_cleared = "年底清零",
            //    need_push_on_view = true,
            //    prerogative = "vip九折优惠",
            //    supply_balance = false,
            //    supply_bonus = true
            //};
            //var info = new Movie_Ticket
            //{
            //    base_info = new BaseInfo
            //    {
            //        bind_openid = false,
            //        brand_name = "微企卡科技",
            //        can_give_friend = false,
            //        can_share = false,
            //        color = "Color010",
            //        custom_url = "http://ypyle.xicp.net/member_center.aspx",
            //        code_type = CodeType.CODE_TYPE_TEXT,
            //        custom_url_name = "更多详情",
            //        custom_url_sub_title = "查看更多优惠",
            //        sku = new Sku { quantity = 50000000 },
            //        date_info = new DateInfo
            //        {
            //            type = 2,
            //            fixed_term = 30
            //        },
            //        description = "1.3米（含）以下儿童在成人陪同下可免费观看2D电影（3D影片无优惠，儿童单独观看2D影片无优惠），无座位，且每位成人限带1名儿童（以上仅供参考，具体以各门店为准），如遇动画片/儿童影片，优惠详情请咨询商家店面",
            //        get_limit = 30,
            //        logo_url = "http://mmbiz.qpic.cn/mmbiz/icIxxjVX9TaZe6jxWAQQ5ydyO79LGEfQYAvAzk4lN4VKKFmkD6P86ZvGFM3SmYlK0SNUAx9FS5GTicLfh3vfpm7A/0",
            //        notice = "请出示二维码核销卡券",
            //        promotion_url = "http://ypyle.xicp.net/cardlink.aspx",
            //        promotion_url_sub_title = "点击进入",
            //        promotion_url_name = "查看更多",
            //        service_phone = "020-88888888",
            //        title = "3D电影票",
            //        use_custom_code = false,
            //    },
            //    detail = "免费提供3D眼镜，无需押金 ，有部分影院是需要顾客自行购买3D眼镜的（每幅加10元） 具体见店内公告"
            //};
            //var info = new Boarding_Pass
            //{
            //    base_info = new BaseInfo
            //    {
            //        bind_openid = false,
            //        brand_name = "微企卡科技",
            //        can_give_friend = false,
            //        can_share = false,
            //        color = "Color010",
            //        custom_url = "http://ypyle.xicp.net/member_center.aspx",
            //        code_type = CodeType.CODE_TYPE_TEXT,
            //        custom_url_name = "更多详情",
            //        custom_url_sub_title = "查看更多优惠",
            //        sku = new Sku { quantity = 50000000 },
            //        date_info = new DateInfo
            //        {
            //            type = 1,
            //            begin_timestamp = Utils.ConvertDateTimeInt(DateTime.Today.AddDays(1)).ToString(),
            //            end_timestamp = Utils.ConvertDateTimeInt(DateTime.Now.AddDays(1)).ToString(),
            //        },
            //        description = "请提前检票，以免耽误行程",
            //        get_limit = 30,
            //        logo_url = "http://mmbiz.qpic.cn/mmbiz/icIxxjVX9TaZe6jxWAQQ5ydyO79LGEfQYAvAzk4lN4VKKFmkD6P86ZvGFM3SmYlK0SNUAx9FS5GTicLfh3vfpm7A/0",
            //        notice = "请出示二维码核销卡券",
            //        promotion_url = "http://ypyle.xicp.net/cardlink.aspx",
            //        promotion_url_sub_title = "点击进入",
            //        promotion_url_name = "查看更多",
            //        service_phone = "020-88888888",
            //        title = "特价机票",
            //        use_custom_code = false,
            //    },
            //    air_model = "空客A320",
            //    boarding_time = "1020",
            //    check_in_url = "http://ypyle.xicp.net/cardlink.aspx",
            //    departure_time = Utils.ConvertDateTimeInt(DateTime.Now.AddHours(15)).ToString(),
            //    flight = "MH170",
            //    from = "北京",
            //    gate = "A3",
            //    landing_time = Utils.ConvertDateTimeInt(DateTime.Now.AddHours(17)).ToString(),
            //    to = "武汉"
            //};
            var info = new Meeting_Ticket
            {
                base_info = new BaseInfo
                {
                    bind_openid = false,
                    brand_name = "微企卡科技",
                    can_give_friend = false,
                    can_share = false,
                    color = "Color010",
                    custom_url = "http://ypyle.xicp.net/member_center.aspx",
                    code_type = CodeType.CODE_TYPE_TEXT,
                    custom_url_name = "更多详情",
                    custom_url_sub_title = "查看主席信息",
                    sku = new Sku { quantity = 50000000 },
                    date_info = new DateInfo
                    {
                        type = 1,
                        begin_timestamp = Utils.ConvertDateTimeInt(DateTime.Today.AddDays(1)).ToString(),
                        end_timestamp = Utils.ConvertDateTimeInt(DateTime.Now.AddDays(1)).ToString(),
                    },
                    description = "请提前半个小时到达会场",
                    get_limit = 30,
                    logo_url = "http://mmbiz.qpic.cn/mmbiz/icIxxjVX9TaZe6jxWAQQ5ydyO79LGEfQYAvAzk4lN4VKKFmkD6P86ZvGFM3SmYlK0SNUAx9FS5GTicLfh3vfpm7A/0",
                    notice = "请出示二维码签到",
                    promotion_url = "http://ypyle.xicp.net/cardlink.aspx",
                    promotion_url_sub_title = "点击进入",
                    promotion_url_name = "查看更多",
                    service_phone = "020-88888888",
                    title = "董事大会",
                    use_custom_code = false,
                },
                map_url = "http://map.baidu.com/",
                meeting_detail = "董事大会，迟到解雇"
            };
            var ss = CardVoucher.Create(info, accessToken);
            Response.Write(QrCode.GetQrByTicket(CardVoucher.CreateCardQrTicket(ss.card_id, accessToken).ticket));
            #endregion

            // var ticket = CardVoucher.CreateCardQrTicket("pxb7QsteCZmqSJuKlmMauJPEWYN0", accessToken);

        }
    }
}