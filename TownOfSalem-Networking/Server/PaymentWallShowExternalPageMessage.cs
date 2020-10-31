using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PaymentWallShowExternalPageMessage : BaseMessage
    {
        public readonly string Url;

        public PaymentWallShowExternalPageMessage(string url) : base(MessageType.ExternalPurchase)
        {
            Url = url;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Url));
        }
    }
}