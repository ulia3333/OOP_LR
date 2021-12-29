using System;

namespace LR_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reflector.toFile(typeof(CList<int>), typeof(int), "IntCListInfo.txt") + "\n");
            Console.WriteLine(Reflector.toFile(typeof(string), typeof(string), "StringInfo.txt") + "\n");
            Console.WriteLine(Reflector.toFile(typeof(CList<char>), typeof(char), "CharCListInfo.txt") + "\n");
            Console.WriteLine(Reflector.toFile(typeof(Product), typeof(Exception), "ProductInfo.txt") + "\n");
            Console.WriteLine(Reflector.Invoke(typeof(Math), "Pow", "params.txt"));
            Console.WriteLine(Reflector.Invoke(typeof(Math), "Pow"));

        }
    }
}
