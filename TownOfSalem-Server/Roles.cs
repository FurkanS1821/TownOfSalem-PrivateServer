using System;

namespace TownOfSalem_Logic
{
    [Flags]
    public enum Roles : ulong
    {
        // TOWN
        // - TOWN INVESTIGATIVE
        Investigator    = 0x1,
        Lookout         = 0x2,
        Psychic         = 0x4 | IsCovenDlcOnly,
        Sheriff         = 0x8,
        Spy             = 0x10,
        Tracker         = 0x20 | IsCovenDlcOnly,
        // - TOWN KILLING
        Jailor          = 0x40 | IsUniqueRole,
        VampireHunter   = 0x80,
        Veteran         = 0x100 | IsUniqueRole,
        Vigilante       = 0x200,
        // - TOWN PROTECTIVE
        Bodyguard       = 0x400,
        Doctor          = 0x800,
        Crusader        = 0x1000 | IsCovenDlcOnly,
        Trapper         = 0x2000 | IsCovenDlcOnly,
        // - TOWN SUPPORT
        Escort          = 0x4000,
        Mayor           = 0x8000 | IsUniqueRole,
        Medium          = 0x10000,
        Retributionist  = 0x20000 | IsUniqueRole,
        Transporter     = 0x40000,

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
        Disguiser       = 0x80000,
        Forger          = 0x100000,
        Framer          = 0x200000,
        Hypnotist       = 0x400000 | IsCovenDlcOnly,
        Janitor         = 0x800000,
        // - MAFIA KILLING
        Ambusher        = 0x1000000 | IsCovenDlcOnly | IsUniqueRole,
        Godfather       = 0x2000000 | IsUniqueRole,
        Mafioso         = 0x4000000 | IsUniqueRole,
        // - MAFIA SUPPORT
        Blackmailer     = 0x8000000,
        Consigliere     = 0x10000000,
        Consort         = 0x20000000,

        MafiaDeception = Disguiser | Forger | Framer | Janitor,
        MafiaDeceptionCoven = MafiaDeception | Hypnotist,
        MafiaKilling = Godfather | Mafioso,
        MafiaKillingCoven = MafiaKilling | Ambusher,
        MafiaSupport = Blackmailer | Consigliere | Consort,

        RandomMafia = MafiaDeception | MafiaKilling | MafiaSupport,
        RandomMafiaCoven = MafiaDeceptionCoven | MafiaKillingCoven | MafiaSupport,

        // NEUTRAL
        // - NEUTRAL BENIGN
        Amnesiac        = 0x40000000,
        GuardianAngel   = 0x80000000 | IsCovenDlcOnly,
        Survivor        = 0x100000000,
        // - NEUTRAL CHAOS
        Pirate          = 0x200000000 | IsCovenDlcOnly | IsUniqueRole,
        Plaguebearer    = 0x400000000 | IsCovenDlcOnly | IsUniqueRole,
        Pestilence      = 0x800000000 | IsCovenDlcOnly | IsUniqueRole,
        Vampire         = 0x1000000000,
        // - NEUTRAL EVIL
        Executioner     = 0x2000000000,
        Jester          = 0x4000000000,
        Witch           = 0x8000000000,
        // - NEUTRAL KILLING
        Arsonist        = 0x10000000000,
        Juggernaut      = 0x20000000000 | IsCovenDlcOnly | IsUniqueRole,
        SerialKiller    = 0x40000000000,
        Werewolf        = 0x80000000000 | IsUniqueRole,

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
        CovenLeader     = 0x100000000000 | IsCovenDlcOnly | IsUniqueRole,
        HexMaster       = 0x200000000000 | IsCovenDlcOnly | IsUniqueRole,
        Medusa          = 0x400000000000 | IsCovenDlcOnly | IsUniqueRole,
        Necromancer     = 0x800000000000 | IsCovenDlcOnly | IsUniqueRole,
        Poisoner        = 0x1000000000000 | IsCovenDlcOnly | IsUniqueRole,
        PotionMaster    = 0x2000000000000 | IsCovenDlcOnly | IsUniqueRole,

        CovenEvil = CovenLeader | HexMaster | Medusa | Necromancer | Poisoner | PotionMaster,

        RandomCoven = CovenEvil,

        AllRandom = RandomTown | RandomMafia | RandomNeutral,
        AllRandomCoven = RandomTownCoven | RandomMafiaCoven | RandomNeutralCoven | RandomCoven,

        IsUniqueRole    = 0x4000000000000000,
        IsCovenDlcOnly  = 0x8000000000000000
    }

    [Flags]
    public enum Faction : uint
    {
        TownInvestigative = 0b1,
        TownKilling       = 0b10,
        TownProtective    = 0b100,
        TownSupport       = 0b1000,
        Town,
        MafiaDeception    = 0b10000,
        MafiaKilling      = 0b100000,
        MafiaSupport      = 0b1000000,
        Mafia,
        NeutralBenign     = 0b10000000,
        NeutralChaos      = 0b100000000,
        NeutralEvil       = 0b1000000000,
        NeutralKilling    = 0b10000000000,
        Neutral,
        CovenEvil         = 0b100000000000,
        Coven
    }
}
