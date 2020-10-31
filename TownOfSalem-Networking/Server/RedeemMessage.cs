using System.Collections.Generic;
using System.IO;
using System.Text;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class RedeemMessage : BaseMessage
    {
        public readonly RedeemResult Result;
        public readonly int ItemType;
        public readonly int ItemId;
        public readonly List<string> AdditionalValues;

        public RedeemMessage(RedeemResult result, int itemType, int itemId, List<string> additionalValues)
            : base(MessageType.RedeemMessage)
        {
            Result = result;
            ItemType = itemType;
            ItemId = itemId;
            AdditionalValues = additionalValues;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Result);
            if (Result == RedeemResult.Success)
            {
                writer.Write((byte)ItemType);
                writer.Write(Encoding.UTF8.GetBytes($"{ItemId},{string.Join(",", AdditionalValues)}"));
                // AdditionalValues doesn't seem to be parsed client-side in current version,
                // but ItemId is parsed using str.Split(',').
            }
        }
    }
}