using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilesSearch
{
    class AboutAuthor
    {
        private  ConsoleColor[] colors = new ConsoleColor[10];
        private  Random rndNum = new Random();
        private ConsoleKey key;

        private string aboutAuthorText;
        private int index = 0;

        public AboutAuthor()
        {
            Console.CursorVisible = false;
            colors[0] = ConsoleColor.Red;
            colors[1] = ConsoleColor.Yellow;
            colors[2] = ConsoleColor.Blue;
            colors[3] = ConsoleColor.Gray;
            colors[4] = ConsoleColor.Green;
            colors[5] = ConsoleColor.Magenta;
            colors[6] = ConsoleColor.Cyan;
            colors[7] = ConsoleColor.DarkGray;
            colors[8] = ConsoleColor.DarkBlue;
            colors[9] = ConsoleColor.DarkYellow;

            ShowInformation();
        }
        private void ShowInformation()
        {
            while (true)
            {
                Console.ForegroundColor = colors[rndNum.Next(0, 10)];
                if (index == 0)
                {
                    aboutAuthorText += "\n• Зинич Максим Миколайович";
                }
                else if (index == 1)
                {
                    aboutAuthorText += "\n• Студент ВСП ЛФК ХПП НУХТ";
                }
                else if (index == 2)
                {
                    aboutAuthorText += "\n• Група ПК-3";
                }
                else if (index == 3)
                {
                    aboutAuthorText += "\n• zip.way.dev@gmail.com";
                }
                else if (index == 6)
                {
                    Console.WriteLine("\n ~~~ Натисніть Enter щоб повернутись до головно меню ~~~");

                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Enter)
                    {
                        MainMenu mainMenu = new MainMenu();
                        break;
                    }
                }

                Console.WriteLine(aboutAuthorText);
                index++;

                Thread.Sleep(500);
                if(index != 6)
                    Console.Clear();
            }
        }
    }
}