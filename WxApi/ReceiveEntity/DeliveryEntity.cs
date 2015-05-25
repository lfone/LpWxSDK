using System;
using System.Collections.Generic;
using System.Linq;
namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 快递公司列表
    /// </summary>
    public class DeliveryEntity
    {
        private static Dictionary<string, string> _deliverylist;
        public static Dictionary<string, string> Deliverylist
        {
            get
            {
                //判断值是否为空，如果不为空，则直接返回。否则从资源文件中读取。
                if (_deliverylist != null && _deliverylist.Count > 0)
                    return _deliverylist;
                _deliverylist = new Dictionary<string, string>();
                var temp = Code.DeliveryCode.Split(new char[]{'\r','\n'},
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var strArr in temp.Select(str => str.Split('\t')))
                {
                    _deliverylist.Add(strArr[0], strArr[1]);
                }
                return _deliverylist;
            }
        }
    }
}
