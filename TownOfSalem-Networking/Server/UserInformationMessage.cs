using System;

namespace TownOfSalem_Networking.Server
{
    public class UserInformationMessage : BaseMessage
    {
        public readonly string Username;
        public readonly int TownPoints;
        public readonly int MeritPoints;

        public UserInformationMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                Username = strArray[0];
                TownPoints = int.Parse(strArray[1]);
                MeritPoints = int.Parse(strArray[2]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
