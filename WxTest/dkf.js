var Dkf = {
    //初始化多客服
    Init: function (ticket) {
        $.getScript('http://crm1.dkf.qq.com/php/index.php/thirdapp/appdemo/get_workeraccount_by_sessionkey?callback=wokeraccountCallback&ticket=' + ticket);
    },
    //向会话窗口输入框中输入一条消息
    PutMsg: function (type, content) {
        var obj = {
            msg: {
                head: { random: Math.ceil(Math.random() * 10000000).toString() },
                body: [{ type: type, content: content }]
            }
        };
        window.external.PutMsg(JSON.stringify(obj));
    },
    //向会话窗口输入框中输入文本消息
    PutTextMsg:function(text) {
        var content = { text: text };
        Dkf.PutMsg(0,content);
    },
    //向会话窗口输入框中输入图片消息
    PutImgMsg: function (picUrl) {
        var content = { picUrl: picUrl };
        Dkf.PutMsg(1, content);
    },
    //向会话窗口输入框中输入图文消息
    PutNewsMsg: function (news) {
        Dkf.PutMsg(7, news);
    },
    Notice: function() {
        window.external.Notice("");
    },
};

function MCS_ClientNotify(EventData) {
    var edjson = (new Function("return " + EventData))();;
    switch (edjson['event']) {
        case 'OnUserChange': {
            OnUserChange(edjson);
            break;
        }
        case 'OnMapMsgClick': {
            OnMapMsgClick(EventData);
            break;
        }
    }
}

function OnUserChange(EventData) {
    var openid = EventData.useraccount;
}
function OnMapMsgClick(EventData) {
    var latitude = EventData.latitude;
    var longitude = EventData.longitude;
    var location = EventData.location;
    var scale = EventData.scale;
}
