using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WxApi;
using WxApi.PayEntity;

namespace WxTest
{
    /// <summary>
    /// nativenotify 的摘要说明
    /// </summary>
    public class nativenotify : IHttpHandler
    {
        private string key = "c4115c3cbb9e4f64b3d0cfb726e06001";
        string notify_url = "http://{0}/paynotify.ashx";
        public void ProcessRequest(HttpContext context)
        {
            WxApi.Pay.GetNotiveRes(key, e =>
            {
                //创建订单

                //创建订单
                var un = new UnifiedEntity
                {
                    appid = e.appid,
                    body = "测试商品",
                    mch_id = e.mch_id,
                    nonce_str = e.nonce_str,
                    notify_url = string.Format(notify_url, Utils.GetCurrentFullHost()),
                    out_trade_no = Utils.GetGuid(),
                    openid = e.openid,
                    product_id = e.product_id,
                    spbill_create_ip = Utils.GetIP(),
                    total_fee = 1,
                    trade_type = "NATIVE"
                };
                return WxApi.Pay.UnifiedOrder(un,key);//调用一般处理程序
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