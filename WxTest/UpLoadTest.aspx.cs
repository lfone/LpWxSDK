using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WxApi;
using WxApi.ReceiveEntity;
using WxApi.SendEntity;

namespace WxTest
{
    public partial class UpLoadTest : System.Web.UI.Page
    {
        public string url = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("wxd7008116979a800d", "49523ae424f3d22b369c16f8738fecba");
            WxApi.GroupSend.SendVideoByOpenID("I9sIPBRlTHGjsqTtwHj4oWIX9k-NFaGiTwNm59pctukTWNBGxpZ_8iXNEXmb2Jf5",
                accessToken, new[] {"o8mXItyyhht1ubxsO9nidRzfMIOU", "o8mXIt-fC-3pcE0Og1v1IFkj8rO8"});
            return;
            //var ss =  MaterialLib.GetList(MaterialType.image, 0, 2, accessToken);
            // return;
            List<Article> articles = new List<Article>
            {
                new Article
                {
                    author="king",
                    content = "content",
                    digest = "ddd",
                    show_cover_pic = 0,
                    thumb_media_id = "8794518790",
                    title = "kingcome"
                },
                new Article
                {
                    author="king1",
                    content = "content1",
                    digest = "ddd1",
                    show_cover_pic = 1,
                    thumb_media_id = "8794518790",
                    title = "kingcome1"
                }
            };
            var ret = MaterialLib.AddArticle(articles, accessToken);
        }
    }
}