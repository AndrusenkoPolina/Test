using Connection;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAL
{
    public class DataBaseReader
    {

        public List<Question> GetQuestion(string config)
        {

            List<Question> Questions = new List<Question>();

            if (config == null)
                throw new ArgumentNullException("Строка подключения пустая");

            using (SqlConnection connection = new SqlConnection(config))
            {

                try
                {
                    connection.Open();
                }
                catch
                {
                    logger.Log.Error("Неверная строка подключения к базе данных!");
                }


                //Добавление запроса в константы
                const string COMMAND = "select q.id_question, question,answerA,answerB from question q inner join answerAB a ON a.id_question = q.id_question";

                try
                {
                    SqlCommand command = new SqlCommand(COMMAND, connection);
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
                }
                catch
                {
                    logger.Log.Error("Неверная команда sql");
                }
                return Questions;

            }

        }




        public Result GetResult(string config, string result)
        {
            Result r = new Result();
            if (config == null)
                throw new ArgumentNullException("Строка подключения пустая");
            using (SqlConnection connection = new SqlConnection(config))
            {
        try
        {
            connection.Open();



            SqlCommand command = new SqlCommand("select * from Result where type ='" + result + "'", connection);
            var ChooseResult = command.ExecuteReader();
            ChooseResult.Read();

           
            r.id = (int)ChooseResult["id"];
            r.type = (string)ChooseResult["type"];
            r.name = (string)ChooseResult["name"];
            r.result = (string)ChooseResult["result"];
        }
        catch (SqlException)
        {
            MessageBox.Show("При отправке данных в базу данных произошла ошибка!", "Данные не были отправлены", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        return r;

            }

        }
    }
}

