using System;

namespace LR_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Abiturient abi1 = Abiturient.defConstructor();
            Console.WriteLine(abi1.ToString());
            Console.WriteLine($"Средний балл абитуриента составляет: {abi1.Sred()}");
            Console.WriteLine(new string('=', 25));

            Abiturient abi2 = new Abiturient("Худякова", "Анастасия", "Сергеевна", "г. Витебск", 8989, 45, 56, 46, 66); ;
            Console.WriteLine($"Тип объекта abi2: {abi2.GetType()}");
            abi2.TelNumber = 7878;
            Console.WriteLine($"Мобильный номер телефна абитуриентки {abi2.Surname} {abi2.FirstName}: {abi2.TelNumber}");
            Console.WriteLine($"Средний балл абитуриента составляет: {abi2.Sred()}");
            Console.WriteLine(new string('=', 25));

            Abiturient abi3 = new Abiturient("Петров", "Пёрт", "Петрович", "г. Могилёв");
            abi3.Marks0 = 17;
            abi3.Marks1 = 99;
            abi3.Marks2 = 66;
            abi3.Marks3 = 28;
            Console.WriteLine($"Изменённый балл marks[0] равен: {abi3.Marks0}");
            Console.WriteLine($"Средний балл абитуриента составляет: {abi3.Sred()}");
            Console.WriteLine($"Минимальный балл абитуриента: {abi3.Min()}. Максимальный балл: {abi3.Max()}");

            Console.WriteLine(new string('=', 25));
            Console.WriteLine(abi1.Equals(abi3) ? "Объекты равны" : "Объекты не равны");
            abi3.Method();
           

            Abiturient.info();
            Console.WriteLine(new string('=', 25));

            Abiturient[] abiturients = new Abiturient[3] { abi1, abi2, abi3 };

            // 2 пункт задания
            int k = 1;
            bool flag = false;
            Console.WriteLine("Введите минимальный балл: ");
            int minEx = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Абитуриенты с баллами ниже заданного: ");
            foreach (Abiturient abiturient in abiturients)
            {
                if (abiturient.Marks0 <= minEx || abiturient.Marks1 <= minEx ||
                    abiturient.Marks2 <= minEx || abiturient.Marks3 <= minEx)
                {
                    Console.WriteLine($"{k}. {abiturient.Surname} {abiturient.FirstName}");
                    k++;
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"Абитуриентов с баллами ниже {minEx} нет.");
            }

            Console.WriteLine(new string('=', 25));

            // 3 пункт задания
            k = 1;
            flag = false;
            Console.WriteLine("Введите средний балл: ");
            int sredMark = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Абитуриенты со средним баллом ниже заданного: ");
            foreach (Abiturient abiturient in abiturients)
            {
                if (abiturient.Sred() > sredMark)
                {
                    Console.WriteLine($"{k}. {abiturient.Surname} {abiturient.FirstName}");
                    k++;
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"Абитуриентов со средним баллом выше {sredMark} нет.");
            }

            // 4) Анонимный тип
            Console.WriteLine(new string('=', 25));
            var newAbiturient = new { surname = "Ермолович", firstName = "Леонид", middleName = "Дмитриевич", addres = "г. Минск", telNumber = 8888 };
            Console.WriteLine($"Тип объекта newAbiturient: {newAbiturient.GetType()}");
            Console.WriteLine("Данные о абитуриенте");
            Console.WriteLine($"Фамилия: {newAbiturient.surname} Имя: {newAbiturient.firstName} Отчество: {newAbiturient.middleName} " +
                $"Адрес: {newAbiturient.addres} Номер телефона: {newAbiturient.telNumber}");

            Console.ReadKey();

        }
    }
}
