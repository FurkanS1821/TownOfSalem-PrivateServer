using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DeathAnimationsChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> DeathAnimations;

        public DeathAnimationsChosenMessage(Dictionary<int, int> deathAnims) : base(MessageType.DeathAnimationsChosen)
        {
            DeathAnimations = deathAnims;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var deathAnimation in DeathAnimations)
            {
                writer.Write((byte)(deathAnimation.Key + 1));
                writer.Write((byte)(deathAnimation.Value + 1));
            }
        }
    }
}
