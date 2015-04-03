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
        public static Dictionary<String, Boolean> МетодыМодуля;

        public Модуль(FileInfo file)
        {
            this.file = file;
            Текст = СчитатьСодержимоеФайла(file);
            ЕстьОшибки = false;
            ТаблицаАнализа = new List<ИнформацияАнализа>();
            МетодыМодуля = new Dictionary<String, Boolean>();
        }

        public Модуль ДобавитьПроблему(String Проблема, int Index)
        {
            ТаблицаАнализа.Add(new ИнформацияАнализа(Index, Проблема, Проблема));
            ЕстьОшибки = true;
            return this;
        }

        public Модуль ДобавитьПроблему(ИнформацияАнализа Проблема)
        {
            ТаблицаАнализа.Add(Проблема);
            ЕстьОшибки = true;
            return this;
        }

        private String СчитатьСодержимоеФайла(FileInfo file)
        {
            var Str = file.OpenText();
            return Str.ReadToEnd();
        }

        public ИнформацияАнализа ПрямойЗапрос(String Текст, int Index)
        {
            var ПоискЗапроса = new Regex(@"^(?!\/\/)[^\/]*?\.(выполнить|найтипокоду|найтипореквизиту|найтипонаименованию)[\s]?\(", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match Найдены = ПоискЗапроса.Match(Текст);
            if (!Найдены.Success)
                return null;
            return new ИнформацияАнализа(Найдены.Index + Index, Найдены.Groups[1].Value, Найдены.Groups[1].Value);
        }

        public Boolean ЕстьЗапрос(String Текст, int Index)
        {
            ИнформацияАнализа Проблема = ПрямойЗапрос(Текст, Index);
            if (Проблема == null)
                return false;
            ДобавитьПроблему(Проблема);
            return true;
        }

        private void НайтиВсеФункцииИПроцедуры(String ИсходныйКод)
        {
            var ПоискФункций = new Regex(@"^(?!\/\/)[^\.\/]*?(procedur|functio|Процедур|Функци)[enая][\s]*?([А-Яа-яa-z0-9_]*?[\s]?\()[\S\s]*?(Конец|End)\1[enыи]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
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
