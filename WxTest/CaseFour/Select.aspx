<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="WxTest.CaseFour.Select" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>在线选座</title>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.0.js"></script>
    <style>
        body, ul, li {
            padding: 0;
            margin: 0;
            border: 0;
        }

        ul {
            list-style: none;
        }

        li {
            float: left;
            width: 31%;
            height: 50px;
            text-align: center;
            background: #008000;
            color: #fff;
            margin: 1%;
            line-height: 50px;
        }

        .select {
            background: #4b0082;
        }
    </style>
</head>
<body>
    <ul class="lul" style="float: left; width: 48%">
        <li>1排1号</li>
        <li>1排2号</li>
        <li>1排3号</li>
        <li>2排1号</li>
        <li>2排2号</li>
        <li>2排3号</li>
        <li>3排1号</li>
        <li>3排2号</li>
        <li>3排3号</li>
        <li>4排1号</li>
        <li>4排2号</li>
        <li>4排3号</li>
    </ul>
    <ul style="float: right; width: 48%;">
        <li>1排4号</li>
        <li>1排5号</li>
        <li>1排6号</li>
        <li>2排4号</li>
        <li>2排5号</li>
        <li>2排6号</li>
        <li>3排4号</li>
        <li>3排5号</li>
        <li>3排6号</li>
        <li>4排4号</li>
        <li>4排5号</li>
        <li>4排6号</li>
    </ul>
    <div style="clear: both"></div>
    <input type="button" value="确定" style="height: 40px; line-height: 40px; color: #fff; background: #008080; width: 80%; margin: 20px auto; -ms-border-radius: 5px; border-radius: 5px; display: block" />
    <script>
        $(function () {
            $("li").click(function () {
                if (!$(this).hasClass("select") && $(".select").size() >= 4) {
                    alert("对不起，您最多选择4个座位！");//根据具体逻辑限制座位的数量
                    return;
                }
                $(this).toggleClass("select");
            });
            $("input[type=button]").click(function () {
                var size = $(".select").size();
                if (size != 4) {
                    alert("请选择4个座位");
                    return;
                }
                var data = "";
                $(".select").each(function () {
                    data += $(this).text() + ",";
                });
                $.post(location.href, { data: data }, function (res) {
                    if (res.ErrCode == 0)
                    { alert("选择成功"); wx.closeWindow(); }
                    else
                    {
                        alert(res.ErrDescription);
                    }
                }, "json");
            })
        })
    </script>
</body>
</html>
