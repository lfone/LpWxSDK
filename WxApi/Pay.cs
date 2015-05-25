using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using WxApi.PayEntity;
using WxApi.ReceiveEntity;

namespace WxApi
{
    /// <summary>
    /// 微信支付相关处理方法
    /// </summary>
    public class Pay
    {
        /// <summary>
        /// 调用统一下单接口并解析返回的XML
        /// </summary>
        /// <returns>响应实体</returns>
        public static UnifiedRes UnifiedOrder(UnifiedEntity entity, string key)
        {
            var url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            return PayRequest<UnifiedRes>(entity, key, url);
        }

        /// <summary>
        /// 退款请求
        /// </summary>
        /// <param name="reFund">退款实体</param>
        /// <param name="key">支付密钥</param>
        /// <param name="certpath">证书路径</param>
        /// <param name="certpwd">证书密码</param>
        /// <returns></returns>
        public static ReFundRes ReFund(ReFund reFund, string key, string certpath, string certpwd)
        {
            var url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            return PayRequest<ReFundRes>(reFund, key, url, certpath, certpwd);
        }
        /// <summary>
        /// 查询退款
        /// </summary>
        public static QueryRefundRes QueryReFund(QueryRefund refund, string key)
        {
            var url = "https://api.mch.weixin.qq.com/pay/refundquery";
            return PayRequest<QueryRefundRes>(refund, key, url);
        }
        /// <summary>
        /// 代金券与立减优惠
        /// </summary>
        /// <param name="coupon"></param>
        /// <param name="key"></param>
        /// <param name="certpath"></param>
        /// <param name="certpwd"></param>
        /// <returns></returns>
        public static SendCouponRes SendCoupon(SendCoupon coupon, string key, string certpath, string certpwd)
        {
            var url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/send_coupon";
            return PayRequest<SendCouponRes>(coupon, key, url, certpath, certpwd);
        }
        /// <summary>
        /// 企业付款
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="key"></param>
        /// <param name="certpath"></param>
        /// <param name="certpwd"></param>
        /// <returns></returns>
        public static EPaymentRes EPayment(EPayment payment, string key, string certpath, string certpwd)
        {
            var url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
            return PayRequest<EPaymentRes>(payment, key, url, certpath, certpwd);
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="orderQuery">订单查询实体</param>
        /// <param name="key">支付密钥</param>
        /// <returns></returns>
        public static OrderQueryRes QueryOrder(QueryOrder orderQuery, string key)
        {
            var url = "https://api.mch.weixin.qq.com/pay/orderquery";
            return PayRequest<OrderQueryRes>(orderQuery, key, url);
        }


        public static RedPackRes SendRePack(RedPack redPack, string key, string certpath, string certpwd)
        {
            var url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";
            return PayRequest<RedPackRes>(redPack, key, url, certpath, certpwd);
        }
        /// <summary>
        /// 撤销订单
        /// </summary>
        public static ReverseRes ReverseOrder(QueryOrder order, string key, string certpath, string certpwd)
        {
            var url = "https://api.mch.weixin.qq.com/secapi/pay/reverse";
            return PayRequest<ReverseRes>(order, key, url, certpath, certpwd);
        }
        public static OrderInfo ScanPay(ScanPayEntity scan, string key)
        {
            var url = "https://api.mch.weixin.qq.com/pay/micropay";
            return PayRequest<OrderInfo>(scan, key, url);
        }
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="close"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static CloseOrderRes CloseOrder(CloseOrder close, string key)
        {
            var url = "https://api.mch.weixin.qq.com/pay/closeorder";
            return PayRequest<CloseOrderRes>(close, key, url);
        }
        /// <summary>
        /// 获取通用回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="callBack"></param>
        public static void GetNotifyRes(string key, Action<OrderInfo> callBack)
        {
            try
            {
                var reqdata = Utils.GetRequestData();
                var rev = Utils.XmlToEntity<OrderInfo>(reqdata);
                if (rev.return_code != "SUCCESS")
                { BackMessage("通讯错误"); return; }
                if (rev.result_code != "SUCCESS")
                { BackMessage("业务出错"); return; }
                if (rev.sign == Utils.GetPaySign(rev, key))
                {
                    //回调函数，业务逻辑处理，处理结束后返回信息给微信
                    callBack(rev);
                }
            }
            catch (Exception e)
            {
                BackMessage("回调函数处理错误");
            }
        }

        public static void GetNotiveRes(string key, Func<NativeNotify, UnifiedRes> func)
        {
            var reqdata = Utils.GetRequestData();
            var rev = Utils.XmlToEntity<NativeNotify>(reqdata);
            var unifie = func(rev);
            var res = new NativeRes
            {
                appid = unifie.appid,
                err_code_des = unifie.err_code_des,
                mch_id = unifie.mch_id,
                nonce_str = unifie.nonce_str,
                prepay_id = unifie.prepay_id,
                return_code = unifie.return_code,
                return_msg = unifie.return_msg,
                result_code = unifie.result_code
            };
            var param = Utils.EntityToDictionary(res);//将实体转换成数据集合
            param.Add("sign", Utils.GetPaySign(param, key));//生成签名，并将签名添加到数据集合
            var xml = Utils.parseXML(param);//将数据集合转换成xml
            HttpContext.Current.Response.Write(xml);
        }
        public static void BackMessage(string msg = "")
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (msg != "")
            {
                dic.Add("return_code", "FAIL");
                dic.Add("return_msg", msg);
                HttpContext.Current.Response.Write(Utils.parseXML(dic));
            }
            else
            {
                dic.Add("return_code", "SUCCESS");
                HttpContext.Current.Response.Write(Utils.parseXML(dic));
            }
        }

        public static string CreateNativeUrl(NativeEntity nativeEntity, string key)
        {
            var param = Utils.EntityToDictionary(nativeEntity);//将实体转换成数据集合
            param.Add("sign", Utils.GetPaySign(param, key));//生成签名，并将签名添加到数据集合
            var arr = param.Select(p => p.Key + "=" + p.Value);
            return string.Format("weixin://wxpay/bizpayurl?{0}", string.Join("&", arr));
        }
        /// <summary>
        /// 微信支付接口请求
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="obj">请求实体</param>
        /// <param name="key">支付密钥</param>
        /// <param name="url">接口地址</param>
        /// <param name="certpath">证书路径，为null时说明不适用证书</param>
        /// <param name="certpwd">证书密码</param>
        public static T PayRequest<T>(object obj, string key, string url, string certpath = "", string certpwd = "")
        {
            var param = Utils.EntityToDictionary(obj);//将实体转换成数据集合
            param.Add("sign", Utils.GetPaySign(param, key));//生成签名，并将签名添加到数据集合
            var xml = Utils.parseXML(param);//将数据集合转换成xml
            return Utils.XmlToEntity<T>(Utils.HttpPost(url, xml, certpath, certpwd));
        }

        public static string GetEditAddressSign(EditAddress edit)
        {
            var dic = Utils.EntityToDictionary(edit);
            var arr = dic.OrderBy(d => d.Key).Select(d => string.Format("{0}={1}", d.Key, d.Value)).ToArray();
            string stringA = string.Join("&", arr);
            return FormsAuthentication.HashPasswordForStoringInConfigFile(stringA, "SHA1");
        }
    }
}
