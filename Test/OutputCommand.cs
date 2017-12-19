using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Test;

namespace Test
{

    public class OutputCommand : ICommand
    {
       
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var vmsort = parameter as QuestionsViewModel;
            if (vmsort == null)
                throw new ArgumentNullException("Модель представления не может быть null!");

            //Выдача вопросов по COUNT штук   
            var sort = vmsort.Questions;
            ObservableCollection<QuestionViewModel> SortQuestion = new ObservableCollection<QuestionViewModel>();
            const int COUNT = 5;
            int countfrom = new int();
            int countto = new int();
            countfrom = vmsort.count;
            countto = vmsort.count + COUNT;
            if (countfrom != sort.Count)
            {
                for (int i = countfrom; i < countto; i++)
                {
                    SortQuestion.Add(sort[i]);
                }
                var propcontent= parameter.GetType().GetProperty("ContentButton",
                    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                
                if (countto==sort.Count)
                {
                    propcontent.SetValue(parameter, "Результат");
                }
                else propcontent.SetValue(parameter, "Следующие");

                var propvis = parameter.GetType().GetProperty("GridVisibility",
                    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propvis.SetValue(parameter,"Visible");

                var propcount = parameter.GetType().GetProperty("count",
                    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propcount.SetValue(parameter, countto);

                var prop = parameter.GetType().GetProperty("SortQuestion",
                    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);

                prop.SetValue(parameter, SortQuestion);

                var meth = parameter.GetType().GetMethod("DoPropertyChanged");
                if (meth != null)
                {

                    object[] parContent = new object[] { "ContentButton" };
                    meth.Invoke(parameter, parContent);
                    object[] parVisibility = new object[] { "GridVisibility" };
                    meth.Invoke(parameter, parVisibility);
                    object[] parSort = new object[] { "SortQuestion" } ;
                    meth.Invoke(parameter, parSort);
                }
            }

        }

        public event EventHandler CanExecuteChanged;

    }
}

