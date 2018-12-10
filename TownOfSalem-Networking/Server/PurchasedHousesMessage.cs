using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedHousesMessage : BaseMessage
    {
        public int[] Houses;

        public PurchasedHousesMessage(int[] houses) : base(MessageType.PurchasedHouses)
        {
            Houses = houses;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Houses.Length; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Houses[i].ToString()));

                if (i < Houses.Length - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
