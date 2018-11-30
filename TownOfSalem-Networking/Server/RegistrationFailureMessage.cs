using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class RegistrationFailureMessage : BaseMessage
    {
        public readonly RegistrationFailure Reason;

        public RegistrationFailureMessage(RegistrationFailure reason) : base(MessageType.RegistrationFailure)
        {
            Reason = reason;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Reason);
        }
    }
}
