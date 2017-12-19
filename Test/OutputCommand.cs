using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test;

namespace Test
{

    public class OutputCommand : ICommand
    {
        public OutputCommand(int count)
        {

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            var vmsort = parameter as QuestionsViewModel;
            if (vmsort == null)
                throw new ArgumentNullException("Модель представления не может быть null!");

            
            var sort = vmsort.Questions;
            ObservableCollection<QuestionViewModel> SortQuestion = new ObservableCollection<QuestionViewModel>();
            for (int  i = 0; i < 5; i++)
            {
                SortQuestion.Add(sort[i]);
            }

            var prop = parameter.GetType().GetProperty("SortQuestion",
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);

            prop.SetValue(parameter, SortQuestion);

            var meth = parameter.GetType().GetMethod("DoPropertyChanged");
            if (meth != null)
            {
                Object[] parameters = new object[] { "SortQuestion" };
                meth.Invoke(parameter, parameters);
            }


        }

        public event EventHandler CanExecuteChanged;

    }
}

