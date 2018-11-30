using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class LoginResultMessage : BaseMessage
    {
        public LoginStatus Status;

        public LoginResultMessage(LoginStatus status) : base(MessageType.LoginResult)
        {
            Status = status;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Status + 1));
        }
    }
}
