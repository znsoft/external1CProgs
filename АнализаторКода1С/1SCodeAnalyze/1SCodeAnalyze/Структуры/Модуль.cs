using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace _1SCodeAnalyze.Структуры
{
    class Модуль
    {
        public FileInfo file;
        public List<ИнформацияАнализа> ТаблицаАнализа;
        public String Текст;
        public Boolean ЕстьОшибки;
        //public static Dictionary<String, Boolean> Методы;

        public Модуль(FileInfo file)
        {
            this.file = file;
            Текст = СчитатьСодержимоеФайла(file);
            ЕстьОшибки = false;
            ТаблицаАнализа = new List<ИнформацияАнализа>();
          //  Методы = new Dictionary<String, Boolean>();
        }

        private String СчитатьСодержимоеФайла(FileInfo file)
        {
            var Str = file.OpenText();
            return Str.ReadToEnd();
        }

        private void НайтиВсеФункцииИПроцедуры(String ИсходныйКод)
        {
            //var ПоискФункций = new Regex(@"^(?!\/\/)[^\.\/]*?(procedur|functio|Процедур|Функци)[enая][\s]*?([А-Яа-яa-z0-9_]*?[\s]?\()([\S\s]*?)Конец\1[enыи]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            var ПоискФункций = new Regex(@"^(?!\/\/)[^\.\/]*?(procedur|functio|Процедур|Функци)[enая][\s]*?([А-Яа-яa-z0-9_]*?[\s]?\()[\S\s]*?(\/\/)?.*?\.(выполнить|найтипокоду|найтипореквизиту|найтипонаименованию)[\s]?\([\S\s]*?(Конец|End)\1[enыи]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection Найдены = ПоискФункций.Matches(ИсходныйКод);
            foreach (Match Функция in Найдены)
            {
                //foreach (Capture capture in Функция.Captures)
                //{
                Console.WriteLine("Index={0}, Groups={1}, Captures={2}\n{3}\n{4}", Функция.Index, Функция.Groups.Count, Функция.Captures.Count, Функция.Groups[2].Value, Функция.Groups[3].Value);
            }



        }

    }
}
