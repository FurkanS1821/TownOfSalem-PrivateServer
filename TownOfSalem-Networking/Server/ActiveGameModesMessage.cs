using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class ActiveGameModesMessage : BaseMessage
    {
        public int[] ActiveModes;

        public ActiveGameModesMessage(int[] activeModes) : base(MessageType.ActiveGameModes)
        {
            ActiveModes = activeModes;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var num in ActiveModes)
            {
                writer.Write((byte)num);
            }
        }
    }
}
