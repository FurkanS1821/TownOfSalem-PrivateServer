using System;

namespace TownOfSalem_Networking.Server
{
    public class DisguiserStoleYourIdentityMessage : BaseMessage
    {
        public readonly int Position;

        public DisguiserStoleYourIdentityMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
