using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WxApi.ReceiveEntity;

namespace WxApi
{
    public class QrCode
    {
        private static QrTicket Create(object obj, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", accessToken);
            return Utils.PostResult<QrTicket>(obj, url);
        }
        /// <summary>
        /// 生成临时二维码
        /// </summary>
        /// <param name="expireSeconds">过期时间，最大不超过1800</param>
        /// <param name="sceneId">场景值ID，临时二维码时为32位非0整型</param>
        /// <param name="accessToken">accessToken</param>
        /// <returns>ticket实体，ticket可以换取二维码，也可以根据url自行生成。</returns>
        public static QrTicket CreateTemp(int expireSeconds, int sceneId, string accessToken)
        {
            if (expireSeconds<=0||expireSeconds>1800)
            {
                return new QrTicket{ErrCode = -3,ErrDescription = "有效时间不合法"};
            }
            var json = new
            {
                expire_seconds = expireSeconds,
                action_name = "QR_SCENE",
                action_info = new {scene = new {scene_id = sceneId}}
            };
            return Create(json, accessToken);
        }
        /// <summary>
        /// 创建场景值为数字的永久二维码
        /// </summary>
        /// <param name="sceneId">场景值，有效范围1-100000</param>
        /// <param name="accessToken">accessToken</param>
        /// <returns>ticket实体，ticket可以换取二维码，也可以根据url自行生成。</returns>
        public static QrTicket CreateByID(int sceneId, string accessToken)
        {
            if (sceneId < 1 || sceneId > 100000)
            {
                return new QrTicket { ErrCode = -3, ErrDescription = "场景值不合法，有效范围1-100000" };
            }
            var json = new
            {
                action_name = "QR_LIMIT_SCENE",
                action_info = new { scene = new { scene_id =sceneId} }
            };
            return Create(json, accessToken);
        }

        /// <summary>
        /// 创建场景值为数字的永久二维码
        /// </summary>
        /// <param name="sceneId">场景值，有效范围1-100000</param>
        /// <param name="accessToken">accessToken</param>
        /// <returns>ticket实体，ticket可以换取二维码，也可以根据url自行生成。</returns>
        public static QrTicket CreateByStr(string  sceneStr, string accessToken)
        {
            if (sceneStr.Length < 1 || sceneStr.Length > 64)
            {
                return new QrTicket { ErrCode = -3, ErrDescription = "场景值不合法，长度限制为1到64" };
            }
            var json = new
            {
                action_name = "QR_LIMIT_SCENE",
                action_info = new { scene = new { scene_str = sceneStr } }
            };
            return Create(json, accessToken);
        }
        /// <summary>
        /// 根据ticket获取二维码的地址
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static string GetQrByTicket(string ticket)
        {
            return string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}",ticket);
        }
    }
}
