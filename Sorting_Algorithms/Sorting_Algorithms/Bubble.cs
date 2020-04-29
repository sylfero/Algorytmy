namespace Sorting_Algorithms
{
    class Bubble : ISort
    {
        public string Name { get; } = "Bubble";

        public void Sort(int[] array)
        {
            bool swapped;
            for (int i = 0; i < array.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                        swapped = true;
                    }
                }

                if (swapped == false) break;
            }
        }
    }
}
