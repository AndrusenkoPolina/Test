using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
    }
}
