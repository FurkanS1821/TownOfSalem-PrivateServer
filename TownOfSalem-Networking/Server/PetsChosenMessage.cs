using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class PetsChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> Pets;

        public PetsChosenMessage(Dictionary<int, int> pets) : base(MessageType.PetsChosen)
        {
            Pets = pets;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var pet in Pets)
            {
                writer.Write((byte)(pet.Key + 1));
                writer.Write((byte)(pet.Value + 1));
            }
        }
    }
}