using System;

namespace TownOfSalem_Networking.Server
{
    public class CovenGotNecronomiconMessage : BaseMessage
    {
        public readonly bool IsFirstPossession;
        public readonly int LostPosition;
        public readonly int GainedPosition;

        public CovenGotNecronomiconMessage(byte[] data) : base(data)
        {
            try
            {
                IsFirstPossession = data[1] == 1;
                if (IsFirstPossession)
                {
                    GainedPosition = data[2] - 1;
                }
                else
                {
                    LostPosition = data[2] - 1;
                    GainedPosition = data[3] - 1;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
