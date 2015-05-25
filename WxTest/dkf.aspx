<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dkf.aspx.cs" Inherits="WxTest.dkf" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="http://libs.baidu.com/jquery/1.8.3/jquery.min.js"></script>
    <script src="dkf.js"></script>
    <script>
        $(function () {
            Dkf.Init("<%=Request.QueryString["ticket"]%>");
            var i = 0;
            function  ss() {
                if (i++==5) {
                    Dkf.Notice();
                }
            }
            $("#bb").click(function () {
                setInterval(ss, 1000);
                //var dd = [
                //    {
                //        title: "白哦天",
                //        digest: "摘要",
                //        cover: "http://ypyle.xicp.net/wx.jpg",
                //        url: "http://www.baidu.com"
                //    }, {
                //        title: "白哦12天",
                //        digest: "摘要212",
                //        cover: "http://ypyle.xicp.net/wx.jpg",
                //        url: "http://www.baidu.com"
                //    }
                //];
                //Dkf.PutNewsMsg(dd);
                //Dkf.PutTextMsg("您好啊");
                //Dkf.PutImgMsg("http://ypyle.xicp.net/wx.jpg");
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" id="bb" value="输入消息" />
        </div>
    </form>
</body>
</html>
