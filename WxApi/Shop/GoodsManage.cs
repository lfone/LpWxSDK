using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;
using WxApi.ReceiveEntity.Shop;
using WxApi.SendEntity.Shop;

namespace WxApi.Shop
{
    /// <summary>
    /// 商品管理相关
    /// </summary>
    public class GoodsManage
    {
        /// <summary>
        /// 获取指定商品分类的子分类
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="cate_id">大分类ID(根节点分类id为1)</param>
        /// <returns>子分类列表</returns>
        public static GoodsCategoryList GetChildCategory(string accessToken, string cate_id = "1")
        {
            var obj = new { cate_id = cate_id };
            var url = String.Format("https://api.weixin.qq.com/merchant/category/getsub?access_token={0}", accessToken);
            return Utils.PostResult<GoodsCategoryList>(obj, url);
        }
        /// <summary>
        /// 获取子分类的所有SKU
        /// </summary>
        /// <param name="cate_id">子分类ID</param>
        /// <param name="accessToken">调用凭据</param>
        /// <returns></returns>
        public static SkuList GetsSkuList(string cate_id, string accessToken)
        {
            var obj = new { cate_id = cate_id };
            var url = String.Format("https://api.weixin.qq.com/merchant/category/getsku?access_token={0}", accessToken);
            return Utils.PostResult<SkuList>(obj, url);
        }
        /// <summary>
        ///获取指定分类的所有属性
        /// </summary>
        /// <param name="cate_id">分类ID</param>
        /// <param name="accessToken">调用凭据</param>
        /// <returns></returns>
        public static PropertyList GetPropertyList(string cate_id, string accessToken)
        {
            var obj = new { cate_id = cate_id };
            var url = String.Format("https://api.weixin.qq.com/merchant/category/getproperty?access_token={0}", accessToken);
            return Utils.PostResult<PropertyList>(obj, url);
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods">商品实体</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ProductId AddGoods(Product goods, string accessToken)
        {
            var url = String.Format("https://api.weixin.qq.com/merchant/create?access_token={0}", accessToken);
            return Utils.PostResult<ProductId>(goods, url);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity DelGoods(string productId, string accessToken)
        {
            var url = String.Format("https://api.weixin.qq.com/merchant/del?access_token={0}", accessToken);
            var obj = new { product_id = productId };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="goods">商品信息</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity UpdateGoods(ProductInfo goods, string accessToken)
        {
            var url = String.Format("https://api.weixin.qq.com/merchant/update?access_token={0}", accessToken);
            return Utils.PostResult<ProductId>(goods, url);
        }
        /// <summary>
        /// 根据商品ID获取商品信息
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ProductRevEntity GetProductInfo(string productId, string accessToken)
        {
            var url = String.Format("https://api.weixin.qq.com/merchant/get?access_token={0}", accessToken);
            var obj = new { product_id = productId };
            return Utils.PostResult<ProductRevEntity>(obj, url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="status">商品状态(0-全部, 1-上架, 2-下架)</param>
        /// <returns></returns>
        public static ProductList GetProductList(string accessToken,int status=0)
        {
            var url = String.Format("https://api.weixin.qq.com/merchant/getbystatus?access_token={0}", accessToken);
            var obj = new { status = status };
            return Utils.PostResult<ProductList>(obj, url);
        }
        /// <summary>
        /// 更新商品状态。 （上架or下架）
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="status">商品上下架标识(0-下架, 1-上架)</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity UpdateStatus(string productId, string status, string accessToken)
        {
            var url = String.Format("https://api.weixin.qq.com/merchant/modproductstatus?access_token={0}", accessToken);
            var obj = new { status = status, product_id=productId };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }

        /// <summary>
        /// 增加或减少库存
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="skuInfo">sku信息,格式"id1:vid1;id2:vid2",如商品为统一规格，则此处赋值为空字符串即可</param>
        /// <param name="quantity">增加或减少的库存数量</param>
        /// <param name="flag">操作标志。0减少。1增加</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ErrorEntity UpdateStock(string productId, string skuInfo, string quantity, int flag, string accessToken)
        {
            var url = String.Format("https://api.weixin.qq.com/merchant/stock/{0}?access_token={1}", flag == 1 ? "add" : "reduce", accessToken);
            var obj = new { product_id = productId, sku_info = skuInfo, quantity = quantity };
            return Utils.PostResult<ErrorEntity>(obj, url);
        }
    }
}
