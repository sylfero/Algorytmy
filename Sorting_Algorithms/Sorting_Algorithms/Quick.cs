namespace Sorting_Algorithms
{
    class Quick : ISort
    {
        public string Name { get; } = "Quick";

        public void Sort(int[] array) => Sort(array, 0, array.Length - 1);

        private void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);

                Sort(array, left, pivot - 1);
                Sort(array, pivot + 1, right);
            }
        }

        private int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                }
            }

            int tmp1 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = tmp1;
            return i + 1;
        }
    }
}
