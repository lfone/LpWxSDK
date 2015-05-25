using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxApi.SendEntity
{
    public class FormEntity
    {
        /// <summary>
        /// 表单名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 表单值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 是否是文件
        /// </summary>
        public bool IsFile { get; set; }
    }
}
