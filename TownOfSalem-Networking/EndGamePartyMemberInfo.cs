using System.Collections.Generic;

namespace TownOfSalem_Networking
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
