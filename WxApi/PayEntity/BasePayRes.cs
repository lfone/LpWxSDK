namespace WxApi.PayEntity
{
    /// <summary>
    /// 支付接口调用后，响应参数基础类。
    /// </summary>
    public class BasePayRes:BasePay
    {
        /// <summary>
        /// SUCCESS/FAIL此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        public string return_code { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// </summary>
        public string return_msg { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 业务结果
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string err_code { get; set; }
        /// <summary>
        /// 错误代码描述 
        /// </summary>
        public string err_code_des { get; set; }
    }
}
