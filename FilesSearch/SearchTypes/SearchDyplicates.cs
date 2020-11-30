using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch.SearchTypes
{
    class SearchDyplicates : SearchController
    {
        private FileInfo[] files = new FileInfo[999];

        private int amountOfFiles = 0;
        private int selectedOption = 0;

        private string header;
        private string text;

        private bool isFileFounded = false;

        public void Display()
        {
            if (!isFileFounded)
            {
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

        private void FindDuplicates(FileInfo[] allFoundedFiles, int amountReserveredFiles)
        {
            for (int i = 0; i < amountReserveredFiles; i++)
            {
                for (int j = 0; j < amountReserveredFiles; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    if (allFoundedFiles[i].Name == allFoundedFiles[j].Name)
                    {
                        files[amountOfFiles] = allFoundedFiles[i];
                        amountOfFiles++;
                    }
                }
            }
        }

        private void SearchFiles()
        {
            header = $"Пошук дублікатів.";

            string[] allFoundFiles = Directory.GetFiles(PathToFolder, "*", SearchOption.AllDirectories);
            if (allFoundFiles.Length != 0)
            {
                isFileFounded = true;
            }

            FileInfo[] reserve = new FileInfo[999];
            int amountReservedFiles = 0;
            for (int i = 0; i < allFoundFiles.Length; i++)
            {
                reserve[i] = new FileInfo(allFoundFiles[i]);
                amountReservedFiles++;
            }
            FindDuplicates(reserve, amountReservedFiles);
        }
    }
}
