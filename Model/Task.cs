using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class Task
    {
        public string? Name { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }

    }
}
