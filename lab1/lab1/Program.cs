using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {

        static string RPN(string word)
        {
            word += ' ';
            StringBuilder output = new StringBuilder();
            string[] characters = { "(", "+", "-", "*", "/", "^" };
            int[] weight = { 4, 1, 1, 2, 2, 3 };
            string tmp = "";
            Stack<string> stack = new Stack<string>();
            foreach (char i in word)
            {
                if (i != ' ')
                {
                    tmp += i;
                }
                else
                {
                    if (Int32.TryParse(tmp, out _))
                    {
                        output.Append(tmp + ' ');
                    }
                    else
                    {
                        if (stack.Count == 0 || stack.Peek().Equals("(") || tmp.Equals("("))
                        {
                            stack.Push(tmp);
                        }
                        else
                        {
                            if (tmp.Equals(")"))
                            {
                                while (!stack.Peek().Equals("("))
                                {
                                    output.Append(stack.Pop() + ' ');
                                }
                                stack.Pop();
                            }
                            else
                            {
                                if (weight[Array.IndexOf(characters, tmp)] > weight[Array.IndexOf(characters, stack.Peek())])
                                {
                                    stack.Push(tmp);
                                }
                                else
                                {
                                    while (stack.Count > 0 && weight[Array.IndexOf(characters, tmp)] <= weight[Array.IndexOf(characters, stack.Peek())] && !stack.Peek().Equals("("))
                                    {
                                        output.Append(stack.Pop() + ' ');
                                    }
                                    stack.Push(tmp);
                                }
                            }
                        }
                    }
                    tmp = "";
                }
            }
            while (stack.Count > 0)
            {
                output.Append(stack.Pop() + ' ');
            }
            output.Length--;
            return output.ToString();
        }
        static string rRPN(string word)
        {
            word += ' ';
            string tmp = "";
            string n0, n1;
            Stack<string> stack = new Stack<string>();
            foreach (char i in word)
            {
                if (i != ' ')
                {
                    tmp += i;
                }
                else
                {
                    if (Int32.TryParse(tmp, out _))
                    {
                        stack.Push(tmp);
                    }
                    else
                    {
                        n0 = stack.Pop();
                        n1 = stack.Pop();
                        tmp = "( " + n1 + ' ' + tmp + ' ' + n0 + " )";
                        stack.Push(tmp);
                    }
                    tmp = "";
                }
            }
            return stack.Pop().ToString();
        }

        static int max(int[] tab)
        {
            int max = tab[0];
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i] > max)
                {
                    max = tab[i];
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            List<string> ex = new List<string>();
            List<string> solved = new List<string>(); ;
            ex.Add("3 + 4 * 2 / ( 1 - 5 ) ^ 2");
            ex.Add("( ( 2 + 7 ) / 3 + ( 14 - 3 ) * 4 ) / 2");
            ex.Add("( 2 + 3 ) * 5");
            ex.Add("3 + 6 ^ 8 * 2 - 7");
            ex.Add("3 + 6 ^ ( 8 * 2 - 7 )");
            foreach (string i in ex)
            {
                solved.Add(RPN(i));
                Console.WriteLine(RPN(i));
            }
            Console.WriteLine("-----");
            foreach (string i in solved)
            {
                Console.WriteLine(rRPN(i));
            }
            int[] tab = { 1, 4, 6, -6, 12, 7, -4, 0 };
            Console.WriteLine(max(tab));
            Console.ReadKey();
        }
    }
}
