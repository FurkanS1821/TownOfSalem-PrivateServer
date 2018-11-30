using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class HasNecronomiconMessage : BaseMessage
    {
        public readonly bool HasNecronomicon;
        public readonly int NightsUntilNecronomicon;

        public HasNecronomiconMessage(bool hasNecronomicon, int nightsUntilNecronomicon)
            : base(MessageType.HasNecronomicon)
        {
            HasNecronomicon = hasNecronomicon;
            NightsUntilNecronomicon = nightsUntilNecronomicon;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(HasNecronomicon ? 1 : 2));
            writer.Write((byte)NightsUntilNecronomicon);
        }
    }
}
