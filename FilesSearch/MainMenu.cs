using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class MainMenu
    {
        private string fileName;
        private int fileSize;
        private DateTime fileDateTime;

        private int selectedOption;

        public MainMenu()
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            try
            {
                selectedOption = MenuBuilder.MultipleChoice(
                    "Головне меню", 
                    "", 
                    "Інструкція", 
                    "Меню пошуку", 
                    "Про автора", 
                    "Вихід");
                if (selectedOption == 1)
                {
                    selectedOption = MenuBuilder.MultipleChoice(
                        "", 
                        "", 
                        "Розширений пошук", 
                        "Вибірковий пошук", 
                        "Повернутися до меню");
                    if (selectedOption == 0)
                    {
                        //WriteMenu();

                        //fileName = FileNameInput();
                        //fileSize = FileSizeInput();
                        //fileDateTime = FileDateInput();
                        //SelectFileAttributes();
                    }
                    else if (selectedOption == 1)
                    {
                        selectedOption = MenuBuilder.MultipleChoice(
                            "",
                            "",
                            "Пошук за іменем файла", 
                            "Пошук за розміром файла", 
                            "Пошук за датою створення файла",
                            "Пошук за атрибутами файла");
                        if(selectedOption == 0)
                        {
                            SearchByName searchByName = new SearchByName();
                            searchByName.Display();
                        }else if(selectedOption == 1)
                        {
                            SearchBySize searchBySize = new SearchBySize();
                            searchBySize.Display();
                        }else if(selectedOption == 2)
                        {
                            SearchByDate searchByDate = new SearchByDate();
                            searchByDate.Display();
                        }else if(selectedOption == 3)
                        {
                            SearchByAttributes searchByAttributes = new SearchByAttributes();
                            searchByAttributes.Display();
                        }
                    }
                    else if (selectedOption == 2)
                    {
                        ShowMenu();
                    }
                }
                else if (selectedOption == 2)
                {
                    AboutAuthor aboutAuthor = new AboutAuthor();
                }
                else if (selectedOption == 3)
                {
                    Environment.Exit(0);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Неправильно заповнене поле!");
            }
            //catch (IndexOutOfRangeException)
            //{
            //    Console.WriteLine("Error! Введіть дату в форматі (Year.Month.Day)!");
            //}
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error! Неправильно вказана дата. Введіть дату в форматі Year.Month(1-12).Day(1-31)");
            }
            finally
            {
                Console.ReadKey();
            }
        }
        //private void WriteMenu()
        //{
        //    Console.WriteLine(
        //        $"Ім'я файлу: {fileName}" +
        //        $"\nРозмір файлу: {fileSize}" +
        //        $"\nДата створення: {fileDateTime}" +
        //        "\nДодаткові атрибути: ");
        //}
        //private string FileNameInput()
        //{
        //    string fileName;

        //    Console.SetCursorPosition(15, 0);
        //    fileName = Console.ReadLine();

        //    return fileName;
        //}

        //private int FileSizeInput()
        //{
        //    int fileSize;

        //    Console.SetCursorPosition(15, 1);
        //    fileSize = Convert.ToInt32(Console.ReadLine());

        //    return fileSize;
        //}

        //private DateTime FileDateInput()
        //{
        //    DateTime fileDateTime;
        //    string fileDate;

        //    Console.SetCursorPosition(15, 2);
        //    fileDate = Console.ReadLine();

        //    string[] dates = fileDate.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        //    fileDateTime = new DateTime(Convert.ToInt32(dates[0]), Convert.ToInt32(dates[1]), Convert.ToInt32(dates[2]));

        //    return fileDateTime;
        //}

        //private void SelectFileAttributes()
        //{
        //    MultipleChoice("Приховані файли", "Системні файли", "Файли тільки для читання", "Архівні файли", "Дублікати файлів", "Далі");
        //}
    }
}
