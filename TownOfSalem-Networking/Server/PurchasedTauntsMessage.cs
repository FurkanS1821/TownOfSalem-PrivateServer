using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedTauntsMessage : BaseMessage
    {
        public Dictionary<int, int> Taunts;

        public PurchasedTauntsMessage(Dictionary<int, int> taunts) : base(MessageType.PurchasedTaunts)
        {
            Taunts = taunts;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Taunts.Select(x => $"{x.Key}*{x.Value}"))));
        }
    }
}