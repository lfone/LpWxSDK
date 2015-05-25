namespace WxApi.PayEntity
{
    public class EPayment
    {
        /// <summary>
        /// 公众账号appid
        /// </summary>
        public string mch_appid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string mchid { get; set; }
        /// <summary>
        /// 子商户号
        /// </summary>
        public string sub_mch_id { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }
        public string sign { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string partner_trade_no { get; set; }
        public string openid { get; set; }
        /// <summary>
        /// NO_CHECK：不校验真实姓名 FORCE_CHECK：强校验真实姓名（未实名认证的用户会校验失败，无法转账） OPTION_CHECK：针对已实名认证的用户才校验真实姓名（未实名认证用户不校验，可以转账成功）
        /// </summary>
        public CheckNameOption check_name { get; set; }
        /// <summary>
        /// 收款用户真实姓名。 如果check_name设置为FORCE_CHECK或OPTION_CHECK，则必填用户真实姓名
        /// </summary>
        public string re_user_name { get; set; }
        /// <summary>
        /// 企业付款金额，单位为分
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// 企业付款描述信息
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 调用接口的机器Ip地址
        /// </summary>
        public string spbill_create_ip { get; set; }
    }
    public enum CheckNameOption
    {
        /// <summary>
        /// 不校验真实姓名 
        /// </summary>
        NO_CHECK,
        /// <summary>
        /// 强校验真实姓名（未实名认证的用户会校验失败，无法转账） 
        /// </summary>
        FORCE_CHECK,
        /// <summary>
        /// 针对已实名认证的用户才校验真实姓名（未实名认证用户不校验，可以转账成功）
        /// </summary>
        OPTION_CHECK
    }
    
}
