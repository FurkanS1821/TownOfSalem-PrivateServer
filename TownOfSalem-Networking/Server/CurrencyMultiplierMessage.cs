using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class CurrencyMultiplierMessage : BaseMessage
    {
        public readonly float TownPoints;
        public readonly float MeritPoints;

        public CurrencyMultiplierMessage(float townPoints, float meritPoints) : base(MessageType.CurrencyMultiplier)
        {
            TownPoints = townPoints;
            MeritPoints = meritPoints;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var town = (int)TownPoints;
            var merit = (int)MeritPoints;
            var packet = new List<string>();
            if (town > 0 && town < 10)
            {
                packet.Add($"1{town}");
            }

            if (merit > 0 && merit < 10)
            {
                packet.Add($"3{merit}");
            }

            writer.Write(Encoding.UTF8.GetBytes(string.Join("*", packet)));
        }
    }
}