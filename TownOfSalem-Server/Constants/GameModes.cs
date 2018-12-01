using System.Collections.Generic;

namespace TownOfSalem_Logic.Constants
{
    public static class GameModes
    {
        public static List<Roles> ClassicMode = new List<Roles>
        {
            Roles.Sheriff,
            Roles.Doctor,
            Roles.Investigator,
            Roles.Jailor,
            Roles.Medium,
            Roles.Godfather,
            Roles.Framer,
            Roles.Executioner,
            Roles.Escort,
            Roles.Mafioso,
            Roles.Lookout,
            Roles.SerialKiller,
            Roles.TownKilling,
            Roles.Jester,
            Roles.RandomTown
        };

        public static List<Roles> Ranked = new List<Roles>
        {
            Roles.Jailor,
            Roles.TownInvestigative,
            Roles.TownInvestigative,
            Roles.TownProtective,
            Roles.TownKilling,
            Roles.TownSupport,
            Roles.RandomTown,
            Roles.RandomTown,
            Roles.RandomTown,
            Roles.Godfather,
            Roles.Mafioso,
            Roles.RandomMafia,
            Roles.RandomMafia,
            Roles.NeutralEvil,
            Roles.NeutralKilling
        };

        public static List<Roles> AllAny = new List<Roles>();

        public static List<Roles> Rainbow = new List<Roles>
        {
            Roles.Godfather,
            Roles.Arsonist,
            Roles.Survivor,
            Roles.Jailor,
            Roles.Amnesiac,
            Roles.SerialKiller,
            Roles.Witch,
            Roles.AllRandom,
            Roles.Witch,
            Roles.SerialKiller,
            Roles.Amnesiac,
            Roles.Veteran,
            Roles.Survivor,
            Roles.Arsonist,
            Roles.Mafioso
        };

        public static List<Roles> DraculasPalace = new List<Roles>
        {
            Roles.Doctor,
            Roles.Lookout,
            Roles.Lookout,
            Roles.Jailor,
            Roles.Vigilante,
            Roles.TownProtective,
            Roles.TownSupport,
            Roles.TownSupport,
            Roles.VampireHunter,
            Roles.Jester,
            Roles.Witch,
            Roles.Vampire,
            Roles.Vampire,
            Roles.Vampire,
            Roles.Vampire
        };

        public static List<Roles> CovenClassic = new List<Roles>
        {
            Roles.Sheriff,
            Roles.Lookout,
            Roles.Psychic,
            Roles.Jailor,
            Roles.TownProtectiveCoven,
            Roles.CovenLeader,
            Roles.PotionMaster,
            Roles.Executioner,
            Roles.RandomCoven,
            Roles.Medusa,
            Roles.RandomTownCoven,
            Roles.Plaguebearer,
            Roles.RandomTownCoven,
            Roles.Pirate,
            Roles.RandomTownCoven
        };

        public static List<Roles> CovenRanked = new List<Roles>
        {
            Roles.Jailor,
            Roles.TownInvestigativeCoven,
            Roles.TownInvestigativeCoven,
            Roles.TownSupport,
            Roles.TownProtectiveCoven,
            Roles.TownKilling,
            Roles.RandomTownCoven,
            Roles.RandomTownCoven,
            Roles.RandomTownCoven,
            Roles.CovenLeader,
            Roles.Medusa,
            Roles.RandomCoven,
            Roles.RandomCoven,
            Roles.NeutralKillingCoven,
            Roles.NeutralEvil
        };

        public static List<Roles> CovenMafiaReturns = new List<Roles>
        {
            Roles.Sheriff,
            Roles.Lookout,
            Roles.Psychic,
            Roles.Jailor,
            Roles.TownProtectiveCoven,
            Roles.Godfather,
            Roles.Ambusher,
            Roles.RandomMafiaCoven,
            Roles.Hypnotist,
            Roles.Executioner,
            Roles.Plaguebearer,
            Roles.Pirate,
            Roles.RandomTownCoven,
            Roles.RandomTownCoven,
            Roles.RandomTownCoven
        };

        public static List<Roles> CovenVIP = new List<Roles>
        {
            Roles.Sheriff,
            Roles.Crusader,
            Roles.Psychic,
            Roles.Vigilante,
            Roles.Trapper,
            Roles.CovenLeader,
            Roles.PotionMaster,
            Roles.GuardianAngel,
            Roles.RandomCoven,
            Roles.Medusa,
            Roles.Tracker,
            Roles.TownProtectiveCoven,
            Roles.TownSupport,
            Roles.Pirate,
            Roles.TownProtectiveCoven
        };

        public static List<Roles> CovenLovers = new List<Roles>
        {
            Roles.Sheriff,
            Roles.Doctor,
            Roles.Psychic,
            Roles.Tracker,
            Roles.TownProtectiveCoven,
            Roles.TownProtectiveCoven,
            Roles.TownSupport,
            Roles.TownSupport,
            Roles.Pirate,
            Roles.Arsonist,
            Roles.Werewolf,
            Roles.SerialKiller,
            Roles.Godfather,
            Roles.Medusa,
            Roles.Plaguebearer
        };

        static GameModes()
        {
            for (var i = 0; i < 15; i++)
            {
                AllAny.Add(Roles.AllRandom);
            }
        }
    }
}
