using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class UpdateMeritPointsMessage : BaseMessage
    {
        public readonly int MeritPoints;

        public UpdateMeritPointsMessage(int meritPoints) : base(MessageType.UpdateMeritPoints)
        {
            MeritPoints = meritPoints;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(MeritPoints.ToString()));
        }
    }
}
