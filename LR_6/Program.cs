using System;

namespace LR_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintDevice printObj = new PrintDevice("Canon", 5, "Устройство PIXMA MG2540S «Все в одном» для ежедневной печати, сканирования и копирования.", 760, "Китай");
            Skaner skanObj = new Skaner("Canon CanoScan", 4, "Легкий и компактный планшетный сканер формата A4 со стильным дизайном Canon CanoScan LiDE 300.", 550, "Китай");
            Computer compObj = new Computer("Asus Zenbook", 10, "Креативность, стиль, инновационность – эти качества воплощает новый ZenBook 14.", "AMD Ryzen 5", 1500, "Ультрабук");
            Tablet tablObj = new Tablet("Lenovo M10 Plus", 6, "-", 10.3, 990, "Tab M10 (Lenovo)");

            PrintDevice newPrintObj = new PrintDevice("Canon", 7, "Устройство PIXMA MG2540S «Все в одном» для ежедневной печати, сканирования и копирования.", 1030, "Китай");
            Skaner newSkanObj = new Skaner("Canon CanoScan", 6, "Легкий и компактный планшетный сканер формата A4 со стильным дизайном Canon CanoScan LiDE 300.", 660, "Китай");
            Computer newCompObj = new Computer("Asus Zenbook", 12, "Креативность, стиль, инновационность – эти качества воплощает новый ZenBook 14.", "AMD Ryzen 4", 1500, "Ультрабук");
            Tablet newTablObj = new Tablet("Legion", 8, "-", 14.2, 780, "Tab M10");

            Laboratory.Add(printObj);
            Laboratory.Add(skanObj);
            Laboratory.Add(compObj);
            Laboratory.Add(tablObj);
            Laboratory.Add(newPrintObj);
            Laboratory.Add(newSkanObj);
            Laboratory.Add(newCompObj);
            Laboratory.Add(newTablObj);


            compObj.Available();
            skanObj.Available();
            printObj.priceIncrease();

            Console.WriteLine(new string('=', 35));
            Console.WriteLine("Информация о имеющемся планшете: ");
            Console.WriteLine(tablObj.ToString());

            Console.WriteLine(new string('=', 35));
            Product prodObj = new Computer("Lenovo IdeaPad L3", 3, "Встречайте 15,6-дюймовый ноутбук Lenovo IdeaPad 3. Оснащенный передовым процессором Intel® Core™ 10-го поколения и дискретной видеокартой.", "Intel Core i3", 2200, "Универсальный");
            Laboratory.Add(prodObj);
            Console.WriteLine("Информация о новом товаре:");
            Console.WriteLine(prodObj.ToString());

            Console.WriteLine(new string('=', 35));
            Console.WriteLine(prodObj is Product ? "Объект prodObj является элементом класса Product" : "Объект prodObj не является элементом класса Product");
            Console.WriteLine(compObj is Device ? "Объект compObj является элементом класса Device" : "Объект compObj не является элементом класса Device");
            Console.WriteLine(tablObj is Skaner ? "Объект tablObj является элементом класса Device" : "Объект tablObj не является элементом класса Device");

            Console.WriteLine(new string('=', 35));
            var secProd = prodObj as Computer;
            if (secProd != null)
                Console.WriteLine(secProd.ToString());

            Console.WriteLine(new string('=', 35));
            compObj.Producer();
            compObj.GetDiscounts();
            tablObj.InfoAboutDiscounts();

            Console.WriteLine(new string('=', 35));
            Console.WriteLine("Вызываем класс IPrinter и метод IAmPrinting(): ");
            IPrinter printing = new IPrinter();
            Product[] ArrayTech = new Product[] { printObj, skanObj, tablObj };
            foreach (var tech in ArrayTech)
            {
                printing.IAmPrinting(tech);
                Console.ReadKey();
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', 45));
            Console.WriteLine("============ Лабораторная №6 ============");
            Console.WriteLine(new string('=', 45));

            Laboratory.ShowList();
            Console.WriteLine("=== Поиск техники старше заданного срока службы ===");
            Controller.FindOldest(Laboratory.Equipment);
            Console.WriteLine(new string('=', 35));

            Console.WriteLine("=== Задание 1: Подсчитать количество каждого вида техники. ===");
            Controller.TechCounter(Laboratory.Equipment);
            Console.WriteLine(new string('=', 35));

            Console.WriteLine("=== Задание 2: Вывести список техники в порядке убывания цены. ===");
            Controller.PriceToMin(Laboratory.Equipment);
            Laboratory.ShowList();
            Console.WriteLine(new string('=', 35));

            

        }
    }
}
