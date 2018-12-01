using System;

namespace TownOfSalem_Logic
{
    [Flags]
    public enum Roles : ulong
    {
        // TOWN
        // - TOWN INVESTIGATIVE
        Investigator    = 0x1u,
        Lookout         = 0x2u,
        Psychic         = 0x4u | IsCovenDlcOnly,
        Sheriff         = 0x8u,
        Spy             = 0x10u,
        Tracker         = 0x20u | IsCovenDlcOnly,
        // - TOWN KILLING
        Jailor          = 0x40u | IsUniqueRole,
        VampireHunter   = 0x80u,
        Veteran         = 0x100u | IsUniqueRole,
        Vigilante       = 0x200u,
        // - TOWN PROTECTIVE
        Bodyguard       = 0x400u,
        Doctor          = 0x800u,
        Crusader        = 0x1000u | IsCovenDlcOnly,
        Trapper         = 0x2000u | IsCovenDlcOnly,
        // - TOWN SUPPORT
        Escort          = 0x4000u,
        Mayor           = 0x8000u | IsUniqueRole,
        Medium          = 0x10000u,
        Retributionist  = 0x20000u | IsUniqueRole,
        Transporter     = 0x40000u,

        TownInvestigative = Investigator | Lookout | Sheriff | Spy,
        TownInvestigativeCoven = TownInvestigative | Psychic | Tracker,
        TownKilling = Jailor | VampireHunter | Veteran | Vigilante,
        TownProtective = Bodyguard | Doctor,
        TownProtectiveCoven = TownProtective | Crusader | Trapper,
        TownSupport = Escort | Mayor | Medium | Retributionist | Transporter,

        RandomTown = TownInvestigative | TownKilling | TownProtective | TownSupport,
        RandomTownCoven = TownInvestigativeCoven | TownKilling | TownProtectiveCoven | TownSupport,

        // MAFIA
        // - MAFIA DECEPTION
        Disguiser       = 0x80000u,
        Forger          = 0x100000u,
        Framer          = 0x200000u,
        Hypnotist       = 0x400000u | IsCovenDlcOnly,
        Janitor         = 0x800000u,
        // - MAFIA KILLING
        Ambusher        = 0x1000000u | IsCovenDlcOnly | IsUniqueRole,
        Godfather       = 0x2000000u | IsUniqueRole,
        Mafioso         = 0x4000000u | IsUniqueRole,
        // - MAFIA SUPPORT
        Blackmailer     = 0x8000000u,
        Consigliere     = 0x10000000u,
        Consort         = 0x20000000u,

        MafiaDeception = Disguiser | Forger | Framer | Janitor,
        MafiaDeceptionCoven = MafiaDeception | Hypnotist,
        MafiaKilling = Godfather | Mafioso,
        MafiaKillingCoven = MafiaKilling | Ambusher,
        MafiaSupport = Blackmailer | Consigliere | Consort,

        RandomMafia = MafiaDeception | MafiaKilling | MafiaSupport,
        RandomMafiaCoven = MafiaDeceptionCoven | MafiaKillingCoven | MafiaSupport,

        // NEUTRAL
        // - NEUTRAL BENIGN
        Amnesiac        = 0x40000000u,
        GuardianAngel   = 0x80000000u | IsCovenDlcOnly,
        Survivor        = 0x100000000u,
        // - NEUTRAL CHAOS
        Pirate          = 0x200000000u | IsCovenDlcOnly | IsUniqueRole,
        Plaguebearer    = 0x400000000u | IsCovenDlcOnly | IsUniqueRole,
        Pestilence      = 0x800000000u | IsCovenDlcOnly | IsUniqueRole,
        Vampire         = 0x1000000000u,
        // - NEUTRAL EVIL
        Executioner     = 0x2000000000u,
        Jester          = 0x4000000000u,
        Witch           = 0x8000000000u,
        // - NEUTRAL KILLING
        Arsonist        = 0x10000000000u,
        Juggernaut      = 0x20000000000u | IsCovenDlcOnly | IsUniqueRole,
        SerialKiller    = 0x40000000000u,
        Werewolf        = 0x80000000000u | IsUniqueRole,

        NeutralBenign = Amnesiac | Survivor,
        NeutralBenignCoven = NeutralBenign | GuardianAngel,
        NeutralChaos = Vampire,
        NeutralChaosCoven = NeutralChaos | Pirate | Plaguebearer | Pestilence,
        NeutralEvil = Executioner | Jester | Witch,
        NeutralKilling = Arsonist | SerialKiller | Werewolf,
        NeutralKillingCoven = NeutralKilling | Juggernaut,

        RandomNeutral = NeutralBenign | NeutralChaos | NeutralEvil | NeutralKilling,
        RandomNeutralCoven = NeutralBenignCoven | NeutralChaosCoven | NeutralEvil | NeutralKillingCoven,

        // COVEN
        // - COVEN EVIL
        CovenLeader     = 0x100000000000u | IsCovenDlcOnly | IsUniqueRole,
        HexMaster       = 0x200000000000u | IsCovenDlcOnly | IsUniqueRole,
        Medusa          = 0x400000000000u | IsCovenDlcOnly | IsUniqueRole,
        Necromancer     = 0x800000000000u | IsCovenDlcOnly | IsUniqueRole,
        Poisoner        = 0x1000000000000u | IsCovenDlcOnly | IsUniqueRole,
        PotionMaster    = 0x2000000000000u | IsCovenDlcOnly | IsUniqueRole,

        CovenEvil = CovenLeader | HexMaster | Medusa | Necromancer | Poisoner | PotionMaster,

        RandomCoven = CovenEvil,

        AllRandom = RandomTown | RandomMafia | RandomNeutral,
        AllRandomCoven = RandomTownCoven | RandomMafiaCoven | RandomNeutralCoven | RandomCoven,

        IsUniqueRole    = 0x4000000000000000u,
        IsCovenDlcOnly  = 0x8000000000000000u
    }

    [Flags]
    public enum Faction : uint
    {
        TownInvestigative = 0x1u,
        TownKilling       = 0x2u,
        TownProtective    = 0x4u,
        TownSupport       = 0x8u,
        Town = TownInvestigative | TownKilling | TownProtective | TownSupport,
        MafiaDeception    = 0x10u,
        MafiaKilling      = 0x20u,
        MafiaSupport      = 0x40u,
        Mafia = MafiaDeception | MafiaKilling | MafiaSupport,
        NeutralBenign     = 0x80u,
        NeutralChaos      = 0x100u,
        NeutralEvil       = 0x200u,
        NeutralKilling    = 0x400u,
        Neutral = NeutralBenign | NeutralChaos | NeutralEvil | NeutralKilling,
        CovenEvil         = 0x800u,
        Coven = CovenEvil
    }
}
