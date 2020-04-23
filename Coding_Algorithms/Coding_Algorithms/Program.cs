using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //caesar
            string text = "Mój stary to fanatyk wędkarstwa.";
            string encode = Caesar.Encode(text, 2);
            string decode = Caesar.Decode(encode, 2);
            Console.WriteLine("Encode: " + encode + "\nDecode: " + decode);
            Console.WriteLine(new string('-', 10));
            //huffman
            Huffman h = new Huffman();
            encode = h.Encode(text);
            decode = h.Decode(encode);
            Console.WriteLine("Encode: " + encode + "\nDecode: " + decode);
            Console.WriteLine(new string('-', 10));
            //shannon fano
            Shannon_Fano s = new Shannon_Fano();
            encode = s.Encode(text);
            decode = s.Decode(encode);
            Console.WriteLine("Encode: " + encode + "\nDecode: " + decode);
            Console.ReadKey();
        }
    }
}
