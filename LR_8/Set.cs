using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_8
{
    public interface IGeneric<T>
    {
        public void Add(T newElem);
        public void Delete(T elem);
        public void LookUp();
    }

    class Set<T> : IGeneric<T> where T : IComparable<T>
    {
        internal T[] elements;
        public Set(T[] array)
        {
            elements = new T[array.Length];
            array.CopyTo(elements, 0);
        }

        public T this[int i]
        {
            get
            {
                if (i >= 0 && i < elements.Length) return elements[i];
                else return default(T);
            }
        }

        public void LookUp()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(this.elements[i] + "||");
            }
            Console.WriteLine();
        }

        public void Add(T newElem)
        {
            try
            {
                Array.Resize(ref elements, elements.Length + 1);
                elements[elements.Length - 1] = newElem;

            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Обработано возможное исключение OutOfMemoryException");
            }
        }

        public void Delete(T elem)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Equals(elem))
                {
                    T addVar = elements[^1];
                    elements[^1] = elements[i];
                    elements[i] = addVar;
                    Array.Resize(ref elements, elements.Length - 1);
                }
            }
        }

        public void Sort()
        {
            Array.Sort(elements);
        }
        public void ToFile(string path)
        {
            using (StreamWriter strWriter = new StreamWriter(path))
            {
                foreach (var el in elements)
                {
                    strWriter.WriteLine(el.ToString());
                }

            }
        }
    }
}
