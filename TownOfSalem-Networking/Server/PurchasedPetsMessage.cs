using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedPetsMessage : BaseMessage
    {
        public int[] Pets;

        public PurchasedPetsMessage(int[] pets) : base(MessageType.PurchasedPets)
        {
            Pets = pets;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Pets.Length; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Pets[i].ToString()));

                if (i < Pets.Length - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
