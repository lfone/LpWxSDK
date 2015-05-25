using System;
using System.Data;
using WxApi;
using WxApi.ReceiveEntity;
using WxApi.UserManager;

namespace WxTest.CaseOne
{
    public partial class PopularKing : WxBasePage
    {
        public DataRow sharedr;//分享信息
        public DataRow currentdr;//当前用户信息
        public string openid;
        protected string timestamp; //时间戳
        protected string noncestr; //随机字符串
        protected string url; //当前url
        protected string sign; //签名
        protected string shareurl; //分享url
        protected string shareimg; //分享图片
        static JsApiTicket ticket;
        private string shareid;
        protected void Page_Load(object sender, EventArgs e)
        {
            shareid = Request.QueryString["shareid"];
            if (Request.HttpMethod.ToLower() == "get")
            {
                openid = currentinfo.openid;
                //判断数据库是否有此微信用户的信息，如果没有则写入到数据库。
                var isexist = Convert.ToInt32(SQLHelper.ExcuteScalarSQL("select count(1) from [dbo].[Users] where Openid='" + currentinfo.openid + "'")) != 0;
                if (!isexist)
                {
                    //如果不存在，则将信息添加到数据库中
                    SQLHelper.ExcuteSQL(string.Format("insert Users (Openid,NickName,Headimgurl,Popular)values('{0}','{1}','{2}',0)",
                            currentinfo.openid, currentinfo.nickname, currentinfo.headimgurl));
                }
                //判断此页面是否是从别人分享的页面进来的。
                if (string.IsNullOrEmpty(shareid))
                {
                    shareid = currentinfo.openid;
                }
                //分享者信息
                sharedr =
                    SQLHelper.GetTable(string.Format("select * from Users where Openid='{0}'", shareid)).Rows[0];
                //当前登录的用户信息
                currentdr =
                    SQLHelper.GetTable(string.Format("select * from Users where Openid='{0}'", currentinfo.openid))
                        .Rows[0];
                //用户分享时，分享的url
                shareurl = OAuth.GetAuthUrl(appid,
                    string.Format("http://{0}/CaseOne/PopularKing.aspx?shareid={1}", currenthost, currentinfo.openid),
                    "",
                    AuthType.snsapi_userinfo);
                // //用户分享时，分享的图片
                shareimg = string.Format("http://{0}/logo.png", currenthost);
                timestamp = Utils.ConvertDateTimeInt(DateTime.Now).ToString();
                noncestr = timestamp; //随机字符串也使用时间戳。
                url = GetRawUrl();
                if (ticket == null || ticket.expires_time < DateTime.Now)
                {
                    ticket = JsApi.GetHsJsApiTicket(accessToken);
                }
                sign = JsApi.GetJsApiSign(noncestr, ticket.ticket, timestamp, url);
                //获取活动排名信息，并绑定
                reList.DataSource = SQLHelper.GetTable("select * from Users where Popular>0 order by Popular desc");
                reList.DataBind();
            }
            else
            {
                //post请求，说明是助力操作。  首先查询是否已经助力了。不能为同一个人重复助力
                if (Convert.ToInt32(SQLHelper.ExcuteScalarSQL( string.Format("select COUNT(1) from Record where ShareOpenid='{0}' and HelperOpenid='{1}'",
                    shareid, currentinfo.openid))) == 0)
                {
                    //插入助力记录，并更新用户助力次数。   实际项目中需要使用事物，限于篇幅，此处只实现了业务逻辑。
                    SQLHelper.ExcuteSQL(string.Format("insert Record(ShareOpenid,HelperOpenid)values('{0}','{1}');update Users set Popular=Popular+1 where Openid='{0}'", shareid, currentinfo.openid));
                    Response.Write("1");
                }
                else
                {
                    Response.Write("0");
                }
                Response.End();
            }

        }
    }
}