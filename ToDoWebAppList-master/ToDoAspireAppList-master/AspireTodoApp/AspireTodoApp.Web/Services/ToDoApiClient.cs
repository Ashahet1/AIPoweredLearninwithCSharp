using AspireTodoApp.ApiService.Models; // Reference your shared models from the API project

namespace AspireTodoApp.Web.Services
{
    public class TodoApiClient
    {
        private readonly HttpClient _httpClient;

        public TodoApiClient(HttpClient httpClient)
        {
            Console.WriteLine(">>> ACTUAL BASE ADDRESS " + httpClient.BaseAddress);
            if (httpClient.BaseAddress == null)
            {
                throw new Exception("BASE ADREESS IS STILL NULL ");
            }
            _httpClient = httpClient;
        }

        // GET all Todo items
        public async Task<List<TodoItem>?> GetTodosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TodoItem>>("/api/todo");
        }

        // GET a single Todo item by ID
        public async Task<TodoItem?> GetTodoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TodoItem>($"/api/todo/{id}");
        }

        // POST a new Todo item
        public async Task<TodoItem?> CreateTodoAsync(TodoItem todoItem)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/todo", todoItem);
            response.EnsureSuccessStatusCode(); // Throws if not a 2xx status code
            return await response.Content.ReadFromJsonAsync<TodoItem>();
        }

        // PUT (Update) an existing Todo item
        public async Task<bool> UpdateTodoAsync(TodoItem todoItem)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/todo/{todoItem.ToDoId}", todoItem);
            return response.IsSuccessStatusCode;
        }

        // DELETE a Todo item
        public async Task<bool> DeleteTodoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/todo/{id}");
            return response.IsSuccessStatusCode;
        }

        // Method to toggle completion status (if your API has a specific endpoint for this)
        // If not, you'd use UpdateTodoAsync and change the IsComplete property
        public async Task<bool> ToggleCompleteAsync(int id, bool isComplete)
        {
            // This assumes your API's PUT endpoint handles updating IsComplete
            var todoItem = await GetTodoByIdAsync(id);
            if (todoItem == null) return false;

            todoItem.IsComplete = isComplete;
            return await UpdateTodoAsync(todoItem);
        }
    }
}