using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DeathAnimationsChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> DeathAnimations = new Dictionary<int, int>();

        public DeathAnimationsChosenMessage(Dictionary<int, int> deathAnimations) : base(MessageType.DeathAnimationsChosen)
        {
            DeathAnimations = deathAnimations;
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