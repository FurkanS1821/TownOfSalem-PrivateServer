using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedDeathAnimationsMessage : BaseMessage
    {
        public List<int> DeathAnimations;

        public PurchasedDeathAnimationsMessage(List<int> deathAnimations) : base(MessageType.PurchasedDeathAnimations)
        {
            DeathAnimations = deathAnimations;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", DeathAnimations)));
        }
    }
}