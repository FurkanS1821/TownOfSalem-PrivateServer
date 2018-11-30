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
            for (var i = 0; i < Scrolls.Count; i++)
            {
                var scroll = Scrolls.ElementAt(i);

                writer.Write(Encoding.UTF8.GetBytes(scroll.Key.ToString()));
                writer.Write('*');
                writer.Write(Encoding.UTF8.GetBytes(scroll.Value.ToString()));

                if (i < Scrolls.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
