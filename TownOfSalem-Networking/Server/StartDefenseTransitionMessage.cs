using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class StartDefenseTransitionMessage : BaseMessage
    {
        public readonly int Position;

        public StartDefenseTransitionMessage(int position) : base(MessageType.StartDefenseTransition)
        {
            Position = position;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
        }
    }
}