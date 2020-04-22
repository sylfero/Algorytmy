using System;

namespace Text_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //kmp
            string text = "ABC ABCDAB ABCDABCDABDE";
            string pattern = "ABCDABD";
            Console.WriteLine("Pattern at index: " + KMP_Algorithm.Search(pattern, text));
            Console.WriteLine(new string('-', 10));
            //boyer moore
            Console.WriteLine("Pattern at index: " + BoyerMoore_Algorithm.Search(pattern, text));
            Console.WriteLine(new string('-', 10));
            //karp rabin
            Console.WriteLine("Pattern at index: " + KarpRabin_Algorithm.Search(pattern, text));
            Console.ReadLine();
        }
    }
}
