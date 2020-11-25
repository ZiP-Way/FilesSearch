using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    static class SortingFiles
    {
        public static void SortingBySize(ref FileInfo[] files, int amountOfFiles)
        {
            for (int i = 0; i < amountOfFiles; i++)
            {
                for (int j = 0; j < amountOfFiles - 1; j++)
                {
                    if (files[j].Length > files[j + 1].Length)
                    {
                        FileInfo temp = files[j];
                        files[j] = files[j + 1];
                        files[j + 1] = temp;
                    }
                }
            }
        }

        public static void SortingByName(ref FileInfo[] files, int amountOfFiles)
        {
            for(int i = 0; i < amountOfFiles; i++)
            {
                for(int j = 0; j < amountOfFiles - 1; j++)
                {
                    if(NeedToReOrder(files[j].Name, files[j + 1].Name))
                    {
                        FileInfo temp = files[j];
                        files[j] = files[j + 1];
                        files[j + 1] = temp;
                    }
                }
            }
        }

        private static bool NeedToReOrder(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }
    }
}
