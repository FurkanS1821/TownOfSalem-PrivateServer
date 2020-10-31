using System;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class ConnectionStatusMessage : BaseMessage
    {
        public readonly int Status;
        public readonly int SuspensionTime;
        public readonly int Reason;
        public readonly string DirectMessage;

        public ConnectionStatusMessage(int status, int suspensionTime, int reason, string directMessage)
            : base(MessageType.ConnectionStatus)
        {
            Status = status;
            SuspensionTime = suspensionTime;
            Reason = reason;
            DirectMessage = directMessage;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            // {Header} {Status:0x63} {DirectMessage}
            // {Header} {Status:0x07} {Reason} {SuspensionTime}
            // {Header} {Status} {Reason}
            // {Header} {Status}
            writer.Write((byte)(Status + 1));

            if (Status == 99)
            {
                writer.Write(Encoding.UTF8.GetBytes(DirectMessage));
            }
            else
            {
                if (Reason != -1)
                {
                    writer.Write((byte)(Reason + 1));
                }

                if (Status != 7)
                {
                    return;
                }

                if (Reason == -1)
                {
                    throw new ArgumentException();
                }

                if (SuspensionTime != 0)
                {
                    writer.Write(Encoding.UTF8.GetBytes(SuspensionTime.ToString()));
                }
            }
        }
    }
}