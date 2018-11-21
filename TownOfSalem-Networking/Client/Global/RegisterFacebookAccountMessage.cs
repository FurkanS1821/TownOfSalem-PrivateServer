namespace TownOfSalem_Networking.Client.Global
{
    public class RegisterFacebookAccountMessage : RegisterAccountMessage
    {
        public RegisterFacebookAccountMessage(string username, string password, string email, string referFriendName,
            string facebookId, string facebookToken) : base(username, password, email, referFriendName)
        {
            _data.FacebookId = facebookId;
            _data.FacebookToken = facebookToken;
        }
    }
}
