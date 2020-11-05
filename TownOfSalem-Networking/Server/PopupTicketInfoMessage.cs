using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class PopupTicketInfoMessage : BaseMessage
    {
        public readonly int Quantity;
        public readonly int TicketType;

        public PopupTicketInfoMessage(int ticketType, int quantity = 3) : base(MessageType.PopupTicketInfo)
        {
            TicketType = ticketType;
            Quantity = quantity;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)TicketType);
            if (Quantity != 3)
            {
                writer.Write((byte)Quantity);
            }
        }
    }
}