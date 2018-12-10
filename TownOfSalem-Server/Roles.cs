using System.Collections.Generic;
using System.Linq;
using TownOfSalem_Logic.Enums;

namespace TownOfSalem_Logic
{
    public class Roles
    {
        public static readonly IEnumerable<Role> RandomTownList = new List<Role>
        {
            Role.Bodyguard, Role.Doctor, Role.Escort, Role.Investigator, Role.Jailor, Role.Lookout, Role.Mayor,
            Role.Medium, Role.Retributionist, Role.Sheriff, Role.Spy, Role.Transporter, Role.VampireHunter,
            Role.Veteran, Role.Vigilante
        };

        public static readonly IEnumerable<Role> CovenRandomTownList = RandomTownList.Concat(new List<Role>
        {
            Role.Crusader, Role.Tracker, Role.Trapper, Role.Psychic
        });

        public static readonly IEnumerable<Role> TownInvestigativeList = new List<Role>
        {
            Role.Investigator, Role.Sheriff, Role.Lookout, Role.Spy
        };

        public static readonly IEnumerable<Role> CovenTownInvestigativeList = new List<Role>
        {
            Role.Investigator, Role.Lookout, Role.Sheriff, Role.Spy, Role.Tracker, Role.Psychic
        };

        public static readonly IEnumerable<Role> TownProtectiveList = new List<Role>
        {
            Role.Bodyguard, Role.Doctor
        };

        public static readonly IEnumerable<Role> CovenTownProtectiveList = new List<Role>
        {
            Role.Bodyguard, Role.Doctor, Role.Crusader, Role.Trapper
        };

        public static readonly IEnumerable<Role> TownKillingList = new List<Role>
        {
            Role.Jailor, Role.VampireHunter, Role.Veteran, Role.Vigilante
        };

        public static readonly IEnumerable<Role> CovenTownKillingList = new List<Role>
        {
            Role.Jailor, Role.VampireHunter, Role.Veteran, Role.Vigilante
        };

        public static readonly IEnumerable<Role> TownSupportList = new List<Role>
        {
            Role.Escort, Role.Mayor, Role.Medium, Role.Retributionist, Role.Transporter
        };

        public static readonly IEnumerable<Role> CovenTownSupportList = new List<Role>
        {
            Role.Escort, Role.Mayor, Role.Medium, Role.Retributionist, Role.Transporter
        };

        public static readonly IEnumerable<Role> RandomMafiaList = new List<Role>
        {
            Role.Blackmailer, Role.Consigliere, Role.Consort, Role.Disguiser, Role.Forger, Role.Framer, Role.Godfather,
            Role.Janitor, Role.Mafioso
        };

        public static readonly IEnumerable<Role> CovenRandomMafiaList = new List<Role>
        {
            Role.Blackmailer, Role.Consigliere, Role.Consort, Role.Disguiser, Role.Forger, Role.Framer, Role.Godfather,
            Role.Janitor, Role.Mafioso, Role.Hypnotist, Role.Ambusher
        };

        public static readonly IEnumerable<Role> MafiaSupportList = new List<Role>
        {
            Role.Blackmailer, Role.Consigliere, Role.Consort
        };

        public static readonly IEnumerable<Role> CovenMafiaSupportList = new List<Role>
        {
            Role.Blackmailer, Role.Consigliere, Role.Consort
        };

        public static readonly IEnumerable<Role> MafiaDeceptionList = new List<Role>
        {
            Role.Disguiser, Role.Forger, Role.Framer, Role.Janitor
        };

        public static readonly IEnumerable<Role> CovenMafiaDeceptionList = new List<Role>
        {
            Role.Disguiser, Role.Forger, Role.Framer, Role.Janitor, Role.Hypnotist
        };

        public static readonly IEnumerable<Role> RandomNeutralList = new List<Role>
        {
            Role.Amnesiac, Role.Arsonist, Role.Executioner, Role.Jester, Role.SerialKiller, Role.Survivor, Role.Vampire,
            Role.Werewolf, Role.Witch
        };

        public static readonly IEnumerable<Role> CovenRandomNeutralList = new List<Role>
        {
            Role.Amnesiac, Role.Arsonist, Role.Executioner, Role.Jester, Role.SerialKiller, Role.Survivor, Role.Vampire,
            Role.Werewolf, Role.GuardianAngel
        };

        public static readonly IEnumerable<Role> NeutralBenignList = new List<Role>
        {
            Role.Amnesiac, Role.Survivor
        };

        public static readonly IEnumerable<Role> CovenNeutralBenignList = new List<Role>
        {
            Role.Amnesiac, Role.Survivor, Role.GuardianAngel
        };

        public static readonly IEnumerable<Role> NeutralEvilList = new List<Role>
        {
            Role.Executioner, Role.Jester, Role.Witch
        };

        public static readonly IEnumerable<Role> CovenNeutralEvilList = new List<Role>
        {
            Role.Executioner, Role.Jester
        };

        public static readonly IEnumerable<Role> NeutralKillingList = new List<Role>
        {
            Role.Arsonist, Role.SerialKiller, Role.Werewolf
        };

        public static readonly IEnumerable<Role> CovenNeutralKillingList = new List<Role>
        {
            Role.Arsonist, Role.SerialKiller, Role.Werewolf
        };

        public static readonly IEnumerable<Role> NeutralChaosList = new List<Role>
        {
            Role.Vampire
        };

        public static readonly IEnumerable<Role> CovenNeutralChaosList = new List<Role>
        {
            Role.Vampire, Role.Plaguebearer, Role.Pirate
        };

        public static readonly IEnumerable<Role> CovenRandomCovenList = new List<Role>
        {
            Role.CovenLeader, Role.PotionMaster, Role.HexMaster, Role.Necromancer, Role.Poisoner, Role.Medusa
        };

        public static readonly IEnumerable<Role> HiddenRoleWheelList = new List<Role>
        {
            Role.Juggernaut
        };

        public static readonly IEnumerable<Role> ClassicRoles = new List<Role>
        {
            Role.Bodyguard, Role.Doctor, Role.Escort, Role.Investigator, Role.Jailor, Role.Lookout, Role.Mayor,
            Role.Medium, Role.Retributionist, Role.Sheriff, Role.Spy, Role.Transporter, Role.VampireHunter,
            Role.Veteran, Role.Vigilante, Role.Blackmailer, Role.Consigliere, Role.Consort, Role.Disguiser, Role.Forger,
            Role.Framer, Role.Godfather, Role.Janitor, Role.Mafioso, Role.Amnesiac, Role.Arsonist, Role.Executioner,
            Role.Jester, Role.SerialKiller, Role.Survivor, Role.Vampire, Role.Werewolf, Role.Witch
        };

        public static readonly IEnumerable<Role> CovenRoles = new List<Role>
        {
            Role.Crusader, Role.Tracker, Role.Trapper, Role.Psychic, Role.Hypnotist, Role.Ambusher, Role.Plaguebearer,
            Role.Juggernaut, Role.GuardianAngel, Role.Pirate, Role.CovenLeader, Role.PotionMaster, Role.HexMaster,
            Role.Necromancer, Role.Poisoner, Role.Medusa
        };

        public static readonly IEnumerable<Role> UniqueTownRoles = new List<Role>
        {
            Role.Jailor, Role.Mayor, Role.Retributionist, Role.Veteran
        };

        public static readonly IEnumerable<Role> RolesSafeForCovenTeammatesList = new List<Role>
        {
            Role.Bodyguard, Role.Doctor, Role.Framer, Role.Janitor, Role.Crusader, Role.Ambusher, Role.GuardianAngel
        };

        public static readonly IEnumerable<Role> RolesExcludedFromZombieingList = new List<Role>
        {
            Role.Amnesiac, Role.Cleaned, Role.CovenLeader, Role.Executioner, Role.Jailor, Role.Jester, Role.Mayor,
            Role.Medium, Role.Medusa, Role.Necromancer, Role.Pirate, Role.PotionMaster, Role.Psychic,
            Role.Retributionist, Role.Spy, Role.Stoned, Role.Survivor, Role.Transporter, Role.Trapper, Role.Veteran,
            Role.Witch
        };

        public static bool RoleUsesDeathNote(Role role)
        {
            return role == Role.Godfather || role == Role.Mafioso || role == Role.Ambusher ||
                   role == Role.SerialKiller || role == Role.Arsonist || role == Role.Werewolf ||
                   role == Role.Pestilence || role == Role.Juggernaut || role == Role.Pirate || role == Role.Poisoner ||
                   role == Role.Medusa || role == Role.PotionMaster || role == Role.Jailor;
        }
    }
}