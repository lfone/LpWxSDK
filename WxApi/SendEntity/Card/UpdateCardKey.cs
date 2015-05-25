using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.SendEntity.Card
{
    /// <summary>
    /// 卡券可更新基础字段枚举
    /// </summary>
    public enum BaseInfoKey
    {
        /// <summary>
        /// 卡券的商户 logo。
        /// </summary>
        logo_url,
        /// <summary>
        /// 使用提醒。（一句话描述，展示在首页）
        /// </summary>
        notice,
        /// <summary>
        /// 使用说明。长文本描述，可以分行。
        /// </summary>
        description,
        /// <summary>
        /// 客服电话。 
        /// </summary>
        service_phone,
        /// <summary>
        /// 券颜色。按色彩规范标注填写 Color010-Color100
        /// </summary>
        color,
        /// <summary>
        /// 门店 id 列表。
        /// </summary>
        location_id_list,
        /// <summary>
        /// 自定义跳转入口的名字。 
        /// </summary>
        custom_url_name,
        /// <summary>
        /// 自定义跳转的 url。
        /// </summary>
        custom_url,
        /// <summary>
        /// 显示在入口右侧的 tips，长度限制在 6 个汉字内。
        /// </summary>
        custom_url_sub_title,
        /// <summary>
        /// 营销场景的自定义入口。
        /// </summary>
        promotion_url_name,
        /// <summary>
        /// 入口跳转外链的地址链接。
        /// </summary>
        promotion_url,
        /// <summary>
        /// 显示在入口右侧的 tips，长度限制在 6 个汉字内。
        /// </summary>
        promotion_url_sub_title,
        /// <summary>
        /// code 类型
        /// </summary>
        code_type,
        /// <summary>
        /// 用券限制
        /// </summary>
        use_limit,
        /// <summary>
        /// 领券限制
        /// </summary>
        get_limit,
        /// <summary>
        /// 是否可转增
        /// </summary>
        can_give_friend,
        /// <summary>
        /// 是否可分享
        /// </summary>
        can_share,
        /// <summary>
        /// 卡券日期
        /// </summary>
        date_info
    }

    /// <summary>
    /// 卡券日期字段枚举。使用日期，有效期时间修改仅支持有效区间的扩大。
    /// </summary>
    public enum DateInfoKey
    {
        /// <summary>
        /// 1：固定日期区间，仅支持更改 type 为 1 的时间戳，暂不支持 type2 的修改。
        /// </summary>
        type,
        /// <summary>
        /// 固定日期区间专用，表示起用时间。（单位为秒）
        /// </summary>
        begin_timestamp,
        /// <summary>
        /// 固定日期区间专用，表示结束时间。结束时间仅支持往后延长。
        /// </summary>
        end_timestamp
    }
    /// <summary>
    /// 会员卡可修改字段枚举
    /// </summary>
    public enum MemberCardKey
    {
        /// <summary>
        /// 积分清零规则
        /// </summary>
        bonus_cleared,
        /// <summary>
        /// 积分规则
        /// </summary>
        bonus_rules,
        /// <summary>
        /// 储值说明 
        /// </summary>
        balance_rules,
        /// <summary>
        /// 特权说明 
        /// </summary>
        prerogative,
        /// <summary>
        /// 基础信息
        /// </summary>
        base_info
    }

    /// <summary>
    /// 飞机票可修改字段枚举
    /// </summary>
    public enum BoardingPassKey
    {
        /// <summary>
        /// 起飞时间
        /// </summary>
        departure_time,
        /// <summary>
        /// 降落时间 
        /// </summary>
        landing_time,
        /// <summary>
        /// 登机口。如发生登机口变更，建议商家实时调用该接口变更。
        /// </summary>
        gate,
        /// <summary>
        /// 登机时间，只显示“时分”不显示日期，按时间戳格式填写。如发生登机时间变更，建议商家实时调用该接口变更。
        /// </summary>
        boarding_time,
        /// <summary>
        /// 基础信息
        /// </summary>
        base_info
    }

    /// <summary>
    /// 景点门票可修改字段枚举
    /// </summary>
    public enum ScenicTicketKey
    {
        /// <summary>
        /// 导览图 url
        /// </summary>
        guide_url,
        /// <summary>
        /// 基础信息
        /// </summary>
        base_info
    }
    /// <summary>
    /// 电影票可修改字段枚举
    /// </summary>
    public enum MovieTicketKey
    {
        /// <summary>
        /// 电影票详情 
        /// </summary>
        detail,
        /// <summary>
        /// 基础信息
        /// </summary>
        base_info
    }
    /// <summary>
    /// 会议可修改字段枚举
    /// </summary>
    public enum MeetingTicketKey
    {
        /// <summary>
        /// 会场导览图
        /// </summary>
        map_url,
        /// <summary>
        /// 基础信息
        /// </summary>
        base_info
    }
}
