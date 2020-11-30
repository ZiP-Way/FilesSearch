using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    static class ExceptionMessages
    {
        static public string FileNotFound {
            get
            {
                return "Файлів не знайдено!";
            }
        }

        static public string EmptyField
        {
            get
            {
                return "Поле не може бути пустим!";
            }
        }
        static public string WrongPath
        {
            get
            {
                return "Шлях до папки неправильний!";
            }
        }

        static public string WrongDate
        {
            get
            {
                return "Неправильно вказана дата!";
            }
        }
    }
}
