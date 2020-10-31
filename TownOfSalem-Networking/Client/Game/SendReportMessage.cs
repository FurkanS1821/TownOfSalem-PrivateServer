using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendReportMessage : BaseMessage
    {
        public int Position;
        public int Reason;
        public string Description;

        public SendReportMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                Reason = data[2] - 2;
                Description = BytesToString(data, 3);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}