using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class RedeemMessage : BaseMessage
    {
        public readonly RedeemResult Result;
        public readonly int ItemType;
        public readonly int ItemId;

        public RedeemMessage(RedeemResult result, int itemType, int itemId) : base(MessageType.RedeemMessage)
        {
            Result = result;
            ItemType = itemType;
            ItemId = itemId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Result);
            writer.Write((byte)ItemType);
            writer.Write(Encoding.UTF8.GetBytes(ItemId.ToString()));
        }
    }
}
