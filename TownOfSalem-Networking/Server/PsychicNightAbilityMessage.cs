using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class PsychicNightAbilityMessage : BaseMessage
    {
        public readonly int Type;
        public readonly List<int> Positions;

        public PsychicNightAbilityMessage(int type, List<int> positions) : base(MessageType.PsychicNightAbility)
        {
            Type = type;
            Positions = positions;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Type);
            foreach (var position in Positions)
            {
                writer.Write((byte)(position + 1));
            }
        }
    }
}