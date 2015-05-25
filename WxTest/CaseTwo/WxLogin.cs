using System;
using System.Collections.Generic;
using System.Linq;

namespace WxTest.CaseTwo
{
    public class WxLogin
    {
        /// <summary>
        /// 二维码参数值
        /// </summary>
        public int key { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime exptime { get; set; }
        /// <summary>
        /// 扫描者的openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 当前登陆者列表
        /// </summary>
        private static List<WxLogin> _Logins;
        public static List<WxLogin> Logins
        {
            get
            {
                if (_Logins == null) _Logins = new List<WxLogin>();
                else
                {
                    _Logins.Where(l => l.exptime > DateTime.Now).ToList();
                }
                return _Logins;
            }
            set { _Logins = value; }
        }
    }
}