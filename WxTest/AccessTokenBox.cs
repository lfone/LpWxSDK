using System;
using System.Collections.Generic;
using System.Linq;
using WxApi;
using WxApi.ReceiveEntity;
namespace WxTest
{
    public class AccessTokenBox
    {
        public string AppId { get; set; }
        public AccessToken Token { get; set; }
        private static List<AccessTokenBox> _boxs;

        public static string GetTokenValue(string appid, string appSecret)
        {
            _boxs =( _boxs == null ? new List<AccessTokenBox>() : _boxs.Where(b=>b.Token.ExpirationTime>DateTime.Now).ToList()); 
            var tempat = _boxs.FirstOrDefault(b => b.AppId == appid);
            if (tempat != null)
            {
                return tempat.Token.access_token;
            }
            var newAT = BaseServices.GetAccessToken(appid, appSecret);
            if (!string.IsNullOrEmpty(newAT.access_token))
            {
                _boxs.Add(new AccessTokenBox
                {
                    AppId = appid,
                    Token = newAT
                });
                return newAT.access_token;
            }
            else
            {
                //此处可以写日志，将错误信息保存。
                return "";
            }
        }
    }
}