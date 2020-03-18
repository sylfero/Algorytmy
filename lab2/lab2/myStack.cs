using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class myStack<T>
    {
        private T[] Stack;
        private int Size;

        public myStack()
        {
            Size = 0;
            Stack = new T[0];
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

        public void Push(T toPush)
        {
            Size++;
            Array.Resize(ref Stack, Size);
            Stack[Size - 1] = toPush;
        }

        public T Peek()
        {
            if (!isEmpty())
            {
                return Stack[Size - 1];
            }
            else
            {
                throw new Exception("Stos jest pusty!");
            }
        }

        public T Pop()
        {
            if (!isEmpty())
            {
                T tmp = Stack[Size - 1];
                Size--;
                Array.Resize(ref Stack, Size);
                return tmp;
            }
            else
            {
                throw new Exception("Stos jest pusty!");
            }
        }

        public void Print()
        {
            if (!isEmpty())
            {
                for (int i = Size - 1; i >= 0; i--)
                {
                    Console.WriteLine(Stack[i]);
                }
            }
        }
    }
}
