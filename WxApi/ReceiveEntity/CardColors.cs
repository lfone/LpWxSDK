using System.Collections.Generic;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 卡券最新颜色列表
    /// </summary>
    public class CardColors:ErrorEntity
    {
        /// <summary>
        /// 颜色列表
        /// </summary>
        public List<Color> colors { get; set; }
    }
    public class Color
    {
        /// <summary>
        /// 颜色名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 颜色值
        /// </summary>
        public string value { get; set; }
    }
}
