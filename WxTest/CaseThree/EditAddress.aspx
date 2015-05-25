<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAddress.aspx.cs" Inherits="WxTest.CaseThree.EditAddress" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0" />
    <script src="http://apps.bdimg.com/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
    <button type="button">选择地址</button>
    <label></label>
    <script>
        $(function () {
            $("button").click(function () {
                WeixinJSBridge.invoke('editAddress', {
                    "appId": "<%=Edit.appid%>",
                    "scope": "jsapi_address",
                    "signType": "sha1",
                    "addrSign": "<%=sign%>",
                    "timeStamp": "<%=Edit.timestamp%>",
                    "nonceStr": "<%=Edit.noncestr%>",
                }, function (res) {
                    if (res.err_msg=="edit_address:ok") {
                        $("label").text("地址：" + res.proviceFirstStageName +
                            res.addressCitySecondStageName +
                            res.addressCountiesThirdStageName +
                            res.addressDetailInfo+" 姓名："+res.userName+" 手机："+res.telNumber+" 邮编："+res.addressPostalCode);
                    }
                });
            });
        })
    </script>
</body>
</html>
