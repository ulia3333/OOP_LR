using System;

namespace LR_8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {

                int[] intArray = new int[] { 2, 4, 6, 8, 10 };
                Set<int> intSet = new Set<int>(intArray);
                intSet.LookUp();
                intSet.Delete(2);
                intSet.LookUp();
                intSet.Add(9);
                intSet.Sort();
                intSet.LookUp();
                float[] floatArray = new float[] { 2.8f, 1.9f, 2.2f, 4.2f, 3.3f };
                Set<float> floatSet = new Set<float>(floatArray);
                floatSet.LookUp();
                floatSet.Delete(2);
                floatSet.LookUp();
                floatSet.Add(10);
                floatSet.Sort();
                floatSet.LookUp();
                PrintDevice printObj = new PrintDevice("Canon", 5, "Устройство PIXMA MG2540S «Все в одном» для ежедневной печати, сканирования и копирования.", 760, "Китай");
                Skaner skanObj = new Skaner("Canon CanoScan", 4, "Легкий и компактный планшетный сканер формата A4 со стильным дизайном Canon CanoScan LiDE 300.", 550, "Китай");
                Computer compObj = new Computer("Asus Zenbook", 10, "Креативность, стиль, инновационность – эти качества воплощает новый ZenBook 14.", "AMD Ryzen 5", 1500, "Ультрабук");
                Tablet tablObj = new Tablet("Lenovo M10 Plus", 6, "-", 10.3, 990, "Tab M10 (Lenovo)");
                Product[] prArr = new Product[] { printObj, skanObj, compObj, tablObj };
                Set<Product> prSet = new Set<Product>(prArr);
                prSet.LookUp();
                prSet.Delete(skanObj);
                prSet.LookUp();
                prSet.Add(printObj);
                prSet.Sort();
                prSet.LookUp();
                prSet.ToFile(@"D:\VisualStudio\OOP\Lab8\Set.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine("End of program");
            }
        }
    }
    }

