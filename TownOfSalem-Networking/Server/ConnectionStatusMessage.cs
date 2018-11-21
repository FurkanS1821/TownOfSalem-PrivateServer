using System;

namespace TownOfSalem_Networking.Server
{
    public class ConnectionStatusMessage : BaseMessage
    {
        public readonly int Status;
        public readonly int SuspensionTime;

        public ConnectionStatusMessage(byte[] data) : base(data)
        {
            try
            {
                Status = Convert.ToInt32(data[1]) - 1;
                if (Status != 7)
                {
                    return;
                }

                var s = BytesToString(data, 2);
                if (string.IsNullOrEmpty(s) || int.TryParse(s, out SuspensionTime))
                {
                    return;
                }

                SuspensionTime = 0;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
