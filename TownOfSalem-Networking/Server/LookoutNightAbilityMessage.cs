using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class LookoutNightAbilityMessage : BaseMessage
    {
        public readonly int Position;

        public LookoutNightAbilityMessage(int position) : base(MessageType.LookoutNightAbilityMessage)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}