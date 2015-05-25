using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WxApi;

namespace WxTest
{
    /// <summary>
    /// warn 的摘要说明
    /// </summary>
    public class warn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}