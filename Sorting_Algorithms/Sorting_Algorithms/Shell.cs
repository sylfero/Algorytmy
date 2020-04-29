namespace Sorting_Algorithms
{
    class Shell : ISort
    {
        public string Name { get; } = "Shell";

        public void Sort(int[] array)
        {
            for (int gap = array.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    int tmp = array[i];

                    int j;
                    for (j = i; j >= gap && array[j - gap] > tmp; j -= gap)
                        array[j] = array[j - gap];

                    array[j] = tmp;
                }
            }
        }
    }
}
