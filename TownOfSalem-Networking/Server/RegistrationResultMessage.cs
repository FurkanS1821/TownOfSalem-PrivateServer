using System.IO;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class RegistrationResultMessage : BaseMessage
    {
        public readonly RegistrationStatus Status;

        public RegistrationResultMessage(RegistrationStatus status) : base(MessageType.RegistrationResult)
        {
            Status = status;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Status + 1));
        }
    }
}
