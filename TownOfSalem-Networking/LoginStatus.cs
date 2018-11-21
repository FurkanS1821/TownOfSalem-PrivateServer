namespace TownOfSalem_Networking
{
    public enum LoginStatus
    {
        Success,
        Authenticating,
        GenericFailure,
        InvalidClientVersion,
        InvalidPlatform,
        InvalidUsernamePassword,
        InvalidFacebookId,
        InvalidSteamId,
    }
}
