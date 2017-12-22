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
          
            if (parameter == null)
                throw new ArgumentNullException("Модель представления не может быть null!");
            
            var vmsort = parameter as QuestionsViewModel;
            ObservableCollection<Question> SortQuestion = new ObservableCollection<Question>();
            var sort = vmsort.Questions;
            const int COUNT = 5;

            if (vmsort.ContentButton == "")
                throw new ArgumentNullException("Кнопка должна содержать Content");

            if (vmsort.ContentButton == "Начать тест")
            {
                vmsort.ContentButton = "Следующие";
                vmsort.GridVisibility = "Visible";
                vmsort.StartVisibility = "Collapsed";

                for (int i = 0; i < COUNT; i++)
                {
                    SortQuestion.Add(sort[i]);
                }
                vmsort.count = COUNT;

                var prop = parameter.GetType().GetProperty("SortQuestion",
                    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                prop.SetValue(parameter, SortQuestion);
                var meth = parameter.GetType().GetMethod("DoPropertyChanged");

                if (meth != null)
                {
                   
                    object[] parSort = new object[] { "SortQuestion" };
                    meth.Invoke(parameter, parSort);
                }
            }

            else
            {



                if (vmsort.AnswerA1 == vmsort.AnswerB1 ||
                      vmsort.AnswerA2 == vmsort.AnswerB2 ||
                      vmsort.AnswerA3 == vmsort.AnswerB3 ||
                      vmsort.AnswerA4 == vmsort.AnswerB4 ||
                      vmsort.AnswerA5 == vmsort.AnswerB5)
                {
                    MessageBox.Show("Вы ответили не на все вопросы!");
                }
                else
                {
                    //Добавляем выбранные значение в массив, чтобы потом его использовать в подсчёте результатов
                  
                    QuestionsViewModel.answers.Add(vmsort.AnswerA1);
                    QuestionsViewModel.answers.Add(vmsort.AnswerA2);
                    QuestionsViewModel.answers.Add(vmsort.AnswerA3);
                    QuestionsViewModel.answers.Add(vmsort.AnswerA4);
                    QuestionsViewModel.answers.Add(vmsort.AnswerA5);

                    //Обнуляем значения
                    vmsort.AnswerA1 = false;
                    vmsort.AnswerB1 = false;
                    vmsort.AnswerA2 = false;
                    vmsort.AnswerB2 = false;
                    vmsort.AnswerA3 = false;
                    vmsort.AnswerB3 = false;
                    vmsort.AnswerA4 = false;
                    vmsort.AnswerB4 = false;
                    vmsort.AnswerA5 = false;
                    vmsort.AnswerB5 = false;
                    

                    //Выдача вопросов по COUNT штук  
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
                        vmsort.count = countto;

                        if (countto == sort.Count)
                            vmsort.ContentButton = "Результат";

                    }
                    else
                    {

                        vmsort.GridVisibility = "Collapsed";
                        vmsort.ResultVisibility = "Visible";
                        vmsort.ContentButton = "Выход";
                        GetResult gr = new GetResult();
                        Result res = new Result();
                        res = gr.getResult();

                        var propResult = parameter.GetType().GetProperty("Result",
                  BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                        propResult.SetValue(parameter, res);

                        var meth2 = parameter.GetType().GetMethod("DoPropertyChanged");

                        if (meth2 != null)
                        {

                            object[] result = new object[] { "Result" };
                            meth2.Invoke(parameter, result);
                        }
                    }
                        var prop = parameter.GetType().GetProperty("SortQuestion",
                    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                    prop.SetValue(parameter, SortQuestion);
                    var meth = parameter.GetType().GetMethod("DoPropertyChanged");

                    if (meth != null)
                    {
                        object[] parSort = new object[] { "SortQuestion" };
                        meth.Invoke(parameter, parSort);
                    }

                }
            }

            
            //#endregion
        }
        public event EventHandler CanExecuteChanged;

    }
}
