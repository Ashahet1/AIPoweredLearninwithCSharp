// Import Entity Framework Core (for DbContext, DbSet, etc.)
using Microsoft.EntityFrameworkCore;

// Import your TodoItem model
using ToDoWebAppList.Models;

// This class manages the database connection and tables
namespace ToDoWebAppList.Data
{
    // AppDbContext inherits from EF Core's DbContext
    public class AppDbContext : DbContext
    {
        // This constructor passes options (like connection string) to the base DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        // DbSet<TodoItem> will become a table in the database
        // "TodoItems" is the table name — holds all TodoItem objects
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
