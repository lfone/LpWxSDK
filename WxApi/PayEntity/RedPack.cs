namespace WxApi.PayEntity
{
    public class RedPack
    {
        /// <summary>
        /// 随机字符串 
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名 
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 商户订单号 
        /// </summary>
        public string mch_billno { get; set; }
        /// <summary>
        /// 商户号 
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 子商户号 
        /// </summary>
        public string sub_mch_id { get; set; }
        /// <summary>
        /// 公众账号appid  
        /// </summary>
        public string wxappid { get; set; }
        /// <summary>
        /// 提供方名称  
        /// </summary>
        public string nick_name { get; set; }
        /// <summary>
        /// 商户名称  
        /// </summary>
        public string send_name { get; set; }
        /// <summary>
        /// 用户openid  
        /// </summary>
        public string re_openid { get; set; }
        /// <summary>
        /// 付款金额 
        /// </summary>
        public int total_amount { get; set; }
        /// <summary>
        /// 最小红包金额 
        /// </summary>
        public int min_value { get; set; }
        /// <summary>
        /// 最大红包金额.最小金额等于最大金额： min_value=max_value =total_amount 
        /// </summary>
        public int max_value { get; set; }
        /// <summary>
        /// 红包发放总人数 
        /// </summary>
        public int total_num { get; set; }
        /// <summary>
        /// 红包祝福语  
        /// </summary>
        public string wishing{ get; set; }
        /// <summary>
        /// Ip地址 
        /// </summary>
        public string client_ip{ get; set; }
        /// <summary>
        /// 活动名称 
        /// </summary>
        public string act_name { get; set; }
        /// <summary>
        /// 备注 
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 商户logo的url  
        /// </summary>
        public string logo_imgurl { get; set; }
        /// <summary>
        /// 分享文案  
        /// </summary>
        public string share_content{ get; set; }
        /// <summary>
        /// 分享链接  
        /// </summary>
        public string share_url { get; set; }
        /// <summary>
        /// 分享的图片 
        /// </summary>
        public string share_imgurl{ get; set; }
    }
}
