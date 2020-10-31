using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class AccountItemConsumedMessage : BaseMessage
    {
        public readonly int AccountItemId;
        public readonly int QuantityConsumed;
        public readonly int QuantityRemaining;

        public AccountItemConsumedMessage(int accountItemId, int quantityConsumed, int quantityRemaining)
            : base(MessageType.AccountItemConsumed)
        {
            AccountItemId = accountItemId;
            QuantityConsumed = quantityConsumed;
            QuantityRemaining = quantityRemaining;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var packet = $"{AccountItemId},{QuantityConsumed},{QuantityRemaining}";
            writer.Write(Encoding.UTF8.GetBytes(packet));
        }
    }
}