using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class SearchBySize : SearchController
    {
        private FileInfo[] files = new FileInfo[999];

        private string header;
        private string text;

        private int amountOfFiles = 0;
        private int selectedOption = 0;

        private bool isFileFounded = false;

        private string strMinSize;
        private string strMaxSize;

        private int minSize = 0;
        private int maxSize = 0;

        public void Display()
        {
            MenuBuilder.WriteHeader("Пошук файлів за розміром");

            if (!isFileFounded)
            {
                FileSizeInput();
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

        private void FileSizeInput()
        {
            Console.WriteLine("\n @--> Вкажіть розмір файлу.");

            Console.WriteLine(" @--> Від: ");
            Console.WriteLine(" @--> До: ");

            Console.SetCursorPosition(12, 4);
            strMinSize = Console.ReadLine();

            if (strMinSize == "") throw new Exception(ExceptionMessages.EmptyField);
            else minSize = Convert.ToInt32(strMinSize);

            Console.SetCursorPosition(12, 5);
            strMaxSize = Console.ReadLine();

            if (strMaxSize == "") maxSize = int.MaxValue;
            else maxSize = Convert.ToInt32(strMaxSize);


            header = $"Пошук файлів за розміром: ~ Від: {minSize} б. До: {maxSize} б. ~";
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

                if (file.Length >= minSize && file.Length <= maxSize)
                {
                    files[amountOfFiles] = new FileInfo(allFoundFiles[index]);
                    amountOfFiles++;
                }
            }
        }
    }
}
