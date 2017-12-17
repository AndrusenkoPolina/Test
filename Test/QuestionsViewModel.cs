using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace Test
{
     public class QuestionsViewModel: INotifyPropertyChanged
    
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(String propertyName)
        {
            var ev = PropertyChanged;
            if (ev != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<AnswerViewModel> Questions { get; set; }

        public QuestionsViewModel()
        {
            Questions = new ObservableCollection<AnswerViewModel>();
            var question = QuestionModel.GetQuestion();

            foreach (var q in question)
            {
                Questions.Add(new AnswerViewModel()
                {
                    id = q.id,
                    question = q.question,
                    answerA=q.answerA,
                    answerB=q.answerB

                });
            }
        }
       
    }
}
