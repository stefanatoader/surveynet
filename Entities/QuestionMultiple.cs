using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    class QuestionMultiple : Question
    {
        [Required]
        public List<string> Answers { get; set; }
        [Required]
        public bool Radio { get; set; }
    }
}
