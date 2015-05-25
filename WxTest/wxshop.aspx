<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxshop.aspx.cs" Inherits="WxTest.wxshop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" onclick="openProductView()" value="顶顶顶"/>
        </div>
        <script>
            function openProductView() {
                alert(WeixinJSBridge);
                if (typeof WeixinJSBridge == "undefined")
                    return false;

                var pid = "pxb7Qsl0KYZKvcK0XgDQVZaDgTMQ";//只需要传递
                WeixinJSBridge.invoke('openProductViewWithPid', {
                    "pid": pid
                }, function (res) {
                    // 返回res.err_msg,取值 
                    // open_product_view_with_id:ok 打开成功
                    alert(res.err_msg);
                    if (res.err_msg != "open_product_view_with_id:ok") {
                        WeixinJSBridge.invoke('openProductView', {
                            "productInfo": "{\"product_id\":\"" + pid + "\",\"product_type\":0}"
                        }, function (res) {
                            alert(res.err_msg);
                        });
                    }
                });
            }
        </script>
    </form>
</body>
</html>
