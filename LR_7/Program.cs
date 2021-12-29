using System;

namespace LR_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(new string('=', 45));
            Console.WriteLine("============ Лабораторная №7 ============");
            Console.WriteLine(new string('=', 45));

            try
            {
                Console.WriteLine(new string('~', 45));
                try
                {
                    Tablet tablObj1 = new Tablet("Lenovo M10 Plus", 6, "-", 10.3, 990, "M");
                }
                catch (IsNotRightModel nam)
                {
                    Console.WriteLine($"{nam.Message}\n {nam.Source} \n {nam.StackTrace}");
                }
                Console.WriteLine(new string('~', 45));

                try
                {
                    Computer compObj1 = new Computer("Asus Zenbook", 10, "Креативность, стиль, инновационность – эти качества воплощает новый ZenBook 14.", "AMD Ryzen 5", 400, "Ультрабук");
                }
                catch (IsNotRightPrice ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine(new string('~', 45));

                Skaner skanObj1 = new Skaner("Canon CanoScan", 4, "Легкий и компактный планшетный сканер формата A4 со стильным дизайном Canon CanoScan LiDE 300.", "Китай");
                try
                {
                    skanObj1.WorkingLife = 17;
                }
                catch (WrongWorkingLifeValue ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine(new string('~', 45));


                try
                {
                    Tablet tablObj2 = new Tablet("Lenovo M10 Plus", 6, "-", 1, 990, "Tab M10 (Lenovo)");
                }
                catch (IsNotScreenDiagonal ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine(new string('~', 45));

                PrintDevice printObj = new PrintDevice("Canon", 4, "Устройство PIXMA MG2540S «Все в одном» для ежедневной печати, сканирования и копирования.", "Китай");
                Skaner skanObj = new Skaner("CanoScan", 0, "Легкий и компактный планшетный сканер формата A4 со стильным дизайном Canon CanoScan LiDE 300.", "Китай");
                Computer compObj = new Computer("Asus Vivobook", 8, "Креативность, стиль, инновационность – эти качества воплощает новый ZenBook 14.", "AMD Ryzen 5", 2000, "Ультрабук");
                Tablet tablObj = new Tablet("Lenovo E5", 6, "-", 6.7, 1100, "Tab M10 (Lenovo)");

                Product[] Technic = new Product[] { printObj, skanObj, compObj, tablObj };

                try
                {
                    Console.WriteLine(Technic[5].Name);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine(new string('~', 45));

                try
                {
                    object obj = skanObj.Name;
                    int name = (int)obj;
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine(new string('~', 45));

                try
                {
                    int problem = printObj.WorkingLife / skanObj.WorkingLife;
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine(new string('~', 45));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine("End of try/catch blocks.");
            }

            Debug.Assert(true, "End of program.");
        }
    }
}
