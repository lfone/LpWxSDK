<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qrLogin.aspx.cs" Inherits="WxTest.CaseTwo.index" %>

<%@ Import Namespace="Newtonsoft.Json" %>
<%@ Import Namespace="WxApi" %>
<%@ Import Namespace="WxTest" %>
<%@ Import Namespace="WxTest.CaseTwo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="http://apps.bdimg.com/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
    <input type="button" id="login" value="微信登陆" />
    <img />
    <script>
        var time;
        var key;
        $(function () {
            //生成带参数二维码
            $("#login").click(function () {
                $.get(location.href + "?action=loginqr", function (data) {
                    $("img").attr("src", data.qrurl).css({ "height": 300, "width": 300 });
                    key = data.key;
                    setTimeout(function () {
                        time = setInterval(res, 1000);
                    }, 3000);

                }, "json");
            });
        });
        //监听二维码扫描事件
        var res = function () {
            $.get(location.href + "?action=checkscan&key=" + key, function (data) {
                if (data.status == 1) {
                    clearInterval(time);
                    alert(JSON.stringify(data.userinfo));
                }
            }, "json");
        };
    </script>
</body>
</html>
