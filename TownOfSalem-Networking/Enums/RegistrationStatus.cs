namespace TownOfSalem_Networking.Enums
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
        Failed,
        RegistrationDisabled,
        UsernameTaken,
        SteamHasLinkedAccount,
        LinkedAccountBanned,
        InvalidUsernameAlphanumericsOnly,
        InvalidUsernameNotJustNumbers,
        InvalidUsernameBannedWords
    }
}