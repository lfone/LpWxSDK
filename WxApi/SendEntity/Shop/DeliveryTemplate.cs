using System.Collections.Generic;

namespace WxApi.SendEntity.Shop
{
    /// <summary>
    /// 运费模版
    /// </summary>
   public class DeliveryTemplate
   {
       /// <summary>
       /// 邮费模板名称
       /// </summary>
       public string Name { get; set; }
       /// <summary>
       /// 支付方式(0-买家承担运费, 1-卖家承担运费)
       /// </summary>
       public int Assumer { get; set; }
       /// <summary>
       /// 计费单位(0-按件计费, 1-按重量计费, 2-按体积计费，目前只支持按件计费，默认为0)
       /// </summary>
       public int Valuation { get; set; }
       /// <summary>
       /// 具体运费计算
       /// </summary>
       public List<TopFee> TopFee { get; set; }

   }

    public class TopFee
    {
        /// <summary>
        /// 快递类型ID  10000027(平邮)	10000028(快递)	10000029(EMS)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 默认邮费计算方法
        /// </summary>
        public NormalFormula Normal { get; set; }
        /// <summary>
        /// 指定地区邮费计算方法
        /// </summary>
        public List<CustomFormula> Custom { get; set; }
    }
   /// <summary>
   /// 默认邮费计算方法实体
   /// </summary>
    public class NormalFormula
   {
       /// <summary>
       /// 起始计费数量
       /// </summary>
       public int StartStandards { get; set; }
       /// <summary>
       /// 起始计费金额(单位: 分）
       /// </summary>
       public int StartFees { get; set; }
       /// <summary>
       /// 递增计费数量
       /// </summary>
       public int AddStandards { get; set; }
       /// <summary>
       /// 递增计费金额(单位 : 分)
       /// </summary>
       public int AddFees { get; set; }
   }
    /// <summary>
   /// 指定地区邮费计算方法实体
    /// </summary>
    public class CustomFormula:NormalFormula
    {
        /// <summary>
        /// 指定国家
        /// </summary>
        public string DestCountry { get; set; }
        /// <summary>
        /// 指定省份
        /// </summary>
        public string DestProvince { get; set; }
        /// <summary>
        /// 指定城市
        /// </summary>
        public string DestCity { get; set; }
    }
}
