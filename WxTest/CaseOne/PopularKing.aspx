<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopularKing.aspx.cs" Inherits="WxTest.CaseOne.PopularKing" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我是人气王</title>
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0" />
    <script src="http://apps.bdimg.com/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <style>
        body, ul, li, form {
            padding: 0;
            margin: 0;
        }

        body {
            width: 100%;
            position: relative;
        }

        .tx {
            margin: 10px auto;
            width: 50%;
        }

            .tx img {
                width: 100px;
                height: 100px;
                -ms-border-radius: 50%;
                border-radius: 50%;
                margin: 0 auto;
                display: block;
            }

        button {
            width: 100%;
            border-radius: 5px;
            background: #00bfff;
            color: #ffffff;
            height: 30px;
            border: 0;
            margin: 5px 0;
        }

        td {
            text-align: center;
        }

        #mess_share {
            margin: 15px 0;
        }

        #share_1 {
            float: left;
            width: 49%;
        }

        #share_2 {
            float: right;
            width: 49%;
        }

        #mess_share img {
            width: 22px;
            height: 22px;
        }

        #cover {
            display: none;
            position: fixed;
            left: 0;
            top: 0;
            z-index: 18888;
            background-color: #000000;
            opacity: 0.7;
        }

        #guide {
            display: none;
            position: absolute;
            right: 18px;
            top: 5px;
            z-index: 19999;
        }

            #guide img {
                width: 260px;
                height: 180px;
            }
    </style>
    <script type="text/javascript">
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: '<%=appid%>', // 必填，公众号的唯一标识
            timestamp:<%=timestamp%> , // 必填，生成签名的时间戳
            nonceStr: '<%=noncestr%>', // 必填，生成签名的随机串
            signature: '<%=sign%>',// 必填，签名，见附录1
            jsApiList: [
                'onMenuShareTimeline',
                'onMenuShareAppMessage','showOptionMenu'
            ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        wx.ready(function() {
            wx.showOptionMenu();
            var title = '我是人气王，我已经有<%=currentdr["Popular"]%>人气了，快来帮我攒人气吧。';
            var link = '<%=shareurl%>';
            var imgUrl = '<%=shareimg%>';
            wx.onMenuShareTimeline({
                title: title, // 分享标题
                link: link, // 分享链接
                imgUrl:imgUrl, // 分享图标
                success: function () { 
                    // 用户确认分享后执行的回调函数
                    alert("分享成功");
                },
                cancel: function () { 
                    alert("取消分享");
                    // 用户取消分享后执行的回调函数
                }
            });
            wx.onMenuShareAppMessage({
                title:title, // 分享标题
                desc: '', // 分享描述
                link:link, // 分享链接
                imgUrl:imgUrl, // 分享图标
                success: function () { 
                    // 用户确认分享后执行的回调函数
                    alert("分享成功");
                },
                cancel: function () { 
                    alert("取消分享");
                    // 用户取消分享后执行的回调函数
                }
            });
        });
    </script>
</head>
<body>
    <input type="hidden" id="helper" value="<%=openid %>" />
    <input type="hidden" id="sharer" value="<%=sharedr["Openid"] %>" />
    <div class="tx">
        <img src="<%=sharedr["Headimgurl"] %>" />
    </div>
    <div>现在我的人气值是<b style="color: red"><%=sharedr["Popular"] %></b>，点击【助力】帮我攒更多人气吧。</div>
    <button type="button" id="helperntn">助力</button>
    <button type="button" onclick="_system._guide(true);">我也来玩</button>
    <br />
    <br />
    人气旺排行：
    <div style="border-bottom: 2px solid #cccccc; width: 100%"></div>
    <table style="width: 100%;">
        <tr>
            <th>排名</th>
            <th>昵称</th>
            <th>人气值</th>
        </tr>
        <asp:Repeater ID="reList" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%#Container.ItemIndex+1 %></td>
                    <td><%#Eval("NickName") %></td>
                    <td><%#Eval("Popular") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

    </table>
    <div id="cover"></div>
    <div id="guide">
        <img src="/img/guide1.png" />
    </div>

    <script>
        $(function() {
            $("#helperntn").click(function() {
                var helper = $("#helper").val();
                var sharer = $("#sharer").val();
                if (sharer==helper) {
                    alert("您不能为自己助力，请分享给您的朋友帮你助力！");
                    _system._guide(true);//分享引导
                    return;
                }
                $.post(location.href, function(data) {
                    if (data == 1) {
                        alert("助力成功");
                        location.href = location.href;
                    } else {
                        alert("请勿重复助力哦");
                    }
                });
            });
        })
    </script>
    <script type="text/javascript">

        var _system = {

            $: function (id) { return document.getElementById(id); },

            _client: function () {

                return { w: document.documentElement.scrollWidth, h: document.documentElement.scrollHeight, bw: document.documentElement.clientWidth, bh: document.documentElement.clientHeight };

            },

            _scroll: function () {

                return { x: document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft, y: document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop };

            },

            _cover: function (show) {

                if (show) {

                    this.$("cover").style.display = "block";

                    this.$("cover").style.width = (this._client().bw > this._client().w ? this._client().bw : this._client().w) + "px";

                    this.$("cover").style.height = (this._client().bh > this._client().h ? this._client().bh : this._client().h) + "px";

                } else {

                    this.$("cover").style.display = "none";

                }

            },

            _guide: function (click) {

                this._cover(true);

                this.$("guide").style.display = "block";

                this.$("guide").style.top = (_system._scroll().y + 5) + "px";

                window.onresize = function () { _system._cover(true); _system.$("guide").style.top = (_system._scroll().y + 5) + "px"; };

                if (click) {
                    _system.$("cover").onclick = function () {

                        _system._cover();

                        _system.$("guide").style.display = "none";

                        _system.$("cover").onclick = null;

                        window.onresize = null;

                    };
                }

            },

            _zero: function (n) {

                return n < 0 ? 0 : n;

            }

        }

    </script>

</body>
</html>
