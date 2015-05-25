using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WxApi;
using WxApi.MsgEntity;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;
using WxTest.CaseTwo;

namespace WxTest
{
    /// <summary>
    /// wx 的摘要说明
    /// </summary>
    public class wx : IHttpHandler
    {
        static EnterParam param;
        public void ProcessRequest(HttpContext context)
        {
            //如果param为null，则实例化
            param = param ?? new EnterParam
           {
               appid = "wx891ee9903ba8d74e",
               EncodingAESKey = "nKh7i1tBlQoFFp3bBX99e536VsM2tX4fIjjVFqKiKt3",
               token = "qqq"
           };
            //var ip = context.Request.UserHostAddress;
            //var ipEntity = BaseServices.GetIpArray("你的access_token");
            //if (ipEntity!=null&&!ipEntity.ip_list.Contains(ip))
            //{
            //    context.Response.Write("非法请求");
            //    return;
            //}
            if (context.Request.HttpMethod == "GET")
            {
                BaseServices.ValidUrl(param.token);
            }
            else
            {
                //判断MsgHandlerEntities是否为空，如果是，则实例化，并将各个消息类型的处理程序实体添加到此列表中
                //因为MsgHandlerEntities是静态变量，只需绑定一次即可。免去了重复绑定的性能损耗。
                if (MsgHandlerEntity.MsgHandlerEntities == null)
                {
                    MsgHandlerEntity.MsgHandlerEntities = new List<MsgHandlerEntity>();

                    #region 文本消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.TEXT,
                        Action = TextHandler
                    });
                    #endregion

                    #region 图片消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.IMAGE,
                        Action = ImgHandler
                    });
                    #endregion

                    #region 语音消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.VOICE,
                        Action = VoiceHandler
                    });
                    #endregion

                    #region 视频消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.VIDEO,
                        Action = VideoHandler
                    });
                    #endregion

                    #region 地理位置消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.LOCATION,
                        Action = LoctionHandler
                    });
                    #endregion

                    #region 链接消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.LINK,
                        Action = linkHandler
                    });
                    #endregion

                    #region 群发消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.MASSSENDJOBFINISH,
                        Action = GroupJobHandler
                    });
                    #endregion

                    #region 模板消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.TEMPLATESENDJOBFINISH,
                        Action = TemplateJobHandler
                    });
                    #endregion

                    #region 扫描带参数二维码消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.SCAN,
                        Action = SanQrEventHandler
                    });
                    #endregion

                    #region 自定义菜单Click消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.CLICK,
                        Action = ClickEventHandler
                    });
                    #endregion

                    #region 自定义菜单View消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.VIEW,
                        Action = ViewEventHandler
                    });
                    #endregion

                    #region 自定义菜单扫描二维码（scancode_push）消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.SCANCODE_PUSH,
                        Action = MenuSanQrEventHandler
                    });
                    #endregion

                    #region 自定义菜单扫描二维码（scancode_waitmsg）消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.SCANCODE_WAITMSG,
                        Action = MenuSanQrEventHandler
                    });
                    #region 自定义菜单扫描二维码（scancode_waitmsg）消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.SCANCODE_WAITMSG,
                        Action = MenuSanQrEventHandler
                    });
                    #endregion
                    #endregion

                    #region 自定义菜单发送图片（pic_sysphoto）消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.PIC_SYSPHOTO,
                        Action = MenuSendPicEventHandler
                    });
                    #region 自定义菜单发送图片（pic_photo_or_album）消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.PIC_PHOTO_OR_ALBUM,
                        Action = MenuSendPicEventHandler
                    });
                    #endregion

                    #region 自定义菜单发送图片（pic_weixin）消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.PIC_WEIXIN,
                        Action = MenuSendPicEventHandler
                    });
                    #endregion
                    #endregion

                    #region 创建多客服会话消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.KF_CREATE_SESSION,
                        Action = KfHandler
                    });
                    #endregion

                    #region 关闭多客服会话消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.KF_CLOSE_SESSION,
                        Action = KfHandler
                    });
                    #endregion

                    #region 转接多客服会话消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.KF_SWITCH_SESSION,
                        Action = KfHandler
                    });
                    #endregion

                    #region 微信小店订单消息处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.MERCHANT_ORDER,
                        Action = OrderHandler
                    });
                    #endregion

                    #region 门店审核处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.POI_CHECK_NOTIFY,
                        Action = PoiNotifyHandler
                    });
                    #endregion

                    #region 卡券审核通过处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.CARD_PASS_CHECK,
                        Action = CardCheckNotifyHandler
                    });
                    #endregion
                    #region 卡券审核未通过处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.CARD_NOT_PASS_CHECK,
                        Action = CardCheckNotifyHandler
                    });
                    #endregion
                    #region 领取卡券处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.USER_GET_CARD,
                        Action = UserGetCardHandler
                    });
                    #endregion

                    #region 关注事件处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.SUBSCRIBE,
                        Action = SubscribeHandler
                    });
                    #endregion
                    #region 取消关注事件处理绑定
                    MsgHandlerEntity.MsgHandlerEntities.Add(new MsgHandlerEntity
                    {
                        MsgType = MsgType.EVENT,
                        EventType = EventType.UNSUBSCRIBE,
                        Action = SubscribeHandler
                    });
                    #endregion
                }

                MsgFactory.LoadMsg(param, MsgHandlerEntity.MsgHandlerEntities);
            }
        }

        private void SubscribeHandler(BaseMsg obj)
        {
            var msg = obj as SubEventMsg;
            QrLogin(msg, msg.EventKey);
        }

        private void CardCheckNotifyHandler(BaseMsg baseMsg)
        {
            var msg = baseMsg as CardCheckEventMsg;
        }

        private void UserGetCardHandler(BaseMsg baseMsg)
        {
            var accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
            var msg = baseMsg as GetCardEventMsg;
            var ss = CardVoucher.UpdateMeeting(accessToken, msg.UserCardCode, Utils.ConvertDateTimeInt(DateTime.Now.AddHours(2)),
                Utils.ConvertDateTimeInt(DateTime.Now.AddHours(4)), "C区", "东北门", "2 排 15 号");
        }

        #region 群发消息推送处理程序
        private void GroupJobHandler(BaseMsg baseMsg)
        {
            //此处编写业务处理代码
        }
        #endregion

        #region 模板消息推送处理程序
        private void TemplateJobHandler(BaseMsg baseMsg)
        {
            //此处编写业务处理代码
        }
        #endregion

        #region 扫描带参数二维码处理程序
        private void SanQrEventHandler(BaseMsg baseMsg)
        {
            //此处编写业务处理代码
            var msg = baseMsg as ScanQrEventMsg;
            QrLogin(msg, msg.EventKey);
        }
        #endregion

        #region 自定义菜单扫描二维码处理程序
        private void MenuSanQrEventHandler(BaseMsg baseMsg)
        {
            //此处编写业务处理代码
        }
        #endregion


        #region 自定义菜单发送图片处理程序
        private void MenuSendPicEventHandler(BaseMsg baseMsg)
        {
            //此处编写业务处理代码
        }
        #endregion

        #region 文本消息处理程序
        /// <summary>
        /// 文本消息处理程序
        /// </summary>
        private void TextHandler(BaseMsg baseMsg)
        {
            var msg = baseMsg as TextMsg;
            baseMsg.ResText(param,msg.Content);
            //baseMsg.TransDkf(param);
        }
        #endregion

        #region 图片消息处理程序
        /// <summary>
        /// 图片消息处理程序
        /// </summary>
        private void ImgHandler(BaseMsg baseMsg)
        {
            var msg = (ImgMsg)baseMsg;

        }
        #endregion

        #region 视频消息处理程序
        /// <summary>
        /// 视频消息处理程序
        /// </summary>
        private void VideoHandler(BaseMsg baseMsg)
        {
            var msg = (VideoMsg)baseMsg;

        }
        #endregion

        #region 语音消息处理程序
        /// <summary>
        /// 语音消息处理程序
        /// </summary>
        private void VoiceHandler(BaseMsg baseMsg)
        {
            var msg = (VoiceMsg)baseMsg;

        }
        #endregion

        #region 链接消息处理程序
        /// <summary>
        /// 链接消息处理程序
        /// </summary>
        private void linkHandler(BaseMsg baseMsg)
        {
            var msg = (LinkMsg)baseMsg;

        }
        #endregion

        #region 地理位置消息处理程序
        /// <summary>
        /// 地理位置消息处理程序
        /// </summary>
        private void LoctionHandler(BaseMsg baseMsg)
        {
            var msg = (LocationMsg)baseMsg;

        }
        #endregion


        #region 客服消息会话事件推送

        private void KfHandler(BaseMsg baseMsg)
        {
            var msg = (KfEventMsg) baseMsg;
            //处理不同的会话事件
            switch (msg.Event)
            {
                case EventType.KF_CLOSE_SESSION:
                    break;
                case EventType.KF_CREATE_SESSION:
                    break;
                case EventType.KF_SWITCH_SESSION:
                    break;
            }
        }
        #endregion

        #region 订单消息事件推送

        private void OrderHandler(BaseMsg baseMsg)
        {
            var msg = (OrderEventMsg)baseMsg;
          
        }
        #endregion

        #region 门店审核事件推送

        private void PoiNotifyHandler(BaseMsg baseMsg)
        {
            var msg = (PoiNotifyEventMsg)baseMsg;

        }

        void ClickEventHandler(BaseMsg baseMsg)
        {
            var msg = (BaseMenuEventMsg) baseMsg;
        }

        void ViewEventHandler(BaseMsg baseMsg)
        {
            var msg = (BaseMenuEventMsg)baseMsg;
        }
        #endregion

        #region 带参数二维码登陆处理

        void QrLogin(BaseMsg baseMsg,string key)
        {
            var app = HttpContext.Current.Application;
            app.Lock();
            var logins = app["logins"] as List<WxLogin>;
            var logininfo = logins.FirstOrDefault(l => l.key.ToString() == key);
            if (logininfo == null)
            {
                baseMsg.ResText(param, "不存在登陆信息");
            }
            else
            {
                logininfo.openid = baseMsg.FromUserName;
                HttpContext.Current.Response.Write("");
            }
            app.UnLock();
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}