using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;
using WxApi.ReceiveEntity.Shop;
using WxApi.SendEntity.Shop;

namespace WxApi.Shop
{
    /// <summary>
    /// 运费管理
    /// </summary>
    public class DeliveryManage
    {
        /// <summary>
        /// 添加运费模版
        /// </summary>
        /// <param name="template">模版</param>
        public static DeliveryIDEntity AddTemplate(DeliveryTemplate template,string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/express/add?access_token={0}",accessToken);
            var obj = new {delivery_template = template};
            return Utils.PostResult<DeliveryIDEntity>(obj, url);
        }
        /// <summary>
        /// 删除运费模版
        /// </summary>
        /// <param name="templateId">模板ID</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity DelTemplate(string templateId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/express/del?access_token={0}", accessToken);
            var obj = new { template_id =templateId};
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 更新运费模版
        /// </summary>
        /// <param name="template">运费模版</param>
        /// <param name="templateId">模板ID</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity UpdateTemplate(DeliveryTemplateInfo dti,string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/express/update?access_token={0}", accessToken);
            return Utils.PostResult<DeliveryIDEntity>(dti, url);
        }
        /// <summary>
        /// 获取指定ID的运费模板
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static DeliveryInfoRev GetTemplateInfo(string templateId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/express/getbyid?access_token={0}", accessToken);
            var obj = new { template_id = templateId };
            return Utils.PostResult<DeliveryInfoRev>(obj, url);
        }
        /// <summary>
        /// 获取所有邮费模板
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static DeliveryList GetList(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/express/getall?access_token={0}",accessToken);
            return Utils.GetResult<DeliveryList>(url);
        }
    }
}
