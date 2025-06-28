using AspireTodoApp.ApiService.Models;
using AspireTodoApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspireTodoApp.Web
{
    public class TodoController : Controller
    {
        private readonly TodoApiClient _todoApiClient;

        public TodoController(TodoApiClient todoApiClient)
        {
            _todoApiClient = todoApiClient;
        }

        // GET: /Todo/Index
        public async Task<IActionResult> Index() // Recommended: Make async for DB calls
        {
            var todos = await _todoApiClient.GetTodosAsync(); // Use ToListAsync()
            return View(todos);
        }

        // GET: /Todo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItem todoItem) // Recommended: Make async
        {

            // --- CRUCIAL FIX HERE ---

            // 1. Check if the Title is null or whitespace *from the incoming request*.
            //    Store this state *before* potentially setting a default.
            bool titleWasInitiallyEmptyOrWhitespace = string.IsNullOrWhiteSpace(todoItem.Title);

            // 2. If it was empty/whitespace, apply your default.
            if (titleWasInitiallyEmptyOrWhitespace)
            {
                todoItem.Title = "Untitled Task";
            }

            // 3. If the title was initially empty AND there was a [Required] validation error
            //    for Title, we need to explicitly remove that specific error from ModelState.
            //    This effectively tells ModelState that we've "fixed" this particular issue programmatically.
            if (titleWasInitiallyEmptyOrWhitespace && ModelState.ContainsKey(nameof(todoItem.Title)))
            {
                ModelState.Remove(nameof(todoItem.Title)); // <--- THIS IS THE KEY FIX
            }

            // 4. Now, check if ModelState is valid.
            //    It should now be valid if the 'Title' was the only issue, or if other fields are valid.
            if (ModelState.IsValid)
            {
                await _todoApiClient.CreateTodoAsync(todoItem); // Use await for async SaveChanges
                // Use await for async SaveChanges
                return RedirectToAction("Index");
            }

            // 5. If ModelState is still invalid (meaning there are *other* validation errors,
            //    or the Title error wasn't the only one and we're just letting validation flow),
            //    then return the view with the item and its errors.
            Console.WriteLine("Model state is invalid.");
            // You can iterate ModelState.Values for more specific error messages if needed for debugging
            foreach (var state in ModelState.Values)
            {
                foreach (var error in state.Errors)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
            }
            return View(todoItem);
        }
        // GET: /Todo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _todoApiClient.GetTodoByIdAsync(id.Value); // Use .Value for nullable int
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }
        // GET: /Todo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _todoApiClient.GetTodoByIdAsync(id.Value); // Use .Value for nullable int
            if (todoItem == null)
            {
                return NotFound();
            }
            return View(todoItem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoItem todoItem)
        {
            if (id != todoItem.ToDoId) return NotFound();

            if (ModelState.IsValid)
            {
                var success = await _todoApiClient.UpdateTodoAsync(todoItem);
                if (!success) return NotFound(); // Or handle conflict
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _todoApiClient.DeleteTodoAsync(id);
            if (!success) return NotFound(); // Item might have been deleted already
            return RedirectToAction(nameof(Index));
        }
    }
}


