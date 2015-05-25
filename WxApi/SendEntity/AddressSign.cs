using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.SendEntity
{
    /// <summary>
    /// 共享地址签名参数实体
    /// </summary>
    public class AddressSign
    {
        public string appid { get; set; }
        public string url { get; set; }
        public string timestamp { get; set; }
        public string noncestr { get; set; }
        public string accesstoken { get; set; }
        public string code { get; set; }
        public string state { get; set; }
    }
}
