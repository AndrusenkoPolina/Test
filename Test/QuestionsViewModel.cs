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
using DTO;

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


        public ObservableCollection<Question> Questions { get; set; }
        public ObservableCollection<Question> SortQuestion { get; set; }
        public string GridVisibility { get; set; }
        public string ButtonVisibility { get; set; }
        public string ContentButton { get; set; }
        public static List<bool> answers { get; set; }
        public GetResult result { get; set; }
        public bool answerA1 { get; set; }
        public bool answerB1 { get; set; }
        public bool answerA2 { get; set; }
        public bool answerB2 { get; set; }
        public bool answerA3 { get; set; }
        public bool answerB3 { get; set; }
        public bool answerA4 { get; set; }
        public bool answerB4 { get; set; }
        public bool answerA5 { get; set; }
        public bool answerB5 { get; set; }
        public int count { get; set; }
        public string ResultVisibility { get; set; }
        public ICommand ChooseQuestion { get; set; }

        public QuestionsViewModel()
        {

            ChooseQuestion = new OutputCommand();
            Config cnf = new Config();
            cnf.DataPath = "Server=LENOVO-PC\\POLINA;Database=Question;Trusted_Connection=True;";

            Logic lg = new Logic(cnf, "Open", "");

            Questions = new ObservableCollection<Question>();
            foreach (var q in lg.Questions)
            {
                Questions.Add(new Question()
                {
                    id = q.id,
                    question = q.question,
                    answerA = q.answerA,
                    answerB = q.answerB

                });

            }
            const int COUNT = 5;
            count = COUNT;
            SortQuestion = new ObservableCollection<Question>();
            for (int i = 0; i < count; i++)
            {
                SortQuestion.Add(Questions[i]);
            }
            answers = new List<bool>();
            ContentButton = "Следующие";
            ResultVisibility = "Collapsed";
        }
            
                 
           

        

       
    }
}
