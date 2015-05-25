using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WxApi.ReceiveEntity;
using WxApi.ReceiveEntity.Shop;
using WxApi.SendEntity.Shop;

namespace WxApi.Shop
{
    /// <summary>
    /// 货架管理
    /// </summary>
    public class ShelfManage
    {
        /// <summary>
        /// 添加货架
        /// </summary>
        public static ShelfId Add(Shelf shelf,string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/shelf/add?access_token={0}", accessToken);
            return Utils.PostResult<ShelfId>(shelf, url);
        }

        public static ErrorEntity Delete(string shelfId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/shelf/del?access_token={0}", accessToken);
            var obj = new { shelf_id =shelfId};
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

        public static ErrorEntity Update(Shelf shelf, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/shelf/mod?access_token={0}", accessToken);
            return Utils.PostResult<ErrorEntity>(shelf, url);
        }

        public static Shelfs GetAllList(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/shelf/getall?access_token={0}",accessToken);
            return Utils.GetResult<Shelfs>(url);
        }

        public static ShelfInfo GetInfo(int shelfId, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/merchant/shelf/getbyid?access_token={0}", accessToken);
            var res = Utils.HttpPost(url, "{\"shelf_id\":"+shelfId+"}");
            //将返回的JSON数据反序列化为实体对象。
            var tempe = JsonConvert.DeserializeObject<ShelfInfo>(res);
            //由于在实体对象中的包含控件列表，且控件列表是以基类的形式。在反序列化的过程中，并不会判断控件的子类类型，所以需要单独反序列化控件列表
            var jobj = JsonConvert.DeserializeObject<JObject>(res);
            var module_infos = jobj["shelf_info"]["module_infos"];
            tempe.shelf_info.module_infos.Clear();
            foreach (JToken info in module_infos)
            {
                switch (info.Value<int>("eid"))
                {
                    case 1: tempe.shelf_info.module_infos.Add(info.ToObject<ShelfModuleOne>()); break;
                    case 2: tempe.shelf_info.module_infos.Add(info.ToObject<ShelfModuleTwo>()); break;
                    case 3: tempe.shelf_info.module_infos.Add(info.ToObject<ShelfModuleThree>()); break;
                    case 4: tempe.shelf_info.module_infos.Add(info.ToObject<ShelfModuleFour>()); break;
                    case 5: tempe.shelf_info.module_infos.Add(info.ToObject<ShelfModuleFive>()); break;
                }
            }
            return tempe;
        }
    }
}
