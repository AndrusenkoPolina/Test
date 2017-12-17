using Connection;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic
{
    public class Logic
    {
        public List<Question> Questions { get; set; }

        public Logic(Config cnf)
        {
            DataBaseReader reader = new DataBaseReader();
            Questions = new List<Question>();
           reader.GetQuestion(cnf.DataPath);
        }
    }
}

