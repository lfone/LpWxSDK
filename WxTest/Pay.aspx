<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="WxTest.Pay" %>

<%@ Import Namespace="WxApi" %>

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width,initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="http://libs.baidu.com/jquery/1.8.3/jquery.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="layer.m/layer.m.js"></script>
    <title>微信支付</title>
    <script>
        var time;
        var timecount = 0;
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: 'appid', // 必填，公众号的唯一标识
            timestamp:<%=timestamp%> , // 必填，生成签名的时间戳
            nonceStr: '<%=noncestr%>', // 必填，生成签名的随机串
            signature: '<%=sign%>',// 必填，签名，见附录1
            jsApiList: [
                'chooseWXPay', 
            ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        wx.ready(function() {
            $("#btnpay").click(function () {
                layer.open({type:2,content:"正在创建订单…",shadeClose:false});//加载loading层
                $.post("/WxPayHandler.ashx?action=jspay", $("form").serialize(), function (data) {
                    layer.closeAll();//关闭load层
                    if (data.status=="OK") {
                        var param = data.info;
                        wx.chooseWXPay({
                            timestamp: param.timeStamp, // 支付签名时间戳，注意微信jssdk中的所有使用timestamp字段均为小写。但最新版的支付后台生成签名使用的timeStamp字段名需大写其中的S字符
                            nonceStr:  param.nonceStr, // 支付签名随机串，不长于 32 位
                            package: param.package, // 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）
                            signType: param.signType, // 签名方式，默认为'SHA1'，使用新版支付需传入'MD5'
                            paySign:param.paySign, // 支付签名
                            success: function (res) {
                                layer.open({type:2,content:"正在查询订单状态…",shadeClose:false});
                                time= setInterval(function() { queryorder($("input[name='out_trade_no']").val()); }, 2000);
                            
                                // 支付成功后的回调函数
                           
                            },
                            cancel:function(res) {
                                alert(JSON.stringify(res));
                            }
                        });
                    } else {
                        alert(data.info);
                    }
                    
                }, "json");
            });
        });

        function queryorder(tradeno) {
            if (timecount++<3) {
                $.post("/WxPayHandler.ashx?action=query", {out_trade_no:tradeno}, function(data,status) {
                    if (data=="SUCCESS") {
                        layer.closeAll();
                        alert("支付成功！");
                        clearInterval(time);
                    }
                });
            } else {
                layer.closeAll();
                alert("订单貌似没有支付成功！");
                clearInterval(time);
            }
           
        }
    </script>
  
</head>
<body>
    <form>
        商品名：<input type="text" name="body" value="测试商品" /><br />
        商品详情：<input type="text" name="detail" /><br />
        订单号：<input type="text" name="out_trade_no" value="<%=Utils.GetGuid() %>" /><br />
        订单金额：<input type="text" name="total_fee" /><br />
        <input type="hidden" name="msgid" value="oR19CsyUvziSlctqDmEoMwwph4Jk" /><br />
        <input type="button" id="btnpay" value="支付" /><input type="button" id="reverse" value="撤销订单" />
        <input type="button" id="close" value="关闭订单" />
    </form>
</body>
    <script>
        $(function() {
            $("#reverse").click(function() {
                var out_trade_no = $("input[name='out_trade_no']").val();

                $.post("/WxPayHandler.ashx?action=reverse", {out_trade_no:out_trade_no},function(data) {
                    alert(data.info);
                },"json");
            });
            $("#close").click(function() {
                var out_trade_no = $("input[name='out_trade_no']").val();

                $.post("/WxPayHandler.ashx?action=close", {out_trade_no:out_trade_no},function(data) {
                    alert(data.info);
                },"json");
            });
        });
    </script>
<%--<script>
    function onBridgeReady() {
        $("#btnpay").click(function () {
            $.post("/WxPayHandler.ashx?action=jspay", $("form").serialize(), function (data) {
                var param = data.info;
                WeixinJSBridge.invoke(
                       'getBrandWCPayRequest',param,
                       function (res) {
                           if (res.err_msg == "get_brand_wcpay_request:ok") {
                           } // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回    ok，但并不保证它绝对可靠。 
                       }
                   );
            }, "json");
        });
    }
    if (typeof WeixinJSBridge == "undefined") {
        if (document.addEventListener) {
            document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
        } else if (document.attachEvent) {
            document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
            document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
        }
    } else {
        onBridgeReady();
    }
</script>--%>
</html>
