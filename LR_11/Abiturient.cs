using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_11
{
    public partial class Abiturient
    {

        // поля класса
        private long id;
        private string surname;
        private string first_name;
        private int course;
        private int first_year;
        private uint tel_number;
        private int marks0;
        private int marks1;
        private int marks2;
        private int marks3;
        private int summ_marks;
        private readonly int hash;

        static string allAbiturients;
        static int abiCount = 0;
        public int First_year
        {
            get => 2020 - course;
        }

        public override string ToString() => $"{surname} {first_name} {course} ({tel_number}) :: {marks0} {marks1} {marks2} {marks3} :: ({id})";

        public Abiturient(int id, string surname, string first_name, int course, int first_year, uint tel_number, int marks0, int marks1, int marks2, int marks3)
        {
            this.id = id;
            this.surname = surname;
            this.first_name = first_name;
            this.course = course;
            this.first_year = first_year;
            this.tel_number = tel_number;
            this.marks0 = marks0;
            this.marks1 = marks1;
            this.marks2 = marks2;
            this.marks3 = marks3;
            this.summ_marks = marks0 + marks1 + marks2 + marks3;


            hash = id % 15;
            abiCount++;
        }

        public Abiturient()
        {
            int newId = new Random().Next(1, 10);
            Id = newId;
            abiCount++;
            hash = GetHashCode();
        }

        ~Abiturient()
        {
            abiCount--;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(Id);
            hash.Add(Surname);
            hash.Add(FirstName);
            hash.Add(Course);
            hash.Add(FirstYear);
            return hash.ToHashCode();
        }

        public override bool Equals(object o)
        {

            if ((o == null) || !GetType().Equals(o.GetType()))
            {
                return false;
            }
            else
            {
                Abiturient s = (Abiturient)o;
                return (s.Id == Id) && (s.Surname == Surname) &&
                    (s.FirstName == FirstName) && (s.Course == Course) &&
                    (s.FirstYear == FirstYear) && (s.TelNumber == TelNumber) &&
                    (s.Marks0 == Marks0) && (s.Marks1 == Marks1) &&
                    (s.Marks2 == Marks2) && (s.Marks3 == Marks3);
            }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public int Course
        {
            get { return course; }
            set { course = value; }
        }

        public uint FirstYear
        {
            get { return tel_number; }
            set { tel_number = value; }
        }

        public uint TelNumber
        {
            get { return tel_number; }
            set { tel_number = value; }
        }

        public int Marks0
        {
            get => marks0;
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        marks0 = value;
                } while (value < 0);
            }
        }

        public int Marks1
        {
            get => marks1;
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        marks1 = value;
                } while (value < 0);
            }
        }

        public int Marks2
        {
            get => marks2;
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        marks2 = value;
                } while (value < 0);
            }
        }

        public int Marks3
        {
            get => marks3;
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        marks3 = value;
                } while (value < 0);
            }
        }

        public int SummMarks
        {
            get => summ_marks;
            set
            {

                do
                {
                    if (value < 0)
                        Console.WriteLine("Баллы не могут быть меньше нуля!");
                    else
                        summ_marks = value;
                } while (value < 0);
            }
        }

        public int GetAge() => 2020 - course;

        static public string Info => $"Класс {typeof(Abiturient)}, " +
            $"включающий {abiCount} объектов";
        static Abiturient() { }
    }
}
