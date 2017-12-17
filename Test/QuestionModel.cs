using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class QuestionModel
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }

        public static List<QuestionModel>GetQuestion()
        {
            List<QuestionModel> question = new List<QuestionModel>();
            using (SqlConnection connection = new SqlConnection("Server=LENOVO-PC\\POLINA;Database=Question;Trusted_Connection=True;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select q.id_question, question,answerA,answerB from question q inner join answerAB a ON a.id_question = q.id_question", connection);
                var questionReader = command.ExecuteReader();
                while (questionReader.Read())
                {

                    QuestionModel q = new QuestionModel();
                    q.id = (int) questionReader["id_question"];
                    q.question = (string)questionReader["question"];
                    q.answerA = (string)questionReader["answerA"];
                    q.answerB = (string)questionReader["answerB"];

                    question.Add(q);
                }
            }
            return question;            
        }
    }
}
