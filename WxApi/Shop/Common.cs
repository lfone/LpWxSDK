using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity.Shop;
using WxApi.SendEntity;

namespace WxApi.Shop
{
    public class Common
    {
        public static PicInfo UploadImg(string filepath, string accessToken)
        {
            var fsi = Utils.GetFileStreamInfo(filepath);
            var url = string.Format("https://api.weixin.qq.com/merchant/common/upload_img?access_token={0}&filename={1}",accessToken,fsi.FileName);
            return Utils.PostResult<PicInfo>(fsi, url);
        }
    }
}
