using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class PurchaseProductMessage : BaseMessage
    {
        public string ProductId;
        public int Quantity;

        public PurchaseProductMessage(string productId, int quantity) : base(MessageType.PurchaseProduct)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(ProductId));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Quantity.ToString()));
        }
    }
}
