using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class CovenGotNecronomiconMessage : BaseMessage
    {
        public readonly bool IsFirstPossession;
        public readonly int LostPosition;
        public readonly int GainedPosition;

        public CovenGotNecronomiconMessage(bool isFirstPossession, int lostPosition, int gainedPosition)
            : base(MessageType.CovenGotNecronomicon)
        {
            IsFirstPossession = isFirstPossession;
            LostPosition = lostPosition;
            GainedPosition = gainedPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(IsFirstPossession ? 1 : 2);

            if (IsFirstPossession)
            {
                writer.Write((byte)(GainedPosition + 1));
            }
            else
            {
                writer.Write((byte)(LostPosition + 1));
                writer.Write((byte)(GainedPosition + 1));
            }
        }
    }
}
