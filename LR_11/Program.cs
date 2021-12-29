using System;
using System.Collections.Generic;
using System.Linq;

namespace LR_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.
            var months = new string[12] { "June", "July", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May" };

            int n = 4;
            var monthsWithLength = from x in months
                                   where x.Length == n
                                   select x;
            foreach (var word in monthsWithLength)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            var monthsSummerAndWinter = months.Take(3).Union(months.Skip(6).Take(3));


            foreach (var word in monthsSummerAndWinter)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            var monthsSorted = from x in months
                               orderby x
                               select x;

            foreach (var word in monthsSorted)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            var monthsWithLetterAndLength = (from x in months where x.Length >= 4 select x).Intersect(from x in months where x.Contains('u') select x);

            foreach (var word in monthsWithLetterAndLength)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            //2.
            var abiturients = new List<Abiturient>();
            abiturients.Add(new Abiturient(0, "Иванов", "Иван", 2, 2019, 7778899, 7, 7, 7, 7));
            abiturients.Add(new Abiturient(1, "Петров", "Петр", 2, 2019, 1112233, 6, 5, 3, 4));
            abiturients.Add(new Abiturient(2, "Ермолович", "Леонид", 3, 2018, 1234567, 8, 9, 5, 7));
            abiturients.Add(new Abiturient(3, "Филатова", "Юля", 1, 2020, 9998877, 10, 9, 9, 8));
            abiturients.Add(new Abiturient(4, "Петухов", "Кирилл", 2, 2019, 3334455, 4, 3, 5, 7));
            abiturients.Add(new Abiturient(5, "Виннов", "Виктор", 4, 2017, 5641287, 9, 9, 8, 9));
            abiturients.Add(new Abiturient(6, "Шмурадко", "Кристина", 4, 2017, 3452678, 10, 10, 9, 10));
            abiturients.Add(new Abiturient(7, "Савритская", "Алина", 2, 2019, 7682435, 3, 5, 6, 7));
            abiturients.Add(new Abiturient(8, "Орлова", "Полина", 1, 2020, 1111122, 6, 4, 5, 3));

            var abiturientBadMarks = abiturients.Where(x => x.Marks0 == 3);
            abiturientBadMarks = abiturients.Where(x => x.Marks1 == 3);
            abiturientBadMarks = abiturients.Where(x => x.Marks2 == 3);
            abiturientBadMarks = abiturients.Where(x => x.Marks3 == 3);

            foreach (var abiturient in abiturientBadMarks)
            {
                Console.Write(abiturient + " | ");
            }
            Console.WriteLine();

            var abiturientSredMarks = abiturients.Where(x => x.SummMarks > 29);
            foreach (var abiturient in abiturientSredMarks)
            {
                Console.Write(abiturient + " | ");
            }
            Console.WriteLine();

            int counter = 0;
            var abiturientWithTen = abiturients.Where(x => x.Marks3 == 10);
            foreach (var abiturient in abiturientWithTen)
            {
                Console.Write($"{counter}. " + abiturient + " | ");
                counter++;
            }
            Console.WriteLine();

            var abiturientSortBySurname = abiturients.OrderByDescending(x => x.Surname);
            foreach (var abiturient in abiturientSortBySurname)
            {
                Console.Write(abiturient + " | ");
            }
            Console.WriteLine();


            var abiturientWorst = abiturients.OrderBy(x => x.SummMarks).TakeLast(4);
            foreach (var car in abiturientWorst)
            {
                Console.Write(car + " | ");
            }
            Console.WriteLine();

            var task4 = (((from x in months where x.Length > 3 select x)).Skip(3).
                           Intersect(from x in months where x.Contains("u") select x)).
                           Count();

            var log = new LogRecord[]
            {

                    new LogRecord("Action 1",       "Action"),
                    new LogRecord("Action 2",       "Action"),
                    new LogRecord("Event 1",        "Event"),
                    new LogRecord("Exception 1",    "Exception"),
                    new LogRecord("Exception 2",    "Exception"),
                    new LogRecord("Error 1",        "Error"),
                    new LogRecord("Error 2",        "Error")
            };

            var attentionLevel = new AttentionLevel[]
            {
                    new AttentionLevel ((LogType)0, "Regular"),
                    new AttentionLevel ((LogType)1, "Regular"),
                    new AttentionLevel ((LogType)2, "Warning"),
                    new AttentionLevel ((LogType)3, "Error"),

            };

            var mergedLog = log.Join(attentionLevel, a => a.type, b => b.type, (a, b) => new { attentionLevel = b.level, desc = a.desc });

            foreach (var elem in mergedLog)
            {
                Console.WriteLine(string.Format("[{0}] {1}", elem.attentionLevel, elem.desc));
            }
            Console.WriteLine();
        }

        public enum LogType
        {
            Action,
            Event,
            Exception,
            Error
        }
        public class LogRecord
        {
            public string desc;
            public LogType type;

            public LogRecord(string arg_desc, LogType arg_type) => (desc, type) = (arg_desc, arg_type);
            public LogRecord(string arg_desc, string arg_type) : this(arg_desc, (LogType)Enum.Parse(typeof(LogType), arg_type)) { }
        };

        public class AttentionLevel
        {

            public LogType type;
            public string level;

            public AttentionLevel(LogType arg_type, string arg_level) => (level, type) = (arg_level, arg_type);

        }
    }
}
