namespace WxApi.ReceiveEntity
{
    /// <summary>
    /// 创建卡券时，返回的实体
    /// </summary>
   public class CardIdInfo:ErrorEntity
    {
       /// <summary>
       /// 卡券ID
       /// </summary>
       public string card_id { get; set; }
    }
}
