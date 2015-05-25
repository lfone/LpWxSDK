<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WxJs.aspx.cs" Inherits="WxTest.WxJs" %>

<%@ Import Namespace="WxTest" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js"></script>

    <script src="layer.m/layer.m.js"></script>
    <script src="http://map.qq.com/api/js?v=2.exp&libraries=convertor"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script type="text/javascript">
        wx.config({
            debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: 'appid', // 必填，公众号的唯一标识
            timestamp:<%=timestamp%> , // 必填，生成签名的时间戳
            nonceStr: '<%=noncestr%>', // 必填，生成签名的随机串
            signature: '<%=sign%>',// 必填，签名，见附录1
            jsApiList: [
                 'startRecord', //开始录音
                'onVoiceRecordEnd',//监听录音自动停止
                'stopRecord',//停止录音
                'playVoice',//播放语音
                'pauseVoice',//暂停播放
                'stopVoice',//停止播放
                'onVoicePlayEnd',//监听语音播放完毕
                'uploadVoice',//上传语音
                'downloadVoice',//下载语音
                'translateVoice',//识别音频
                'checkJsApi',
                'onMenuShareTimeline',
                'onMenuShareAppMessage',
                'onMenuShareWeibo',
                'onMenuShareQQ',
                'chooseImage',
                'previewImage',
                'uploadImage',
                'downloadImage',
                'getLocation',
                'openLocation','scanQRCode','addCard','openCard','chooseCard'

            
            ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        wx.ready(function() {
            $("#opencard").click(function() {
                wx.openCard({
                    cardList: [
                    {
                        cardId: 'pR19Cs9-Uw0i1s-suViNozAkPgjk',
                        code:'583884053317'
                    },
                    {
                        cardId: 'pR19Cs9-Uw0i1s-suViNozAkPgjk',
                        code:'171769789507'
                    }
                    ]// 需要打开的卡券列表
                });
               
            });
            $("#cardlist").click(function() {
                wx.chooseCard({
                    shopId: '<%=CardSign.location_id%>', // 门店Id
                    cardType: '<%=CardSign.card_type%>', // 卡券类型
                    cardId: '<%=CardSign.card_id%>', // 卡券Id
                    timestamp: <%=CardSign.times_tamp%>, // 卡券签名时间戳
                    nonceStr: '<%=CardSign.nonce_str%>', // 卡券签名随机串
                    signType: 'SHA1', // 签名方式，默认'SHA1'
                    cardSign: '<%=CardSign.signature%>', // 卡券签名，详见附录4
                    success: function (res) {
                        document.write(JSON.stringify(res));
                        //var cardList= res.cardList; // 用户选中的卡券列表信息
                        //var obj = eval('(' + cardList + ')');
                        //alert(obj[0].encrypt_code);
                        //$.get("WebForm1.aspx?dc=" + encodeURIComponent(obj[0].encrypt_code), function(data) {
                        //    alert(data);
                        //});
                    }
                });
            });
            $("#addcard").click(function() {
                wx.addCard({
                    cardList: [{
                        cardId: '<%=cardext.card_id%>',
                        cardExt:"{\"timestamp\":\"<%=cardext.timestamp%>\",\"signature\":\"<%=cardext.signature%>\"}"
                    }<%--,
                    {
                        cardId: '<%=cardext1.card_id%>',
                        cardExt:"{\"timestamp\":\"<%=cardext1.timestamp%>\",\"signature\":\"<%=cardext1.signature%>\"}"
                    }--%>
                    ], // 需要添加的卡券列表
                    success: function (res) {
                        var cardList = res.cardList; // 添加的卡券列表信息
                    }
                });
            });
            $('#checkJsApi').click(function() {
                wx.checkJsApi({
                    jsApiList: [
                        'onVoiceRecordEnd'
                    ],
                    success: function(res) {
                        alert(JSON.stringify(res));
                    }
                });
            });
            wx.onMenuShareTimeline({
                title: '我要分享到朋友圈', // 分享标题
                link: 'http://www.baidu.com', // 分享链接
                imgUrl: 'http://ypyle.xicp.net/wx.jpg', // 分享图标
                success: function() {
                    alert("分享成功");
                    // 用户确认分享后执行的回调函数
                },
                cancel: function() {
                    alert("取消分享了");
                    // 用户取消分享后执行的回调函数
                }
            });

            wx.onMenuShareAppMessage({
                title: '有件事想分享给你', // 分享标题
                desc: '普通人我是不会告诉他的哟', // 分享描述
                link: 'http://www.baidu.com', // 分享链接
                imgUrl: 'http://ypyle.xicp.net/wx.jpg', // 分享图标
                success: function() {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function() {
                    // 用户取消分享后执行的回调函数
                }
            });
            wx.onMenuShareQQ({
                title: '有件事想分享给你', // 分享标题
                desc: '普通人我是不会告诉他的哟', // 分享描述
                link: 'http://www.baidu.com', // 分享链接
                imgUrl: 'http://ypyle.xicp.net/wx.jpg', // 分享图标
                success: function() {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function() {
                    // 用户取消分享后执行的回调函数
                }
            });
            wx.onMenuShareWeibo({
                title: '有件事想分享给你', // 分享标题
                desc: '普通人我是不会告诉他的哟', // 分享描述
                link: 'http://www.baidu.com', // 分享链接
                imgUrl: 'http://ypyle.xicp.net/wx.jpg', // 分享图标
                success: function() {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function() {
                    // 用户取消分享后执行的回调函数
                }
            });
            $("#uploadImg").click(function() {
                wx.chooseImage({
                    success: function(res) {
                        layer.open({
                            type:2,content:"正在上传图片…"
                        });
                        var localIds = res.localIds; // 返回选定照片的本地ID列表，localId可以作为img标签的src属性显示图片
                        var idcount = localIds.length;
                        var j = 0;
                        for (var i = 0; i < idcount; i++) {
                            wx.uploadImage({
                                localId:localIds[i], // 需要上传的图片的本地ID，由chooseImage接口获得
                                isShowProgressTips: 0, // 默认为1，显示进度提示
                                success: function (ress) {
                                    var serverId = ress.serverId; // 返回图片的服务器端ID
                                    if (++j==idcount) {
                                        layer.closeAll();
                                    }
                                    //if (i==localIds.length-1) {
                                    //   
                                    //}
                                }
                            }); 
                           
                        }
                    }
                });

            });

            $("#previewImage").click(function() {
                wx.previewImage({
                    current: 'http://ypyle.xicp.net/qr.jpg', // 当前显示的图片链接
                    urls: ['http://ypyle.xicp.net/qr.jpg','http://ypyle.xicp.net/wx.jpg','/0.jpg'] // 需要预览的图片链接列表
                });
            })
        });
    </script>
    <title>WsJsTest</title>
</head>
<body>
    <label id="ll"></label>
    <input id="checkJsApi" type="button" value="checkJsApi" />
    <input id="uploadImg" type="button" value="上传图片" />
    <input id="previewImage" type="button" value="预览图片" />
    <br />
    <input type="range" id="range" max="60" value="0" /><span id="time"></span><br />
    <input type="button" value="开始录音" id="startRecord" />
    <input type="button" value="停止录音" id="stopRecord" />
    <input type="button" value="播放录音" id="playRecord" />
    <input type="button" value="暂停播放" id="pauseVoice" />
    <input type="button" value="停止播放" id="stopVoice" />
    <input type="button" value="上传语音" id="uploadVoice" />
    <input type="button" value="下载语音" id="downloadVoice" />
    <input type="button" value="识别语音" id="translateVoice" />
    <input type="button" value="获取地理位置" id="getlocation" />
    <input type="button" value="查看地图" id="location" />
    <input type="button" value="scan" id="scan" />
    <input type="button" value="添加到卡券" id="addcard" />
    <input type="button" value="打开卡券" id="opencard" />
    <input type="button" value="获取卡券列表" id="cardlist" />

</body>
<script>
    var i = 0;
    var t;
    var voiceServerId;
    var voiceLocalId;
    $(function() {
        $("#scan").click(function() {
            wx.scanQRCode({
                needResult: 1, // 默认为0，扫描结果由微信处理，1则直接返回扫描结果，
                scanType: ["qrCode","barCode"], // 可以指定扫二维码还是一维码，默认二者都有
                success: function (res) {
                    var result = res.resultStr; // 当needResult 为 1 时，扫码返回的结果
                    alert(JSON.stringify(res));
                }
            });

        });

        $("#startRecord").click(function() {
            i = 0;
            wx.startRecord({
                complete :function(res) {
                    wx.onVoiceRecordEnd({
                        // 录音时间超过一分钟没有停止的时候会执行 complete 回调
                        complete: function (res1) {
                            voiceLocalId = res1.localId; 
                        }
                    });
                    t = setInterval(rangestart, 1000);
                },  
                cancel:function(res) {
                    alert("您取消了录音");
                }
            });
        });
        $("#stopRecord").click(function() {
            wx.stopRecord({
                success: function(res) {
                    voiceLocalId = res.localId;
                    clearInterval(t);//清除计时器
                }
            });
        });
        $("#playRecord").click(function() {
            wx.playVoice({
                localId:voiceLocalId // 需要播放的音频的本地ID
            });
            //监听语音播放完毕接口
            wx.onVoicePlayEnd({
                success: function (res) {
                    var localId = res.localId; // 返回音频的本地ID
                    alert("语音播放完毕");
                }
            });
        });
        $("#pauseVoice").click(function() {
            wx.pauseVoice({
                localId:voiceLocalId // 需要暂停的音频的本地ID
            });
        });
        $("#stopVoice").click(function() {
            wx.stopVoice({
                localId:voiceLocalId// 需要停止的音频的本地ID
            });

        });
        $("#uploadVoice").click(function() {
            wx.uploadVoice({
                localId:voiceLocalId , // 需要上传的音频的本地ID，由stopRecord接口获得
                isShowProgressTips: 1, // 默认为1，显示进度提示
                success: function (res) {
                    voiceServerId = res.serverId; // 返回音频的服务器端ID
                }
            });
        });
        $("#downloadVoice").click(function() {
            wx.downloadVoice({
                serverId: voiceServerId, // 需要下载的音频的服务器端ID，由uploadVoice接口获得
                isShowProgressTips: 1, // 默认为1，显示进度提示
                success: function(res) {
                    var localId = res.localId; // 返回音频的本地ID
                }
            });
        });
        $("#translateVoice").click(function() {
            wx.translateVoice({
                localId:voiceLocalId, // 需要识别的音频的本地Id，由录音相关接口获得
                isShowProgressTips: 1, // 默认为1，显示进度提示
                success: function (res) {
                    alert(res.translateResult); // 语音识别的结果
                }
            });
        });
        var latitude;
        var longitude;
        $("#getlocation").click(function() {
            wx.getLocation({
                success: function (res) {
                    latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                    longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
                    var speed = res.speed; // 速度，以米/每秒计
                    var accuracy = res.accuracy; // 位置精度
                    qq.maps.convertor.translate(new qq.maps.LatLng(latitude,longitude), 1, function(res){
                        alert(res[0]);
                    });
                }
            });

        })
        $("#location").click(function() {
            wx.openLocation({
                latitude: latitude, // 纬度，浮点数，范围为90 ~ -90
                longitude: longitude, // 经度，浮点数，范围为180 ~ -180。
                name: '测试', // 位置名
                address: '测试测试测试测试', // 地址详情说明
                scale: 20, // 地图缩放级别,整形值,范围从1~28。默认为最大
                infoUrl: 'http://www.baidu.com' // 在查看位置界面底部显示的超链接,可点击跳转
            });

        });
    });
    var rangestart= function() {
        if (i == 50) {
            $("#stopRecord").click();
        } else {
            $("#range").val(i++);
            $("#time").text(i);
        }
    }
</script>
</html>
