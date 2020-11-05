using System.IO;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class UpdatePasswordResultMessage : BaseMessage
    {
        public readonly UpdatePasswordResultCode Result;

        public UpdatePasswordResultMessage(UpdatePasswordResultCode result) : base(MessageType.UpdatePasswordResult)
        {
            Result = result;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Result);
        }
    }
}