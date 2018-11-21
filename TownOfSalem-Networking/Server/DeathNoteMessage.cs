using System;

namespace TownOfSalem_Networking.Server
{
    public class DeathNoteMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasLastWill;
        public readonly string DeathNote;

        public DeathNoteMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                HasLastWill = GetBoolValue(data[2]);
                if (data.Length < 4)
                {
                    return;
                }

                DeathNote = BytesToString(data, 3).Replace('\r', '\n');
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
