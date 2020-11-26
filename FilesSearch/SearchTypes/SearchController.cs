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

        private int selectedOption = 0;

        public void SetPathToFolder()
        {
            selectedOption = MenuBuilder.MultipleChoice(
                "=== Шлях до папки ===\n",
                "",
                "Використати стандартний шлях (E:\\TermPaper)",
                "Вказати власний шлях");

            if (selectedOption == 0)
            {
                PathToFolder = @"E:\TermPaper";
            }
            else if (selectedOption == 1)
            {
                Console.Write("Введіть шлях до папки: ");
                PathToFolder = Console.ReadLine();
            }
            IsPathSet = true;

            if (!IsFolderExists(PathToFolder))
            {
                SetPathToFolder();
            }
        }

        private bool IsFolderExists(string path)
        {
            return Directory.Exists(path);
        }

        protected void MenuAfterSearch(ref int selectedOption, string header, string text)
        {
            selectedOption = MenuBuilder.MultipleChoice(
                header,
                text,
                "Сортування за назвою",
                "Сортування за розміром",
                "Зберегти результати пошуку",
                "Повернутись до головного меню");
        }
        protected void ShowFiles(ref string text, int amountOfFiles, FileInfo[] files)
        {
            text = "";
            for (int index = 0; index < amountOfFiles; index++)
            {
                text += $"\n - Назва: {files[index].Name} " +
                        $"\n - Розмір: {files[index].Length} б." +
                        $"\n - Дата створення: {files[index].CreationTime}" +
                        $"\n - Місце знаходження: {files[index].FullName} " +
                        "\n===============================\n";
            }
            Console.WriteLine(text);
        }
    }
}
