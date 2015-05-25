<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NativePay.aspx.cs" Inherits="WxTest.NativePay" %>
<%@ Import Namespace="WxApi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="http://libs.baidu.com/jquery/1.8.3/jquery.js"></script>
</head>
<body>
    <form>
        商品名：<input type="text" name="body" value="测试商品" /><br />
        商品详情：<input type="text" name="detail" /><br />
        订单号：<input type="text" name="out_trade_no" value="<%=Utils.GetGuid() %>" /><br />
        订单金额：<input type="text" name="total_fee" /><br />
        <input type="hidden" name="msgid" value="332323" /><br />
        <input type="button" id="btnpay" value="支付" />
        <img id="qr"/>
    </form>
    <script>
        $(function () {
            $("#qr").attr("src", "http://qr.liantu.com/api.php?text=<%=url%>");
            $("#btnpay").click(function () {
                $.post("/WxPayHandler.ashx?action=native2", $("form").serialize(), function (data) {
                    $("#qr").attr("src", "http://qr.liantu.com/api.php?text="+data);
                });
            });
        })
    </script>
</body>
</html>
