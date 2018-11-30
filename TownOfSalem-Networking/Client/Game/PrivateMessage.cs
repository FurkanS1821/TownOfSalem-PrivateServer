using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class PrivateMessage : BaseMessage
    {
        public int ToPosition;
        public string Message;

        public PrivateMessage(byte[] data) : base(data)
        {
            try
            {
                ToPosition = data[1] - 1;
                Message = BytesToString(data, 2);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
