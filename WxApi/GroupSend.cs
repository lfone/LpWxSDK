using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxApi
{
    public class GroupSend
    {
        #region 基础服务
        /// <summary>
        /// 上传图文消息
        /// </summary>
        public static GroupUpLoadEntity UpLoadNew(List<Article> artList, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}", accessToken);
            var json = new
            {
                articles = artList
            };
            return Utils.PostResult<GroupUpLoadEntity>(json, url);
        }
        /// <summary>
        /// 上传视频消息
        /// </summary>
        /// <param name="media_id">视频文件媒体ID，此参数需要调用上传多媒体接口获取</param>
        /// <param name="title">视频标题</param>
        /// <param name="description">视频描述</param>
        public static GroupUpLoadEntity UpLoadVideo(string media_id, string title, string description, string accessToken)
        {
            var url = string.Format("https://file.api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token={0}", accessToken);
            var json = new
            {
                media_id = media_id,
                title = title,
                description = description
            };
            return Utils.PostResult<GroupUpLoadEntity>(json, url);
        }
        /// <summary>
        /// 基础发送接口
        /// </summary>
        /// <param name="obj">json对象</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="sendtype">群发类型，1为按分组群发，2为按openid列表群发，3为预览接口。默认为按分组群发</param>
        private static GroupSendEntity BaseSend(object obj, string accessToken, int sendtype = 1)
        {
            string url = null;
            switch (sendtype)
            {
                //分组群发
                case 1: url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}",
                accessToken); break;
                //openid列表群发
                case 2: url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}",
            accessToken); break;
                //预览接口
                case 3: url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token={0}",
   accessToken); break;
                default: url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}",
            accessToken); break;
            }
            return Utils.PostResult<GroupSendEntity>(obj, url);
        }
        /// <summary>
        /// 删除群发
        /// </summary>
        /// <param name="msg_id">群发消息ID</param>
        public static ErrorEntity Delete(string msg_id, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token={0}",
                accessToken);
            var json = new { msg_id = msg_id };
            return Utils.PostResult<ErrorEntity>(json, url);
        }

        public static GroupStatus QueryStatus(string msg_id, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/get?access_token={0}", accessToken);
            var json = new { msg_id = msg_id };
            return Utils.PostResult<GroupStatus>(json, url);
        }
        #endregion

        #region 按分组群发
        /// <summary>
        /// 按分组群发文本消息，isall为true时，说明群发所有用户，此时group_id可为空，否则，根据grou_id进行群发
        /// </summary>
        /// <param name="content">群发内容</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="isall">是否群发所有用户</param>
        /// <param name="group_id">分组ID</param>
        public static GroupSendEntity SendTextByGroup(string content, string accessToken, bool isall = true, string group_id = "")
        {
            var json = new
            {
                filter = new
                {
                    is_to_all = isall,
                    group_id = group_id
                },
                text = new
                {
                    content = content
                },
                msgtype = "text"
            };
            return BaseSend(json, accessToken);
        }
        /// <summary>
        ///  按分组群发图片消息，isall为true时，说明群发所有用户，此时group_id可为空，否则，根据grou_id进行群发
        /// </summary>
        /// <param name="media_id">图片的媒体ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="isall">是否群发所有用户</param>
        /// <param name="group_id">分组ID</param>
        public static GroupSendEntity SendImgByGroup(string media_id, string accessToken, bool isall = true, string group_id = "")
        {
            var json = new
            {
                filter = new
                {
                    is_to_all = isall,
                    group_id = group_id
                },
                image = new
                {
                    media_id = media_id
                },
                msgtype = "image"
            };
            return BaseSend(json, accessToken, 1);
        }

        /// <summary>
        ///  按分组群发语音消息，isall为true时，说明群发所有用户，此时group_id可为空，否则，根据grou_id进行群发
        /// </summary>
        /// <param name="media_id">图片的媒体ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="isall">是否群发所有用户</param>
        /// <param name="group_id">分组ID</param>
        public static GroupSendEntity SendVoiceByGroup(string media_id, string accessToken, bool isall = true, string group_id = "")
        {
            var json = new
            {
                filter = new
                {
                    is_to_all = isall,
                    group_id = group_id
                },
                voice = new
                {
                    media_id = media_id
                },
                msgtype = "voice"
            };
            return BaseSend(json, accessToken);
        }

        /// <summary>
        ///  按分组群发图文消息，isall为true时，说明群发所有用户，此时group_id可为空，否则，根据grou_id进行群发
        /// </summary>
        /// <param name="media_id">图片的媒体ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="isall">是否群发所有用户</param>
        /// <param name="group_id">分组ID</param>
        public static GroupSendEntity SendArticleByGroup(string media_id, string accessToken, bool isall = true, string group_id = "")
        {
            var json = new
            {
                filter = new
                {
                    is_to_all = isall,
                    group_id = group_id
                },
                mpnews = new
                {
                    media_id = media_id
                },
                msgtype = "mpnews"
            };
            return BaseSend(json, accessToken);
        }


        /// <summary>
        ///  按分组群发视频消息，isall为true时，说明群发所有用户，此时group_id可为空，否则，根据grou_id进行群发
        /// </summary>
        /// <param name="media_id">图片的媒体ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="isall">是否群发所有用户</param>
        /// <param name="group_id">分组ID</param>
        public static GroupSendEntity SendVideoByGroup(string media_id, string accessToken, bool isall = true, string group_id = "")
        {
            var json = new
            {
                filter = new
                {
                    is_to_all = isall,
                    group_id = group_id
                },
                mpvideo = new
                {
                    media_id = media_id
                },
                msgtype = "mpvideo"
            };
            return BaseSend(json, accessToken);
        }
        #endregion

        #region 按openid列表群发和预览接口【订阅号不可用，服务号认证后可用】
        /// <summary>
        /// 按用户列表群发文本消息
        /// </summary>
        /// <param name="content">群发内容</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="touser">如果为数组，则表示openid列表，调用的群发接口，否则表示openid，调用的是预览接口</param>
        public static GroupSendEntity SendTextByOpenID(string content, string accessToken, object touser)
        {
            var json = new
            {
                touser = touser,
                text = new
                {
                    content = content
                },
                msgtype = "text"
            };
            return BaseSend(json, accessToken, touser.GetType().IsArray ? 2 : 3);
        }
        /// <summary>
        /// 按用户列表群发图片消息
        /// </summary>
        /// <param name="media_id">图片媒体ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="touser">如果为数组，则表示openid列表，调用的群发接口，否则表示openid，调用的是预览接口</param>
        public static GroupSendEntity SendImgByOpenID(string media_id, string accessToken, object touser)
        {
            var json = new
            {
                touser = touser,
                image = new
                {
                    media_id = media_id
                },
                msgtype = "image"
            };
            return BaseSend(json, accessToken, touser.GetType().IsArray ? 2 : 3);
        }

        /// <summary>
        /// 按用户列表群发图片消息
        /// </summary>
        /// <param name="media_id">语音媒体ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="touser">如果为数组，则表示openid列表，调用的群发接口，否则表示openid，调用的是预览接口</param>
        public static GroupSendEntity SendVoiceByOpenID(string media_id, string accessToken, object touser)
        {
            var json = new
            {
                touser = touser,
                voice = new
                {
                    media_id = media_id
                },
                msgtype = "voice"
            };
            return BaseSend(json, accessToken, touser.GetType().IsArray ? 2 : 3);
        }

        /// <summary>
        /// 按用户列表群发图文消息
        /// </summary>
        /// <param name="media_id">图文ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="touser">如果为数组，则表示openid列表，调用的群发接口，否则表示openid，调用的是预览接口</param>
        public static GroupSendEntity SendArticleByOpenID(string media_id, string accessToken, object touser)
        {
            var json = new
            {
                touser = touser,
                mpnews = new
                {
                    media_id = media_id
                },
                msgtype = "mpnews"
            };
            return BaseSend(json, accessToken, touser.GetType().IsArray ? 2 : 3);
        }


        /// <summary>
        /// 按用户列表群发视频消息
        /// </summary>
        /// <param name="media_id">视频ID</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="touser">如果为数组，则表示openid列表，调用的群发接口，否则表示openid，调用的是预览接口</param>
        public static GroupSendEntity SendVideoByOpenID(string media_id, string accessToken, object touser)
        {
            var json = new
            {
                touser = touser,
                mpvideo = new
                {
                    media_id = media_id
                },
                msgtype = "mpvideo"
            };
            return BaseSend(json, accessToken, touser.GetType().IsArray ? 2 : 3);
        }
        #endregion

    }
}
