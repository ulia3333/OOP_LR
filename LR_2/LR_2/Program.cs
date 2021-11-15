using System;

namespace LR_2
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            //1) Типы
            
            //Определите переменные всех возможных примитивных типов
            // С# и проинициализируйте их. Осуществите ввод и вывод их
            //значений используя консоль. 
            
            bool a = true;//хранит значение true или false (логические литералы). Представлен системным типом System.Boolean
            Console.WriteLine($"bool:{a}");
            byte b = 254;//хранит целое число от 0 до 255 и занимает 1 байт. Представлен системным типом System.Byte
            Console.WriteLine($"byte:{b}");
            sbyte c = -100;//хранит целое число от -128 до 127 и занимает 1 байт. Представлен системным типом System.SByte
            Console.WriteLine($"sbyte:{c}");
            char d = 'A';//хранит одиночный символ в кодировке Unicode и занимает 2 байта. Представлен системным типом System.Char.
            Console.WriteLine($"char:{d}");
            decimal e1 = 30.4m;//хранит десятичное дробное число. Если употребляется без десятичной запятой, имеет значение
                              //от ±1.0*10-28 до ±7.9228*1028, может хранить 28 знаков после запятой и занимает 16 байт.
                              //Представлен системным типом System.Decimal
            Console.WriteLine($"decimal:{e1}");
            double f = 30.4;//хранит число с плавающей точкой от ±5.0*10-324 до ±1.7*10308 и занимает 8 байта.
                            //Представлен системным типом System.Double
            Console.WriteLine($"double:{f}");
            float g = 30.4f;//хранит число с плавающей точкой от -3.4*1038 до 3.4*1038 и занимает 4 байта. Представлен системным типом System.Single
            //При присвоении значений надо иметь в виду следующую тонкость: все вещественные литералы (дробные числа) рассматриваются как значения типа double.
            //И чтобы указать, что дробное число представляет тип float или тип decimal, необходимо к литералу добавлять суффикс: F/f - для float и M/m - для decimal.
            Console.WriteLine($"float:{g}");
            int h = 10;//хранит целое число от -2147483648 до 2147483647 и занимает 4 байта. Представлен системным типом System.Int32. Все целочисленные литералы по умолчанию представляют значения типа int
            Console.WriteLine($"int:{h}");
            //Подобным образом все целочисленные литералы рассматриваются как значения типа int. Чтобы явным образом указать, что целочисленный литерал представляет значение типа uint,
            //надо использовать суффикс U/u, для типа long - суффикс L/l, а для типа ulong - суффикс UL/ul
            uint i = 10U;//хранит целое число от 0 до 4294967295 и занимает 4 байта. Представлен системным типом System.UInt32
            Console.WriteLine($"uint:{i}");
            long l = 10L;//хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт.
                         //Представлен системным типом System.Int64
            Console.WriteLine($"long:{l}");
            ulong m = 10UL;//0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer	System.UInt64
            Console.WriteLine($"ulong:{m}");
            short s = -20;//-32,768 to 32,767	Signed 16-bit integer	System.Int16
            Console.WriteLine($"short:{s}");
            ushort o = 60;//0 to 65,535	Unsigned 16-bit integer	System.UInt16
            Console.WriteLine($"ushort:{o}");
            object p = Console.ReadLine();//может хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе и 8 байт на 64-разрядной платформе.
                                          //Представлен системным типом System.Object, который является базовым для всех других типов и классов .NET.
            Console.WriteLine($"object:{p}");
            string q1 = "hi!";// хранит набор символов Unicode. Представлен системным типом System.String. Этому типу соответствуют строковые литералы.
            Console.WriteLine($"string:{q1}");
            Console.Write("Введите значение переменной q: ");
            q1 = Console.ReadLine();
            Console.WriteLine($"string:{q1}");
            Console.WriteLine();
            Console.WriteLine($"b. Выполните 5 операций явного и 5 неявного приведения.");

            ///////////////b. Выполните операции явного и неявного приведения. Изучите возможности класса Convert.

            byte b1 = 100;
            short s1 = b1; // расширение типа
            Console.WriteLine($"byte value: {b1}, short value: {s1}");

            short s2 = 100;
            byte b2 = (byte)s2;
            Console.WriteLine($"byte value: {b2}, short value: {s2}");

            float y1 = -5.4F;
            short y2 = (short)y1;
            Console.WriteLine($"float value: {y1}, short value: {y2}");

            byte b3 = 99;
            sbyte s3 = (sbyte) b3; 
            Console.WriteLine($"byte value: {b3}, short value: {s3}");

            //Для приведения типов можно воспользоваться классом System.Convert,
            //который содержит методы для приведения одного типа к другому.

            short s4 = 33;
            byte b4 = System.Convert.ToByte(s4);
            Console.WriteLine($"byte value: {b4}, short value: {s4}");

            //////////////////c. Выполните упаковку и распаковку значимых типов
           
            int ip = 666;
            object myobj = ip; //упаковка
            int k = (int)myobj; //распаковка
            Console.WriteLine("k = {0}", k);

            //d)Продемонстрируйте работу с неявно типизированной переменной.

            var hello = "Hell to World";
            var cl = 20;
            Console.WriteLine($"{hello}"+ $"{cl}");
            //Для неявной типизации вместо названия типа данных используется ключевое слово var.
            //Затем уже при компиляции компилятор сам выводит тип данных исходя из присвоенного значения.
            //Так как по умолчанию все целочисленные значения рассматриваются как значения типа int,
            //то поэтому в итоге переменная c будет иметь тип int. Аналогично переменной hello присваивается строка,
            //поэтому эта переменная будет иметь тип string
            //Эти переменные подобны обычным, однако они имеют некоторые ограничения.
            //Во - первых, мы не можем сначала объявить неявно типизируемую переменную, а затем инициализировать
            //Во-вторых, мы не можем указать в качестве значения неявно типизируемой переменной null



            //e)Продемонстрируйте пример работы с Nullable переменной

            int? x = null;
            x = 9;

            //f)Ошибка с var

            var h1 = 134.45E-2f;
            h1 = 6776;

            //////////////////////////////////Строки

            ///a.Объявите строковые литералы.Сравните их.

            string str1 = "ulia", str12 = "hello!";
            Console.WriteLine("Сравниваемые строки: \"" + str1 + "\" и \"" + str12 + "\nРезультат сравнения: " + String.Compare(str1, str12));

            //b)Создайте три строки на основе String  
            //сцепление
            string string1 = "What fgjhjfhgugh",
            string2 = "a nice hffffffffffff ",
            string3 = "day";

            Console.WriteLine("Сцепление: " + string1 + string2 + string3);

            // Разделение строки на подстроки
            string w = "What a good day , what a good stump";
            Console.WriteLine("Разделение строки на подстроки:");
            string[] words = w.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string cc in words)
                Console.WriteLine(cc);

            //КОПИРОВАНИЕ - метод String.CopyTo() -  Этот метод копирует из строки часть символов, начиная с заданной позиции, и вставляет их !в массив символов!, также с указанной позиции. 
            char[] myarray = string3.ToCharArray(); //cоздание символьного массива на основе строки 3
            string2.CopyTo(0, myarray, 0, 3); //вставляем 2, начиная с 0 позиции, в символьный массив, начиная с 0 позиции, вставляем 3 элемента
            Console.WriteLine(myarray);

            //ВЫДЕЛЕНИЕ ПОДСТРОКИ - метод String.Substring() - Извлекает подстроку из данного экземпляра. Подстрока начинается в указанном положении символов и продолжается до конца строки.
            string str4 = string1.Substring(5);
            Console.WriteLine(str4);

            str4 = string2.Substring(0, 3);
            Console.WriteLine(str4);

            //ВСТАВКА ПОДСТРОКИ В ЗАДАННУЮ ПОЗИЦИЮ - метод String.Insert() 
            string modified = string2.Insert(5, string1);
            Console.WriteLine(modified);

            // Удаление подстроки
            string num = "0123456789";
            Console.WriteLine("Удаление подстроки: " + num.Remove(0, 5));

            // Интерполирование строк
            int one = 1,
            two = 2;
            Console.WriteLine($"Интерполирование строк: один - {one}, два - {two}");

            // Пустые и null строки
            string nullString = null;
            string emptyString = "";
            bool IsEmptyStr1 = String.IsNullOrEmpty(emptyString);//Указывает, действительно ли указанная строка является строкой null или пустой строкой
            Console.WriteLine(IsEmptyStr1);
            //Можно проверить, являются ли равными пустая строка и null-строка:
            bool AreEquals = (emptyString == nullString);

            //////////////////// МАССИВЫ/////////////////////////////////////////////////
            //Создайте целый двумерный массив и выведите его на консоль в отформатированном виде(матрица).

            int[,] arr = { { 1, 10 }, { 2, 20 }, { 3, 30 }, { 4, 40 } };

            Console.WriteLine("Матрица:");
            for (int km = 0; km < 4; km++)
            {
                for (int n = 0; n < 2; n++)
                    Console.Write(arr[k, n] + "\t");
                Console.WriteLine();
            }
            // Одномерный массив строк
            string[] arrOfStr = { "Hello ", "World!" };
            //Поменяйте произвольный элемент, пользователь определяет позицию и значение
            foreach (string smth in arrOfStr)
                Console.WriteLine(smth);
            Console.WriteLine("Длина массива строк: " + arrOfStr.Length);
            Console.Write("Выберете индекс строки: ");
            int index = Convert.ToInt32((Console.ReadLine()));
            if (index != 0 && index != 1)
                Console.WriteLine("Введены неверные данные!");
            else
            {
                Console.Write("Введите строку: ");
                arrOfStr[index] = Console.ReadLine();
                Console.Write("Полученная строка: ");
                foreach (string smth in arrOfStr)
                    Console.Write(smth);
                Console.WriteLine();
            }

            // Ступенчатый массив
            int[][] steppedArray = new int[3][];
            steppedArray[0] = new int[2];
            steppedArray[1] = new int[3];
            steppedArray[2] = new int[4];
            int j;
            for (i = 0; i < steppedArray.Length; i++)
                for (j = 0; j < steppedArray[i].Length; j++)
                {
                    Console.Write($"Введите число с координатами ({i},{j}): ");
                    steppedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            Console.WriteLine("Полученный массив: ");
            for (i = 0; i < steppedArray.Length; i++)
            {
                for (j = 0; j < steppedArray[i].Length; j++)
                    Console.Write(steppedArray[i][j] + "\t");
                Console.WriteLine();
            }

            // неявно типизированные переменные для хранения массива и строки. 
            var varArr = new[] { 5, 10, 23, 16, 8 };
            var varStr = "Hi, how are you?";

            ////////////////////////КОРТЕЖИ-множество симвалов разного типа
            //Задайте кортеж и вывести

            (int, string, char, string, ulong) t = (88, "Help", 'm', "meeee", 999);
            Console.WriteLine($"Кортеж: {t.Item1}, {t.Item2}, {t.Item3}, {t.Item4}, {t.Item5}");
            Console.WriteLine($"1, 3 и 4 элементы кортежа: {t.Item1}, {t.Item3}, {t.Item4}");

            // Распаковка кортежей
            (int q, string wd, char e, string r, ulong y) = t;
            int cortInt;
            string cortStr1, cortStr2;
            char cortChar;
            ulong cortUlong;
            (cortInt, cortStr1, cortChar, cortStr2, cortUlong) = t;
            var (c1, c2, c3, c4, c5) = t;
            _ = Console.ReadLine(); //_ - переменная, которая ничего не хранит, не выделяется память под нее

            // Сравнение кортежей
            (long a, int b) righttuple = (5, 10);
            (float a, int b) middletuple = (-5.77F, 10);
            Console.WriteLine(righttuple != middletuple);  // output: True

            // Локальная функция, которая возвращает кортеж
            static (int, int, int, char) func(int[] arr, string str)
            {
                int min = arr[0],
                max = arr[0],
                sum = 0;
                foreach (int i in arr)
                {
                    if (i > max)
                        max = i;
                    if (i < min)
                        min = i;
                    sum += i;
                }
                return (max, min, sum, str[0]);
            }

            var returnedCort = func(new int[] { 1, 2, 3, 4, 5 }, "Hello");
        
            //a. Определите две локальные функции. 
            // b.Разместите в одной из них блок checked, в котором определите переменную типа int с
            // максимальным возможным значением этого типа.
            //Во второй функции определите блок unchecked стаким же содержимым. 
            //c.Вызовите две функции.
            static void checkedFunc()
            {
                int x = checked(int.MaxValue);
            }
            static void uncheckedFunc()
            {
                int x = unchecked(int.MaxValue);
            }
            checkedFunc();
            uncheckedFunc();
        }
    }
}

