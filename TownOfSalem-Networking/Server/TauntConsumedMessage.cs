using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TauntConsumedMessage : BaseMessage
    {
        public readonly int TauntId;

        public TauntConsumedMessage(int tauntId) : base(MessageType.TauntConsumed)
        {
            TauntId = tauntId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(TauntId + 1));
        }
    }
}