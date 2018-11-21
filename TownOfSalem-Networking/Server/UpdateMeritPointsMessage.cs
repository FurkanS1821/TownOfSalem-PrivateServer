using System;

namespace TownOfSalem_Networking.Server
{
    public class UpdateMeritPointsMessage : BaseMessage
    {
        public readonly int MeritPoints;

        public UpdateMeritPointsMessage(byte[] data) : base(data)
        {
            try
            {
                MeritPoints = int.Parse(BytesToString(data, 1));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
