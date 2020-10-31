using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class SpyNightAbilityMessage : BaseMessage
    {
        public readonly int Type;
        public readonly int Position;

        public SpyNightAbilityMessage(int type, int position) : base(MessageType.SpyNightAbility)
        {
            Type = type;
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Type);
            writer.Write((byte)(Position + 1));
        }
    }
}