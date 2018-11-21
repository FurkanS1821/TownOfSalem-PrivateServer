using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class SteamApproveMessage : BaseMessage
    {
        public string OrderId;

        public SteamApproveMessage(string orderId) : base(MessageType.SteamApprove)
        {
            OrderId = orderId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(OrderId));
        }
    }
}
