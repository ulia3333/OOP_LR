using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_6
{
    internal class Laboratory
    {
        public static List<Product> Equipment = new List<Product>();

        public static List<Product> techEquipment { get; set; }

        public static void Add(Product product)
        {
            Equipment.Add(product);
            Console.WriteLine($"В лабораторию добавлен новый объект: {product.Name}");
        }

        public static Product Remove(Product product)
        {
            foreach (Product tech in Equipment)
            {
                if (product == tech)
                {
                    Equipment.Remove(product);
                    return product;
                }
            }
            Console.WriteLine("Данного оборудования в лаборатории нет!");
            return null;
        }

        public static void ShowList()
        {
            Console.WriteLine("Перечень техники в лаборатории: ");
            foreach (Product product in Equipment)
            {
                Console.WriteLine($"Наименовение товара: {product.Name}");
                Console.WriteLine($"Срок службы: {product.WorkingLife}");
                Console.WriteLine($"Описание: {product.Description}");
                Console.WriteLine($"Цена: {product.MinPrice}");
                Console.WriteLine(new string('~', 35));
            }
        }

        public struct LaboratoryRoom
        {
            public string facilities;

            public enum Devices : int
            {
                computer = 1, tablet, skaner, printdevice
            }
        }
    }

    partial class Controller : IComparer<Product>
    {
        public int Compare(Product item1, Product item2)
        {
            if (item1.Name.Length > item2.Name.Length)
                return 1;
            else if (item1.Name.Length < item2.Name.Length)
                return -1;
            else
                return 0;
        }

        public static void FindOldest(List<Product> products)
        {
            Console.WriteLine("Введите минимальное значение для срока службы товаров: ");
            int minYear = Convert.ToInt32(Console.ReadLine());
            bool cheker = false;

            Console.WriteLine($"Товары со сроком службы больше {minYear} лет: ");
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].WorkingLife > minYear)
                {
                    Console.WriteLine($"Наименовение товара: {products[i].Name}");
                    Console.WriteLine($"Срок службы: {products[i].WorkingLife}");
                    cheker = true;
                }

            }

            if (!cheker)
                Console.WriteLine("Таких товаров нет!");
        }
    }
}
