using System.Linq;

namespace Sorting_Algorithms
{
    class Counting : ISort
    {
        public string Name { get; } = "Counting";

        public void Sort(int[] array)
        {
            int min = array.Min();
            int max = array.Max();

            int[] count = new int[max - min + 1];

            for (int i = 0; i < array.Length; i++)
            {
                count[array[i] - min]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            int[] clone = (int[])array.Clone();
            for (int i = array.Length - 1; i >=0; i--)
            {
                array[--count[clone[i] - min]] = clone[i];

            }
        }
    }
}
