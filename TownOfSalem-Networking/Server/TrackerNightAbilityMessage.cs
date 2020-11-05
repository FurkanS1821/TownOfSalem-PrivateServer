using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TrackerNightAbilityMessage : BaseMessage
    {
        public readonly int Position;

        public TrackerNightAbilityMessage(int position) : base(MessageType.TrackerNightAbility)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}