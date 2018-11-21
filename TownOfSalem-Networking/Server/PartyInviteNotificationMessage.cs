


using System;

namespace TownOfSalem_Networking.Server
{
    public class PartyInviteNotificationMessage : BaseMessage
    {
        public readonly PartyInvite PartyInvite;

        public PartyInviteNotificationMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                PartyInvite = new PartyInvite();
                if (strArray.Length <= 1)
                {
                    return;
                }

                int.TryParse(strArray[0], out PartyInvite.PartyId);
                PartyInvite.HostUsername = strArray[1];
                PartyInvite.IsValid = true;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
