    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class MainMenu
    {
        private SearchController search = new SearchController();

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
                    if (!SearchController.IsPathSet)
                    {
                        search.SetPathToFolder();
                        SearchMenu();
                    }
                    else if (SearchController.IsPathSet)
                    {
                        SearchMenu();
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
        private void SearchMenu()
        {
            selectedOption = MenuBuilder.MultipleChoice(
                            "Меню пошуку",
                            "",
                            "Розширений пошук",
                            "Вибірковий пошук",
                            "Повернутися до меню");
            if (selectedOption == 0)
            {

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
                if (selectedOption == 0)
                {
                    SearchByName searchByName = new SearchByName();
                    searchByName.Display();
                }
                else if (selectedOption == 1)
                {
                    SearchBySize searchBySize = new SearchBySize();
                    searchBySize.Display();
                }
                else if (selectedOption == 2)
                {
                    SearchByDate searchByDate = new SearchByDate();
                    searchByDate.Display();
                }
                else if (selectedOption == 3)
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
    }
}
