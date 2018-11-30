using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class JuggernautKillsMessage : BaseMessage
    {
        public readonly int Kills;

        public JuggernautKillsMessage(int kills) : base(MessageType.JuggernautKills)
        {
            Kills = kills;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Kills + 1));
        }
    }
}
