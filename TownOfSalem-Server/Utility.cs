using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using TownOfSalem_Logic.Enums;

namespace TownOfSalem_Logic
{
    public static class Utility
    {
        public static Random Random = new Random();
        public static List<(Gender, string)> RandomNames = new List<(Gender gender, string name)>
        {
            (Gender.Male, "Cotton Mather"),
            (Gender.Male, "Deodat Lawson"),
            (Gender.Male, "Edward Bishop"),
            (Gender.Male, "Giles Corey"),
            (Gender.Male, "James Bayley"),
            (Gender.Male, "James Russel"),
            (Gender.Male, "John Hathorne"),
            (Gender.Male, "John Proctor"),
            (Gender.Male, "John Willard"),
            (Gender.Male, "Jonathan Corwin"),
            (Gender.Male, "Samuel Parris"),
            (Gender.Male, "Samuel Sewall"),
            (Gender.Male, "Thomas Danforth"),
            (Gender.Male, "William Hobbs"),
            (Gender.Male, "William Phips"),
            (Gender.Female, "Abigail Hobbs"),
            (Gender.Female, "Alice Parker"),
            (Gender.Female, "Alice Young"),
            (Gender.Female, "Ann Hibbins"),
            (Gender.Female, "Ann Putnam"),
            (Gender.Female, "Ann Sears"),
            (Gender.Female, "Betty Parris"),
            (Gender.Female, "Dorothy Good"),
            (Gender.Female, "Lydia Dustin"),
            (Gender.Female, "Martha Corey"),
            (Gender.Female, "Mary Eastey"),
            (Gender.Female, "Mary Johnson"),
            (Gender.Female, "Mary Warren"),
            (Gender.Female, "Sarah Bishop"),
            (Gender.Female, "Sarah Good"),
            (Gender.Female, "Sarah Wildes")
        };

        public static string GetRandomNameForGender(Gender gender)
        {
            var list = RandomNames.Where(x => x.Item1 == gender).ToArray();
            return list[Random.Next(0, list.Length)].Item2;
        }

        public static byte[] ByteStringToArray(string str)
        {
            return str.Split(' ').Select(x => byte.Parse(x, NumberStyles.HexNumber)).ToArray();
        }

        public static IEnumerable<Role> GetPossibleRolesForRoleId(Role role)
        {
            switch (role)
            {
                case Role.Any:
                case Role.CovenAny:
                case Role.TownAny:
                case Role.TownInvestigative:
                case Role.TownProtective:
                case Role.TownKilling:
                case Role.TownSupport:
                case Role.MafiaAny:
                case Role.MafiaSupport:
                case Role.MafiaDeception:
                case Role.NeutralAny:
                case Role.NeutralBenign:
                case Role.NeutralEvil:
                case Role.NeutralKilling:
                case Role.CovenEvil:
                case Role.CovenTownAny:
                case Role.CovenTownInvestigative:
                case Role.CovenTownProtective:
                case Role.CovenTownKilling:
                case Role.CovenTownSupport:
                case Role.CovenMafiaAny:
                case Role.CovenMafiaSupport:
                case Role.CovenMafiaDeception:
                case Role.CovenNeutralAny:
                case Role.CovenNeutralBenign:
                case Role.CovenNeutralEvil:
                case Role.CovenNeutralKilling:
                case Role.CovenNeutralChaos:
                    var field = typeof(Roles).GetField(role + "List", BindingFlags.Static | BindingFlags.Public);
                    return field?.GetValue(null) as IEnumerable<Role>;

                default:
                    return new[] {role};
            }
        }
    }
}
