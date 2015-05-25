using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    
    public class StoreCategory
    {
        public string name { get; set; }
        public string value { get; set; }
        /// <summary>
        /// 子列表
        /// </summary>
        public List<StoreCategory> sub { get; set; }
    }
}
