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
            for (var i = 0; i < Items.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Items[i].ToString()));

                if (i < Items.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
