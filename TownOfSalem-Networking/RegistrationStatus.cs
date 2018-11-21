namespace TownOfSalem_Networking
{
    public enum RegistrationStatus
    {
        Success,
        InvalidUsername,
        InvalidPassword,
        FamilyShared,
        InvalidEmail,
        InvalidReferAFriend,
        InvalidFacebookId,
        InvalidSteamId,
        ValidatingFacebookId,
        ValidatingSteamId,
        Failed
    }
}