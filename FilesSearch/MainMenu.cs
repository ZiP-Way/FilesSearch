using FilesSearch.SearchTypes;
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
                int x = 15, y = 3;
                selectedOption = MenuBuilder.MultipleChoice(
                    x,
                    y,
                    "Головне меню",
                    "",
                    "Інструкція",
                    "Меню пошуку",
                    "Про автора",
                    "  Вихід  ");

                if (selectedOption == 1)
                {
                    if (!SearchController.IsPathSet)
                    {
                        SearchController.SetPathToFolder();
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
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error! Неправильно вказана дата. Введіть дату в форматі Year.Month(1-12).Day(1-31)");
            }
            catch (Exception ex)
            {
                Console.CursorVisible = false;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nMessage: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Натисніть");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" Enter ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("щоб повернутись до головного меню.");
                Console.ResetColor();

                Console.ReadKey();
                ShowMenu();
            }
        }
        private void SearchMenu()
        {
            int x = 5, y = 3;

            selectedOption = MenuBuilder.MultipleChoice(
                x,
                y,
                "Меню пошуку",
                "",
                "       Пошук дублікатів       ",
                "     Пошук за іменем файла     ",
                "    Пошук за розміром файла    ",
                "   Пошук за атрибутами файла   ",
                "  Пошук за контентом у файлах  ",
                " Пошук за датою створення файла ",
                "Пошук за розширенням імен файлів",
                "    Змінити шлях до папки    ",
                "     Повернутися до меню      ");
            if (selectedOption == 0)
            {
                SearchDyplicates searchDyplicates = new SearchDyplicates();
                searchDyplicates.Display();
            }
            else if (selectedOption == 1)
            {
                SearchByName searchByName = new SearchByName();
                searchByName.Display();
            }
            else if (selectedOption == 2)
            {
                SearchBySize searchBySize = new SearchBySize();
                searchBySize.Display();
            }
            else if (selectedOption == 3)
            {
                SearchByAttributes searchByAttributes = new SearchByAttributes();
                searchByAttributes.Display();
            }
            else if (selectedOption == 4)
            {
                SearchByContent searchByContent = new SearchByContent();
                searchByContent.Display();
            }
            else if (selectedOption == 5)
            {
                SearchByDate searchByDate = new SearchByDate();
                searchByDate.Display();
            }
            else if (selectedOption == 6)
            {
                SearchByExtension searchByExtension = new SearchByExtension();
                searchByExtension.Display();
            }
            else if (selectedOption == 7)
            {
                SearchController.SetPathToFolder();
                SearchMenu();
            }
            else if (selectedOption == 8)
            {
                ShowMenu();
            }
        }
    }
}
