using DTO;
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


            if (vmsort.answerA1 == vmsort.answerB1 ||
                   vmsort.answerA2 == vmsort.answerB2 ||
                   vmsort.answerA3 == vmsort.answerB3 ||
                   vmsort.answerA4 == vmsort.answerB4 ||
                   vmsort.answerA5 == vmsort.answerB5)
            {
                MessageBox.Show("Вы ответили не на все вопросы!");
            }
            else
            {

                ObservableCollection<Question> SortQuestion = new ObservableCollection<Question>();
                const int COUNT = 5;
                int countfrom = new int();
                int countto = new int();

                QuestionsViewModel.answers.Add(vmsort.answerA1);
                QuestionsViewModel.answers.Add(vmsort.answerA2);
                QuestionsViewModel.answers.Add(vmsort.answerA3);
                QuestionsViewModel.answers.Add(vmsort.answerA4);
                QuestionsViewModel.answers.Add(vmsort.answerA5);

                var prop = parameter.GetType().GetProperty("SortQuestion",
                        BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);

                var propvis = parameter.GetType().GetProperty("GridVisibility",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);

                var propvisResult = parameter.GetType().GetProperty("ResultVisibility",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);

                var propcount = parameter.GetType().GetProperty("count",
                        BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);

                var propcontent = parameter.GetType().GetProperty("ContentButton",
                        BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);

                countfrom = vmsort.count;
                countto = vmsort.count + COUNT;
                if (countfrom != sort.Count)
                {
                    for (int i = countfrom; i < countto; i++)
                    {
                        SortQuestion.Add(sort[i]);
                    }
                    prop.SetValue(parameter, SortQuestion);
                    propvis.SetValue(parameter, "Visible");
                    propcount.SetValue(parameter, countto);
                    if (countto == sort.Count)
                    {
                        propcontent.SetValue(parameter, "Результат");
                    }

                    else propcontent.SetValue(parameter, "Следующие");
                }
                else
                {

                    propvis.SetValue(parameter, "Collapsed");
                    propvisResult.SetValue(parameter, "Visible");
                    propcontent.SetValue(parameter, "Выход");

                }


                #region set radioButton
                var propResetAnswerA1 = parameter.GetType().GetProperty("answerA1",
                        BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerA1.SetValue(parameter, false);

                var propResetAnswerB1 = parameter.GetType().GetProperty("answerB1",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerB1.SetValue(parameter, false);

                var propResetAnswerA2 = parameter.GetType().GetProperty("answerA2",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerA2.SetValue(parameter, false);

                var propResetAnswerB2 = parameter.GetType().GetProperty("answerB2",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerB2.SetValue(parameter, false);

                var propResetAnswerA3 = parameter.GetType().GetProperty("answerA3",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerA3.SetValue(parameter, false);

                var propResetAnswerB3 = parameter.GetType().GetProperty("answerB3",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerB3.SetValue(parameter, false);

                var propResetAnswerA4 = parameter.GetType().GetProperty("answerA4",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerA4.SetValue(parameter, false);

                var propResetAnswerB4 = parameter.GetType().GetProperty("answerB4",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerB4.SetValue(parameter, false);

                var propResetAnswerA5 = parameter.GetType().GetProperty("answerA5",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerA5.SetValue(parameter, false);

                var propResetAnswerB5 = parameter.GetType().GetProperty("answerB5",
                       BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                propResetAnswerB5.SetValue(parameter, false);
                #endregion

                #region DoPropertyChanged
                var meth = parameter.GetType().GetMethod("DoPropertyChanged");

                if (meth != null)
                {

                    object[] parRadioButtonA1 = new object[] { "answerA1" };
                    meth.Invoke(parameter, parRadioButtonA1);
                    object[] parRadioButtonA2 = new object[] { "answerA2" };
                    meth.Invoke(parameter, parRadioButtonA2);
                    object[] parRadioButtonA3 = new object[] { "answerA3" };
                    meth.Invoke(parameter, parRadioButtonA3);
                    object[] parRadioButtonA4 = new object[] { "answerA4" };
                    meth.Invoke(parameter, parRadioButtonA4);
                    object[] parRadioButtonA5 = new object[] { "answerA5" };
                    meth.Invoke(parameter, parRadioButtonA5);
                    object[] parRadioButtonB1 = new object[] { "answerB1" };
                    meth.Invoke(parameter, parRadioButtonB1);
                    object[] parRadioButtonB2 = new object[] { "answerB2" };
                    meth.Invoke(parameter, parRadioButtonB2);
                    object[] parRadioButtonB3 = new object[] { "answerB3" };
                    meth.Invoke(parameter, parRadioButtonB3);
                    object[] parRadioButtonB4 = new object[] { "answerB4" };
                    meth.Invoke(parameter, parRadioButtonB4);
                    object[] parRadioButtonB5 = new object[] { "answerB5" };
                    meth.Invoke(parameter, parRadioButtonB5);
                    object[] parContent = new object[] { "ContentButton" };
                    meth.Invoke(parameter, parContent);
                    object[] parVisibility = new object[] { "GridVisibility" };
                    meth.Invoke(parameter, parVisibility);
                    object[] parVisibilityResult = new object[] { "ResultVisibility" };
                    meth.Invoke(parameter, parVisibilityResult);
                    object[] parSort = new object[] { "SortQuestion" };
                    meth.Invoke(parameter, parSort);
                }
                #endregion
                if (vmsort.ContentButton == "Выход")
                {
                    Result res = new Result();
                    //vmsort.answers = res.answers;
                    //var propAnswer = res.GetType().GetProperty("answers",
                    //    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                    //var meth2 = res.GetType().GetMethod("DoPropertyChanged");

                    //if (meth2 != null)
                    //{

                    //    object[] answer = new object[] { "answers" };
                    //    meth2.Invoke(parameter, answer);

                    //}
                }
            }
        }

        
        public event EventHandler CanExecuteChanged;

    }
}

