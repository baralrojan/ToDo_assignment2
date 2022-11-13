using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoLists
    {
        public int Id { get; set; }
        [Required]
        public string? ToDoValue { get; set; }
    }
}
