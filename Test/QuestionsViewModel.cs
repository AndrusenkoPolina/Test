﻿using System;
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

namespace Test
{
    public class QuestionsViewModel : INotifyPropertyChanged

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

        public ObservableCollection<QuestionViewModel> Questions { get; set; }


        public QuestionsViewModel()
        {
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
                    answerA=q.answerA,
                    answerB=q.answerB

                });
            }
        }
       
    }
}