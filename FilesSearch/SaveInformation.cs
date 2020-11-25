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
        private int selectionOption = 0;

        private string path = "E:\\TermPaper";
        private string subPath = "SavedFiles";
        private string mainPath;

        private StreamWriter sw;

        private string header;
        private string text;

        public SaveInformation(string header, string text)
        {
            this.header = header;
            this.text = text;

            mainPath = path + "\\" + subPath + "\\Log.txt";
            selectionOption = MenuBuilder.MultipleChoice(
                "\n=== Шлях збереження ===\n",
                "",
                "Використати стандартний шлях (E:\\TermPaper)", 
                "Вказати власний шлях");

            if(selectionOption == 1)
            {
                SetPath();
            }
            CreateFolder();
            SaveResult();

            MainMenu menu = new MainMenu();
        }
        private void SaveResult()
        {
            sw = new StreamWriter(mainPath, true, System.Text.Encoding.Default);
            sw.WriteLine(
                $" ###  {header} ###\n {text}");
            sw.Close();

            Console.WriteLine("Результати пошуку успішно збережино. Натисніть Enter щоб продовжити.");
        }

        private void CreateFolder()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            dirInfo.CreateSubdirectory(subPath);
        }
        private void SetPath()
        {
            path = Console.ReadLine();
        }
    }
}
