<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserGroupTest.aspx.cs" Inherits="WxTest.UserGroupTest" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="创建分组" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
