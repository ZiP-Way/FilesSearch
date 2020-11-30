using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch.SearchTypes
{
    class SearchByExtension : SearchController
    {
        private FileInfo[] files = new FileInfo[999];

        private string fileExtansion;

        private int amountOfFiles = 0;
        private int selectedOption = 0;

        private string header;
        private string text;

        private bool isFileFounded = false;

        public void Display()
        {
            MenuBuilder.WriteHeader("Пошук файлів за розширенням імен");

            if (!isFileFounded)
            {
                FileNameInput();
                SearchFiles();
            }

            ShowFiles(ref text, amountOfFiles, files);
            MenuAfterSearch(ref selectedOption, header, text);

            if (selectedOption == 0)
            {
                SortingFiles.SortingByName(ref files, amountOfFiles);
                Display();
            }
            else if (selectedOption == 1)
            {
                SortingFiles.SortingBySize(ref files, amountOfFiles);
                Display();
            }
            else if (selectedOption == 2)
            {
                SaveInformation saveInfo = new SaveInformation(header, text);
                amountOfFiles = 0;
            }
            else if (selectedOption == 3)
            {
                MainMenu menu = new MainMenu();
            }
        }

        private void FileNameInput()
        {
            Console.Write("\n@--> Введіть розширення імені файлу: ");
            fileExtansion = Console.ReadLine();

            if (fileExtansion == "")
            {
                throw new FormatException();
            }

            SetDotInText(ref fileExtansion);

            header = $"Пошук файлів за розширенням імен: ~ {fileExtansion} ~";
        }

        private void SearchFiles()
        {
            string[] allFoundFiles = Directory.GetFiles(PathToFolder, "*" + fileExtansion, SearchOption.AllDirectories);
            for (int index = 0; index < allFoundFiles.Length; index++)
            {
                files[index] = new FileInfo(allFoundFiles[index]);
                amountOfFiles++;
            }
        }

        private void SetDotInText(ref string fileExtansion)
        {
            if(fileExtansion[0] != '.')
            {
                fileExtansion = "." + fileExtansion;
            }
        }
    }
}
