using System.Collections.Generic;
using TownOfSalem_Logic.Enums;

namespace TownOfSalem_Logic.Constants
{
    public static class ConstantRoleLists
    {
        public static readonly List<Role> ClassicMode = new List<Role>
        {
            Role.Sheriff,
            Role.Doctor,
            Role.Investigator,
            Role.Jailor,
            Role.Medium,
            Role.Godfather,
            Role.Framer,
            Role.Executioner,
            Role.Escort,
            Role.Mafioso,
            Role.Lookout,
            Role.SerialKiller,
            Role.TownKilling,
            Role.Jester,
            Role.RandomTown
        };

        public static readonly List<Role> Ranked = new List<Role>
        {
            Role.Jailor,
            Role.TownInvestigative,
            Role.TownInvestigative,
            Role.TownProtective,
            Role.TownKilling,
            Role.TownSupport,
            Role.RandomTown,
            Role.RandomTown,
            Role.RandomTown,
            Role.Godfather,
            Role.Mafioso,
            Role.RandomMafia,
            Role.RandomMafia,
            Role.NeutralEvil,
            Role.NeutralKilling
        };

        public static readonly List<Role> AllAny = new List<Role>();
        public static readonly List<Role> CovenAllAny = new List<Role>();

        public static readonly List<Role> Rainbow = new List<Role>
        {
            Role.Godfather,
            Role.Arsonist,
            Role.Survivor,
            Role.Jailor,
            Role.Amnesiac,
            Role.SerialKiller,
            Role.Witch,
            Role.Any,
            Role.Witch,
            Role.SerialKiller,
            Role.Amnesiac,
            Role.Veteran,
            Role.Survivor,
            Role.Arsonist,
            Role.Mafioso
        };

        public static readonly List<Role> DraculasPalace = new List<Role>
        {
            Role.Doctor,
            Role.Lookout,
            Role.Lookout,
            Role.Jailor,
            Role.Vigilante,
            Role.TownProtective,
            Role.TownSupport,
            Role.TownSupport,
            Role.VampireHunter,
            Role.Jester,
            Role.Witch,
            Role.Vampire,
            Role.Vampire,
            Role.Vampire,
            Role.Vampire
        };

        public static readonly List<Role> CovenClassic = new List<Role>
        {
            Role.Sheriff,
            Role.Lookout,
            Role.Psychic,
            Role.Jailor,
            Role.CovenTownProtective,
            Role.CovenLeader,
            Role.PotionMaster,
            Role.Executioner,
            Role.CovenRandomCoven,
            Role.Medusa,
            Role.CovenRandomTown,
            Role.Plaguebearer,
            Role.CovenRandomTown,
            Role.Pirate,
            Role.CovenRandomTown
        };

        public static readonly List<Role> CovenRanked = new List<Role>
        {
            Role.Jailor,
            Role.CovenTownInvestigative,
            Role.CovenTownInvestigative,
            Role.TownSupport,
            Role.CovenTownProtective,
            Role.TownKilling,
            Role.CovenRandomTown,
            Role.CovenRandomTown,
            Role.CovenRandomTown,
            Role.CovenLeader,
            Role.Medusa,
            Role.CovenRandomCoven,
            Role.CovenRandomCoven,
            Role.CovenNeutralKilling,
            Role.NeutralEvil
        };

        public static readonly List<Role> CovenMafiaReturns = new List<Role>
        {
            Role.Sheriff,
            Role.Lookout,
            Role.Psychic,
            Role.Jailor,
            Role.CovenTownProtective,
            Role.Godfather,
            Role.Ambusher,
            Role.CovenRandomMafia,
            Role.Hypnotist,
            Role.Executioner,
            Role.Plaguebearer,
            Role.Pirate,
            Role.CovenRandomTown,
            Role.CovenRandomTown,
            Role.CovenRandomTown
        };

        public static readonly List<Role> CovenVIP = new List<Role>
        {
            Role.Sheriff,
            Role.Crusader,
            Role.Psychic,
            Role.Vigilante,
            Role.Trapper,
            Role.CovenLeader,
            Role.PotionMaster,
            Role.GuardianAngel,
            Role.CovenRandomCoven,
            Role.Medusa,
            Role.Tracker,
            Role.CovenTownProtective,
            Role.TownSupport,
            Role.Pirate,
            Role.CovenTownProtective
        };

        public static readonly List<Role> CovenLovers = new List<Role>
        {
            Role.Sheriff,
            Role.Doctor,
            Role.Psychic,
            Role.Tracker,
            Role.CovenTownProtective,
            Role.CovenTownProtective,
            Role.TownSupport,
            Role.TownSupport,
            Role.Pirate,
            Role.Arsonist,
            Role.Werewolf,
            Role.SerialKiller,
            Role.Godfather,
            Role.Medusa,
            Role.Plaguebearer
        };

        static ConstantRoleLists()
        {
            for (var i = 0; i < 15; i++)
            {
                AllAny.Add(Role.Any);
                CovenAllAny.Add(Role.Any);
            }
        }
    }
}
