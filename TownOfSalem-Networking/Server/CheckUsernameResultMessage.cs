using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class CheckUsernameResultMessage : BaseMessage
    {
        public readonly bool IsAvailable;
        private const byte NAME_AVAILABLE = 1;
        private const byte NAME_UNAVAILABLE = 2;

        public CheckUsernameResultMessage(bool isAvailable) : base(MessageType.CheckUsernameResult)
        {
            IsAvailable = isAvailable;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(IsAvailable ? NAME_AVAILABLE : NAME_UNAVAILABLE);
        }
    }
}
