using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    class Form
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public List<Account> Autors { get; set; }

        public List<Guid> Order { get; set; }
    }
}
