using System;
using System.Linq;

namespace Text_Algorithms
{
    static class BoyerMoore_Algorithm
    {

        public static int Search(string pattern, string text)
        {
            int[] badChar = BadChar(pattern);
            int i = 0;

            while (i <= text.Length - pattern.Length)
            {
                int j = pattern.Length - 1;

                while (j >= 0 && pattern[j] == text[i + j])
                    j--;

                if (j < 0)
                    return i;
                else
                    i += Math.Max(1, j - badChar[text[i + j]]);
            }
            return -1;
        }

        private static int[] BadChar(string pattern)
        {
            int[] output = Enumerable.Repeat(-1, 256).ToArray();

            for (int i = 0; i < pattern.Length; i++)
                output[pattern[i]] = i;

            return output;
        }
    }
}
