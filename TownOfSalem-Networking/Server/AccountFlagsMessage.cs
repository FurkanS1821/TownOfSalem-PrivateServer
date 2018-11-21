using System;

namespace TownOfSalem_Networking.Server
{
    public class AccountFlagsMessage : BaseMessage
    {
        public UserAccountFlags Flags = new UserAccountFlags();

        public AccountFlagsMessage(byte[] data) : base(data)
        {
            try
            {
                var num = Convert.ToInt32(data[1]) - 1;
                Flags.OwnsSteam = (num & 1) > 0;
                Flags.OwnsCoven = (num & 2) > 0;
                Flags.OwnsWebPremium = (num & 4) > 0;
                Flags.OwnsMobilePremium = (num & 8) > 0;
                Flags.IsRestricted = (num & 16) > 0;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
