using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendForgedWillMessage : BaseMessage
    {
        public int RoleId;
        public string Will;

        public SendForgedWillMessage(byte[] data) : base(data)
        {
            try
            {
                RoleId = data[1] + 1;
                if (data.Length < 3)
                {
                    return;
                }

                Will = BytesToString(data, 2);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}