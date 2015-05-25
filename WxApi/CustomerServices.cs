using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxApi
{
    /// <summary>
    /// 客服消息及多客服相关处理方法
    /// </summary>
    public class CustomerServices
    {
        #region 发送消息
        /// <summary>
        /// 发送文本
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="content"></param>
        /// <param name="accessToen"></param>
        /// <returns></returns>
        public static ErrorEntity SendText(string openid, string content, string accessToen)
        {
            var json = new
            {
                touser = openid,
                msgtype = "text",
                text = new
                {
                    content = content
                }
            };
            return Send(json, accessToen);
        }
        /// <summary>
        /// 发送图片
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="media_id"></param>
        /// <param name="accessToen"></param>
        /// <returns></returns>
        public static ErrorEntity SendImg(string openid, string media_id, string accessToen)
        {
            var json = new
            {
                touser = openid,
                msgtype = "image",
                image = new
                {
                    media_id = media_id
                }
            };
            return Send(json, accessToen);
        }
        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="media_id"></param>
        /// <param name="accessToen"></param>
        /// <returns></returns>
        public static ErrorEntity SendVoice(string openid, string media_id, string accessToen)
        {
            var json = new
            {
                touser = openid,
                msgtype = "voice",
                voice = new
                {
                    media_id = media_id
                }
            };
            return Send(json, accessToen);
        }
        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="Video"></param>
        /// <param name="accessToen"></param>
        /// <returns></returns>

        public static ErrorEntity SendVideo(string openid, CustomVideo Video, string accessToen)
        {
            var json = new
            {
                touser = openid,
                msgtype = "video",
                video = Video
            };
            return Send(json, accessToen);
        }
        /// <summary>
        /// 发送音乐消息
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="music"></param>
        /// <param name="accessToen"></param>
        /// <returns></returns>
        public static ErrorEntity SendMusic(string openid, CustomMusic music, string accessToen)
        {
            var json = new
            {
                touser = openid,
                msgtype = "music",
                music = music
            };
            return Send(json, accessToen);
        }
        /// <summary>
        /// 发送图文消息
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="article"></param>
        /// <param name="accessToen"></param>
        /// <returns></returns>
        public static ErrorEntity SendArticle(string openid, CustomArticle article, string accessToen)
        {
            var json = new
            {
                touser = openid,
                msgtype = "news",
                news = article
            };
            return Send(json, accessToen);
        }

        public static ErrorEntity SendArticleNoPic(string openid, string title, string description, string url, string accessToen)
        {
            var json = new
            {
                touser = openid,
                msgtype = "news",
                news = new[]
                {
                    new
                    {
                        title=title,
                        description= description,
                        url=url
                    }
                }
            };
            return Utils.PostResult<ErrorEntity>(json, string.Format(url, accessToen));
        }
        private static ErrorEntity Send(object obj, string accessToen)
        {
            return Utils.PostResult<ErrorEntity>(obj, string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToen));
        }

        #endregion

        #region 客服管理

        /// <summary>
        /// 添加客服
        /// </summary>
        /// <param name="account">完整客服账号，格式为：账号前缀@公众号微信号，账号前缀最多10个字符，必须是英文或者数字字符。如果没有公众号微信号，请前往微信公众平台设置。</param>
        /// <param name="nickName">客服昵称，最长6个汉字或12个英文字符</param>
        /// <param name="password">客服账号登录密码</param>
        public static ErrorEntity SetAccount(string account, string nickName, string password, string accessToken, bool isUpdate = false)
        {
            var url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/{0}?access_token={1}", isUpdate ? "update" : "add", accessToken);
            var obj = new { kf_account = account, nickname = nickName, password = Utils.MD5(password) };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 上传客服头像
        /// </summary>
        /// <param name="filepath">图片路径，支持网络图片</param>
        /// <param name="account">完整客服账号，格式为：账号前缀@公众号微信号</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity UploadHeadImg(string filepath, string account, string accessToken)
        {
            var url = string.Format("http://api.weixin.qq.com/customservice/kfaccount/uploadheadimg?access_token={0}&kf_account={1}", accessToken, account);
            var formlist = new List<FormEntity> { new FormEntity { IsFile = true, Name = "media", Value = filepath } };
            return Utils.PostResult<ErrorEntity>(formlist, url);
        }
        /// <summary>
        /// 删除客服账号
        /// </summary>
        public static ErrorEntity DeleteAccount(string account, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}&kf_account={1}", accessToken, account);
            return Utils.GetResult<ErrorEntity>(url);
        }
        /// <summary>
        /// 获取在线客服接待信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static KfOnLineList GetKfOnLineList(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getonlinekflist?access_token={0}", accessToken);
            return Utils.GetResult<KfOnLineList>(accessToken);
        }
        /// <summary>
        /// 获取客服列表
        /// </summary>
        public static KfList GetKfList(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}", accessToken);
            return Utils.GetResult<KfList>(url);
        }


        public static RecordList GetRecordList(DateTime startTime, DateTime endTime, int pageIndex, int pageSize,
            string accessToken, string openid = "")
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getrecord?access_token={0}", accessToken);
            var obj = new
            {
                endtime = Utils.ConvertDateTimeInt(endTime),
                starttime = Utils.ConvertDateTimeInt(startTime),
                openid = openid,
                pageindex = pageIndex,
                pagesize = pageSize
            };
            return Utils.PostResult<RecordList>(obj, url);
        }
        #endregion

        #region 会话管理
        /// <summary>
        /// 客服会话创建与关闭
        /// </summary>
        /// <param name="kfAccount">客服工号</param>
        /// <param name="openId">用户ID</param>
        /// <param name="text">附加文本</param>
        /// <param name="sessionType">请求的会话状态</param>
        public static ErrorEntity KfSession(string kfAccount, string openId, string text, KfSessionType sessionType, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/customservice/kfsession/{0}?access_token={1}", sessionType.ToString(), accessToken);
            var obj = new { kf_account = kfAccount, openid = openId, text = text };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 获取客户的会话状态
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static KfSessionStatus GetsKfSessionStatus(string openId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/customservice/kfsession/getsession?access_token={0}&openid={1}", accessToken, openId);
            return Utils.GetResult<KfSessionStatus>(url);
        }

        /// <summary>
        /// 获取客服的会话列表
        /// </summary>
        /// <param name="kfAccount">客服工号</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static KfSessionList GetKfSessionList(string kfAccount, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/customservice/kfsession/getsessionlist?access_token={0}&kf_account={1}", accessToken, kfAccount);
            return Utils.GetResult<KfSessionList>(url);
        }
        /// <summary>
        /// 获取未接入会话列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static WaitCaseList GetWaitCaseList(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/customservice/kfsession/getwaitcase?access_token={0}",accessToken);
            return Utils.GetResult<WaitCaseList>(url);
        }
        #endregion
    }
}
