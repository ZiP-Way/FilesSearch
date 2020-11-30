using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch.SearchTypes
{
    class SearchByContent : SearchController
    {
        private FileInfo[] files = new FileInfo[999];

        private string fileContent;

        private int amountOfFiles = 0;
        private int selectedOption = 0;

        private string header;
        private string text;

        private bool isFileFounded = false;

        public void Display()
        {
            MenuBuilder.WriteHeader("Пошук за контентом у файлах");

            if (!isFileFounded)
            {
                FileContentInput();
                SearchContent();
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

        private void FileContentInput()
        {
            Console.Write("\n@--> Введіть слово(а) всередині файлу: ");
            fileContent = Console.ReadLine();

            if (fileContent.Replace(" ", "") == "")
            {
                throw new Exception(ExceptionMessages.EmptyField);
            }

            header = $"Пошук за контентом у файлах. Введені дані: ~ {fileContent} ~";
        }

        private void SearchContent()
        {
            string[] allFoundFiles = Directory.GetFiles(PathToFolder, "*", SearchOption.AllDirectories);
            for (int index = 0; index < allFoundFiles.Length; index++)
            {
                FileInfo reserveFile = new FileInfo(allFoundFiles[index]);

                StreamReader sr = new StreamReader(reserveFile.FullName, Encoding.Default);
                string s = sr.ReadToEnd();
                sr.Close();


                if (s.Contains(fileContent))
                {
                    files[amountOfFiles] = reserveFile;
                    amountOfFiles++;
                }

            }
        }
    }
}
