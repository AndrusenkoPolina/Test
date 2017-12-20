﻿using Connection;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataBaseReader
    {

        public List<Question> GetQuestion(string config)
        {
            List<Question> Questions = new List<Question>();
            using (SqlConnection connection = new SqlConnection(config))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select q.id_question, question,answerA,answerB from question q inner join answerAB a ON a.id_question = q.id_question", connection);
                var questionReader = command.ExecuteReader();

                while (questionReader.Read())
                {
                    Question q = new Question();
                    q.id = (int)questionReader["id_question"];
                    q.question = (string)questionReader["question"];
                    q.answerA = (string)questionReader["answerA"];
                    q.answerB = (string)questionReader["answerB"];
                    Questions.Add(q);
                }

                return Questions;

            }
        }
        public List<Result> GetResult(string config, string result)
        {
            using (SqlConnection connection = new SqlConnection(config))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Result where type ='" +result +"'" , connection);
                var ChooseResult = command.ExecuteReader();

                    ChooseResult.Read();
                    List<Result> listResult = new List<Result>();
                    Result r = new Result();
                r.id = (int)ChooseResult["id"];
                r.type = (string)ChooseResult["type"];
                r.name = (string)ChooseResult["name"];
                r.result = (string)ChooseResult["result"];
                listResult.Add(r);
            
                return listResult;

            }

        }
    }
}

