using System.IO;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class AccountFlagsMessage : BaseMessage
    {
        public UserAccountFlags Flags;

        public AccountFlagsMessage(UserAccountFlags flags) : base(MessageType.AccountFlags)
        {
            Flags = flags;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            int flag = 0;
            flag |= Flags.OwnsSteam ? 1 << 0 : 0;
            flag |= Flags.OwnsCoven ? 1 << 1 : 0;
            flag |= Flags.OwnsWebPremium ? 1 << 2 : 0;
            flag |= Flags.OwnsMobilePremium ? 1 << 3 : 0;
            flag |= Flags.IsRestricted ? 1 << 4 : 0;
            flag |= Flags.IsTrial ? 1 << 5 : 0;

            writer.Write((byte)(flag + 1));
        }
    }
}