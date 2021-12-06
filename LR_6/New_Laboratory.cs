using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_6
{
    partial class Controller
    {
        //Задание 1. Подсчитать количество каждого вида техники.
        public static void TechCounter(List<Product> products)
        {
            int printDeviceCounter = 0;
            int SkanerCounter = 0;
            int ComputerCounter = 0;
            int TabletCounter = 0;

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i] is PrintDevice)
                {
                    printDeviceCounter++;
                }

                if (products[i] is Skaner)
                {
                    SkanerCounter++;
                }

                if (products[i] is Computer)
                {
                    ComputerCounter++;
                }

                if (products[i] is Tablet)
                {
                    TabletCounter++;
                }
            }
            Console.WriteLine("Информация о количестве единиц техники в Лаборатории: ");
            Console.WriteLine($"Количество принтеров: {printDeviceCounter}");
            Console.WriteLine($"Количество сканеров: {SkanerCounter}");
            Console.WriteLine($"Количество компьютеров: {ComputerCounter}");
            Console.WriteLine($"Количество планшетов: {TabletCounter}");

        }

        //Задание 2. Вывести список техники в порядке убывания цены.
        public static List<Product> PriceToMin(List<Product> products)
        {
            Product temp;
            for (int i = 0; i < products.Count; i++)
            {
                for (int j = i + 1; j < products.Count; j++)
                {
                    if (products[i].MinPrice < products[j].MinPrice)
                    {
                        temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }

            return products;
        }

    }
}
