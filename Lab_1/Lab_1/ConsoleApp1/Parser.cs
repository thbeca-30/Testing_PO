using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Parser
    {
        public int howManyVowels(String word)
        {
            char[] split = word.ToCharArray();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int count = 0;
            foreach (char vowel in split)
            {
                if (vowels.Contains(vowel))
                    count++;
            }
            return count;
        }

        public int howManyСonsonants(String word)
        {
            char[] split = word.ToCharArray();
            char[] consonants = { 'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z',
                              'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'R', 'T', 'P', 'S', 'D', 'F',
                              'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M'};
            int count = 0;
            foreach (char consonant in split)
            {
                if (consonants.Contains(consonant))
                    count++;
            }
            return count;
        }

        public String toUp(String word) { return word.ToUpper(); }

        public String toLow(String word) { return word.ToLower(); }

        public String reverse(String word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }



    }
}
