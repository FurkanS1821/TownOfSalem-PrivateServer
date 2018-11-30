using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class HousesChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> Houses;

        public HousesChosenMessage(Dictionary<int, int> houses) : base(MessageType.HousesChosen)
        {
            Houses = houses;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var house in Houses)
            {
                writer.Write((byte)(house.Key + 1));
                writer.Write((byte)(house.Value + 1));
            }
        }
    }
}
