using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    class QuestionMultiple : Question
    {
        public List<string> Answers { get; set; }
        public bool Radio { get; set; }
    }
}
