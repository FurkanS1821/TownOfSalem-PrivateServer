namespace TownOfSalem_Networking.Structs
{
    public class FriendRequest
    {
        public string UserName;
        public int AccountId;

        public FriendRequest(string username, int accountId)
        {
            UserName = username;
            AccountId = accountId;
        }
    }
}
