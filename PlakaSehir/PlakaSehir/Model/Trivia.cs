using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakaSehir
{
    public class Trivia
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public override string ToString()
        {
            return Question;
        }
    }
}
