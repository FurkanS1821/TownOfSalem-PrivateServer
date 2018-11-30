using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class ConnectionStatusMessage : BaseMessage
    {
        public readonly int Status;
        public readonly int SuspensionTime;

        public ConnectionStatusMessage(int status, int suspensionTime) : base(MessageType.ConnectionStatus)
        {
            Status = status;
            SuspensionTime = suspensionTime;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Status + 1));

            if (Status == 7)
            {
                writer.Write(Encoding.UTF8.GetBytes(SuspensionTime.ToString()));
            }
        }
    }
}
