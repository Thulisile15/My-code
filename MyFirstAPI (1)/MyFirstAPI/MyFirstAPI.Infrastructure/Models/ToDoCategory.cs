using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAPI.Infrastructure.Models
{
    public class ToDoCategory
    {
        public int Id { get; set; }
        public ToDoItem ToDoItem { get; set; }
        public Category Category { get; set; }
    }
}
