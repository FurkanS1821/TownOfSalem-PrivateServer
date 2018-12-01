using System.IO;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class NameChangeResultMessage : BaseMessage
    {
        public readonly NameChangeResultCode Result;

        public NameChangeResultMessage(NameChangeResultCode result) : base(MessageType.NameChangeResult)
        {
            Result = result;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Result);
        }
    }
}
