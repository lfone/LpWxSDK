using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxTest
{
    /// <summary>
    /// paynotify 的摘要说明
    /// </summary>
    public class paynotify : IHttpHandler
    {
        private string key = "c4115c3cbb9e4f64b3d0cfb726e06001";
        public void ProcessRequest(HttpContext context)
        {
            WxApi.Pay.GetNotifyRes(key, e =>
            {
                //订单业务逻辑处理。需要先判断订单是否已经被处理，如已经被处理则直接回复处理结果。
                if (true) //订单处理成功
                {
                    WxApi.Pay.BackMessage();
                }
                else
                {
                    WxApi.Pay.BackMessage("错误原因");
                }
            });
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