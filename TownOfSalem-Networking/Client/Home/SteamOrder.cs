using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class SteamOrder : BaseMessage
    {
        public int ProductId;
        public string SteamId;

        public SteamOrder(int productId, string steamId) : base(MessageType.SteamOrder)
        {
            ProductId = productId;
            SteamId = steamId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)ProductId);
            writer.Write(Encoding.UTF8.GetBytes(SteamId));
        }
    }
}
