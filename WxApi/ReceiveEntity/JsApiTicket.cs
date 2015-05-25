using System;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// jsapi中。Ticket实体
    /// </summary>
    public class JsApiTicket : ErrorEntity
    {
        /// <summary>
        /// ticket
        /// </summary>
        public string ticket { get; set; }
        private int _expires_in;
        /// <summary>
        /// 有效期时间。单位秒
        /// </summary>
        public int expires_in
        {
            get { return _expires_in; }
            set
            {
                //获取失效时间
                expires_time = DateTime.Now.AddSeconds(value);
                _expires_in = value;
            }
        }
        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime expires_time { get; set; }
    }
}
