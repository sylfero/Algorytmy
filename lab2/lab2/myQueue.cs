using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class myQueue<T>
    {
        private int Size;
        private T[] Queue;

        public myQueue()
        {
            Queue = new T[0];
            Size = 0;
        }

        private bool isEmpty()
        {
            if (Size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Enqueue(T toQueue)
        {
            Size++;
            Array.Resize(ref Queue, Size);
            Queue[Size - 1] = toQueue;
        }

        public T Peek()
        {
            if (!isEmpty())
            {
                return Queue[0];
            }
            else
            {
                throw new Exception("Kolejka jest pusta!");
            }
        }

        public T Dequeue()
        {
            if (!isEmpty())
            {
                T tmp = Queue[0];
                for (int i = 0; i < Size - 1; i++)
                {
                    Queue[i] = Queue[i + 1];
                }
                Size--;
                Array.Resize(ref Queue, Size);
                return tmp;
            }
            else
            {
                throw new Exception("Kolejka jest pusta!");
            }
        }

        public void Print()
        {
            if (!isEmpty())
            {
                foreach (T i in Queue)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
