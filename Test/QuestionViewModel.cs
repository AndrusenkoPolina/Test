using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
   public class QuestionViewModel
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }

        //public QuestionViewModel output(int count)
        //{
        //    QuestionViewModel qvm = new QuestionViewModel();
        //    qvm.id = count;
        //    return qvm;
        //}
       
    }
}
