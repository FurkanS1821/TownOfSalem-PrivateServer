using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class PurchasePromotionMessage : BaseMessage
    {
        public int PromotionInstanceId;

        public PurchasePromotionMessage(int promotionInstanceId) : base(MessageType.PurchasePromotion)
        {
            PromotionInstanceId = promotionInstanceId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(PromotionInstanceId.ToString()));
        }
    }
}
