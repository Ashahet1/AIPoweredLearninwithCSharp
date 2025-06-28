using System.ComponentModel.DataAnnotations;

namespace AspireTodoApp.ApiService.Models;

public class TodoItem
{
    [Key]
    public int ToDoId { get; set; }
    [Required]
    public string? Title { get; set; }

    public bool IsComplete { get; set; }

    public string? Notes { get; set; }
}
