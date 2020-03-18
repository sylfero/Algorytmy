using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class myPriorityQueue<T>
    {
        private int Size;
        private Element[] Queue;

        public myPriorityQueue()
        {
            Queue = new Element[0];
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

        public void Enqueue(T toQueue, int priority = 0)
        {
            int index = Size - 1; 
            while (index >= 0)
            {
                if (Queue[index].Priority >= priority)
                {
                    break;
                }
                else
                {
                    index--;
                }
            }
            Size++;
            Array.Resize(ref Queue, Size);
            for (int i = Size - 1; i > index + 1; i--)
            {
                Queue[i] = Queue[i - 1];
            }
            Queue[index + 1] = new Element(priority, toQueue);
        }

        public T Peek()
        {
            if (!isEmpty())
            {
                return Queue[0].Value;
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
                T tmp = Queue[0].Value;
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
                foreach (Element i in Queue)
                {
                    Console.WriteLine(i.Value);
                }
            }
        }

        private class Element
        {
            public int Priority;
            public T Value;

            public Element(int priority, T value)
            {
                Priority = priority;
                Value = value;
            }
        }
    }
}
