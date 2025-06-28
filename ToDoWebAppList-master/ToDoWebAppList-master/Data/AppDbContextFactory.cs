using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToDoWebAppList.Data
{
    // This factory is used by EF Core CLI tools at design time
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        // This method creates AppDbContext with the correct options (SQLite connection string)
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Set up SQLite connection
            optionsBuilder.UseSqlite("Data Source=todo.db");

            // Return new instance of AppDbContext with options
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
