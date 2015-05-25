using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxApi
{
    /// <summary>
    /// 素材管理
    /// </summary>
    public class MaterialLib
    {
        /// <summary>
        /// 添加素材。临时素材的有效时间为3天
        /// </summary>
        /// <param name="filePath">服务器文件的物理路径，可用Request.MapPath将虚拟路径转换为物理路径。也可为网络路径，如：http://XXXX</param>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="mediaType">媒体类型枚举</param>
        /// <param name="IsTemp">是否是临时素材</param>
        /// <param name="videotitle">永久视频素材标题</param>
        /// <param name="videointroduction">永久视频素材描述</param>
        public static UpLoadInfo Add(string filePath, string accessToken, MaterialType mediaType, bool IsTemp = true, string videotitle = "", string videointroduction = "")
        {
            try
            {
                //临时素材接口
                var url = "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
                if (!IsTemp)
                {
                    //永久素材接口
                    url = "http://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}&type={1}";
                }
                var formlist = new List<FormEntity>
                {
                    new FormEntity {IsFile = true, Name = "media",  Value = filePath}
                };
                if (mediaType == MaterialType.video&&!IsTemp)
                {
                    //新增视频素材的特殊处理
                    var value = JsonConvert.SerializeObject(new { title = videotitle, introduction = videointroduction });
                    formlist.Add(new FormEntity { IsFile = false, Name = "description", Value = value });
                }
                return Utils.PostResult<UpLoadInfo>(formlist, string.Format(url, accessToken, mediaType.ToString()));
            }
            catch (Exception e)
            {
                return new UpLoadInfo
                {
                    ErrCode = -2,
                    ErrDescription = e.Message
                };
            }
        }
        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        /// <param name="articles"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static UpLoadInfo AddArticle(List<Article> articles, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}", accessToken);
            return Utils.PostResult<UpLoadInfo>(new { articles = articles }, url);
        }

        /// <summary>
        /// 获取临时素材的url
        /// </summary>
        /// <param name="mediaId">素材ID</param>
        /// <param name="accessToken">全局接口凭据</param>
        /// <returns>url</returns>
        public static string GetTempUrl(string mediaId, string accessToken)
        {
            var url = "http://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
            return string.Format(url, mediaId, accessToken);
        }

        /// <summary>
        /// 获取永久素材总数。图片和图文消息素材的总数上限为5000，其他素材为1000
        /// </summary>
        /// <param name="accessToken">全局票据</param>
        /// <returns>包括voice_count，video_count，image_count，news_count</returns>
        public static MaterialCount GetCount(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/material/get_materialcount?access_token={0}", accessToken);
            return Utils.GetResult<MaterialCount>(url);
        }
        /// <summary>
        /// 获取永久素材列表，会包含公众号在公众平台官网素材管理模块中新建的图文消息、语音、视频等素材（但需要先通过获取素材列表来获知素材的media_id）
        ///临时素材无法通过本接口获取
        /// </summary>
        /// <param name="mediaType">素材类型</param>
        /// <param name="index">从全部素材的指定索引开始返回。0表示从第一个素材返回</param>
        /// <param name="count">返回素材的数量，取值在1到20之间</param>
        /// <param name="accessToken">全局票据</param>
        public static MaterialList GetList(MaterialType mediaType, int index, int count, string accessToken)
        {
            if (count < 1 || count > 20)
            {
                return new MaterialList { ErrCode = -2, ErrDescription = "素材的数量，取值在1到20之间" };
            }
            if (index < 0)
            {
                return new MaterialList { ErrCode = -2, ErrDescription = "索引不能小于0" };
            }
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}",
                accessToken);
            var obj = new { type = mediaType.ToString(), offset = index, count = count };
            return Utils.PostResult<MaterialList>(obj, url);
        }
        /// <summary>
        /// 获取永久素材。
        /// </summary>
        /// <param name="mediaId">媒体ID</param>
        /// <param name="accessToken">全局凭证</param>
        /// <param name="stream">文件流</param>
        /// <returns>当请求的是图文消息时，返回图文消息实体。其他类型的消息则返回文件流</returns>
        public static MaterialNews Get(string mediaId, string accessToken, out FileStreamInfo stream)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/material/get_material?access_token={0}", accessToken);
            var retdata = Utils.HttpPost(url, "{\"media_id\":" + mediaId + "}", out stream);
            if (retdata == "")//说明非图文消息
            {
                return new MaterialNews { ErrCode = 0 };
            }
            return JsonConvert.DeserializeObject<MaterialNews>(retdata);
        }
        /// <summary>
        /// 删除永久素材
        /// </summary>
        /// <param name="mediaId">mediaId</param>
        /// <param name="accessToken">接口调用凭据</param>
        /// <returns></returns>
        public static ErrorEntity Del(string mediaId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/material/del_material?access_token={0}", accessToken);
            return Utils.PostResult<ErrorEntity>(new { media_id = mediaId }, url);
        }
        /// <summary>
        /// 修改永久图文素材
        /// </summary>
        /// <param name="mediaId">图文素材ID</param>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="index">要更新的文章在图文消息中的位置（多图文消息时，此字段才有意义），第一篇为0</param>
        /// <param name="article">图文实体。此处表示的修改后的图文信息</param>
        /// <returns></returns>
        public static ErrorEntity Update(string mediaId, string accessToken, int index, Article article)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/material/update_news?access_token={0}", accessToken);
            var obj = new
            {
                media_id = mediaId,index = index, articles = article
            };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

    }
}
