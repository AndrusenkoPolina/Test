﻿using BisnessLogic;
using Connection;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class GetResult : INotifyPropertyChanged

    {
  

        #region вычисление результата
        public List<object> result(List<bool> answers)
        {
            //Индикаторы нужны для составления подробного отчёта в Word
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
            { result[0] = 'E'; }
            else result[0] = 'I';

            if (Indicator2 >= 10)
            { result[1] = 'S'; }
            else result[1] = 'N';

            if (Indicator3 >= 10)
            { result[2] = 'T'; }
            else result[2] = 'F';

            if (Indicator4 >= 10)
            { result[3] = 'J'; }
            else result[3] = 'P';

            string Result="";
            for (int i = 0; i < 4; i++)
                Result = Result + result[i];
            List<object> output = new List<object>();
            output.Add(Result);
            output.Add(Indicator1);
            output.Add(Indicator2);
            output.Add(Indicator3);
            output.Add(Indicator4);

            return output;

        }
        #endregion
        public List<object> getResult()
        {
           
            List<bool> answers = new List<bool>();
            answers = QuestionsViewModel.answers;

            List<object> res = new List<object>();
            res = result(answers);

            Config cnf = new Config();
            //REVIEW: В настройки
            cnf.DataPath = "Server=LENOVO-PC\\POLINA;Database=Question;Trusted_Connection=True;";

            Logic lg = new Logic(cnf, "Result", res[0].ToString());
            Result Output = new Result();
            Output = lg.Result;
            res[0] = Output;
            return res;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
