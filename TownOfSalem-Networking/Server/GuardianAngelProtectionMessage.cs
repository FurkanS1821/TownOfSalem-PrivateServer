using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class GuardianAngelProtectionMessage : BaseMessage
    {
        public readonly int Position;

        public GuardianAngelProtectionMessage(int position) : base(MessageType.GuardianAngelProtection)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}