using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi
{
    /// <summary>
    ///  事件类型枚举
    /// </summary>
   public enum EventType
    {
        /// <summary>
        /// 非事件类型
        /// </summary>
        NOEVENT,
        /// <summary>
        /// 订阅
        /// </summary>
        SUBSCRIBE,
        /// <summary>
        /// 取消订阅
        /// </summary>
        UNSUBSCRIBE,
        /// <summary>
        /// 扫描带参数的二维码
        /// </summary>
        SCAN,
        /// <summary>
        /// 地理位置
        /// </summary>
        LOCATION,
        /// <summary>
        /// 单击按钮
        /// </summary>
        CLICK,
        /// <summary>
        /// 链接按钮
        /// </summary>
        VIEW,
        /// <summary>
        /// 扫码推事件
        /// </summary>
        SCANCODE_PUSH,
        /// <summary>
        /// 扫码推事件且弹出“消息接收中”提示框
        /// </summary>
        SCANCODE_WAITMSG,
        /// <summary>
        /// 弹出系统拍照发图
        /// </summary>
        PIC_SYSPHOTO,
        /// <summary>
        /// 弹出拍照或者相册发图
        /// </summary>
        PIC_PHOTO_OR_ALBUM,
        /// <summary>
        /// 弹出微信相册发图器
        /// </summary>
        PIC_WEIXIN,
        /// <summary>
        /// 弹出地理位置选择器
        /// </summary>
        LOCATION_SELECT,
        /// <summary>
        /// 模板消息推送
        /// </summary>
        TEMPLATESENDJOBFINISH,
       /// <summary>
       /// 群发消息推送
       /// </summary>
        MASSSENDJOBFINISH,
       /// <summary>
       /// 创建客服会话
       /// </summary>
        KF_CREATE_SESSION,
       /// <summary>
       /// 关闭客服会话
       /// </summary>
        KF_CLOSE_SESSION,
       /// <summary>
       /// 转接客服会话
       /// </summary>
        KF_SWITCH_SESSION,
       /// <summary>
       /// 微信小店订单
       /// </summary>
        MERCHANT_ORDER,
       /// <summary>
       /// 门店审核事件
       /// </summary>
        POI_CHECK_NOTIFY,
       /// <summary>
       /// 卡券通过审核
       /// </summary>
        CARD_PASS_CHECK,
       /// <summary>
       /// 卡券未通过审核
       /// </summary>
        CARD_NOT_PASS_CHECK,
       /// <summary>
       /// 用户领取卡券
       /// </summary>
        USER_GET_CARD,
       /// <summary>
       /// 用户删除卡券
       /// </summary>
        USER_DEL_CARD,
       /// <summary>
       /// 进入会员卡事件
       /// </summary>
        USER_VIEW_CARD,
       /// <summary>
       /// 卡券核销
       /// </summary>
        USER_CONSUME_CARD
    }
}
