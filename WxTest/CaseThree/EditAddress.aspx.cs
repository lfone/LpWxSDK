using System;
using WxApi;

namespace WxTest.CaseThree
{
    public partial class EditAddress :WxBasePage
    {
        public WxApi.PayEntity.EditAddress Edit;
        public string sign;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edit = new WxApi.PayEntity.EditAddress
            {
                appid =appid,
                accesstoken =AuthToken.access_token,
                noncestr =Utils.GetGuid(),
                timestamp = Utils.ConvertDateTimeInt(DateTime.Now),
                url = GetRawUrl()
            };
            sign = WxApi.Pay.GetEditAddressSign(Edit);
        }
    }
}