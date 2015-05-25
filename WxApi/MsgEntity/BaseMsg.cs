using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Tencent;
using WxApi.SendEntity;

namespace WxApi.MsgEntity
{
    /// <summary>
    /// 所有消息类型的基类
    /// </summary>
    public abstract class BaseMsg
    {

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType MsgType { get; set; }

        public virtual void ResText(EnterParam param, string content)
        {
            var resxml = new StringBuilder();
            resxml.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName>",FromUserName);
            resxml.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>",ToUserName);
            resxml.AppendFormat("<CreateTime>{0}</CreateTime>", Utils.ConvertDateTimeInt(DateTime.Now));
            resxml.Append("<MsgType><![CDATA[text]]></MsgType>");
            resxml.AppendFormat("<Content><![CDATA[{0}]]></Content></xml>", content);
            Response(param,resxml.ToString());
        }

        /// <summary>
        /// 回复消息(图片)
        /// </summary>
        public void ResPicture(EnterParam param, string media_id)
        {
            var resxml = new StringBuilder();
            resxml.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName>", FromUserName);
            resxml.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", ToUserName);
            resxml.AppendFormat("<CreateTime>{0}</CreateTime>", Utils.ConvertDateTimeInt(DateTime.Now));
            resxml.Append("<MsgType><![CDATA[image]]></MsgType>");
            resxml.AppendFormat("<Image><MediaId><![CDATA[{0}]]></MediaId></Image></xml>", media_id);
            Response(param, resxml.ToString());
        }

        /// <summary>
        /// 回复消息(语音)
        /// </summary>
        public void ResVoice(EnterParam param, string media_id)
        {
            var resxml = new StringBuilder();
            resxml.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName>", FromUserName);
            resxml.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", ToUserName);
            resxml.AppendFormat("<CreateTime>{0}</CreateTime>", Utils.ConvertDateTimeInt(DateTime.Now));
            resxml.Append("<MsgType><![CDATA[voice]]></MsgType>");
            resxml.AppendFormat("<Voice><MediaId><![CDATA[{0}]]></MediaId></Voice></xml>", media_id);
            Response(param, resxml.ToString());
        }

        /// <summary>
        /// 回复消息(视频)
        /// </summary>
        public void ResVideo(EnterParam param, ResVideo video)
        {
            var resxml = new StringBuilder();
            resxml.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName>", FromUserName);
            resxml.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", ToUserName);
            resxml.AppendFormat("<CreateTime>{0}</CreateTime>", Utils.ConvertDateTimeInt(DateTime.Now));
            resxml.Append("<MsgType><![CDATA[video]]></MsgType>");
            resxml.AppendFormat("<Video><MediaId><![CDATA[{0}]]></MediaId>", video.MediaId);
            resxml.AppendFormat("<Title><![CDATA[{0}]]></Title>", video.Title);
            resxml.AppendFormat("<Description><![CDATA[{0}]]></Description></Video></xml>", video.Description);
            Response(param, resxml.ToString());
        }

        /// <summary>
        /// 回复消息(音乐)
        /// </summary>
        public void ResMusic(EnterParam param, ResMusic music)
        {
            var resxml = new StringBuilder();
            resxml.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName>", FromUserName);
            resxml.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", ToUserName);
            resxml.AppendFormat("<CreateTime>{0}</CreateTime>", Utils.ConvertDateTimeInt(DateTime.Now));
            resxml.Append("<MsgType><![CDATA[music]]></MsgType>");
            resxml.AppendFormat("<Music><MusicUrl><![CDATA[{0}]]></MusicUrl>", music.MusicUrl);
            resxml.AppendFormat("<Title><![CDATA[{0}]]></Title>", music.Title);
            resxml.AppendFormat("<HQMusicUrl><![CDATA[{0}]]></HQMusicUrl>", music.HQMusicUrl);
            resxml.AppendFormat("<ThumbMediaId><![CDATA[{0}]]></ThumbMediaId>", music.ThumbMediaId);
            resxml.AppendFormat("<Description><![CDATA[{0}]]></Description></Music></xml>", music.Description);
            Response(param, resxml.ToString());
        }

        /// <summary>
        /// 回复图文
        /// </summary>
        public void ResArticles(EnterParam param, List<ResArticle> artList)
        {
            var resxml = new StringBuilder();
            resxml.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName>", FromUserName);
            resxml.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", ToUserName);
            resxml.AppendFormat("<CreateTime>{0}</CreateTime>", Utils.ConvertDateTimeInt(DateTime.Now));
            resxml.Append("<MsgType><![CDATA[news]]></MsgType>");
            resxml.AppendFormat("<ArticleCount>{0}</ArticleCount><Articles>", artList.Count);
            foreach (var article in artList)
            {
                resxml.AppendFormat("<item><Title><![CDATA[{0}]]></Title>", article.Title);
                resxml.AppendFormat("<PicUrl><![CDATA[{0}]]></PicUrl>", article.PicUrl);
                resxml.AppendFormat("<Url><![CDATA[{0}]]></Url>", article.Url);
                resxml.AppendFormat("<Description><![CDATA[{0}]]></Description></item>", article.Description);
            }
            resxml.Append("</Articles></xml>");
            Response(param, resxml.ToString());
        }

        /// <summary>
        /// 多客服转发如果指定的客服没有接入能力(不在线、没有开启自动接入或者自动接入已满)，
        /// 该用户会一直等待指定客服有接入能力后才会被接入，而不会被其他客服接待。建议在指定客服时，先查询客服的接入能力指定到有能力接入的客服，保证客户能够及时得到服务。
        /// </summary>
        /// <param name="account">客服工号。默认为空</param>
        public void TransDkf(EnterParam param, string account="")
        {
            var resxml = new StringBuilder();
            resxml.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName>",FromUserName);
            resxml.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>",ToUserName);
            resxml.AppendFormat("<CreateTime>{0}</CreateTime>", Utils.ConvertDateTimeInt(DateTime.Now));
            resxml.Append("<MsgType><![CDATA[transfer_customer_service]]></MsgType>");
            if (account!="")
            {
                resxml.AppendFormat("<TransInfo><KfAccount><![CDATA[{0}]]></KfAccount></TransInfo>",account);
            }
            resxml.AppendFormat("</xml>");
            Response(param,resxml.ToString());
        }

        private void Response(EnterParam param, string data)
        {
            if (param.IsAes)
            {
                var wxcpt = new WXBizMsgCrypt(param.token, param.EncodingAESKey, param.appid);
                wxcpt.EncryptMsg(data, Utils.ConvertDateTimeInt(DateTime.Now).ToString(), Utils.ConvertDateTimeInt(DateTime.Now).ToString(), ref data);
            }
            HttpContext.Current.Response.Write(data);
            HttpContext.Current.Response.End();
        }
    }
}
