using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AmbusherNightAbilityMessage : BaseMessage
    {
        public readonly int Position;

        public AmbusherNightAbilityMessage(int position) : base(MessageType.AmbusherNightAbility)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}
