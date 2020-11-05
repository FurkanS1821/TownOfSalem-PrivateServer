using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DisguiserChangedIdentityMessage : BaseMessage
    {
        public readonly int Position;

        public DisguiserChangedIdentityMessage(int position) : base(MessageType._UNUSED_DisguiserChangedIdentity)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}