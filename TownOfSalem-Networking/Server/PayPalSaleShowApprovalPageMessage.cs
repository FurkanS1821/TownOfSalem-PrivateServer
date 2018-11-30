using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PayPalSaleShowApprovalPageMessage : BaseMessage
    {
        public readonly string Url;

        public PayPalSaleShowApprovalPageMessage(string url) : base(0) // todo
        {
            Url = url;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Url));
        }
    }
}
