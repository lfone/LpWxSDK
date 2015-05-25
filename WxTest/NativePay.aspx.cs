using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;
using WxApi.PayEntity;

namespace WxTest
{
    public partial class NativePay : System.Web.UI.Page
    {
        private const string key = "c4115c3cbb9e4f64b3d0cfb726e06001";
        private const string notify_url = "http://{0}/paynotify.ashx";
        private const string appid = "appid";
        private const string mch_id = "1240050702";
        public string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            url = HttpUtility.UrlEncode(WxApi.Pay.CreateNativeUrl(new NativeEntity
            {
                appid = appid,
                mch_id = mch_id,
                nonce_str = Utils.GetGuid(),
                product_id = "324243255345345",
                time_stamp = Utils.ConvertDateTimeInt(DateTime.Now).ToString()
            }, key));

        }
    }
}