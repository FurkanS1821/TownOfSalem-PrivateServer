using System.IO;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class AccountFlagsMessage : BaseMessage
    {
        public UserAccountFlags Flags = new UserAccountFlags();

        public AccountFlagsMessage(UserAccountFlags flags) : base(MessageType.AccountFlags)
        {
            Flags = flags;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            byte flag = 0;
            if (Flags.OwnsSteam)
            {
                flag |= 1;
            }

            if (Flags.OwnsCoven)
            {
                flag |= 2;
            }

            if (Flags.OwnsWebPremium)
            {
                flag |= 4;
            }

            if (Flags.OwnsMobilePremium)
            {
                flag |= 8;
            }

            if (Flags.IsRestricted)
            {
                flag |= 16;
            }

            writer.Write((byte)(flag + 1));
        }
    }
}
