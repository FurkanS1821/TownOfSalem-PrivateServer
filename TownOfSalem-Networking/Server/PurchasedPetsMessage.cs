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
            for (var i = 0; i < Pets.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Pets[i].ToString()));

                if (i < Pets.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
