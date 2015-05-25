<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Refund.aspx.cs" Inherits="WxTest.Refund" %>
<%@ Import Namespace="WxApi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="http://libs.baidu.com/jquery/1.8.3/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            订单号：<input type="text" name="out_trade_no" /><br />
            订单总金额：<input type="text" name="total_fee" /><br />
            退款金额：<input type="text" name="refund_fee" /><br />
            商户退款单号：<input type="text" name="out_refund_no" value="<%=Utils.GetGuid() %>" /><br />
            <input type="button"  id="refund" value="确认退款" />
        </div>
        <script>
            $(function() {
                $("#refund").click(function() {
                    $.post("/WxPayHandler.ashx?action=refund", $("form").serialize(), function (data) {
                        alert(JSON.stringify(data));
                    },"json");
                });
            });
        </script>
    </form>
</body>
</html>
