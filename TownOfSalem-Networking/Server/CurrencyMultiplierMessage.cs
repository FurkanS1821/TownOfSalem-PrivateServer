using System.IO;

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
            writer.Write((byte)1);
            writer.Write((byte)TownPoints);
            writer.Write('*');
            writer.Write((byte)3);
            writer.Write((byte)MeritPoints);
        }
    }
}
