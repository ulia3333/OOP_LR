using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_3
{
    public partial class Abiturient
    {

        // поля класса
        private readonly int id;
        private string surname;
        private string firstName;
        private string middleName;
        private string addres;
        private uint telNumber;
        private int[] marks = new int[4];
        static string allAbiturients;
        static int abiCount;

        public int ID => id;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string Addres
        {
            get { return addres; }
            set { addres = value; }
        }

        public uint TelNumber
        {
            get { return telNumber; }
            set { telNumber = value; }
        }

        public int Marks0
        {
            get => marks[0];
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        marks[0] = value;
                } while (value < 0);
            }
        }

        public int Marks1
        {
            get => marks[1];
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        marks[1] = value;
                } while (value < 0);
            }
        }

        public int Marks2
        {
            get => marks[2];
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        marks[2] = value;
                } while (value < 0);
            }
        }

        public int Marks3
        {
            get => marks[3];
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        marks[3] = value;
                } while (value < 0);
            }
        }

        // методы 

        public void Method()
        {
            Console.WriteLine("Начало выполнения методов");

        }

        public static void info()
        {
            Console.WriteLine($"Всего абитуриентов: {abiCount}");
            Console.WriteLine($"Абитуриент - {allAbiturients}");
        }

        public override int GetHashCode()
        {
            Console.WriteLine("Переопределение метода GetHashCode");
            return base.GetHashCode();
        }

        public static Abiturient defConstructor()  //метод, вызывающий закрытый конструктор
        {
            return new Abiturient();
        }

        public override bool Equals(object obj)
        {
            if (obj is Abiturient objectType)
            {
                if (this.firstName == objectType.firstName && this.middleName == objectType.middleName
                    && this.surname == objectType.surname && this.telNumber == objectType.telNumber
                    && this.addres == objectType.addres && this.firstName == objectType.firstName
                    && this.id == objectType.id && this.marks[0] == objectType.marks[0]
                    && this.marks[1] == objectType.marks[1] && this.marks[2] == objectType.marks[2]
                    && this.marks[3] == objectType.marks[3])
                    return true;

            }
            return false;
        }

        public override string ToString()
        {
            return $"Фамилия - {surname}, Имя - {firstName}, Отчество - {middleName}, Адрес - {addres}," +
                   $" Номер тел. - {telNumber}, Баллы: {marks[0]}, {marks[1]}, {marks[2]}, {marks[3]}";
        }

        public int Sred()
        {
            return (marks[0] + marks[1] + marks[2] + marks[3]) / 4;
        }

        public int Max()
        {
            int max = 0;
            for (int n = 0; n < 4; n++)
            {
                if (marks[n] >= max)
                    max = marks[n];
            }

            return max;
        }

        public int Min()
        {
            int min = 101;
            for (int n = 0; n < 4; n++)
            {
                if (marks[n] <= min)
                    min = marks[n];
            }

            return min;
        }

        public int Sum()
        {
            return marks[0] + marks[1] + marks[2] + marks[3];
        }


        // конструкторы
        static Abiturient()
        {
            allAbiturients = "Абитуриенты";
            Console.WriteLine("Занесены данные нового абитуриента");
        }

        private Abiturient()
        {
            surname = "Пляшкевич";
            firstName = "Кирилл";
            middleName = "Викторович";
            addres = "г. Минск";
            telNumber = 8888;
            marks[0] = 56;
            marks[1] = 78;
            marks[2] = 68;
            marks[3] = 87;
            id = GetHashCode();
            abiCount++;
        }

        public Abiturient(string sn, string fn, string mn, string ad, uint tn, int ma1, int ma2, int ma3, int ma4)  // конструктор с параметрами по умолчанию
        {
            surname = sn;
            firstName = fn;
            middleName = mn;
            addres = ad;
            telNumber = tn;
            marks[0] = ma1;
            marks[1] = ma2;
            marks[2] = ma3;
            marks[3] = ma4;
            id = HashCode.Combine(sn, mn, fn, ad, tn);
            abiCount++;
        }

        public Abiturient(string sn, string fn, string mn, string ad, int ma1 = 50, int ma2 = 50, int ma3 = 50, int ma4 = 50)  // конструктор с параметрами по умолчанию
        {
            surname = sn;
            firstName = fn;
            middleName = mn;
            addres = ad;
            id = GetHashCode();
            abiCount++;
        }
    }
}
