using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WxApi.ReceiveEntity;
using WxApi.ReceiveEntity.DataCube;

namespace WxApi
{
    /// <summary>
    /// 数据统计
    /// </summary>
    public class DataCube
    {
        #region 用户分析数据接口
        /// <summary>
        /// 获取用户增减数据.最大时间跨度7天
        /// </summary>
        public static UserSummarys GetUserSummary(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<UserSummarys>(beginDate, endDate, "getusersummary", accessToken);
        }
        /// <summary>
        /// 获取累计用户数据.最大时间跨度7天
        /// </summary>
        public static UserCumulates GetUserCumulate(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<UserCumulates>(beginDate, endDate, "getusercumulate", accessToken);
        }
        #endregion

        #region 图文分析数据接口
         /// <summary>
        /// 获取图文群发每日数据接口.最大时间跨度1天
        /// </summary>
        public static ArticleSummarys GetArticleSummary(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<ArticleSummarys>(beginDate, endDate, "getarticlesummary", accessToken);
        }
        /// <summary>
        /// 获取图文群发总数据.某天群发的文章，从群发日起到接口调用日（但最多统计发表日后7天数据），每天的到当天的总等数据.最大时间跨度1天
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ArticleTotals GetArticleTotal(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<ArticleTotals>(beginDate, endDate, "getarticletotal", accessToken);
        }
        /// <summary>
        /// 获取图文统计数据.最大时间跨度3天
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ArticleUserReads GetArticleUserRead(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<ArticleUserReads>(beginDate, endDate, "getuserread", accessToken);
        }
        /// <summary>
        /// 获取图文统计分时数据.最大时间跨度1天
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ArticleUserReadHours GetArticleUserReadHour(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<ArticleUserReadHours>(beginDate, endDate, "getuserreadhour", accessToken);
        }
        /// <summary>
        /// 获取图文分享转发数据.最大时间跨度7天
        /// </summary>
        public static ArticleUserShares GetArticleUserShare(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<ArticleUserShares>(beginDate, endDate, "getusershare", accessToken);
        }
        /// <summary>
        /// 获取图文分享转发分时数据.最大时间跨度1天
        /// </summary>
        public static ArticleUserShareHours GetArticleUserShareHour(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<ArticleUserShareHours>(beginDate, endDate, "getusersharehour", accessToken);
        }
        /// <summary>
        /// 获取图文分享转发分时数据.最大时间跨度7天
        /// </summary>
        public static UpstreamMsgs GetUpstreamMsg(DateTime beginDate, DateTime endDate, string accessToken)
        {
            return GetDataCube<UpstreamMsgs>(beginDate, endDate, "getupstreammsg", accessToken);
        }
        #endregion
        private static T GetDataCube<T>(DateTime beginDate, DateTime endDate,string type, string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/datacube/{0}?access_token={1}",type, accessToken);
            var obj = new { begin_date = beginDate.ToString("yyyy-MM-dd"), end_date = endDate.ToString("yyyy-MM-dd") };
            return Utils.PostResult<T>(obj, url);
        }
    }
}
