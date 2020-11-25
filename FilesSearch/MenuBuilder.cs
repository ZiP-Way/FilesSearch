using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    static class MenuBuilder
    {
        static public int MultipleChoice(string header, string text, params string[] options)
        {
            int currentSelection = 0;

            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                Console.Clear();

                if (header != "")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(header);
                    Console.ResetColor();
                }
                if (text != "")
                {
                    Console.WriteLine(text);
                }
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" -> \t" + options[i].ToUpper());
                    }
                    else
                    {
                        Console.WriteLine("\t" + options[i]);
                    }

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (currentSelection > 0)
                    {
                        currentSelection--;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (currentSelection < options.Length - 1)
                    {
                        currentSelection++;
                    }
                }
            } while (key != ConsoleKey.Enter);
            Console.CursorVisible = true;
            Console.Clear();

            return currentSelection;
        }
    }
}
