using System;

namespace LR_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите элементы первого множества (через пробел): ");
            string enteredSet = Console.ReadLine();
            string[] items = enteredSet.Split(' ');
            int[] enteredItems = new int[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                enteredItems[i] = Convert.ToInt32(items[i]);
            }
            Set firstSet = new Set(enteredItems);

            Console.WriteLine();
            Console.WriteLine("Введите элементы второго множества (через пробел): ");
            enteredSet = Console.ReadLine();
            items = enteredSet.Split(' ');
            enteredItems = new int[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                enteredItems[i] = Convert.ToInt32(items[i]);
            }
            Set secondSet = new Set(enteredItems);

            Console.WriteLine();
            bool exit = false;
            do
            {
                Console.Write($"Выберите множество, на основе которого хотите проверить подмножество (0 для пропуска этого условия): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        {
                            exit = true;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine($"Первое множество: ");
                            firstSet.ShowSet();
                            Console.WriteLine($"Проверка на принадлежность подмножества первому множеству\n (Введите элементы подмножества через пробел): ");
                            enteredSet = Console.ReadLine();
                            items = enteredSet.Split(' ');
                            enteredItems = new int[items.Length];
                            for (int i = 0; i < items.Length; i++)
                            {
                                enteredItems[i] = Convert.ToInt32(items[i]);
                            }
                            Console.WriteLine();
                            if (enteredItems > firstSet) Console.WriteLine($"Введённое множество является подмножеством данного множества\n");
                            else Console.WriteLine($"Введённое множество не является подмножеством данного множества\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Второе множество: ");
                            secondSet.ShowSet();
                            Console.WriteLine($"Проверка на принадлежность подмножества второму множеству\n (Введите элементы подмножества через пробел): ");
                            enteredSet = Console.ReadLine();
                            items = enteredSet.Split(' ');
                            enteredItems = new int[items.Length];
                            for (int i = 0; i < items.Length; i++)
                            {
                                enteredItems[i] = Convert.ToInt32(items[i]);
                            }
                            Console.WriteLine();
                            if (enteredItems > secondSet) Console.WriteLine($"Введённое множество является подмножеством данного множества\n");
                            else Console.WriteLine($"Введённое множество не является подмножеством данного множества\n");
                            break;
                        }
                }
            } while (!exit);

            Console.WriteLine("\nПересечение двух введённых множеств: ");
            Set crossedSet = firstSet % secondSet;
            crossedSet.ShowSet();

            Console.WriteLine("\nРавенство или неравенство двух введённых множеств: : ");
            int equalSet = firstSet != secondSet;
            if (equalSet == 0)
                Console.WriteLine("Множества не равны");
            else
                Console.WriteLine("Множества равны");

            firstSet.SetOwner.ToString();
            secondSet.SetDate.ToString();
        }
    }
}
