using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class MafiosoPromotedTellMafiaMessage : BaseMessage
    {
        public readonly int Position;

        public MafiosoPromotedTellMafiaMessage(int position) : base(MessageType.MafiosoPromotedTellMafia)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}