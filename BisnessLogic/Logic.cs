﻿using Connection;
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
        public Result Result { get; set; }

        public Logic(Config cnf, string action,string result)
        {
            if (action == null)
                throw new ArgumentNullException();

            //Исправлено везде сравнение строк с помощью string.equals
            if (action.Equals("Open"))
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
            if (action.Equals("Result"))
            {
                DataBaseReader reader = new DataBaseReader();
                Result = new Result();
                Result = reader.GetResult(cnf.DataPath, result);
                
            }
          
        }
    }
}

