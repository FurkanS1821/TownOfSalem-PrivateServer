using System;
using System.Collections.Generic;
using System.Linq;
using TownOfSalem_Logic.Enums;

namespace TownOfSalem_Logic
{
    public static class Utility
    {
        private static Random _random = new Random();
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
            return list[_random.Next(0, list.Length)].Item2;
        }
    }
}
