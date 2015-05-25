using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi
{
    /// <summary>
    /// 授权类型
    /// </summary>
    public enum AuthType
    {
        /// <summary>
        /// 静默授权，获取openid
        /// </summary>
        snsapi_base,
        /// <summary>
        /// 非静默授权，需用户同意。  获取用户详细信息。
        /// </summary>
        snsapi_userinfo
    }
}
