using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class mySentinel<T>
    {
        private Element Sentinel;
        private Element Last;

        public mySentinel()
        {
            Sentinel = new Element(default);
            Sentinel.Previous = Sentinel;
            Sentinel.Next = Sentinel;
            Last = Sentinel;
        }

        public int GetSize()
        {
            if (Last != Sentinel)
            {
                Element tmp = Sentinel.Next;
                int size = 1;
                while (tmp.Next != Sentinel)
                {
                    size++;
                    tmp = tmp.Next;
                }
                return size;
            }
            else
            {
                return 0;
            }
        }

        public void Add(T toAdd)
        {
            if (Last == Sentinel)
            {
                Last = new Element(toAdd);
                Sentinel.Next = Sentinel.Previous = Last;
                Last.Next = Last.Previous = Sentinel;
            }
            else
            {
                Element tmp = new Element(toAdd);
                Last.Next = tmp;
                tmp.Previous = Last;
                tmp.Next = Sentinel;
                Last = tmp;
                Sentinel.Previous = Last;
            }
        }

        public void Insert(T Value, int Id)
        {
            if (Id < 0 || Id > GetSize())
            {
                throw new Exception("Id spoza zakresu!");
            }
            else
            {
                if (Last == Sentinel)
                {
                    Add(Value);
                }
                else if (Id == 0)
                {
                    Element tmp = Sentinel.Next;
                    Sentinel.Next = new Element(Value);
                    Sentinel.Next.Next = tmp;
                    Sentinel.Next.Previous = Sentinel;
                }
                else
                {
                    Element tmp = Sentinel.Next;
                    int count = 0;
                    while (count != Id - 1)
                    {
                        count++;
                        tmp = tmp.Next;
                    }
                    Element tmp2 = tmp.Next;
                    tmp.Next = new Element(Value);
                    tmp2.Previous = tmp.Next;
                    tmp.Next.Next = tmp2;
                    tmp.Next.Previous = tmp;
                }
            }
        }

        public void RemoveAt(int Id)
        {
            if (Last != Sentinel && Id < GetSize() && Id >= 0)
            {
                if (Id == 0)
                {
                    Sentinel.Next = Sentinel.Next.Next;
                    Sentinel.Next.Previous = Sentinel;
                }
                else if (Id == GetSize() - 1)
                {
                    Last.Previous.Next = Sentinel;
                }
                else
                {
                    Element tmp = Sentinel.Next;
                    int count = 0;
                    while (count != Id - 1)
                    {
                        count++;
                        tmp = tmp.Next;
                    }
                    tmp.Next = tmp.Next.Next;
                    tmp.Next.Previous = tmp;
                }
            }
            else if (GetSize() == 0)
            {
                throw new Exception("Lista jest pusta");
            }
            else
            {
                throw new Exception("Id spoza zakresu!");
            }
        }

        public T this[int i]
        {
            get
            {
                if (Last != Sentinel && i < GetSize() && i >= 0)
                {
                    int count = 0;
                    Element tmp = Sentinel.Next;
                    while (count != i)
                    {
                        count++;
                        tmp = tmp.Next;
                    }
                    return tmp.Value;
                }
                else if (GetSize() == 0)
                {
                    throw new Exception("Lista jest pusta");
                }
                else
                {
                    throw new Exception("Id spoza zakresu!");
                }
            }
            set
            {
                if (i < 0 || i > GetSize())
                {
                    throw new Exception("Id spoza zakresu!");
                }
                else
                {
                    int count = 0;
                    Element tmp = Sentinel.Next;
                    while (count != i)
                    {
                        count++;
                        tmp = tmp.Next;
                    }
                    tmp.Value = value;
                }
            }
        }

        public int? IndexOf(T value)
        {
            Sentinel.Value = value;
            Element tmp = Sentinel.Next;
            int index = 0;
            while(!tmp.Value.Equals(value))
            {
                tmp = tmp.Next;
                index++;
            }
            if (tmp != Sentinel)
            {
                Sentinel.Value = default;
                return index;
            }
            else 
            {
                Sentinel.Value = default;
                return null;
            }
        }

        public void Print()
        {
            Element tmp = Sentinel.Next;
            while (tmp != Last)
            {
                Console.WriteLine(tmp.Value);
                tmp = tmp.Next;
            }
            if (Last != Sentinel)
            {
                Console.WriteLine(Last.Value);
            }
        }

        private class Element
        {
            public T Value;
            public Element Next;
            public Element Previous;

            public Element(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }
    }
}
