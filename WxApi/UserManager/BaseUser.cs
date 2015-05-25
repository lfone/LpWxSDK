using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;

namespace WxApi.UserManager
{
    public class BaseUser
    {
        public static UserInfo GetUserInfo(string OpenID, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}",
                accessToken, OpenID);
            return Utils.GetResult<UserInfo>(url);
        }
        /// <summary>
        /// 设置用户备注
        /// </summary>
        /// <param name="OpenID"></param>
        /// <param name="remark"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity UpdateRemark(string OpenID, string remark, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token={0}&openid={1}",
                accessToken, OpenID);
            return Utils.GetResult<ErrorEntity>(url);
        }
        /// <summary>
        /// 获取关注用户列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="next_openid"></param>
        /// <returns></returns>
        public static UserListEntity GetUserList(string accessToken, string next_openid="")
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}",accessToken,next_openid);
            var retdata = Utils.GetResult<UserListEntity>(url);
            //判断调用是否成功。当调用成功，且总关注人数大于10000,且本次获取到的用户数量等于10000，则说明有尚未获取到的用户，递归调用，添加到列表
            if (retdata.ErrCode == 0 && retdata.total > 10000 && retdata.count == 10000)
            {
                retdata.data.openid.AddRange(GetUserList(accessToken, retdata.next_openid).data.openid);
            }
            return retdata;
        }
    }
}
