using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class myDList<T>
    {
        private Element First;
        private Element Last;

        public myDList()
        {
            First = null;
            Last = null;
        }

        public int GetSize()
        {
            if (First != null)
            {
                int size = 1;
                Element tmp = First;
                while (tmp.Next != null)
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
            if (First == null)
            {
                First = Last = new Element(toAdd);
            }
            else
            {
                Element tmp = new Element(toAdd);
                Last.Next = tmp;
                tmp.Previous = Last;
                Last = tmp;
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
                if (First == null)
                {
                    Add(Value);
                }
                else if (Id == 0)
                {
                    Element tmp = new Element(Value);
                    tmp.Next = First;
                    First.Previous = tmp;
                    First = tmp;
                }
                else
                {
                    Element tmp = First;
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
            if (First != null && Id < GetSize() && Id >= 0)
            {
                if (Id == 0)
                {
                    First = First.Next;
                    if (First != null)
                    {
                        First.Previous = null;
                    }
                }
                else if (Id == GetSize() - 1)
                {
                    Last.Previous.Next = null;
                }
                else
                {
                    Element tmp = First;
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
                if (First != null && i < GetSize() && i >= 0)
                {
                    int count = 0;
                    Element tmp = First;
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
                    Element tmp = First;
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
            int index = 0;
            Element tmp = First;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                {
                    return index;
                }
                index++;
                tmp = tmp.Next;
            }
            return null;
        }

        public void Print()
        {
            Element tmp = First;
            while (tmp != null)
            {
                Console.WriteLine(tmp.Value);
                tmp = tmp.Next;
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
