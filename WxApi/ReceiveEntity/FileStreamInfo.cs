using System.IO;

namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 文件流信息
    /// </summary>
    public class FileStreamInfo : MemoryStream
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
    }
}
