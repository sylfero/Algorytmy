using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int[] small = new int[1000];
            int[] big = new int[100000];

            for (int i = 0; i < 1000; i++)
            {
                small[i] = rnd.Next(-10000000, 10000000);
            }

            for (int i = 0; i < 100000; i++)
            {
                big[i] = rnd.Next(-10000000, 10000000);
            }

            List<ISort> sorts = new List<ISort>();
            sorts.Add(new Bubble());
            sorts.Add(new Quick());
            sorts.Add(new Heap());
            sorts.Add(new Shell());
            sorts.Add(new Counting());
            sorts.Add(new Merge());

            List<(string, TimeSpan)> smallTime = new List<(string, TimeSpan)>();
            List<(string, TimeSpan)> bigTime = new List<(string, TimeSpan)>();

            foreach (ISort sort in sorts)
            {
                int[] clone = (int[])small.Clone();
                Stopwatch watch = Stopwatch.StartNew();
                sort.Sort(clone);
                watch.Stop();
                smallTime.Add((sort.Name, watch.Elapsed));

                clone = (int[])big.Clone();
                watch.Start();
                sort.Sort(clone);
                watch.Stop();
                bigTime.Add((sort.Name, watch.Elapsed));

                Console.WriteLine($"{sort.Name} done!");
            }

            smallTime.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            bigTime.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            Console.WriteLine("\nResults for small set:");
            smallTime.ForEach(x => Console.WriteLine((x.Item1 + ':').PadRight(10) + x.Item2.TotalMilliseconds + " ms"));

            Console.WriteLine("\nResults for big set:");
            bigTime.ForEach(x => Console.WriteLine((x.Item1 + ':').PadRight(10) + x.Item2.TotalMilliseconds + " ms"));

            Console.ReadKey();
        }
    }
}
