﻿using System;
using System.IO;
using System.Threading;

namespace FilesSearch
{
    class SearchByName: SearchController
    {
        private FileInfo[] files = new FileInfo[999];

        private string fileName;
        
        private int amountOfFiles = 0;
        private int selectedOption = 0;

        private string header;
        private string text;

        private bool isFileFounded = false;

        public void Display()
        {
            MenuBuilder.WriteHeader("Пошук за іменем файлу");

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
            Console.Write("\n@--> Введіть ім'я файлу: ");
            fileName = Console.ReadLine();

            if (fileName.Replace(" ", "") == "")
            {
                throw new Exception(ExceptionMessages.EmptyField);
            }

            header = $"Пошук файлів за іменем: ~ {fileName} ~";
        }

        private void SearchFiles()
        {
            string[] allFoundFiles = Directory.GetFiles(PathToFolder, fileName + "*", SearchOption.AllDirectories);
            for (int index = 0; index < allFoundFiles.Length; index++)
            {
                files[index] = new FileInfo(allFoundFiles[index]);
                amountOfFiles++;
            }
            if(amountOfFiles != 0)
            {
                isFileFounded = true;
            }
        }
    }
}
