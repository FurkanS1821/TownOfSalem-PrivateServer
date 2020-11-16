using System.Collections.Generic;
using System.Linq;
using TownOfSalem_Logic.Enums;

namespace TownOfSalem_Logic
{
    public class Roles
    {
        public static readonly IEnumerable<Role> TownAnyList =
            TownInvestigativeList.Concat(TownKillingList).Concat(TownProtectiveList).Concat(TownSupportList);

        public static readonly IEnumerable<Role> CovenTownAnyList =
            CovenTownInvestigativeList.Concat(CovenTownKillingList).Concat(CovenTownProtectiveList).Concat(CovenTownSupportList);

        public static readonly IEnumerable<Role> TownInvestigativeList = new List<Role>
        {
            Role.Investigator, Role.Lookout, Role.Sheriff, Role.Spy
        };

        public static readonly IEnumerable<Role> CovenTownInvestigativeList = TownInvestigativeList.Concat(new List<Role>
        {
            Role.Psychic, Role.Tracker
        });

        public static readonly IEnumerable<Role> TownKillingList = new List<Role>
        {
            Role.Jailor, Role.VampireHunter, Role.Veteran, Role.Vigilante
        };

        public static readonly IEnumerable<Role> CovenTownKillingList = TownKillingList.Concat(new List<Role>
        {

        });

        public static readonly IEnumerable<Role> TownProtectiveList = new List<Role>
        {
            Role.Bodyguard, Role.Doctor
        };

        public static readonly IEnumerable<Role> CovenTownProtectiveList = TownProtectiveList.Concat(new List<Role>
        {
            Role.Crusader, Role.Trapper
        });

        public static readonly IEnumerable<Role> TownSupportList = new List<Role>
        {
            Role.Escort, Role.Mayor, Role.Medium, Role.Retributionist, Role.Transporter
        };

        public static readonly IEnumerable<Role> CovenTownSupportList = TownSupportList.Concat(new List<Role>
        {

        });

        public static readonly IEnumerable<Role> MafiaAnyList =
            MafiaDeceptionList.Concat(MafiaKillingList).Concat(MafiaSupportList);

        public static readonly IEnumerable<Role> CovenMafiaAnyList =
            CovenMafiaDeceptionList.Concat(CovenMafiaKillingList).Concat(CovenMafiaSupportList);

        public static readonly IEnumerable<Role> MafiaDeceptionList = new List<Role>
        {
            Role.Disguiser, Role.Forger, Role.Framer, Role.Hypnotist, Role.Janitor
        };

        public static readonly IEnumerable<Role> CovenMafiaDeceptionList = MafiaDeceptionList.Concat(new List<Role>
        {
            
        });

        public static readonly IEnumerable<Role> MafiaKillingList = new List<Role>
        {
            Role.Ambusher, Role.Godfather, Role.Mafioso
        };

        public static readonly IEnumerable<Role> CovenMafiaKillingList = MafiaKillingList.Concat(new List<Role>
        {

        });

        public static readonly IEnumerable<Role> MafiaSupportList = new List<Role>
        {
            Role.Blackmailer, Role.Consigliere, Role.Consort
        };

        public static readonly IEnumerable<Role> CovenMafiaSupportList = MafiaSupportList.Concat(new List<Role>
        {
            
        });

        public static readonly IEnumerable<Role> NeutralAnyList =
            NeutralBenignList.Concat(NeutralChaosList).Concat(NeutralEvilList).Concat(NeutralKillingList);

        public static readonly IEnumerable<Role> CovenNeutralAnyList =
            CovenNeutralBenignList.Concat(CovenNeutralChaosList).Concat(CovenNeutralEvilList).Concat(CovenNeutralKillingList);

        public static readonly IEnumerable<Role> NeutralBenignList = new List<Role>
        {
            Role.Amnesiac, Role.Survivor
        };

        public static readonly IEnumerable<Role> CovenNeutralBenignList = NeutralBenignList.Concat(new List<Role>
        {
            Role.GuardianAngel
        });

        public static readonly IEnumerable<Role> NeutralChaosList = new List<Role>
        {
            Role.Vampire
        };

        public static readonly IEnumerable<Role> CovenNeutralChaosList = NeutralChaosList.Concat(new List<Role>
        {
            Role.Pirate, Role.Plaguebearer, Role.Pestilence
        });

        public static readonly IEnumerable<Role> NeutralEvilList = new List<Role>
        {
            Role.Executioner, Role.Jester, Role.Witch
        };

        public static readonly IEnumerable<Role> CovenNeutralEvilList = NeutralEvilList.Concat(new List<Role>
        {
            
        });

        public static readonly IEnumerable<Role> NeutralKillingList = new List<Role>
        {
            Role.Arsonist, Role.SerialKiller, Role.Werewolf
        };

        public static readonly IEnumerable<Role> CovenNeutralKillingList = NeutralKillingList.Concat(new List<Role>
        {
            Role.Juggernaut
        });

        public static readonly IEnumerable<Role> CovenEvilList = new List<Role>
        {
            Role.CovenLeader, Role.HexMaster, Role.Medusa, Role.Necromancer, Role.Poisoner, Role.PotionMaster
        };

        public static readonly IEnumerable<Role> AnyList =
            TownAnyList.Concat(MafiaAnyList).Concat(NeutralAnyList);

        public static readonly IEnumerable<Role> CovenAnyList =
            CovenTownAnyList.Concat(CovenMafiaAnyList).Concat(CovenEvilList).Concat(CovenNeutralAnyList);

        public static readonly IEnumerable<Role> UniqueTownRoles = new List<Role>
        {
            Role.Jailor, Role.Mayor, Role.Retributionist, Role.Veteran
        };

        public static readonly IEnumerable<Role> RolesExcludedFromZombieingList = new List<Role>
        {
            Role.Amnesiac, Role.Cleaned, Role.CovenLeader, Role.Executioner, Role.Jailor, Role.Jester, Role.Mayor,
            Role.Medium, Role.Medusa, Role.Necromancer, Role.Pirate, Role.PotionMaster, Role.Psychic,
            Role.Retributionist, Role.Spy, Role.Stoned, Role.Survivor, Role.Transporter, Role.Trapper, Role.Veteran,
            Role.Witch
        };

        private static List<Role> RolesUsingDeathNote = new List<Role>
        {
            Role.Godfather, Role.Mafioso, Role.Ambusher, Role.SerialKiller, Role.Arsonist, Role.Werewolf,
            Role.Pestilence, Role.Juggernaut, Role.Pirate, Role.Poisoner, Role.Medusa, Role.PotionMaster, Role.Jailor
        };

        static Roles()
        {
            var temp = CovenNeutralEvilList.ToList();
            temp.Remove(Role.Witch);
            CovenNeutralEvilList = temp;
        }

        public static bool RoleUsesDeathNote(Role role)
        {
            return RolesUsingDeathNote.Contains(role);
        }
    }
}