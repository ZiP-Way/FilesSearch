using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class SaveInformation
    {
        private string subPath = "SavedFiles";
        private string mainPath;

        private StreamWriter sw;

        private string header;
        private string text;

        public SaveInformation(string header, string text)
        {
            this.header = header;
            this.text = text;

            SearchController.SetPathToFolder();
            
            mainPath = SearchController.PathToFolder + "\\" + subPath + "\\Log.txt";

            CreateFolder();
            SaveResult();

            MainMenu menu = new MainMenu();
        }
        private void SaveResult()
        {
            sw = new StreamWriter(mainPath, true, System.Text.Encoding.Default);
            sw.WriteLine(
                $" ###  {header} ###\n ### Дата збереження: {DateTime.Now} ###\n {text}");
            sw.Close();

            MessageAfterSaving();
        }

        private void CreateFolder()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(SearchController.PathToFolder);
            dirInfo.CreateSubdirectory(subPath);
        }

        private void MessageAfterSaving()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(2,2);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Результати пошуку успішно збережено.");

            Console.SetCursorPosition(2, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Натисніть");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" Enter ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("щоб повернутись до головного меню.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
