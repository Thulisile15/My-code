using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAPI.Infrastructure.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public UserDetail UserDetail { get; set; } = null!;
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string Title { get; set; }
    }
}
