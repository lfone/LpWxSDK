var WxPay = {
    Pay: function (appId, timeStamp, nonceStr, package, signType, paySign, callback) {
        try {
            WeixinJSBridge.invoke('getBrandWCPayRequest', {
                "appId": appId,	//公众号名称，由商户传入
                "timeStamp": timeStamp,	//时间戳，自 1970 年以来的秒数
                "nonceStr": nonceStr, //随机串
                "package": package,
                "signType": signType,	//微信签名方式
                "paySign": paySign //微信签名
            }, function (res) {
                if (res.err_msg == "get_brand_wcpay_request:ok") {
                    callback();
                }
                // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg 将在用户支付成功后返回 ok，但并不保证它绝对可靠。
            });
        } catch (e) {
            alert(e);
        }

    },
    ShareAddress: function (appId, addrSign, timeStamp, nonceStr, callback) {
        WeixinJSBridge.invoke('editAddress', {
            "appId": appId,
            "scope": "jsapi_address",
            "signType": "sha1",
            "addrSign": addrSign,
            "timeStamp": timeStamp,
            "nonceStr": nonceStr,
        }, function (res) {
            callback(res);
            //若 res 中所带的返回值不为空，则表示用户选择该返回值作为收货地址。 
            //否则若返回空，则表示用户取消了这一次编辑收货地址。 
        });

    }
}