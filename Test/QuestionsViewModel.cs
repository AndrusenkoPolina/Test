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
        public string ButtonVisibility { get; set; }
        public string ContentButton { get; set; }
        public List <bool> answers { get; set; }
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
        public int count {get; set; }
        public string ResultVisibility { get; set; }
        public ICommand ChooseQuestion { get; set; }
        public ICommand Check_Answer { get; set; }
        public char[] Result(List<bool> answers)
        {
            int Indicator1 = 0;
            int Indicator2 = 0;
            int Indicator3 = 0;
            int Indicator4 = 0;
            char[] result = new char[4];

            int[] arrayanswers = new int[answers.Count];

            for (int i = 0; i < answers.Count; i = i + 7)
            {
                if (answers[i] == true)
                {
                    Indicator1 = Indicator1 + 1;
                }
            }
            for (int i = 1; i < answers.Count; i = i + 7)
            {
                if (answers[i] == true)
                {
                    Indicator2 = Indicator2 + 1;
                }
            }
            for (int i = 2; i < answers.Count; i = i + 7)
            {
                if (answers[i] == true)
                {
                    Indicator2 = Indicator2 + 1;
                }
            }
            for (int i = 3; i < answers.Count; i = i + 7)
            {
                if (answers[i] == true)
                {
                    Indicator3 = Indicator3 + 1;
                }
            }
            for (int i = 4; i < answers.Count; i = i + 7)
            {
                if (answers[i] == true)
                {
                    Indicator3 = Indicator3 + 1;
                }
            }
            for (int i = 5; i < answers.Count; i = i + 7)
            {
                if (answers[i] == true)
                {
                    Indicator4 = Indicator4 + 1;
                }
            }
            for (int i = 6; i < answers.Count; i = i + 7)
            {
                if (answers[i] == true)
                {
                    Indicator4 = Indicator4 + 1;
                }
            }

            if (Indicator1 >= 5)
                result[0] = 'E';
            else result[0] = 'I';

            if (Indicator1 >= 10)
                result[1] = 'S';
            else result[1] = 'N';

            if (Indicator1 >= 10)
                result[2] = 'T';
            else result[2] = 'F';

            if (Indicator1 >= 10)
                result[3] = 'J';
            else result[3] = 'P';

            return result;


        }

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
            const int COUNT = 5;
            count = COUNT;
            SortQuestion = new ObservableCollection<QuestionViewModel>();
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
