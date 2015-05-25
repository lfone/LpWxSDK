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
    public partial class MenuTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("wxd7008116979a800d", "49523ae424f3d22b369c16f8738fecba");
            var child1 = new List<BaseMenu>();
            var child2 = new List<BaseMenu>();
            var child3 = new List<BaseMenu>();
            var basebtn = new List<BaseMenu>();
            child1.Add(new BaseMenu
            {
                key = "我是click按钮",
                name = "Click按钮",
                type = MenuType.click
            });
            child1.Add(new BaseMenu
            {
                key = "我是选择地理位置按钮",
                name = "选择地理位置",
                type = MenuType.location_select
            });
            child1.Add(new BaseMenu
            {
                url = "http://www.baidu.com",
                name = "跳转链接",
                type = MenuType.view
            });
            child2.Add(new BaseMenu
            {
                key = "我是扫码推事件按钮",
                name = "扫码推事件",
                type = MenuType.scancode_push
            });
            child2.Add(new BaseMenu
            {
                key = "我是扫码推事件按钮且弹出消息接收中",
                name = "扫码等待",
                type = MenuType.scancode_waitmsg
            });
            
            child3.Add(new BaseMenu
            {
                key = "我是拍照或相册按钮",
                name = "拍照或相册",
                type = MenuType.pic_photo_or_album
            });
            child3.Add(new BaseMenu
            {
                key = "我是系统拍照",
                name = "系统拍照",
                type = MenuType.pic_sysphoto
            });
            child3.Add(new BaseMenu
            {
                key = "我是弹出微信相册按钮",
                name = "微信相册",
                type = MenuType.pic_weixin
            });
          
            basebtn.Add(new BaseMenu
            {
                name = "常用菜单",
                sub_button = child1
            });
            basebtn.Add(new BaseMenu
            {
                name = "扫码",
                sub_button = child2
            });
            basebtn.Add(new BaseMenu
            {
                name = "发图",
                sub_button = child3
            });
            var ret = WxApi.Menu.Create(new MenuEntity { button = basebtn }, accessToken);
            Response.Write(ret.ErrDescription);
        }
    }
}