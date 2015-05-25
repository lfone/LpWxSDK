using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using WxApi.ReceiveEntity;

namespace WxApi.UserManager
{
    /// <summary>
    /// 用户分组管理
    /// </summary>
    public class UserGroup
    {
        public static UserGroupEntity Create(string name, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}", accessToken);
            var obj = new { group = new { name = name } };
            var Jobj = Utils.PostResult<JObject>(obj, url);
            JToken errcode = null;
            errcode = Jobj.GetValue("errcode");
            var ret = new UserGroupEntity();
            if (errcode == null)//判断是否存在错误返回码，如果 不存在，说明分组创建成功。
            {
                ret.ErrCode = 0;
                ret.id = Jobj["group"]["id"].Value<int>();
                ret.name = Jobj["group"]["name"].Value<string>();
            }
            else
            {
                ret.ErrCode = errcode.Value<int>();
            }
            return ret;
        }
        /// <summary>
        /// 查询所有分组
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns>分组列表</returns>
        public static UserGroups QueryAll(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}", accessToken);
            return Utils.GetResult<UserGroups>(url);
        }
        /// <summary>
        /// 根据OpenID获取用户所在的分组
        /// </summary>
        /// <param name="OpenID">OpenID</param>
        /// <param name="accessToken">accessToken</param>
        public static QueryGroupEntity QueryByOpenID(string OpenID, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}", accessToken);
            return Utils.PostResult<QueryGroupEntity>(new { openid = OpenID }, url);
        }
        /// <summary>
        /// 修改用户分组
        /// </summary>
        /// <param name="id">修改的分组ID</param>
        /// <param name="name">修改后的分组名</param>
        /// <param name="accessToken">accessToken</param>
        /// <returns></returns>
        public static ErrorEntity Update(int id, string name, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}", accessToken);
            var obj = new
            {
                group = new { id = id, name = name }
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 移动用户到指定分组
        /// </summary>
        /// <param name="OpenID">OpenID</param>
        /// <param name="to_groupid">需要移动到的分组ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <returns></returns>
        public static ErrorEntity UpdateOpenIdToGroup(string OpenID, int to_groupid, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}", accessToken);
            var obj = new
            {
                openid = OpenID,
                to_groupid = to_groupid
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

        public static ErrorEntity UpdateOpenIdListToGroup(List<string> openid_list, int to_groupid, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/members/batchupdate?access_token={0}", accessToken);
            var obj = new
            {
                openid_list = openid_list,
                to_groupid = to_groupid
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
    }
}
