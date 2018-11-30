using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class SomeoneHasWonMessage : BaseMessage
    {
        public readonly List<int> WinningPositions = new List<int>();
        public readonly int WinningFaction;

        public SomeoneHasWonMessage(List<int> winningPositions, int winningFaction) : base(MessageType.SomeoneHasWon)
        {
            WinningPositions = winningPositions;
            WinningFaction = winningFaction;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)WinningFaction);
            foreach (var position in WinningPositions)
            {
                writer.Write((byte)(position + 1));
            }
        }
    }
}
