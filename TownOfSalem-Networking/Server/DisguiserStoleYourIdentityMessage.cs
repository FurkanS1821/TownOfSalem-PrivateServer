using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DisguiserStoleYourIdentityMessage : BaseMessage
    {
        public readonly int Position;

        public DisguiserStoleYourIdentityMessage(int position) : base(MessageType._UNUSED_DisguiserStoleYourIdentity)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}