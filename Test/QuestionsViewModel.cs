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
        private ObservableCollection<Question> sortQuestion { get; set; }
        public ObservableCollection<Question> SortQuestion 
        {
        get { return sortQuestion; }
          set {
                sortQuestion = value;
                DoPropertyChanged("SortQuestion");
            }
        }
        private string gridVisibility { get; set; }
        public string ButtonVisibility { get; set; }
        private string сontentButton { get; set; }
        private string startVisibility { get; set; }
        public int count { get; set; }
        private string resultVisibility { get; set; }
        public ICommand ChooseQuestion { get; set; }
        public static List<bool> answers { get; set; }
        public Result result { get; set; }

        private bool answerA1 { get; set; }
        private bool answerB1 { get; set; }
        private bool answerA2 { get; set; }
        private bool answerB2 { get; set; }
        private bool answerA3 { get; set; }
        private bool answerB3 { get; set; }
        private bool answerA4 { get; set; }
        private bool answerB4 { get; set; }
        private bool answerA5 { get; set; }
        private bool answerB5 { get; set; }
        #region для ответов
        public bool AnswerA1
        {
            get { return answerA1; }
            set
            {
                answerA1 = value;
                DoPropertyChanged("AnswerA1");
            }
        }
        public bool AnswerB1
        {
            get { return answerB1; }
            set
            {
                answerB1 = value;
                DoPropertyChanged("AnswerB1");
            }
        }
      
        public bool AnswerA2
        {
            get { return answerA2; }
            set
            {
                answerA2 = value;
                DoPropertyChanged("AnswerA2");
            }
        }

        public bool AnswerB2
        {
            get { return answerB2; }
            set
            {
                answerB2 = value;
                DoPropertyChanged("AnswerB2");
            }
        }
        public bool AnswerA3
        {
            get { return answerA3; }
            set
            {
                answerA3 = value;
                DoPropertyChanged("AnswerA3");
            }
        }
        public bool AnswerB3
        {
            get { return answerB3; }
            set
            {
                answerB3 = value;
                DoPropertyChanged("AnswerB3");
            }
        }
        public bool AnswerA4
        {
            get { return answerA4; }
            set
            {
                answerA4 = value;
                DoPropertyChanged("AnswerA4");
            }
        }
        public bool AnswerB4
        {
            get { return answerB4; }
            set
            {
                answerB4 = value;
                DoPropertyChanged("AnswerB4");
            }
        }
        public bool AnswerA5
        {
            get { return answerA5; }
            set
            {
                answerA5 = value;
                DoPropertyChanged("AnswerA5");
            }
        }

        public bool AnswerB5
        {
            get { return answerB5; }
            set
            {
                answerB5 = value;
                DoPropertyChanged("AnswerB5");
            }
        }
        #endregion

        public string ContentButton
        {
            get { return сontentButton; }
            set
            {
                сontentButton = value;
                DoPropertyChanged("ContentButton");
            }
        }

            public string StartVisibility
        {
            get { return startVisibility; }
            set
            {
                startVisibility = value;
                DoPropertyChanged("StartVisibility");
            }
        }

        public string ResultVisibility
        {
            get { return resultVisibility; }
            set
            {
                resultVisibility = value;
                DoPropertyChanged("ResultVisibility");
            }
        }

        public string GridVisibility
        {
            get { return gridVisibility; }
            set
            {
                gridVisibility = value;
                DoPropertyChanged("GridVisibility");
            }
        }
        public Result Result
        {
            get { return result; }
            set
            {
                result = value;
                DoPropertyChanged("Result");
            }
        }
            
       
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
      
            ContentButton = "Начать тест";
            ResultVisibility = "Collapsed";
            StartVisibility = "Visible";
            GridVisibility = "Collapsed";
            answers = new List<bool>();




        }
            
                 
           

        

       
    }
}
