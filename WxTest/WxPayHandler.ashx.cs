using System;
using System.Web;
using Newtonsoft.Json;
using WxApi;
using WxApi.PayEntity;

namespace WxTest
{
    /// <summary>
    /// WxPayHandler 的摘要说明
    /// </summary>
    public class WxPayHandler : IHttpHandler
    {
        private const string key = "c4115c3cbb9e4f64b3d0cfb726e06001";
        private const string notify_url = "http://{0}/paynotify.ashx";
        private const string appid = "appid";
        private const string mch_id = "1240050702";
        private const string certpath = @"C:\apiclient_cert.p12";
        public void ProcessRequest(HttpContext context)
        {
            var action = context.Request.QueryString["action"];
            switch (action)
            {
                case "jspay": JsPay(context); break;
                case "refund": Refund(context); break;
                case "query": OrderIsSuccess(context); break;
                case "native2": Native2(context); break;
                case "nativenotify":
                    NativeNotift(context);break;
                case "scanpay":ScanPay(context);break;
                case "reverse": Reverse(context); break;//撤销订单
                case "close": Close(context); break;//关闭订单
            }
        }
        #region 撤销订单
        void Reverse(HttpContext context)
        {
            var query = new QueryOrder
            {
                appid = appid,
                mch_id = mch_id,
                nonce_str = Utils.GetGuid(),
                out_trade_no = context.Request.Form["out_trade_no"],
                transaction_id = context.Request.Form["transaction_id"]
            };
            var res = WxApi.Pay.ReverseOrder(query, key, certpath, mch_id);
            if (res.return_code == "SUCCESS" && Utils.ValidSign(res, res.sign, key) && res.result_code == "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "OK", info = "OK" }));
            }
            else if (res.return_code != "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = res.return_msg }));
            }
            else if (res.result_code != "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = res.err_code_des }));
            }
            else
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = "微信服务器返回的签名不合法！" }));
            }
        }
        #endregion

        #region 关闭订单
        void Close(HttpContext context)
        {
            var query = new CloseOrder
            {
                appid = appid,
                mch_id = mch_id,
                nonce_str = Utils.GetGuid(),
                out_trade_no = context.Request.Form["out_trade_no"],
            };
            var res = WxApi.Pay.CloseOrder(query, key);
            if (res.return_code == "SUCCESS" && Utils.ValidSign(res, res.sign, key) && res.result_code == "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "OK", info = "OK" }));
            }
            else if (res.return_code != "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = res.return_msg }));
            }
            else if (res.result_code != "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = res.err_code_des }));
            }
            else
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = "微信服务器返回的签名不合法！" }));
            }
        }
        #endregion
        
        void NativeNotift(HttpContext context)
        {
            var reqdata = Utils.GetRequestData();
        }
        void Native2(HttpContext context)
        {
            var un = UnifiedOrder(context, "NATIVE");
            if (un.return_code == "SUCCESS" && un.result_code == "SUCCESS" && Utils.ValidSign(un, un.sign, key))
            {
                context.Response.Write(un.code_url);
            }
            else
            {
                context.Response.Write(un.return_msg);
            }
        }
        #region JSAPI支付

        void JsPay(HttpContext context)
        {
            var unifie = UnifiedOrder(context, "JSAPI");
            if (unifie.return_code == "SUCCESS" && Utils.ValidSign(unifie, unifie.sign, key) && unifie.result_code == "SUCCESS")
            {
                var jsentity = new JsEntity
                {
                    appId = appid,
                    nonceStr = Utils.GetGuid(),
                    package = "prepay_id=" + unifie.prepay_id,
                    signType = "MD5",
                    timeStamp = Utils.ConvertDateTimeInt(DateTime.Now).ToString()
                };
                jsentity.paySign = Utils.GetPaySign(jsentity, key);
                context.Response.Write(JsonConvert.SerializeObject(new { status = "OK", info = jsentity }));
            }
            else if (unifie.return_code != "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = unifie.return_msg }));
            }
            else if (unifie.result_code != "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = unifie.err_code_des }));
            }
            else
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = "微信服务器返回的签名不合法！" }));
            }
        }
        #endregion

        #region 调用统一下单接口
        UnifiedRes UnifiedOrder(HttpContext context, string paytype)
        {
            var param = new UnifiedEntity
            {
                appid = appid,
                mch_id = mch_id,
                nonce_str = Utils.GetGuid(),
                body = context.Request.Form["body"],
                detail = context.Request.Form["detail"],
                out_trade_no = context.Request.Form["out_trade_no"],
                spbill_create_ip = Utils.GetIP(),
                total_fee = int.Parse(context.Request.Form["total_fee"]),
                notify_url = string.Format(notify_url, Utils.GetCurrentFullHost()),
                trade_type = paytype,
            };
            if (paytype == "JSAPI")
            {
                param.openid = context.Request.Form["msgid"];
            }
            else
            {
                param.product_id = context.Request.Form["msgid"];
            }
            return WxApi.Pay.UnifiedOrder(param, key);
        }
        #endregion

        #region 退款

        void Refund(HttpContext context)
        {
            var refund = new ReFund
            {
                appid = appid,
                mch_id = mch_id,
                nonce_str = Utils.GetGuid(),
                op_user_id = mch_id,
                out_refund_no = context.Request.Form["out_refund_no"],
                out_trade_no = context.Request.Form["out_trade_no"],
                refund_fee = int.Parse(context.Request.Form["refund_fee"]),
                total_fee = int.Parse(context.Request.Form["total_fee"]),
                transaction_id = context.Request.Form["transaction_id"]
            };
            var rev = WxApi.Pay.ReFund(refund, key, context.Request.MapPath("/apiclient_cert.p12"), mch_id);
            if (rev.return_code == "SUCCESS" && Utils.ValidSign(rev, rev.sign, key) && rev.result_code == "SUCCESS")
            {

                #region 退款业务逻辑处理

                #endregion
                context.Response.Write(JsonConvert.SerializeObject(new { status = "OK" }));
            }
            else if (rev.return_code != "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = rev.return_msg }));
            }
            else if (rev.result_code != "SUCCESS")
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = rev.err_code_des }));
            }
            else
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = "FAIL", info = "微信服务器返回的签名不合法！" }));
            }

        }
        #endregion

        #region 刷卡支付

        void ScanPay(HttpContext context)
        {
            var res = WxApi.Pay.ScanPay(new ScanPayEntity
            {
                appid = appid,
                auth_code = context.Request.Form["auth_code"],
                body = "测试商品",
                mch_id = mch_id,
                nonce_str = Utils.GetGuid(),
                out_trade_no = context.Request.Form["out_trade_no"],
                spbill_create_ip = Utils.GetIP(),
                total_fee = context.Request.Form["total_fee"]
            }, key);
            context.Response.Write(JsonConvert.SerializeObject(res));
        }
        #endregion

        #region 订单查询

        void OrderIsSuccess(HttpContext context)
        {
            var query = new QueryOrder
            {
                appid = appid,
                mch_id = mch_id,
                nonce_str = Utils.GetGuid(),
                out_trade_no = context.Request.Form["out_trade_no"],
                transaction_id = context.Request.Form["transaction_id"]
            };
            var info = WxApi.Pay.QueryOrder(query, key);
            context.Response.Write(info.trade_state);
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}