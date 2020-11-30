using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class SearchByAttributes : SearchController
    {
        private FileInfo[] files = new FileInfo[999];
        FileAttributes selectedAttribute;
        
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
            string[] allFoundFiles = Directory.GetFiles(PathToFolder, "*", SearchOption.AllDirectories);
            if (allFoundFiles.Length != 0)
            {
                isFileFounded = true;
            }
            for (int index = 0; index < allFoundFiles.Length; index++)
            {
                FileInfo file = new FileInfo(allFoundFiles[index]);

                FileAttributes fileAttributes = File.GetAttributes(file.FullName);
                if ((fileAttributes & selectedAttribute) == selectedAttribute)
                {
                    files[amountOfFiles] = new FileInfo(allFoundFiles[index]);
                    amountOfFiles++;
                }
            }
        }
        private void FileAttributeInput()
        {
            int x = 17, y = 3;

            selectedOption = MenuBuilder.MultipleChoice(
                x,
                y,
                "Виберіть потрібний вам пункт",
                "",
                "     Сховані файли     ",
                "     Системні файли     ",
                "    Архівовані файли    ",
                "Файли тільки для читання");

            if (selectedOption == 0)
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
            
            header = $"Пошук файлів з атрибутом: {selectedAttribute}";
        }
    }
}
