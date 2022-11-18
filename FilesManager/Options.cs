using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager
{
    internal class Options
    {
        ConsoleKey Key_Pressed;
        public string path;
        public string path1;
        public string File_Name;
        public string Directory_Name;
        public void Coise()
        {

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("  Дополнительные опции.\n  Чтобы выйти из меню опций -- нажмите Escape\n ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  Создать файл - F2");
            Console.WriteLine("  Удалить файл - F3");
            Console.WriteLine("  Создать директорию - F4");
            Console.WriteLine("  Удалить директорию - F5");
            Console.ResetColor();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                //Создание файла
                if (key.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Console.WriteLine("Укажите путь, где вы хотите создать файл: ");
                    path = Console.ReadLine();
                    Console.WriteLine("Укажите имя файла: ");
                    File_Name = Console.ReadLine();

                    File.Create(path + @"\" + File_Name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Файл успешно создан!!!");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                //Удаление файла
                else if (key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.WriteLine("Укажите путь до файла, который хотите удалить: ");
                    path = Console.ReadLine();

                    File.Delete(path);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Файл успешно удален!!!");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                //Создание папки
                else if (key.Key == ConsoleKey.F4)
                {
                    Console.Clear();
                    Console.WriteLine("Укажите путь,где вы хотите создать папку: ");
                    path = Console.ReadLine();
                    Console.WriteLine("Укажите имя папки: ");
                    Directory_Name = Console.ReadLine();

                    Directory.CreateDirectory(path + @"\" + Directory_Name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Папка успешно создана!!!");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                //Удаление папки
                else if (key.Key == ConsoleKey.F5)
                {
                    Console.Clear();
                    Console.WriteLine("Укажите путь до папки, которую хотите удалить: ");
                    path = Console.ReadLine();

                    //Удаляет со всеми вложеными папками и файлами
                    Directory.Delete(path, true);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Папка успешно удалена!!!");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;

                }

                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
