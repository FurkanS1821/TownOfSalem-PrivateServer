using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendSpecialAbilityMessage : BaseMessage
    {
        public bool Enabled;

        public SendSpecialAbilityMessage(byte[] data) : base(data)
        {
            try
            {
                Enabled = GetBoolValue(data[1]);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}