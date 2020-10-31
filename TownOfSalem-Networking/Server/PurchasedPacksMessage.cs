using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedPacksMessage : BaseMessage
    {
        public readonly List<int> Packs;

        public PurchasedPacksMessage(List<int> packs) : base(MessageType.PurchasedPacks)
        {
            Packs = packs;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Packs)));
        }
    }
}