using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using BisnessLogic;
using Connection;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows;

namespace Test
{
    public class QuestionsViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public ObservableCollection<QuestionViewModel> SortQuestion { get; set; }
        public string GridVisibility { get; set; }
        public string ContentButton { get; set; }
        public int[] answers { get; set; }
        public int count {get; set; }
        public ICommand ChooseQuestion { get; set; }
        public ICommand Check_Answer { get; set; }

        public QuestionsViewModel()
        {

            ChooseQuestion = new OutputCommand();
            Config cnf = new Config();
            cnf.DataPath = "Server=LENOVO-PC\\POLINA;Database=Question;Trusted_Connection=True;";
            
            Logic lg = new Logic(cnf);
            
            Questions = new ObservableCollection<QuestionViewModel>();
            foreach (var q in lg.Questions)
            {
                Questions.Add(new QuestionViewModel()
                {
                    id = q.id,
                    question = q.question,
                    answerA = q.answerA,
                    answerB = q.answerB

                });

            }
            GridVisibility = "Collapsed";
            ContentButton = "Начать тест!";

        }

       
    }
}
