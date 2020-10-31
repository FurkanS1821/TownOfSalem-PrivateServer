using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class TicketConsumedMessage : BaseMessage
    {
        public int TicketId;

        public TicketConsumedMessage(int ticketId) : base(MessageType.TicketConsumed)
        {
            TicketId = ticketId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(TicketId.ToString()));
        }
    }
}