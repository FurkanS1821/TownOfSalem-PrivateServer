using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class PartyCreateMessage : BaseMessage
    {
        public int GameBrand;

        public PartyCreateMessage(byte[] data) : base(data)
        {
            try
            {
                GameBrand = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
