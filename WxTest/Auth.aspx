<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auth.aspx.cs" Inherits="WxTest.Auth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="wxpay.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <script>
        WxPay.ShareAddress("<%=appid%>", "<%=sign%>", "<%=timestamp%>", "<%=noncestr%>", function (res) {
            alert(JSON.stringify(res));
        });
    </script>
</body>
</html>
