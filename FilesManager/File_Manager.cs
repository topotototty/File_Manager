using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager
{
    public static class File_Manager
    {
        public static void Menu()
        {
            Console.CursorVisible = false;
            int selection = 0;

            while (true)
            {
                Console.WriteLine("Выберите диск. Переход к опциям: F1");
                DriveInfo[] drives = DriveInfo.GetDrives();

                for (int i = 0; i < drives.Length; i++)
                {
                    if (i == selection)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($" {drives[i].Name}" + $"      Свободное пространство: {drives[i].AvailableFreeSpace / 1024 / 1024 / 1024} ГБ\n" + $"          Тотал сайз: {drives[i].TotalSize / 1024 / 1024 / 1024} ГБ ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($" {drives[i].Name}");
                    }
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F1:
                        Options options = new Options();
                        options.Coise();
                        break;
                    case ConsoleKey.DownArrow:
                        if (selection + 1 < drives.Length)
                        {
                            selection++;
                            if (selection == drives.Length)
                            {
                                selection = 0;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (selection > 0)
                        {
                            selection--;
                        }
                        break;
                    case ConsoleKey.Enter:

                        Console.Clear();
                        FileSystemInfo[] infos = drives[selection].RootDirectory.GetFileSystemInfos();
                        string currentDirectory = drives[selection].Name;
                        selection = 0;
                        bool exit = false;
                        while (!exit)
                        {
                            Console.WriteLine("  Текущая директория: " + currentDirectory);
                            for (int i = 0; i < infos.Length; i++)
                            {
                                if (i == selection)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine($"  {infos[i].Name}       Время создания: {infos[i].CreationTime}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine($"  {infos[i].Name}");
                                }
                            }
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.DownArrow:
                                    if (selection + 1 < infos.Length)
                                    {
                                        selection++;
                                        if (selection == infos.Length)
                                        {
                                            selection = 0;
                                        }
                                    }
                                    break;
                                case ConsoleKey.UpArrow:
                                    if (selection > 0)
                                    {
                                        selection--;
                                    }
                                    break;
                                case ConsoleKey.Enter:
                                    {
                                        FileSystemInfo fileSystemInfo = infos[selection];
                                        if (fileSystemInfo is DirectoryInfo directory)
                                        {
                                            currentDirectory = directory.FullName;
                                            infos = directory.GetFileSystemInfos();
                                            selection = 0;
                                        }
                                        else
                                        {
                                            Process.Start(new ProcessStartInfo($"{fileSystemInfo.FullName}") { UseShellExecute = true });
                                        }
                                    }
                                    break;
                                case ConsoleKey.Escape:
                                    {
                                        DirectoryInfo directory = Directory.GetParent(currentDirectory);
                                        if (directory == null)
                                        {
                                            exit = true;
                                        }
                                        else
                                        {
                                            infos = directory.GetFileSystemInfos();
                                            currentDirectory = directory.FullName;
                                        }
                                        selection = 0;
                                    }
                                    break;
                            }
                            Console.Clear();
                        }
                        break;
                }
                Console.Clear();
            }
        }
    }
}
