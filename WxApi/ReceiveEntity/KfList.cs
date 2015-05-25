using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 获取客服基本信息接口返回实体
    /// </summary>
    public class KfList:ErrorEntity
    {
        public List<KfInfo> kf_list { get; set; }
    }
    public class KfInfo
    {
        /// <summary>
        /// 完整客服账号，格式为：账号前缀@公众号微信号
        /// </summary>
        public string kf_account { get; set; }
        /// <summary>
        /// 客服头像
        /// </summary>
        public string kf_headimgurl { get; set; }
        /// <summary>
        /// 客服工号
        /// </summary>
        public string kf_id { get; set; }
        /// <summary>
        /// 客服昵称
        /// </summary>
        public string kf_nick { get; set; }
    }
}
