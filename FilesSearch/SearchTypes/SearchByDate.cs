using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class SearchByDate: SearchController
    {
        private FileInfo[] files = new FileInfo[999];
        private DateTime fileDateTime;

        private string header;
        private string text;

        private int amountOfFiles = 0;
        private int selectedOption = 0;

        private bool isFileFounded = false;

        public void Display()
        {
            if (!isFileFounded)
            {
                FileDateInput();
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

        private void SearchFiles()
        {
            string[] allFoundFiles = Directory.GetFiles(PathToFolder, "*", SearchOption.AllDirectories);
            if (allFoundFiles.Length != 0)
            {
                isFileFounded = true;
            }
            for (int index = 0; index < allFoundFiles.Length; index++)
            {
                FileInfo file = new FileInfo(allFoundFiles[index]);

                if (file.CreationTime >= fileDateTime)
                {
                    files[amountOfFiles] = new FileInfo(allFoundFiles[index]);
                    amountOfFiles++;
                }
            }
        }
        private void FileDateInput()
        {
            string fileDate;

            Console.Write("Дата створення: ");
            fileDate = Console.ReadLine();

            string[] dates = fileDate.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            fileDateTime = new DateTime(Convert.ToInt32(dates[0]), Convert.ToInt32(dates[1]), Convert.ToInt32(dates[2]));

            header = $"Пошук файлів за датою: ~ {fileDateTime.ToShortDateString()} б. ~";
        }
    }
}
