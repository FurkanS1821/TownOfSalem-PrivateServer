using System.Globalization;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PresentPromotionMessage : BaseMessage
    {
        public readonly int PromotionId;
        public readonly int PromotionInstanceId;
        public readonly float Discount;
        public readonly int DurationSeconds;
        public readonly string ProductId;

        public PresentPromotionMessage(int promotionId, int promotionInstanceId, float discount, int durationSeconds,
            string productId) : base(MessageType.PresentPromotion)
        {
            PromotionId = promotionId;
            PromotionInstanceId = promotionInstanceId;
            Discount = discount;
            DurationSeconds = durationSeconds;
            ProductId = productId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var data = $"{PromotionId},{PromotionInstanceId},{Discount.ToString(CultureInfo.InvariantCulture)},";
            data += $"{DurationSeconds},{ProductId}";
            writer.Write(Encoding.UTF8.GetBytes(data));
        }
    }
}