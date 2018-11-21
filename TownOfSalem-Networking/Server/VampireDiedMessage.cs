using System;

namespace TownOfSalem_Networking.Server
{
    public class VampireDiedMessage : BaseMessage
    {
        public readonly int DeadPosition;
        public readonly int? YoungestPosition;

        public VampireDiedMessage(byte[] data) : base(data)
        {
            try
            {
                DeadPosition = data[1] - 1;
                if (data.Length < 3)
                {
                    return;
                }

                YoungestPosition = data[2] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
