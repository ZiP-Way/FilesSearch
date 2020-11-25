using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class SearchByAttributes: MainSearch
    {
        private FileInfo[] files = new FileInfo[999];
        FileAttributes selectedAttribute;

        private string directory = @"E:\TermPaper";
        private string header;
        private string text;

        private int amountOfFiles = 0;
        private int selectedOption = 0;

        private bool isFileFounded = false;

        public void Display()
        {
            if (!isFileFounded)
            {
                FileAttributeInput();
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
            string[] allFoundFiles = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            if (allFoundFiles.Length != 0)
            {
                isFileFounded = true;
            }
            for (int index = 0; index < allFoundFiles.Length; index++)
            {
                FileInfo file = new FileInfo(allFoundFiles[index]);
                if (selectedAttribute == 0)
                {
                    FileInfo[] reserve = new FileInfo[999];
                    int amountReservedFiles = 0;
                    for(int i = 0; i < allFoundFiles.Length; i++)
                    {
                        reserve[i] = new FileInfo(allFoundFiles[i]);
                        amountReservedFiles++;
                    }
                    FindDuplicates(reserve, amountReservedFiles);
                }
                else
                {
                    FileAttributes fileAttributes = File.GetAttributes(file.FullName);
                    if ((fileAttributes & selectedAttribute) == selectedAttribute)
                    {
                        files[amountOfFiles] = new FileInfo(allFoundFiles[index]);
                        amountOfFiles++;
                    }
                }
            }
        }
        private void FileAttributeInput()
        {
            selectedOption = MenuBuilder.MultipleChoice(
                "Виберіть потрібний вам пункт: ",
                "",
                "Сховані файли",
                "Файли тільки для читання",
                "Архівовані файли",
                "Системні файли",
                "Пошук дублікатів");
            if(selectedOption == 0)
            {
                selectedAttribute = FileAttributes.Hidden;
            }
            else if (selectedOption == 1)
            {
                selectedAttribute = FileAttributes.ReadOnly;
            }
            else if (selectedOption == 2)
            {
                selectedAttribute = FileAttributes.Archive;
            }
            else if (selectedOption == 3)
            {
                selectedAttribute = FileAttributes.System;
            }
            else if (selectedOption == 4)
            {
                selectedAttribute = 0;
                header = $"Пошук дублікатів";
                return; // Exit from function
            }
            header = $"Пошук файлів з атрибутом: {selectedAttribute}";
        }

        private void FindDuplicates(FileInfo[] allFoundedFiles, int amountReserveredFiles)
        {
            for(int i = 0; i < amountReserveredFiles; i++)
            {
                for(int j = 0; j < amountReserveredFiles; j++)
                {
                    if(j == i)
                    {
                        continue;
                    }

                    if(allFoundedFiles[i].Name == allFoundedFiles[j].Name)
                    {
                        files[amountOfFiles] = allFoundedFiles[i];
                        amountOfFiles++;
                    }
                }
            }
        }
    }
}
