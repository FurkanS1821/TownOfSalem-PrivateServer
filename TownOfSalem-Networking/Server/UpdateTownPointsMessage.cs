using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class UpdateTownPointsMessage : BaseMessage
    {
        public readonly int TownPoints;

        public UpdateTownPointsMessage(int townPoints) : base(MessageType.UpdateTownPoints)
        {
            TownPoints = townPoints;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(TownPoints.ToString()));
        }
    }
}
