using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class VampireDiedMessage : BaseMessage
    {
        public readonly int DeadPosition;
        public readonly int? YoungestPosition;

        public VampireDiedMessage(int deadPosition, int? youngestPosition) : base(MessageType.VampireDied)
        {
            DeadPosition = deadPosition;
            YoungestPosition = youngestPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(DeadPosition + 1));
            if (YoungestPosition.HasValue)
            {
                writer.Write((byte)(YoungestPosition.Value + 1));
            }
        }
    }
}