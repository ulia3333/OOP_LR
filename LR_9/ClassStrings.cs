using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_9
{
    public static class ClassStrings
    {
        public static void AddLeter(string str, char letter)
        {
            str = str + letter;
            Console.WriteLine(str);
        }

        public static string OneSpace(string str)
        {
            int del = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    if (str[i + 1] == ' ')
                        del = i + 1;
            }
            str = str.Remove(del, 1);
            return str;
        }

        public static string AddPlus(string str)
        {
            str = str + "+";
            return str;
        }

        public static string MyToUpper(string str)
        {
            str = str.ToUpper();
            return str;
        }

        public static string Replacer(string str)
        {
            str = str.Replace("Woop", "Oops");
            return str;
        }
    }
}
