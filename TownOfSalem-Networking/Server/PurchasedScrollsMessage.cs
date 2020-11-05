using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedScrollsMessage : BaseMessage
    {
        public Dictionary<int, int> Scrolls;

        public PurchasedScrollsMessage(Dictionary<int, int> scrolls) : base(MessageType.PurchasedScrolls)
        {
            Scrolls = scrolls;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Scrolls.Select(x => $"{x.Key}*{x.Value}"))));
        }
    }
}