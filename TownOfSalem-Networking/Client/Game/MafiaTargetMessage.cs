using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class MafiaTargetMessage : BaseMessage
    {
        public int TargetPosition;
        public int LastServerRequest;

        public MafiaTargetMessage(byte[] data) : base(data)
        {
            try
            {
                TargetPosition = data[1] - 1;
                LastServerRequest = data[2];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
