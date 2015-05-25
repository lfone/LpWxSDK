using System.Collections.Generic;

namespace WxApi.SendEntity.Card
{

    public class Sku
    {
        /// <summary>
        /// 卡券库存的数量（不支持填写0或无限大）
        /// </summary>
        public int quantity { get; set; }
    }
    /// <summary>
    /// 卡券日期信息
    /// </summary>
    public class DateInfo
    {
        /// <summary>
        /// 使用时间的类型，仅支持选择一种时间类型的字段填入。1：固定日期区间，2：固定时长（自领取后按天算）
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// type 为 1 时专用， 表示起用时间。  unix时间戳
        /// </summary>
        public string begin_timestamp { get; set; }
        /// <summary>
        /// type 为 1 时专用， 表示结束时间。  unix时间戳
        /// </summary>
        public string end_timestamp { get; set; }
        /// <summary>
        /// type 为 2 时专用，表示自领取后多少天内有效。（单位为天）领取后当天有效填写 0。
        /// </summary>
        public int? fixed_term { get; set; }
        /// <summary>
        /// type 为 2 时专用，表示自领取后多少天开始生效。（单位为天）领取后当天生效填写 0。
        /// </summary>
        public int? fixed_begin_term { get; set; }
    }
    /// <summary>
    /// code码展示类型
    /// </summary>
    public enum CodeType
    {
        /// <summary>
        /// 文本
        /// </summary>
        CODE_TYPE_TEXT,
        /// <summary>
        /// 一维码
        /// </summary>
        CODE_TYPE_BARCODE,
        /// <summary>
        /// 二维码
        /// </summary>
        CODE_TYPE_QRCODE,
        /// <summary>
        /// 二维码无code显示
        /// </summary>
        CODE_TYPE_ONLY_QRCODE,
        /// <summary>
        ///一维码无code显示
        /// </summary>
        CODE_TYPE_ONLY_BARCODE
    }
    /// <summary>
    /// 卡券基本信息
    /// </summary>
    public class BaseInfo
    {
        /// <summary>
        /// 卡券的商户 logo，尺寸为300*300。
        /// </summary>
        public string logo_url { get; set; }
        /// <summary>
        /// code 码展示类型。
        /// </summary>
        public CodeType code_type { get; set; }
        /// <summary>
        /// 商户名字,字数上限为 12 个汉字。（填写直接提供服务的商户名，第三方商户名填写在 source 字段）
        /// </summary>
        public string brand_name { get; set; }
        /// <summary>
        /// 券名，字数上限为 9 个汉字。(建议涵盖卡券属性、服务及金额)
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 券名的副标题， 字数上限为 18 个汉字。
        /// </summary>
        public string sub_title { get; set; }
        /// <summary>
        /// 券颜色。
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 使用提醒，字数上限为 12 个汉字。（一句话描述，展示在首页，示例：请出示二维码核销卡券）
        /// </summary>
        public string notice { get; set; }
        /// <summary>
        /// 使用说明。长文本描述，可以分行，上限为 1000 个汉字。
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 使用日期，有效期的信息。
        /// </summary>
        public DateInfo date_info { get; set; }
        /// <summary>
        /// 门店位置 ID。商户需在 mp 平台上录入门店信息或调用批量导入门店信息接口获取门店位置 ID。
        /// </summary>
        public List<string> location_id_list { get; set; }
        /// <summary>
        /// 是否自定义 code 码。填写 true或 false，不填代表默认为 false。该字段需单独申请权限
        /// </summary>
        public bool use_custom_code { get; set; }
        /// <summary>
        /// 是否指定用户领取，默认为否
        /// </summary>
        public bool bind_openid { get; set; }
        /// <summary>
        /// 领取卡券原生页面是否可分享。默认为true
        /// </summary>
        public bool can_share { get; set; }
        /// <summary>
        /// 是否可转增。默认为true
        /// </summary>
        public bool can_give_friend { get; set; }
        /// <summary>
        /// 每人最大领取次数，不填写默认等于库存
        /// </summary>
        public int get_limit { get; set; }
        /// <summary>
        /// 客服电话
        /// </summary>
        public string service_phone { get; set; }
        /// <summary>
        /// 第三方来源名，例如同程旅游、格瓦拉。
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 商户自定义入口名称，custom_url 字段共同使用，长度限制在 5 个汉字内。
        /// </summary>
        public string custom_url_name { get; set; }
        /// <summary>
        /// 商户自定义入口跳转外链的地址链接,跳转页面内容需与自定义cell 名称保持匹配。
        /// </summary>
        public string custom_url { get; set; }
        /// <summary>
        /// 显示在入口右侧的 tips，长度限制在 6 个汉字内。
        /// </summary>
        public string custom_url_sub_title { get; set; }
        /// <summary>
        /// 营销场景的自定义入口
        /// </summary>
        public string promotion_url_name { get; set; }
        /// <summary>
        /// 入口跳转外链的地址链接
        /// </summary>
        public string promotion_url { get; set; }
        /// <summary>
        /// 显示在入口右侧的 tips，长度限制在 6 个汉字内。
        /// </summary>
        public string promotion_url_sub_title { get; set; }

        public Sku sku { get; set; }
        /// <summary>
        /// 获取卡券详情时的字段，表示卡券的状态。  创建卡券时无效
        /// </summary>
        public CardStatus? status { get; set; }
        /// <summary>
        /// 获取卡券详情时的字段，表示卡券的card_id。  创建卡券时无效
        /// </summary>
        public string id { get; set; }
    }

    public enum CardStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        CARD_STATUS_NOT_VERIFY,
        /// <summary>
        /// 审核失败
        /// </summary>
        CARD_STATUS_VERIFY_FALL,
        /// <summary>
        /// 通过审核
        /// </summary>
        CARD_STATUS_VERIFY_OK,
        /// <summary>
        /// 卡券被用户删除
        /// </summary>
        CARD_STATUS_USER_DELETE,
        /// <summary>
        /// 在公众平台投放过的卡券
        /// </summary>
        CARD_STATUS_DISPATCH
    }
}
