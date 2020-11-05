using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Structs
{
    public class Friend
    {
        public string UserName;
        public int AccountId;
        public ActivityStatus Status;
        public bool OwnsCoven;

        public Friend(string userName, int accountId, ActivityStatus status, bool ownsCoven)
        {
            UserName = userName;
            AccountId = accountId;
            Status = status;
            OwnsCoven = ownsCoven;
        }
    }
}
