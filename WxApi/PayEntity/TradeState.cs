using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.PayEntity
{
    public enum TradeState
    {
        /// <summary>
        /// 支付成功 
        /// </summary>
        SUCCESS,
        /// <summary>
        /// 转入退款 
        /// </summary>
        REFUND,
        /// <summary>
        /// 未支付
        /// </summary>
        NOTPAY,
        /// <summary>
        /// 已关闭 
        /// </summary>
        CLOSED,
        /// <summary>
        /// 已撤销
        /// </summary>
        REVOKED,
        /// <summary>
        /// 用户支付中 
        /// </summary>
        USERPAYING,
        /// <summary>
        /// 支付失败(其他原因，如银行返回失败) 
        /// </summary>
        PAYERROR
    }
}
