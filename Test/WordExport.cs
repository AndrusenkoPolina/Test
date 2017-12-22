﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace Test
{
    public class WordExport
    {
        private readonly string TemplateFileName = @"C:\Users\Полина\Desktop\Курсовая работа\Test\Отчёт.docx";
        public void GetWord(List<object> result)
        {
            var res = (Result)result[0];
                string type = res.type;
                string name = res.name;
                string type_name = type + " " + name;
                string resulttest = res.result;
                string Indicator11 = ((int)result[1] * 10).ToString();
                string Indicator21 = ((int)result[2] * 5).ToString(); ;
                string Indicator31 = ((int)result[3] * 5).ToString();
                string Indicator41 = ((int)result[4] * 5).ToString();
            //Оболочка word, которая будет сама по себе создавать себе документ

            var wordApp = new Word.Application();
            wordApp.Visible = false; //чтобы в процессе экспорта не видеть перекидывание данныых
            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName); //получаем доступ к файлу
                ReplaceWordStub("{type_name}", type_name, wordDocument);
                ReplaceWordStub("{result}", resulttest, wordDocument);
                ReplaceWordStub("{Indicator11}", Indicator11, wordDocument);
                ReplaceWordStub("{Indicator21}", Indicator21, wordDocument);
                ReplaceWordStub("{Indicator31}", Indicator31, wordDocument);
                ReplaceWordStub("{Indicator41}", Indicator41, wordDocument);

                wordDocument.SaveAs(@"C:\Users\Полина\Desktop\Курсовая работа\Test\Результат.docx");
                wordApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }

        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;//диапозон поиска(весь текст)
            range.Find.ClearFormatting(); //Отчистка поисков до этого совершённых
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);//Выбираем нужные параметры: то что мы хотим найти и то, чем заменить.
        }
    }
}