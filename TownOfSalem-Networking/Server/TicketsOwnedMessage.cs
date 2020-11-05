using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class TicketsOwnedMessage : BaseMessage
    {
        public Dictionary<int, int> Tickets;

        public TicketsOwnedMessage(Dictionary<int, int> tickets) : base(MessageType.TicketsOwned)
        {
            Tickets = tickets;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Tickets.Select(x => $"{x.Key}*{x.Value}"))));
        }
    }
}