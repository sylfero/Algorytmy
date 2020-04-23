using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Algorithms
{
    static class Caesar
    {
        public static string Encode(string text, int shift)
        {
            StringBuilder output = new StringBuilder();

            foreach (char c in text)
            {
                output.Append((char)(c + shift));
            }

            return output.ToString();
        }

        public static string Decode(string text, int shift)
        {
            return Encode(text, -shift);
        }
    }
}
