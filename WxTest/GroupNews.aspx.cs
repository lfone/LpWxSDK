using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxApi;
using WxApi.SendEntity;

namespace WxTest
{
    public partial class GroupNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("wxd7008116979a800d", "49523ae424f3d22b369c16f8738fecba");
            //var list = new List<GroupArticle>();
            //list.Add(new GroupArticle
            //{
            //    author = "张三",
            //    content = "<a href=\"http://www.baidu.com\">百度一下</a>",
            //    content_source_url = "http://www.baidu.com",
            //    digest = "图文消息测试",
            //    show_cover_pic = 1,
            //    thumb_media_id = "aJMnmY9mjGoV3zxtydTRs1fsZxKVTJwIqjW8tRjBkg7dsZuDg2ZvR1tgO2K1VPEq",
            //    title = "哈哈哈哈哈地方东方闪电风很大飞大神"
            //});
            //var ss = GroupSend.UpLoadNew(list, accessToken);
            var ss = WxApi.GroupSend.UpLoadVideo("HY6sEwiWqKLwlbTRn4oLuTMZ1seiYVoKu4gs06oMC5xrExEnTOfC3IPKWiOpXTE1", "视频测试",
                "视频消息描述", accessToken);
        }
    }
}