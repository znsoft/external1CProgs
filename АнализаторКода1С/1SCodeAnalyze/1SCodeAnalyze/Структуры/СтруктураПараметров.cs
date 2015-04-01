using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1SCodeAnalyze
{
    class СтруктураПараметров
    {
        
		//     Параметры = Новый Структура("ТаблицаОшибок, ИмяФайла, Текст, Проблема, ЕстьОшибки, Косяк, Вложенность, Смещение, Match", ТаблицаОшибок, ФайлПроверки.ИмяБезРасширения, ТекстовыйФайл.ПолучитьТекст(), "Запрос в цикле",Ложь,"",0,0);
		public List<ИнформацияАнализа> ТаблицаОшибок;
		public string ИмяФайла;
		public String Текст;
		public int Смещение;
		public Boolean ЕстьОшибки;
		public List<String> ФункцииСЗапросами;


    }
}
