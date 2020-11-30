using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    static class MenuBuilder
    {
        static public int MultipleChoice(int x, int y, string header, string text, params string[] options)
        {
            int currentSelection = 0;

            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                Console.Clear();

                if (header != "")
                {
                    WriteHeader(header);
                }
                if (text != "")
                {
                    Console.WriteLine($"{text}");
                }


                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(x, y+i);
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"~~~ {options[i].ToUpper()} ~~~");
                    }
                    else
                    {
                        Console.WriteLine($"    {options[i]}");
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

        static public void WriteHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\t  === ===%");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" {header} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("%=== ===");
            Console.ResetColor();
        }
    }
}
