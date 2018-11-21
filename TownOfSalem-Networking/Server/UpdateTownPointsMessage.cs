using System;

namespace TownOfSalem_Networking.Server
{
    public class UpdateTownPointsMessage : BaseMessage
    {
        public readonly int TownPoints;

        public UpdateTownPointsMessage(byte[] data) : base(data)
        {
            try
            {
                int.TryParse(BytesToString(data, 1), out TownPoints);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
