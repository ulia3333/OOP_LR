using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_4
{
    internal class Set
    {
        internal int[] items;
        public Owner SetOwner;
        public Date SetDate;
        public Set()
        {
            items = new int[] { 19, 28, 37, 46, 5 };
            SetOwner = new Owner();
            SetDate = new Date();
        }

        public Set(int[] array)
        {
            items = new int[array.Length];
            array.CopyTo(items, 0);
            SetOwner = new Owner();
            SetDate = new Date();
        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < items.Length) return items[i];
                else return 0;
            }
        }

        public void SelfCheck()
        {
            bool isChenged = false;
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[i] == items[j])
                    {
                        int addvar = items[^1];
                        items[^1] = items[j];
                        items[j] = addvar;
                        Array.Resize<int>(ref items, items.Length - 1);

                        isChenged = true;
                    }
                }
            }
            Array.Sort(items);
            if (isChenged)
            {
                Console.WriteLine("Во множестве были повторяющиеся элементы \n Множество изменино!");
                ShowSet();
            }
        }

        public void ShowSet()
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(this.items[i] + " ");
            }
            Console.WriteLine();
        }
        public static bool operator >(int[] numbers, Set obj)
        {
            int amountIsInSet = 0;
            foreach (int number in numbers)
            {
                bool isInSet = false;
                foreach (int it in obj.items)
                {
                    if (number == it)
                    {
                        Console.WriteLine($"Элемент {number} принадлежит данному множеству");
                        isInSet = true;
                        amountIsInSet++;
                        break;
                    }
                }
                if (!isInSet) Console.WriteLine($"Элемент {number} не принадлежит данному множеству");
            }
            if (amountIsInSet == numbers.Length) return true;
            else return false;
        }

        public static bool operator <(int[] subset, Set obj)
        {
            int matches = 0;
            foreach (int itInSubset in subset)
            {
                foreach (int itInObj in obj.items)
                {
                    if (itInSubset == itInObj)
                    {
                        matches++;
                        break;
                    }
                }
            }
            if (matches == subset.Length) return true;
            else return false;
        }

        public static Set operator %(Set obj1, Set obj2)
        {
            int crossedlenght;
            int crossPos = 0;
            if (obj1.items.Length >= obj2.items.Length)
                crossedlenght = obj1.items.Length;
            else
                crossedlenght = obj2.items.Length;
            int[] crossedItems = new int[crossedlenght];

            foreach (int obj1it in obj1.items)
            {
                foreach (int obj2it in obj2.items)
                {
                    if (obj1it == obj2it)
                    {
                        crossedItems[crossPos++] = obj1it;
                        break;
                    }
                }
            }

            Array.Resize<int>(ref crossedItems, crossPos);
            Set crossedSet = new Set(crossedItems);
            return crossedSet;
        }

        public static int operator !=(Set obj1, Set obj2)
        {
            int equalLenght;
            int counter = 0;
            int position = 0;
            if (obj1.items.Length == obj2.items.Length)
                equalLenght = obj1.items.Length;
            else
                equalLenght = 0;

            int[] equalElements = new int[equalLenght];

            if (equalLenght != 0)
            {
                foreach (int obj1it in obj1.items)
                {
                    foreach (int obj2it in obj2.items)
                    {
                        if (obj1it == obj2it)
                        {
                            counter++;
                            equalElements[position++] = obj1it;
                            break;
                        }
                    }
                }
            }

            if (counter != equalElements.Length)
                counter = 0;

            Array.Resize<int>(ref equalElements, position);
            Set equalSet = new Set(equalElements);
            return counter;
        }

        public static int operator ==(Set obj1, Set obj2)
        {
            int equalLenght;
            int counter = 0;
            int position = 0;
            if (obj1.items.Length == obj2.items.Length)
                equalLenght = obj1.items.Length;
            else
                equalLenght = 0;

            int[] equalElements = new int[equalLenght];

            if (equalLenght != 0)
            {
                foreach (int obj1it in obj1.items)
                {
                    foreach (int obj2it in obj2.items)
                    {
                        if (obj1it == obj2it)
                        {
                            counter++;
                            equalElements[position++] = obj1it;
                            break;
                        }
                    }
                }
            }

            if (counter != equalElements.Length)
                counter = 0;

            Array.Resize<int>(ref equalElements, position);
            Set equalSet = new Set(equalElements);
            return counter;
        }

        public static bool operator >>(Set set, int position)
        {
            int addVar;
            bool deletedOnce = false;
            for (int i = 0; i < set.items.Length; i++)
            {
                if (position == i + 1)
                {
                    deletedOnce = true;
                    addVar = set.items[i];
                    set.items[i] = set.items[set.items.Length - 1];
                    set.items[set.items.Length - 1] = addVar;
                    Array.Resize<int>(ref set.items, set.items.Length - 1);
                }
            }
            return deletedOnce;
        }

        public static bool operator <<(Set set, int newItem)
        {
            bool addedOnce = false;
            for (int i = 0; i < set.items.Length; i++)
            {
                Array.Resize<int>(ref set.items, set.items.Length + 1);
                if (i + 1 == set.items.Length)
                {
                    Array.Resize<int>(ref set.items, set.items.Length + 1);
                    addedOnce = true;
                    set.items[set.items.Length + 1] = newItem;
                }
            }
            return addedOnce;
        }

        internal class Owner
        {
            private string Id { get; }
            private string Name { get; }
            private string Organisation { get; }

            public Owner()
            {
                Console.WriteLine("Введите ID создателя объекта: ");
                Id = Console.ReadLine();
                Console.WriteLine("Введите имя создателя объекта: ");
                Name = Console.ReadLine();
                Console.WriteLine("Введите название организации создателя объекта: ");
                Organisation = Console.ReadLine();
            }

            public override string ToString()
            {
                return $"ID владельца - {Id},\nИмя владельца - {Name},\nОрганизация - {Organisation} ";
            }
        }

        public class Date
        {
            private int Day { get; }
            private int Month { get; }
            private int Year { get; }

            public Date()
            {
                DateTime date = DateTime.Now;
                Day = date.Day;
                Month = date.Month;
                Year = date.Year;
            }

            public override string ToString()
            {
                return $"Дата создания объекта\n{Day}.{Month}.{Year} ";
            }

            public static explicit operator Date(Set obj)
            {
                return obj.SetDate;
            }
        }
    }

    static class StaticOperation
    {
        public static string FindMin(this String str)
        {
            Console.WriteLine("Введите строку слов (каждое слово отделять пробелом): ");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(' ');
            string[] enteredWords = new string[words.Length];
            int check = 0, minWord = 99;
            for (int i = 0; i < words.Length; i++)
            {
                if (enteredWords[i].Length < minWord)
                    check = i;
            }
            return enteredWords[check];
        }

        public static void sortSet(this Set set)
        {
            int temp;
            for (int i = 0; i < set.items.Length - 1; i++)
            {
                for (int j = 1; j < set.items.Length - i - 1; j++)
                {
                    if (set.items[j] > set.items[j + 1])
                    {
                        temp = set.items[j];
                        set.items[j] = set.items[j + 1];
                        set.items[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < set.items.Length; i++)
            {
                Console.Write(set.items[i] + " ");
            }
            Console.WriteLine();
        }

        public static int Summ(Set set)
        {
            int summ = 0;
            foreach (int it in set.items)
            {
                summ += it;
            }
            return summ;
        }

        public static int MaxMinDiff(Set set)
        {
            int max = 0;
            int min = set.items[0];
            foreach (int it in set.items)
            {
                if (it > max) max = it;
                if (it < min) min = it;
            }
            return (max - min);
        }

        public static int ItemsAmount(Set set)
        {
            int amount = 0;
            foreach (int it in set.items)
            {
                amount++;
            }
            return amount;
        }
    }
}
