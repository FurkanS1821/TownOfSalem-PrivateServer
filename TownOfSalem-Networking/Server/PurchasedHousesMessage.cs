using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedHousesMessage : BaseMessage
    {
        public List<int> Houses;

        public PurchasedHousesMessage(List<int> houses) : base(MessageType.PurchasedHouses)
        {
            Houses = houses;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Houses)));
        }
    }
}