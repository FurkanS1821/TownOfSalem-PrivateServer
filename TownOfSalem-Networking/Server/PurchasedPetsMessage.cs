using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedPetsMessage : BaseMessage
    {
        public List<int> Pets;

        public PurchasedPetsMessage(List<int> pets) : base(MessageType.PurchasedPets)
        {
            Pets = pets;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Pets)));
        }
    }
}