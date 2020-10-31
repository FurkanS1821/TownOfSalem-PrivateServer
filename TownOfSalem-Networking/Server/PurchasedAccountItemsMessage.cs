using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedAccountItemsMessage : BaseMessage
    {
        public List<int> Items;

        public PurchasedAccountItemsMessage(List<int> items) : base(MessageType.PurchasedAccountItems)
        {
            Items = items;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Items)));
        }
    }
}