using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
    }
    public class Result
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string result { get; set; }
    }
}
