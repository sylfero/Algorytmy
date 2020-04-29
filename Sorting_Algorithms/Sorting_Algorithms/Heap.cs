namespace Sorting_Algorithms
{
    class Heap : ISort
    {
        public string Name { get; } = "Heap";

        public void Sort(int[] array)
        {
            for (int i = (array.Length / 2) - 1; i >= 0; i--)
                Heapify(array, array.Length, i);

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int tmp = array[0];
                array[0] = array[i];
                array[i] = tmp;
                Heapify(array, i, 0);
            }
        }

        private void Heapify(int[] array, int length, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < length && array[left] > array[largest]) largest = left;

            if (right < length && array[right] > array[largest]) largest = right;

            if (largest != i)
            {
                int tmp = array[i];
                array[i] = array[largest];
                array[largest] = tmp;
                Heapify(array, length, largest);
            }
        }
    }
}
