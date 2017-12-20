using Connection;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic
{
    public class Logic
    {
        public List<Question> Questions { get; set; }
        public ObservableCollection<Result> Result { get; set; }

        public Logic(Config cnf, string action,string result)
        {
            if (action == null)
                throw new ArgumentNullException();

            if (action == "Open")
            {
                DataBaseReader reader = new DataBaseReader();
                Questions = new List<Question>();
                foreach (var q in reader.GetQuestion(cnf.DataPath))
                {
                    Questions.Add(new Question()
                    {
                        id = q.id,
                        question = q.question,
                        answerA = q.answerA,
                        answerB = q.answerB
                    });

                }
            }
            if (action == "Result")
            {
                DataBaseReader reader = new DataBaseReader();
                Result = new ObservableCollection<Result>();
                Result = reader.GetResult(cnf.DataPath, result);
                
            }
          
        }
    }
}

