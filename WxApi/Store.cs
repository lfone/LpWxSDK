using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxApi
{
    /// <summary>
    /// 门店管理接口
    /// </summary>
    public class Store
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static PicUrl UploadPic(string filePath, string accessToken)
        {
            var url = string.Format("https://file.api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}", accessToken);
            var formlist = new List<FormEntity>();
            formlist.Add(new FormEntity { IsFile = true, Name = "buffer", Value = filePath });
            return Utils.PostResult<PicUrl>(formlist, url);
        }
        /// <summary>
        /// 添加门店
        /// </summary>
        /// <param name="info">门店信息</param>
        /// <param name="accessToken">调用凭据</param>
        /// <returns></returns>
        public static ErrorEntity Add(BaseStoreInfo info,string accessToken)
        {
            var url = string.Format("http://api.weixin.qq.com/cgi-bin/poi/addpoi?access_token={0}",accessToken);
            var obj = new { business = new { base_info = info } };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<StoreCategory> GetCategory()
        {
            return JsonConvert.DeserializeObject<List<StoreCategory>>(Code.StoreCategory);
        }

        public static Business GetPoi(string poiId, string accessToken)
        {
            var url = string.Format("http://api.weixin.qq.com/cgi-bin/poi/getpoi?access_token={0}", accessToken);
            var obj = new { poi_id = poiId};
            return Utils.PostResult<Business>(obj, url);
        }
        public static string GetList(int begin,int limit,string accessToken)
        {
            var url = string.Format("http://api.weixin.qq.com/cgi-bin/poi/getpoilist?access_token={0}",accessToken);
            var obj = new { begin = begin, limit = limit };
            return Utils.HttpPost(url, JsonConvert.SerializeObject(obj));
        }
    }
}
