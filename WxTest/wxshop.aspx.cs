using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WxApi;
using WxApi.ReceiveEntity.Shop;
using WxApi.SendEntity.Shop;
using WxApi.Shop;

namespace WxTest
{
    public partial class wxshop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accessToken = AccessTokenBox.GetTokenValue("appid", "appsecret");
            //var img =
            //    Common.UploadImg(
            //        "http://img5q.duitang.com/uploads/item/201209/20/20120920165508_EuenZ.thumb.700_0.jpeg", accessToken);
            //var img1 =
            //    Common.UploadImg(
            //        "http://www.gwzq.net/attached/image/20140926/20140926151425_767.jpg", accessToken);
            //var img2 =
            //Common.UploadImg(
            //    "http://s6.sinaimg.cn/middle/6408390f499115079e985&690.jpg", accessToken);
            //var img3 =
            //Common.UploadImg(
            //    "http://img.800.cn/20141011/n_5439304695dc9.JPG", accessToken);
            var img4 =
          Common.UploadImg(
              "http://img.800.cn/20141011/n_5439304695dc9.JPG", accessToken);
            var ss = ShelfManage.Add(new Shelf
             {
                 shelf_banner = "http://mmbiz.qpic.cn/mmbiz/kaDyupsRfHaIhL9xmNxEkd3O2sVnCodBsaePEBIicUXdz64Jnpic1UKsVUsNkDr5wl3xEYCPnCsJ4Gf5j7VKoiaBA/0",
                 shelf_name = "one",
                 shelf_data = new ShelfData
                 {
                     module_infos = new List<ShelfModule>()
                    {
                        //new ShelfModuleOne
                        //{
                        //    group_info = new OneGroupInfo
                        //    {
                        //        filter = new Filter
                        //        {
                        //            count = 4
                        //        },
                        //        group_id = "206613028"
                        //    }
                        //}
                        //new ShelfModuleTwo
                        //{
                        //    group_infos = new GroupIds
                        //    {
                        //        groups = new List<GroupIdEntity>
                        //        {
                        //            new GroupIdEntity
                        //            {
                        //                group_id = "206613028"
                        //            },
                        //            new GroupIdEntity
                        //            {
                        //                group_id = "206613140"
                        //            },
                        //            new GroupIdEntity
                        //            {
                        //                group_id = "206613143"
                        //            },
                        //            new GroupIdEntity
                        //            {
                        //                group_id = "206613147"
                        //            }
                        //        }
                        //    }
                        //}
                        //new ShelfModuleThree
                        //{
                        //    group_info = new GroupImg
                        //    {
                        //        group_id = "206613028",
                        //        img = img.image_url
                        //    }
                        //},
                        //new ShelfModuleFour
                        //{
                        //    group_infos = new GroupInfos
                        //    {
                        //        groups = new List<GroupImg>
                        //        {
                        //            new GroupImg{group_id = "206613140",img = img1.image_url},
                        //            new GroupImg{group_id = "206613143",img = img2.image_url},
                        //            new GroupImg{group_id = "206613147",img = img3.image_url}
                        //        }
                        //    }
                        //}, 
                        //new ShelfModuleThree2
                        //{
                        //    group_info = new GroupImg
                        //    {
                        //        group_id = "202824881",
                        //        img = img.image_url
                        //    }
                        //}
                        new ShelfModuleFive
                        {
                            group_infos = new FiveGroupInfo
                            {
                                groups = new List<GroupIdEntity>
                                {
                                    new GroupIdEntity{group_id = "206613140"},
                                    new GroupIdEntity{group_id = "206613143"},
                                    new GroupIdEntity{group_id = "206613147"},
                                    new GroupIdEntity{group_id = "206613028"}
                                },
                                img_background = img4.image_url
                            }
                        }
                        
                    }
                 }
             }, accessToken);
            Response.Write(JsonConvert.SerializeObject(ss));


            //var goods = new ProductInfo
            //   {
            //       product_base = new ProductBase
            //       {
            //           buy_limit = 10,
            //           category_id = new List<string> { "537103312" },
            //           detail = new List<Detail>()
            //           {
            //               new Detail {text = "32323",img = "http://mmbiz.qpic.cn/mmbiz/4whpV1VZl2iccsvYbHvnphkyGtnvjD3ulEKogfsiaua49pvLfUS8Ym0GSYjViaLic0FD3vN0V8PILcibEGb2fPfEOmw/0"},
            //               new Detail {text = "32323"}
            //           },
            //           img = new List<string> { "http://mmbiz.qpic.cn/mmbiz/4whpV1VZl2iccsvYbHvnphkyGtnvjD3ulEKogfsiaua49pvLfUS8Ym0GSYjViaLic0FD3vN0V8PILcibEGb2fPfEOmw/0" },

            //           main_img =
            //               "http://mmbiz.qpic.cn/mmbiz/4whpV1VZl2iccsvYbHvnphkyGtnvjD3ulEKogfsiaua49pvLfUS8Ym0GSYjViaLic0FD3vN0V8PILcibEGb2fPfEOmw/0",
            //           name = "C#开发微信教程实战",
            //           property = new List<Property>
            //           {
            //               new Property {id = "1075772879", vid = "1079822738"},
            //               new Property {id = "$售后年限", vid = "$一年"}
            //           }
            //       },
            //       attrext = new AttrExt
            //       {
            //           isPostFree = 1,
            //           Location = new Location
            //           {
            //               country = "中国",
            //               province = "湖北省",
            //               city = "武汉市",
            //               address = "街道口"

            //           }
            //       },
            //       sku_list = new List<WxApi.SendEntity.Shop.ProductSku>
            //       {
            //           new WxApi.SendEntity.Shop.ProductSku
            //           {
            //               product_code = "332323",icon_url = "http://mmbiz.qpic.cn/mmbiz/4whpV1VZl2iccsvYbHvnphkyGtnvjD3ulEKogfsiaua49pvLfUS8Ym0GSYjViaLic0FD3vN0V8PILcibEGb2fPfEOmw/0"
            //           ,ori_price = 1000000,price = 700000,quantity = 100000
            //           }
            //       }
            //   };
            //var ssssss = GoodsManage.AddGoods(goods, accessToken);
        }
    }
}