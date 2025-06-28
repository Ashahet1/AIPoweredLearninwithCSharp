using AspireTodoApp.ApiService.Data;
using AspireTodoApp.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// If you used Repositories/Services, add their namespaces too, e.g.:
// using AspireTodoApp.ApiService.Repositories;
// using AspireTodoApp.ApiService.Services;

namespace AspireTodoApp.ApiService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly AppDbContext _context;


        public ToDoController(AppDbContext context) // Or ITodoRepository/ITodoService
        {
            _context = context;

        }


        // GET: api/Todos

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
            // Or if using a repository: return Ok(await _todoRepository.GetAllAsync());
        }

        // GET: api/Todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            // Or if using a repository: var todoItem = await _todoRepository.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Todos
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            // Or if using a repository/service: await _todoRepository.AddAsync(todoItem);

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.ToDoId }, todoItem);
        }

        // PUT: api/Todos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.ToDoId)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                // Or if using a repository/service: await _todoRepository.UpdateAsync(todoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id)) // You'll need to create this helper method
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            // Or if using a repository: var todoItem = await _todoRepository.GetByIdAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            // Or if using a repository/service: await _todoRepository.DeleteAsync(id);

            return NoContent();
        }

        // Helper method for Put and Delete
        private bool TodoItemExists(int id)
        {
            return _context.TodoItems.Any(e => e.ToDoId == id);
            // Or if using a repository: return _todoRepository.Exists(id);
        }
    }
}
