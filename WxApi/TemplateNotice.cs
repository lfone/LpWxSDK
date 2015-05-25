using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using WxApi.MsgEntity;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxApi
{

    /// <summary>
    /// 模板消息接口
    /// </summary>
    public class TemplateNotice
    {
        private static Dictionary<string, Dictionary<string, int>> _IndustryList;
        public static Dictionary<string, Dictionary<string, int>> IndustryList
        {
            get
            {
                if (_IndustryList == null)
                    _IndustryList =
                        JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(Code.IndustryCode);
                return _IndustryList;
            }
        }
        /// <summary>
        /// 设置所属行业
        /// </summary>
        /// <param name="id1">主营行业</param>
        /// <param name="id2">副营行业</param>
        /// <param name="accessToken">accessToken</param>
        public static ErrorEntity SetIndustry(string id1, string id2, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token={0}", accessToken);
            var json = new  {industry_id1 = id1,industry_id2 = id2 };
            return Utils.PostResult<ErrorEntity>(json, url);
        }
        /// <summary>
        /// 获取模板ID
        /// </summary>
        /// <param name="templateNo">模板编号</param>
        /// <param name="accessToken">accessToken</param>
        public static TemplateID GeTemplateId(string templateNo, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/template/api_add_template?access_token={0}", accessToken);
            var json = new { template_id_short = templateNo };
            return Utils.PostResult<TemplateID>(json, url);
        }
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="touser">要发送的用户的openid</param>
        /// <param name="template_id">模板ID</param>
        /// <param name="topcolor">消息卡片顶部的颜色</param>
        /// <param name="dataKeys">模板字段列表</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="url">点击消息卡片跳转的地址。默认为空，如果为空，ios设置会跳转到空白页面，安卓则不跳转</param>
        /// <returns>调用成功后，返回的实体的msgid属性指的是此条模板消息的id</returns>
        public static TemplateMsg Send(string touser, string template_id, string topcolor,
            Dictionary<string, TemplateKey> dataKeys, string accessToken, string url = "")
        {
            var turl = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", accessToken);
            var json = new
            {
                touser=touser,
                template_id=template_id,
                url=url,
                topcolor=topcolor,
                data=dataKeys
            };
            return Utils.PostResult<TemplateMsg>(json, turl);
        }
    }
}
