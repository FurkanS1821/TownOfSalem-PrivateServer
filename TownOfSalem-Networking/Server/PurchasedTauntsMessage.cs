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
            for (var i = 0; i < Taunts.Count; i++)
            {
                var taunt = Taunts.ElementAt(i);

                writer.Write(Encoding.UTF8.GetBytes(taunt.Key.ToString()));
                writer.Write('*');
                writer.Write(Encoding.UTF8.GetBytes(taunt.Value.ToString()));

                if (i < Taunts.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
