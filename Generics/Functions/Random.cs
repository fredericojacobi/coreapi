using System;
using System.Collections.Generic;

namespace Generic.Functions
{
    public abstract class Random
    {
        private static System.Random random = new();

        public static string Cnpj()
        {
            return
                $"{random.Next(9)}{random.Next(9)}.{random.Next(9)}{random.Next(9)}{random.Next(9)}.{random.Next(9)}{random.Next(9)}{random.Next(9)}/0001-{random.Next(9)}{random.Next(9)}";
        }

        public static string Name(int size)
        {
            var consonants = new List<string>
                {"b", "c", "d", "f", "g", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "t", "v", "x"};
            var vowels = new List<string> {"a", "e", "i", "o", "u"};
            var society = new List<string> {"Inc", "GmbH", "Ltda", "Corp"};
            var name = string.Empty;

            name += consonants[random.Next(consonants.Count)].ToUpper();
            name += vowels[random.Next(vowels.Count)];
            
            var b = 2;
            while (b < size)
            {
                var consonant = consonants[random.Next(consonants.Count)];
                name += consonant;
                b++;
                if (consonant.Equals("q"))
                {
                    name += $"u{vowels[random.Next(vowels.Count)]}";
                    b++;
                    continue;
                }
                name += vowels[random.Next(vowels.Count)];
                b++;
            }

            name += $" {society[random.Next(society.Count)]}";
            name += ".";

            return name;
        }
    }
}