using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;
using WxApi.ReceiveEntity.Shop;

namespace WxApi.Shop
{
    public class OrderManage
    {
        public static OrderRev GetOrder(string orderId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/order/getbyid?access_token={0}", accessToken);
            var obj = new {order_id = orderId};
            return Utils.PostResult<OrderRev>(obj, url);
        }

        public static OrderList GetOrderList(string accessToken, int? status=null, DateTime? beginTime = null,
            DateTime? endTime = null)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/order/getbyfilter?access_token={0}", accessToken);
            object obj = null;
            if (beginTime != null && endTime != null)
            {
                obj = new
                {
                    status = status,
                    begintime = Utils.ConvertDateTimeInt(beginTime.Value),
                    endtime = Utils.ConvertDateTimeInt(endTime.Value)
                };
            }
            else
            {
                obj = new { status = status };
            }
            return Utils.PostResult<OrderList>(obj, url);
        }
        /// <summary>
        /// 设置订单发货信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="orderId">订单号</param>
        /// <param name="deliveryCompany">物流公司ID；当need_delivery为0时，可不填本字段；当need_delivery为1时，该字段不能为空；当need_delivery为1且is_others为1时，本字段填写其它物流公司名称)</param>
        /// <param name="deliveryTrackNo">运单ID(当need_delivery为0时，可不填本字段；当need_delivery为1时，该字段不能为空；)</param>
        /// <param name="needDelivery">商品是否需要物流(0-不需要，1-需要，无该字段默认为需要物流)</param>
        /// <param name="isOthers">是否为其它物流公司(0-否，1-是，无该字段默认为不是其它物流公司)</param>
        /// <returns></returns>
        public static ErrorEntity SetDelivery(string accessToken, string orderId, string deliveryCompany,
            string deliveryTrackNo, int needDelivery = 1, int isOthers = 0)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/order/setdelivery?access_token={0}", accessToken);
            var obj = new
            {
                order_id = orderId,
                delivery_company = deliveryCompany,
                delivery_track_no = deliveryTrackNo,
                need_delivery = needDelivery,
                is_others = isOthers
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity CloseOrder(string orderId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/order/close?access_token={0}", accessToken);
            var obj = new { order_id =orderId};
            return Utils.PostResult<ErrorEntity>(obj,url);
        }

    }
}
