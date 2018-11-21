using System;

namespace TownOfSalem_Networking.Server
{
    public class PresentPromotionMessage : BaseMessage
    {
        public readonly int PromotionId;
        public readonly int PromotionInstanceId;
        public readonly float Discount;
        public readonly int DurationSeconds;
        public readonly string ProductId;

        public PresentPromotionMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split(',');
                PromotionId = int.Parse(strArray[0]);
                PromotionInstanceId = int.Parse(strArray[1]);
                Discount = float.Parse(strArray[2]);
                DurationSeconds = int.Parse(strArray[3]);
                ProductId = strArray[4];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
