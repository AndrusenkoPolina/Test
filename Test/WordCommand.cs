using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Test
{
    public class WordCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {

            if (parameter == null)
                throw new ArgumentNullException("Модель представления не может быть null!");

            var vmsort = parameter as QuestionsViewModel;
            //REVIEW:А если тип не совпал?
            if (vmsort.ContentButton == "Выход")
            {
                WordExport wex = new WordExport();
                wex.GetWord(vmsort.forWord);
            }
            else
            {
                MessageBox.Show("Для отчёта требуется пройти тест!");
            }
        }
        public event EventHandler CanExecuteChanged;
    }
}
