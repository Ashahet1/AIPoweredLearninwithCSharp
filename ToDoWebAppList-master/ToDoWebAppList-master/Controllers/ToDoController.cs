
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoWebAppList.Data;
using ToDoWebAppList.Models;

namespace ToDoWebAppList.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Todo/Index
        public async Task<IActionResult> Index() // Recommended: Make async for DB calls
        {
            var todos = await _context.TodoItems.ToListAsync(); // Use ToListAsync()
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
        public async Task<IActionResult> Create(TodoItem item) // Recommended: Make async
        {
            // --- CRUCIAL FIX HERE ---

            // 1. Check if the Title is null or whitespace *from the incoming request*.
            //    Store this state *before* potentially setting a default.
            bool titleWasInitiallyEmptyOrWhitespace = string.IsNullOrWhiteSpace(item.Title);

            // 2. If it was empty/whitespace, apply your default.
            if (titleWasInitiallyEmptyOrWhitespace)
            {
                item.Title = "Untitled Task";
            }

            // 3. If the title was initially empty AND there was a [Required] validation error
            //    for Title, we need to explicitly remove that specific error from ModelState.
            //    This effectively tells ModelState that we've "fixed" this particular issue programmatically.
            if (titleWasInitiallyEmptyOrWhitespace && ModelState.ContainsKey(nameof(item.Title)))
            {
                ModelState.Remove(nameof(item.Title)); // <--- THIS IS THE KEY FIX
            }

            // 4. Now, check if ModelState is valid.
            //    It should now be valid if the 'Title' was the only issue, or if other fields are valid.
            if (ModelState.IsValid)
            {
                _context.TodoItems.Add(item);
                await _context.SaveChangesAsync(); // Use await for async SaveChanges
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
            return View(item);
        }

        // GET: /Todo/Create
        public IActionResult Edit(int id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: /Todo/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoItem item) // Recommended: Make async
        {
            if (id != item.ToDoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.TodoItems.Update(item);
                await _context.SaveChangesAsync(); // Use await for async SaveChanges
                return RedirectToAction("Index");
            }


            return View(item);
        }

        //GET: /Todo/Delete
        public IActionResult Delete(int id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //POST: /Todo/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // Recommended: Make async
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync(); // Use await for async SaveChanges
            return RedirectToAction("Index");
        }
    }
}


