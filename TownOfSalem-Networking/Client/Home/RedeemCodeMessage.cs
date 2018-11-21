using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class RedeemCodeMessage : BaseMessage
    {
        public string RedeemCode;

        public RedeemCodeMessage(string redeemCode) : base(MessageType.RedeemCode)
        {
            RedeemCode = redeemCode;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(RedeemCode));
        }
    }
}
