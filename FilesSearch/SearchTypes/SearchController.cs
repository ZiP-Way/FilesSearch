using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class SearchController
    {
        public static string PathToFolder { get; private set; }
        public static bool IsPathSet { get; private set; }

        private static int selectedOption = 0;

        public static void SetPathToFolder()
        {
            int x = 1, y = 3;
            selectedOption = MenuBuilder.MultipleChoice(
                x,
                y,
                "Шлях до папки",
                "",
                "Використати стандартний шлях (E:\\TermPaper)",
                "           Вказати власний шлях           ");

            if (selectedOption == 0)
            {
                PathToFolder = @"E:\TermPaper";
            }
            else if (selectedOption == 1)
            {
                Console.SetCursorPosition(2,2);
                Console.Write("@--> Введіть шлях до папки: ");
                PathToFolder = Console.ReadLine();

                if (!Directory.Exists(PathToFolder))
                {
                    throw new Exception(ExceptionMessages.WrongPath);
                }
            }
            IsPathSet = true;
        }

        protected void MenuAfterSearch(ref int selectedOption, string header, string text)
        {
            int x = 10;
            int y = Console.CursorTop;

            selectedOption = MenuBuilder.MultipleChoice(
                x, 
                y + 2,
                header,
                text,
                "    Сортування за назвою    ",
                "   Сортування за розміром   ",
                " Зберегти результати пошуку ",
                "Повернутись до головного меню");
        }
        protected void ShowFiles(ref string text, int amountOfFiles, FileInfo[] files)
        {
            FileAttributes fileAttributes;
            if (amountOfFiles == 0)
            {
                throw new Exception(ExceptionMessages.FileNotFound);
            }

            text = "";
            for (int index = 0; index < amountOfFiles; index++)
            {
                fileAttributes = File.GetAttributes(files[index].FullName);

                text += $"\n@@ == Назва: {files[index].Name} " +
                        $"\n@@ == Розмір: {files[index].Length} б." +
                        $"\n@@ == Атрибути: {fileAttributes}" +
                        $"\n@@ == Дата створення: {files[index].CreationTime}" +
                        $"\n@@ == Місце знаходження: {files[index].FullName}\n";
            }
            Console.WriteLine(text);
        }
    }
}
