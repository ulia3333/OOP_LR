using System;

namespace LR_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя диска (напимер D, C...):");
            string DriveName = Console.ReadLine();

            DUKLog.DUKDiskInfo.ShowFreeSpace(DriveName);
            DUKLog.DUKDiskInfo.ShowFileSystem(DriveName);
            DUKLog.DUKDiskInfo.AllInfo();

            Console.WriteLine("Введите путь к файлу по которому будем получать информацию:");
            string path1 = Console.ReadLine();
            DUKLog.DUKFileInfo.ShowFilePath(path1);
            DUKLog.DUKFileInfo.ShowFileSizeExtAndName(path1);
            DUKLog.DUKFileInfo.ShowCreationTime(path1);

            Console.WriteLine("Введите путь к папке по которой будем получать информацию:");
            string path2 = Console.ReadLine();
            DUKLog.DUKDirInfo.NumberOfFiles(path2);
            DUKLog.DUKDirInfo.ListOfDirectory(path2);
            DUKLog.DUKDirInfo.ParentDirectory(path2);

            DUKLog.DUKFileManager.Task_a();


            Console.WriteLine("Введите путь к папке, из которой будут скопированы все файлы с расширением docx:");
            string path3 = Console.ReadLine();

            DUKLog.DUKFileManager.Task_b(path3);

            DUKLog.DUKFileManager.Task_c();

            DUKLog.ForObserver.ObservActiones();
        }
    }
}
