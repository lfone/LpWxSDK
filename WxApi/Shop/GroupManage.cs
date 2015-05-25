using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;
using WxApi.ReceiveEntity.Shop;
using WxApi.SendEntity.Shop;

namespace WxApi.Shop
{
    public class GroupManage
    {
        /// <summary>
        /// 增加分组
        /// </summary>
        /// <param name="groupName">分组名称</param>
        /// <param name="productList">商品ID集合</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static GroupId Add(string groupName, List<string> productList, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/group/add?access_token={0}", accessToken);
            var obj = new { group_detail = new { group_name = groupName, product_list = productList } };
            return Utils.PostResult<GroupId>(obj, url);
        }
        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="groupId">分组ID</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity Delete(string groupId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/group/del?access_token={0}", accessToken);
            var obj = new { group_id = groupId };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="groupId">分组ID</param>
        /// <param name="groupName">分组名</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity UpdateName(string groupId, string groupName, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/group/propertymod?access_token={0}", accessToken);
            var obj = new { group_id = groupId, group_name = groupName };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 修改分组的商品列表
        /// </summary>
        /// <param name="groupId">分组ID</param>
        /// <param name="product">分组的商品集合</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity UpdateProduct(string groupId, List<ModProduct> product, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/group/propertymod?access_token={0}", accessToken);
            var obj = new { group_id = groupId, product = product };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

        /// <summary>
        /// 获取所有分组
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static GroupList GetList(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/group/getall?access_token={0}",accessToken);
            return Utils.GetResult<GroupList>(url);
        }

        /// <summary>
        /// 根据分组ID获取分组详情
        /// </summary>
        /// <param name="groupId">分组ID</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static GroupInfo GetDetail(string groupId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/group/getbyid?access_token={0}", accessToken);
            var obj = new { group_id = groupId};
            return Utils.PostResult<GroupInfo>(obj, url);
        }
    }
}
