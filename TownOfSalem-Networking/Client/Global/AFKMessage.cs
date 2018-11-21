using System.IO;

namespace TownOfSalem_Networking.Client.Global
{
    public class AFKMessage : BaseMessage
    {
        public AFKStatus Status;

        public AFKMessage(AFKStatus status) : base(MessageType.AwayFromKeyboard)
        {
            Status = status;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Status);
        }
    }
}
