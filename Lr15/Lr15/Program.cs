using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace Lr15
{
    class Program
    {
        private static object locker = new object();

        static void Main(string[] args)
        {
            TimerCallback tm = new TimerCallback(MethodForTimer);                      // устанавливаем метод обратного вызова
            Timer timer = new Timer(tm, null, 0, 5000);

            foreach (Process process in Process.GetProcesses())             //получаем все запущенные процессы
            {
                try
                {
                    Console.WriteLine(
                    $"ID: {process.Id}\n" +
                    $"Имя: {process.ProcessName}\n" +
                    $"Приоритет: {process.PriorityClass}\n" +
                    $"Время запуска: {process.StartTime}\n" +
                    $"Текущее состояние(объем памяти, который выделен для данного процесса): {process.VirtualMemorySize64}\n" +
                    $"Отвечает ли пользовательский интерфейс: {process.Responding}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Имя: {process.ProcessName} {ex.Message}");
                }
            }

            Console.WriteLine("<------------------------------------------------------------------------------------>");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine(
                $"Имя домена приложения: {domain.FriendlyName}\n" +
                $"Конфигурация домена приложения: {domain.SetupInformation}\n" +
                $"Базовый каталог, который используется для получения сборок: {domain.BaseDirectory}\n");

            Console.WriteLine("Все сборки, загруженные в домен: ");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(
                    $"-> Имя: \t{asm.GetName().Name}\n" +
                    $"-> Версия: \t{asm.GetName().Version}\n"
                    );
            }

            MakeNewDomain();                                        //создаём новый домен
            Console.WriteLine("<------------------------------------------------------------------------------------>");

            Console.WriteLine("Введите число:");
            int number1 = int.Parse(Console.ReadLine());

            Thread myThread = new Thread(new ParameterizedThreadStart(SimpleNumbers));
            myThread.Name = "SimpleNumbersThread";
            myThread.Start(number1);
            
            Console.WriteLine("<------------------------------------------------------------------------------------>");

            int number2 = int.Parse(Console.ReadLine());

            Thread myThread1 = new Thread(new ParameterizedThreadStart(EvenAndOdd));
            myThread1.Name = "EvenNumbersThread";
            myThread1.Priority = ThreadPriority.Normal;
            Console.WriteLine($"Поток: {myThread1.Name}   Приоритет: {myThread1.Priority}");
            myThread1.Start(number2);

            Thread myThread2 = new Thread(new ParameterizedThreadStart(EvenAndOdd));
            myThread2.Name = "OddNumbersThread";
            myThread2.Priority = ThreadPriority.BelowNormal;                                    //изменили приоритет одного из потоков
            Console.WriteLine($"Поток: {myThread2.Name}   Приоритет: {myThread2.Priority}");
            myThread2.Start(number2);

            Console.ReadLine();
        }

        static void MakeNewDomain()
        {
            AppDomain newD = AppDomain.CreateDomain("MyNewAppDomain");                              // Создадим новый домен приложения
            InfoDomainApp(newD);
            AppDomain.Unload(newD);                                                                 // Уничтожение домена приложения
        }

        static void InfoDomainApp(AppDomain defaultD)
        {
            Console.WriteLine("<--- Информация о новом домене приложения --->\n");
            Console.WriteLine(
                $"Имя: {defaultD.FriendlyName}\n" +
                $"ID: {defaultD.Id}\n" +
                $"По умолчанию? {defaultD.IsDefaultAppDomain()}\n" +
                $"Путь: {defaultD.BaseDirectory}\n"
                );

            Console.WriteLine("Загружаемые сборки: \n");                                       // Извлекаем информацию о загружаемых сборках с помощью LINQ-запроса
            var infAsm = from asm in defaultD.GetAssemblies()
                         orderby asm.GetName().Name
                         select asm;
            foreach (var a in infAsm)
                Console.WriteLine(
                    $"-> Имя: \t{a.GetName().Name}\n" +
                    $"-> Версия: \t{a.GetName().Version}"
                    );
        }
        public static void SimpleNumbers(object num)
        {
            string Path = @"D:\2K\ООП\Lr15\SimpleNumpers.txt";
            Thread t = Thread.CurrentThread;
            for (int i = 2; i <= (int)num; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0 & i % 1 == 0)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    Console.WriteLine(i);
                    using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(i);
                    }
                    Thread.Sleep(400);
                }
                if (i == (int)num)
                {
                    Console.WriteLine($"Имя потока: {t.Name}");
                    Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
                    Console.WriteLine($"Приоритет потока: {t.Priority}");
                    Console.WriteLine($"Статус потока: {t.ThreadState}");
                }
            }
        }
        public static void EvenAndOdd(object num)
        {
            string Path = @"D:\2K\ООП\Lr15\EvenAndOddNumpers.txt";
            Thread t = Thread.CurrentThread;
            lock (locker)
            {
                for (int i = 0; i < (int)num; i++)
                {
                    if (t.Name == "EvenNumbersThread")
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i);
                            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(i);
                            }
                        }
                        Thread.Sleep(300);
                    }

                    if (t.Name == "OddNumbersThread")
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i);
                            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(i);
                            }
                        }
                        Thread.Sleep(300);
                    }
                }
            }
        }
        public static void MethodForTimer(object param)
        {
            Console.WriteLine("TimerTimerTimerTimerTimerTimerTimerTimerTimerTimerTimerTimerTimerTimerTimerTimerTimerTimer");
        }
    }
}
