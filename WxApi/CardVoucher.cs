using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Newtonsoft.Json;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;
using WxApi.SendEntity.Card;

namespace WxApi
{
    /// <summary>
    /// 卡券相关处理类
    /// </summary>
    public class CardVoucher
    {
        /// <summary>
        /// 上传商户logo
        /// </summary>
        /// <param name="filePath">文件路径。 支持网络路径</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static LogoUrlEntity UploadLogo(string filePath, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}", accessToken);
            var formlist = new List<FormEntity>();
            formlist.Add(new FormEntity { IsFile = true, Name = "buffer", Value = filePath });
            return Utils.PostResult<LogoUrlEntity>(formlist, url);
        }
        #region 门店管理
        /// <summary>
        /// 导入门店
        /// </summary>
        public static ImStoreEntity ImportStore(List<Store> stores, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/card/location/batchadd?access_token={0}", accessToken);
            return Utils.PostResult<ImStoreEntity>(new { location_list = stores }, url);
        }
        /// <summary>
        /// 获取门店列表
        /// </summary>
        /// <param name="offset">偏移量。 从0开始</param>
        /// <param name="count">数量</param>
        public static StoresEntity GetStoreList(int offset, int count, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/card/location/batchget?access_token={0}", accessToken);
            var obj = new { offset = offset, count = count };
            return Utils.PostResult<StoresEntity>(obj, url);
        }
        #endregion

        public static CardIds GetCardIdList(int offset, int count, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/card/batchget?access_token={0}", accessToken);
            var obj = new { offset = offset, count = count };
            return Utils.PostResult<CardIds>(obj, url);
        }
        /// <summary>
        /// 获取卡券颜色
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static CardColors GetCardColors(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/card/getcolors?access_token={0}", accessToken);
            return Utils.GetResult<CardColors>(url);
        }

        #region 创建卡券

        /// <summary>
        /// 创建卡券
        /// </summary>
        /// <param name="info">卡券信息</param>
        /// <param name="cardType">卡券类型</param>
        /// <param name="accessToken">全局票据</param>
        public static CardIdInfo Create(BaseCard info, string accessToken)
        {
            var cardType = info.GetType().Name;
            var url = string.Format("https://api.weixin.qq.com/card/create?access_token={0}", accessToken);
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("card_type", cardType.ToUpper());
            dictionary.Add(cardType.ToLower(), info);
            var oo = new { card = dictionary };
            return Utils.PostResult<CardIdInfo>(oo, url);

        }
        /// <summary>
        /// 创建卡券二维码ticket
        /// </summary>
        /// <param name="cardId">卡券ID</param>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="code">指定卡券 code 码，只能被领一次。use_custom_code 字段为 true 的卡券必须填写，非自定义 code 不必填写。</param>
        /// <param name="openid">指定领取者的 openid，只有该用户能领取。bind_openid字段为 true 的卡券必须填写， 非自定义 openid 不必填写。</param>
        /// <param name="expire">指定二维码的有效时间，范围是 60 ~ 1800 秒。不填默认为永久有效。</param>
        /// <param name="is_unique_cide">指定下发二维码，生成的二维码随机分配一个 code，领取后不可再次扫描。填写 true 或 false。默认 false。</param>
        /// <param name="balance">红包余额， 以分为单位。 红包类型必填 （LUCKY_MONEY） ，其他卡券类型不填。</param>
        /// <param name="outer_id">领取场景值，用于领取渠道的数据统计，默认值为 0，字段类型为整型。用户领取卡券后触发的事件推送中会带上此自定义场景值。</param>
        public static CardQrTicket CreateCardQrTicket(string cardId, string accessToken, string code = null, string openid = null, int? expire = null, bool is_unique_cide = false, int? balance = null, int outer_id = 0)
        {
            var obj = new
            {
                action_name = "QR_CARD",
                action_info = new
                {
                    card = new
                    {
                        card_id = cardId,
                        code = code,
                        openid = openid,
                        expire_seconds = expire,
                        is_unique_cide = is_unique_cide,
                        outer_id = outer_id
                    }
                }
            };
            var url = string.Format("https://api.weixin.qq.com/card/qrcode/create?access_token={0}", accessToken);
            return Utils.PostResult<CardQrTicket>(obj, url);
        }
        /// <summary>
        /// 获取api_ticket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static CardApiTicket GetApiTicket(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=wx_card", accessToken);
            return Utils.GetResult<CardApiTicket>(url);
        }

        public static string GetJsApiSign(CardExt ext)
        {
            return Utils.GetParamSign(ext);
        }

        public static string GetChooseSign(ChooseCard param)
        {
            return Utils.GetParamSign(param);
        }

        #endregion
        /// <summary>
        /// 卡券核销
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="code"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public static ConsumeRes Consume(string accessToken, string code, string cardId = null)
        {
            var url = string.Format("https://api.weixin.qq.com/card/code/consume?access_token={0}", accessToken);
            var obj = new { code = code, card_id = cardId };
            return Utils.PostResult<ConsumeRes>(obj, url);
        }
        /// <summary>
        /// 设置测试白名单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openidList"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public static ErrorEntity TestWhite(string accessToken, List<string> openidList = null,
            List<string> userList = null)
        {
            var url = string.Format("https://api.weixin.qq.com/card/testwhitelist/set?access_token={0}", accessToken);
            var obj = new { openid = openidList, username = userList };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// code解码
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="encryptCode"></param>
        /// <returns></returns>
        public static CardCode Decrypt(string accessToken, string encryptCode)
        {
            var url = string.Format("https://api.weixin.qq.com/card/code/decrypt?access_token={0}", accessToken);
            return Utils.PostResult<CardCode>(new { encrypt_code = encryptCode }, url);
        }
        /// <summary>
        /// 获取外链签名
        /// </summary>
        /// <param name="appscret"></param>
        /// <param name="encryptCode"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public static string GetOutLinkSign(string appscret, string code, string cardId)
        {
            return Utils.GetParamSign(new { appscret = appscret, code = code, card_id = cardId });
        }
        /// <summary>
        /// 删除卡券
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public static ErrorEntity Delete(string accessToken, string cardId)
        {
            var obj = new { card_id = cardId };
            var url = string.Format("https://api.weixin.qq.com/card/delete?access_token={0}", accessToken);
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

        public static CodeInfo QueryCode(string accessToken, string code, string cardId = "")
        {
            var obj = new { code = code, card_id = cardId };
            var url = string.Format("https://api.weixin.qq.com/card/code/get?access_token={0}", accessToken);
            return Utils.PostResult<CodeInfo>(obj, url);
        }
        /// <summary>
        /// 获取卡券详情
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public static CardInfo GetCardInfo(string accessToken, string cardId)
        {
            var obj = new { card_id = cardId };
            var url = string.Format("https://api.weixin.qq.com/card/get?access_token={0}", accessToken);
            var ret = Utils.PostResult<CardInfo>(obj, url);
            if (ret.card != null && ret.card.Count == 2)
            {
                var dic = new Dictionary<string, object>();
                var card_type = ret.card["card_type"].ToString();
                dic.Add("card_type", card_type);
                var info = ret.card[card_type.ToLower()].ToString();
                switch (ret.card["card_type"].ToString())
                {
                    case "GENERAL_COUPON":
                        dic.Add(card_type, JsonConvert.DeserializeObject<General_Coupon>(info)); break;
                    case "GROUPON":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Groupon>(info)); break;
                    case "DISCOUNT":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Discount>(info)); break;
                    case "GIFT":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Gift>(info)); break;
                    case "CASH":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Cash>(info)); break;
                    case "MEMBER_CARD":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Member_Card>(info)); break;
                    case "SCENIC_TICKET":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Scenic_Ticket>(info)); break;
                    case "MOVIE_TICKET":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Movie_Ticket>(info)); break;
                    case "BOARDING_PASS":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Boarding_Pass>(info)); break;
                    case "MEETING_TICKET":
                        dic.Add(card_type, JsonConvert.DeserializeObject<Meeting_Ticket>(info)); break;
                }
                ret.card = dic;
            }
            return ret;
        }
        /// <summary>
        /// 更新code
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cardId">卡券ID</param>
        /// <param name="code">卡券code</param>
        /// <param name="new_code">新code</param>
        /// <returns></returns>
        public static ErrorEntity UpdateCode(string accessToken, string cardId, string code, string new_code)
        {
            var url = string.Format("https://api.weixin.qq.com/card/code/update?access_token={0}", accessToken);
            var obj = new { code = code, card_id = cardId, new_code = new_code };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 设置卡券失效
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="code"></param>
        /// <param name="cardId">自定义 code 的卡券必填。非自定义 code的卡券不填</param>
        /// <returns></returns>
        public static ErrorEntity Unavailable(string accessToken, string code, string cardId = "")
        {
            var url = string.Format("https://api.weixin.qq.com/card/code/unavailable?access_token={0}", accessToken);
            var obj = new { code = code, card_id = cardId };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cardId">卡券标示</param>
        /// <param name="sum">修改的数量。 正数为增加，负数为减少。</param>
        /// <returns></returns>
        public static ErrorEntity ModifyStock(string accessToken, string cardId, int sum)
        {
            var url = string.Format("https://api.weixin.qq.com/card/modifystock?access_token={0}", accessToken);
            var dic = new Dictionary<string, string>();
            var obj = new
            {
                increase_stock_value = sum > 0 ? sum : 0,
                reduce_stock_value = sum > 0 ? 0 : Math.Abs(sum),
                card_id = cardId
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

        public static ErrorEntity UpdateCard(string accessToken, string cardId, BaseCard baseCard)
        {
            var url = string.Format("https://api.weixin.qq.com/card/update?access_token={0}", accessToken);
            var dic = new Dictionary<string, object>();
            dic.Add("card_id", cardId);
            dic.Add(baseCard.GetType().Name.ToLower(), baseCard);
            return Utils.PostResult<ErrorEntity>(dic, url);
        }
        /// <summary>
        /// 更新卡券字段（只包括基础信息字段）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cardId"></param>
        /// <param name="cardType">卡券类型</param>
        /// <param name="bik">字段键值对</param>
        /// <returns></returns>
        public static ErrorEntity UpdateCardField(string accessToken, string cardId, CardType cardType, Dictionary<BaseInfoKey, object> bik)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("card_id", cardId);
            dic.Add(cardType.ToString().ToLower(), new { base_info = bik });
            return UpdateCardField(accessToken, dic);
        }
       /// <summary>
        /// 更新卡券字段（特殊卡券更新。包括共有的基础字段和私有字段）
       /// </summary>
       /// <param name="accessToken"></param>
       /// <param name="cardId"></param>
        /// <param name="cardType">卡券类型</param>
       /// <param name="pik">字段键值对</param>
       /// <returns></returns>
        public static ErrorEntity UpdateCardField(string accessToken, string cardId, CardType cardType, Dictionary<Enum, object> pik)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("card_id", cardId);
            dic.Add(cardType.ToString().ToLower(),pik);
            return UpdateCardField(accessToken, dic);
        }
        private static ErrorEntity UpdateCardField(string accessToken,object obj)
        {
            var url = string.Format("https://api.weixin.qq.com/card/update?access_token={0}", accessToken);
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 激活会员卡
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="membership_number">会员卡号</param>
        /// <param name="code"></param>
        /// <param name="init_bonus">初始化积分</param>
        /// <param name="init_balance">初始化余额</param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public static ErrorEntity ActivateMemberCard(string accessToken, string membership_number, string code, int init_bonus = 0, int init_balance = 0, string cardId = "")
        {
            var url = string.Format("https://api.weixin.qq.com/card/membercard/activate?access_token={0}", accessToken);
            var obj = new
            {
                init_bonus = init_bonus,
                init_balance = init_balance,
                membership_number = membership_number,
                code = code,
                card_id = cardId
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        public static ErrorEntity ActivateMemberCard(string accessToken, string cardId, string bonus_url, string balance_url, string membership_number, string code)
        {
            var url = string.Format("https://api.weixin.qq.com/card/membercard/activate?access_token={0}", accessToken);
            var obj = new
            {
                bonus_url = bonus_url,
                balance_url = balance_url,
                membership_number = membership_number,
                code = code,
                card_id = cardId
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        //public static ErrorEntity ActivateMemberCard(string accessToken, string cardId, string bonus, string balance, string membership_number, string code)
        //{
        //    var url = string.Format("https://api.weixin.qq.com/card/membercard/activate?access_token={0}", accessToken);
        //    var obj = new
        //    {
        //        bonus = bonus,
        //        balance = balance,
        //        membership_number = membership_number,
        //        code = code,
        //        card_id = cardId
        //    };
        //    return Utils.PostResult<ErrorEntity>(obj, url);
        //}
        /// <summary>
        /// 会员卡交易后每次积分及余额变更需通过接口通知微信
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="code">要消耗的序列号。</param>
        /// <param name="add_bonus">需要变更的积分，扣除积分用“-“表示。 </param>
        /// <param name="record_bonus">商家自定义积分消耗记录，不超过 14 个汉字。</param>
        /// <param name="add_balance">需要变更的余额，扣除金额用“-”表示。单位为分 </param>
        /// <param name="record_balance">商家自定义金额消耗记录，不超过 14 个汉字。 </param>
        /// <param name="card_id">要消耗序列号所述的 card_id。 自定义 code 的会员卡必填。 </param>
        /// <returns></returns>
        public static MemberCardResult UpdateMemberCard(string accessToken, string code, int add_bonus = 0, string record_bonus = "", int add_balance = 0, string record_balance = "", string card_id = "")
        {
            var url = string.Format("https://api.weixin.qq.com/card/membercard/updateuser?access_token={0}", accessToken);
            var obj = new
            {
                code = code,
                add_balance = add_balance,
                record_balance = record_balance,
                add_bonus = add_bonus,
                record_bonus = record_bonus,
                card_id = card_id
            };
            return Utils.PostResult<MemberCardResult>(obj, url);
        }

        public static ErrorEntity UpdateMovieTicket(string accessToken, string code, string ticket_class, int show_time, int duration, string screening_room, string[] seat_number, string card_id = "")
        {
            var url = string.Format("https://api.weixin.qq.com/card/movieticket/updateuser?access_token={0}", accessToken);
            var obj = new
            {
                code = code,
                card_id = card_id,
                ticket_class = ticket_class,
                show_time = show_time,
                duration = duration,
                screening_room = screening_room,
                seat_number = seat_number
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

        public static ErrorEntity CheckIn(string accessToken, string code, string passenger_name,
            string @class, string etkt_bnr, string seat = "", string qrcode_data = "", bool is_cancel = false, string card_id = "")
        {
            var url = string.Format("https://api.weixin.qq.com/card/boardingpass/checkin?access_token={0}", accessToken);
            var obj = new
            {
                code = code,
                card_id = card_id,
                passenger_name = passenger_name,
                @class = @class,
                seat = seat,
                etkt_bnr = etkt_bnr,
                qrcode_data = qrcode_data,
                is_cancel = is_cancel

            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 更新会议门票接口
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="code"></param>
        /// <param name="begin_time">开场时间</param>
        /// <param name="end_time">结束时间</param>
        /// <param name="zone">区域</param>
        /// <param name="entrance">入口</param>
        /// <param name="seat_number">座位号。</param>
        /// <param name="card_id"></param>
        /// <returns></returns>
        public static ErrorEntity UpdateMeeting(string accessToken, string code, int begin_time, int end_time, string zone = "", string entrance = "", string seat_number = "", string card_id = "")
        {
            var url = string.Format("https://api.weixin.qq.com/card/meetingticket/updateuser?access_token={0}", accessToken);
            var obj = new
            {
                code = code,
                card_id = card_id,
                zone = zone,
                entrance = entrance,
                seat_number = seat_number,
                begin_time = begin_time,
                end_time = end_time
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

    }
}
