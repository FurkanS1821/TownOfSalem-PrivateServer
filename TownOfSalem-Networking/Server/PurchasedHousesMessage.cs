using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedHousesMessage : BaseMessage
    {
        public List<int> Houses = new List<int>();

        public PurchasedHousesMessage(List<int> houses) : base(MessageType.PurchasedHouses)
        {
            Houses = houses;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Houses.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Houses[i].ToString()));

                if (i < Houses.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
