using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_13
{
    public delegate void userActions(string str);

    class DUKLog
    {
        private const string path = "D:\\VisualStudio\\OOP\\observer.txt";
        public static event userActions Observe = (str) =>
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    sw.WriteLine(str);
                    sw.WriteLine($"Дата использования:");
                    sw.WriteLine(DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        };

        public static class DUKDiskInfo
        {
            public static void ShowFreeSpace(string driveName)
            {
                DriveInfo drive = new DriveInfo(driveName);
                Console.WriteLine($"Свободное место на диске {drive.Name} {drive.TotalFreeSpace}");
                Observe("Пользователь использовал класс DISDiskInfo и метод ShowFreeSpace, чтобы узнать свободное место на диске.");
            }

            public static void ShowFileSystem(string driveName)
            {
                DriveInfo drive = new DriveInfo(driveName);
                Console.WriteLine($"Диск {drive.Name} c файловой системой:{drive.DriveFormat}");
                Observe("Пользователь использовал класс DISDiskInfo и метод ShowFileSystem, чтобы узнать файловую систему диска.");
            }

            public static void AllInfo()
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                    {
                        Console.WriteLine($"Имя: {drive.Name}");
                        Console.WriteLine($"Объём: {drive.TotalSize} байт");
                        Console.WriteLine($"Допустимый обьём:{drive.TotalFreeSpace} байт");
                        Console.WriteLine($"Метка тома: {drive.VolumeLabel}");
                    }
                }
                Observe("Пользователь использовал класс DISDiskInfo и метод AllInfo, чтобы узнать общую информацию про диск.");
            }
        }

        public static class DUKFileInfo
        {
            public static void ShowFilePath(string path)
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    Console.WriteLine($"Имя файла: {file.Name}");
                    Console.WriteLine($"Полный путь к файлу: {file.FullName}");
                }
                else
                    Console.WriteLine("Файла по такому пути не существует...");

                Observe("Пользователь использовал класс DISFileInfo и метод ShowFilePath, чтобы узнать имя файла и путь к нему .");
            }

            public static void ShowFileSizeExtAndName(string path)
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    Console.WriteLine($"Имя файла: {file.Name}");
                    Console.WriteLine($"Расширение: {file.Extension}");
                    Console.WriteLine($"Размер: {file.Length} байт");
                }
                else
                    Console.WriteLine("Файла по такому пути не существует...");
                Observe("Пользователь использовал класс DISFileInfo и метод ShowFileSizeExtAndName, чтобы узнать расширение и размер файла.");
            }

            public static void ShowCreationTime(string path)
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    Console.WriteLine($"Имя файла: {file.Name}");
                    Console.WriteLine($"Время создания: {file.CreationTime}");

                }
                else
                    Console.WriteLine("Файла по такому пути не существует...");
                Observe("Пользователь использовал класс DISFileInfo и метод  ShowCreationTime, чтобы узнать дату создания файла.");
            }
        }

        public static class DUKDirInfo
        {
            public static void ListOfDirectory(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    Console.WriteLine($"Папка:{directory.Name}");
                    Console.WriteLine("Подкаталоги:");
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (string s in dirs)
                        Console.WriteLine(s);
                }
                else
                    Console.WriteLine("Каталога по такому пути не существует...");

                Observe("Пользователь использовал класс  DISDirinfo и метод ListOfDirectory, чтобы просмотреть подкаталоги.");
            }

            public static void ParentDirectory(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    Console.WriteLine($"Папка:{directory.Name}");
                    Console.WriteLine($"Родительский каталог:{directory.Parent}");
                }
                else
                    Console.WriteLine("Каталога по такому пути не существует...");

                Observe("Пользователь использовал класс  DISDirinfo и метод ParentDirectory, чтобы просмотреть родительский каталог.");
            }

            public static void NumberOfFiles(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    int counter = 0;
                    Console.WriteLine($"Папка:{directory.Name}");
                    Console.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(path);
                    foreach (string s in files)
                    {
                        Console.WriteLine(s);
                        counter++;
                    }
                    Console.WriteLine($"Общее количество файлов в папке:{counter}");
                }
                else
                    Console.WriteLine("Каталога по такому пути не существует...");

                Observe("Пользователь использовал класс  DISDirinfo и метод NumberOfFiles, чтобы просмотреть общее количество файлов в папке.");
            }

            public static void CreationTime(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    Console.WriteLine($"Папка:{directory.Name}");
                    Console.WriteLine($"Дата создания:{directory.CreationTime}");
                }
                else
                    Console.WriteLine("Каталога по такому пути не существует...");

                Observe("Пользователь использовал класс  DISDirinfo и метод CreationTime, чтобы узнать дату создания папки.");
            }
        }

        public static class DUKFileManager
        {
            public static void Task_a()
            {
                string path1 = "D:\\VisualStudio\\OOP";
                string path2 = "D:\\VisualStudio\\OOP\\DukInspect";
                string path3 = "D:\\VisualStudio\\OOP\\DukInspect\\DukDirinfo.txt";
                string copyPath = "D:\\VisualStudio\\OOP\\DukInspect\\DukDirinfoCopiedAndRenamed.txt";

                if (Directory.Exists(path1))
                {
                    Console.WriteLine("Каталоги:");
                    string[] dirs = Directory.GetDirectories(path1);
                    foreach (string s in dirs)
                        Console.WriteLine(s);
                    Console.WriteLine();
                    Console.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(path1);
                    foreach (string s in files)
                        Console.WriteLine(s);
                }

                DirectoryInfo newDir = new DirectoryInfo(path2);
                if (!newDir.Exists)
                {
                    newDir.Create();
                    Console.WriteLine("Новая папка успешно создана");
                }

                try
                {
                    string[] dirs = Directory.GetDirectories(path1);
                    string[] files = Directory.GetFiles(path1);
                    using (StreamWriter sw = new StreamWriter(path3, true, Encoding.Default))
                    {
                        sw.WriteLine("Информация по диску D:");
                        sw.WriteLine("Каталоги:");
                        foreach (string s in dirs)
                            sw.WriteLine(s);
                        sw.WriteLine("Файлы:");
                        foreach (string s in files)
                            sw.WriteLine(s);
                    }
                    Console.WriteLine("Запись выполнена");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                FileInfo file = new FileInfo(path3);
                if (file.Exists)
                {
                    file.CopyTo(copyPath);
                    file.Delete();
                    Console.WriteLine("Файл скопирован и удалён");
                }

                Observe("Пользователь использовал класс  DUKFileManager и метод Task_a.");
            }

            public static void Task_b(string path)
            {
                string path1 = "D:\\VisualStudio\\OOP\\DukFiles";
                string path2 = "D:\\VisualStudio\\OOP\\DukInspect\\DukFiles";
                DirectoryInfo newDir = new DirectoryInfo(path1);
                if (!newDir.Exists)
                {
                    newDir.Create();
                    Console.WriteLine("Новая папка успешно создана");
                }

                DirectoryInfo dir = new DirectoryInfo(path);

                if (dir.Exists)
                    foreach (FileInfo item in dir.GetFiles())
                        if (item.Name.Contains(".docx"))
                            item.CopyTo($"D:\\VisualStudio\\OOP\\DukFiles\\{item.Name}");

                DirectoryInfo directory = new DirectoryInfo(path1);

                if (directory.Exists)
                {
                    directory.MoveTo(path2);
                    Console.WriteLine("Перемещение прошло успешно");
                }
                Observe("Пользователь использовал класс  DUKFileManager и метод Task_b.");
            }

            public static void Task_c()
            {

                string path1 = "D:\\VisualStudio\\OOP\\DukInspect\\DukFiles";
                string path2 = "D:\\VisualStudio\\OOP\\DukInspect\\DukFiles\\compress.gz";
                DirectoryInfo dir = new DirectoryInfo(path1);
                foreach (FileInfo file in dir.GetFiles())
                {
                    // поток для чтения исходного файла
                    using (FileStream sourceStream = new FileStream(file.FullName, FileMode.OpenOrCreate))
                    {
                        // поток для записи сжатого файла
                        using (FileStream targetStream = File.Create(path2))
                        {
                            // поток архивации
                            using (GZipStream gz = new GZipStream(targetStream, CompressionMode.Compress))
                            {
                                sourceStream.CopyTo(gz);
                                Console.WriteLine($"Сжатие файла {file.FullName} завершено. Исходный размер: {sourceStream.Length.ToString()}  сжатый размер: {targetStream.Length.ToString()}.");
                            }
                        }
                    }
                }

                string path3 = "D:\\VisualStudio\\OOP\\DukInspect\\DukFiles";
                DirectoryInfo directory = new DirectoryInfo(path1);
                foreach (FileInfo file in directory.GetFiles())
                    if (file.Name.Contains(".docx"))
                    {
                        using (FileStream sourceStream = new FileStream(path2, FileMode.OpenOrCreate))
                        {
                            // поток для записи восстановленного файла
                            using (FileStream targetStream = File.Create($"{path3}\\{file.Name}"))
                            {
                                // поток разархивации
                                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                                {
                                    decompressionStream.CopyTo(targetStream);
                                    Console.WriteLine("Восстановлен файл: {0}", path2);
                                }
                            }
                        }
                    }
                Observe("Пользователь использовал класс  DUKFileManager и метод Task_c.");
            }
        }

        public static class ForObserver
        {
            private const string path = "D:\\VisualStudio\\OOP\\observer.txt";
            public static void ObservActiones()
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251)))
                    {
                        Console.WriteLine("Введите дату для поиска:");
                        string date = Console.ReadLine();
                        string line = "";
                        string line_1 = "";
                        string line_2 = "";
                        string line_3 = "";
                        int number = 0;
                        int checker = 0;
                        int counter = 1;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (counter == 1)
                                line_1 = line;

                            if (counter == 2)
                                line_2 = line;

                            if (counter == 3)
                            {
                                line_3 = line;
                                if (line_3.Contains(date))
                                {
                                    Console.WriteLine("Найдена запись:");
                                    Console.WriteLine(line_1);
                                    Console.WriteLine(line_3);
                                    number++;
                                    checker++;
                                }
                            }
                            counter++;
                            if (counter > 3)
                                counter = 1;
                        }

                        if (checker == 0)
                            Console.WriteLine("В эту дату не было произведено никаких действий.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
