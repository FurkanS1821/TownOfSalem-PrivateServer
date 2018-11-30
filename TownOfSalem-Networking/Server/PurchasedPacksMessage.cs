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
            for (var i = 0; i < Packs.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Packs[i].ToString()));

                if (i < Packs.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
