﻿namespace TownOfSalem_Networking.Client
{
    public enum MessageType : byte
    {
        FBLogin = 0x1,
        RequestLoadHomepage,
        ChatMessage,
        CatalogList,
        PossibleRoles,
        AddRole,
        RemoveRole,
        PrivateMessage,
        LobbyStartGame,
        VoteTarget,
        NightTarget,
        NightTargetSecond,
        VoteGuilty = 0xE,
        VoteInnocent,
        DayTarget,
        SendLastWill,
        SendDeathNote,
        MafiaTarget,
        SendCustomizationSettings,
        RequestName,
        SendReport,
        Repick,
        SystemCommand,
        FriendAdd,
        FriendConfirm,
        FriendRemove,
        FriendDecline,
        FriendMessage,
        JoinGame,
        PartyCreate,
        PartyInvite,
        PartyResponse,
        PartyLeave,
        PartyStart,
        PartyMessage,
        SendAccountSetting,
        AwayFromKeyboard,
        ReturnHome,
        RedeemCode = 0x2D,
        FBAchievementShare,
        FBWinShare,
        PartyChangeHost = 0x34,
        PartyKick,
        PartyGiveInvitePrivileges,
        SteamOrder,
        SteamApprove,
        SteamCreateAccount,
        FBCreateAccount,
        SteamLinkAccount,
        SteamHomeLinkAccount = 0x3B,
        RequestRankedGame,
        RankedQueueLeave,
        RankedQueueAccept,
        LeaveGame,
        SendForgedWill,
        RequestPlayerStatistics,
        PurchasePromotion = 0x43,
        PayPalSale,
        TutorialProgress,
        CheckUsername = 0x48,
        NameChange,
        PurchaseProduct,
        RequestCauldronStatus,
        CauldronComplete,
        TauntTarget,
        PirateDuelSelection,
        PotionChosen,
        HostSetPartyConfig,
        VerifyAccountFlag,
        HypnotistChoice,
        JailorDeathNote,
        RegisterAccount,
        Login,
        CaptchaAnswer = 0x57,
        RequestReferralCodes,
        SendReferralCode,
        Ping = 0x7F
    }
}