using System.Collections.Generic;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Structs
{
    public class EndGamePartyMemberInfo
    {
        public string OriginalName;
        public string AccountName;
        public int Position;
        public List<int> Roles;
        public EndGamePartyMemberStatus UserStatus;

        public EndGamePartyMemberInfo(string originalName, string accountName, int position, EndGamePartyMemberStatus status)
        {
            OriginalName = originalName;
            AccountName = accountName;
            Position = position;
            UserStatus = status;
            Roles = new List<int>();
        }

        public int FinalRoleId
        {
            get
            {
                if (Roles.Count > 0)
                {
                    return Roles[Roles.Count - 1];
                }
                return -1;
            }
        }
    }
}
