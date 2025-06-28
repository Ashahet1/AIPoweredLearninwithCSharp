using AspireTodoApp.ApiService.Data; // Ensure this matches your DbContext's namespace
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi(); // For Swagger UI

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=todo.db"));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin() // In development, allowing any origin is fine. For production, specify your frontend's URL.
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Keep this for Swagger UI
}

app.UseHttpsRedirection();
app.UseAuthorization();

// --- START: Your API Service specific additions ---
app.UseCors(); // Apply the CORS policy
// --- END: Your API Service specific additions ---

app.MapControllers(); // This maps your API controllers

app.Run();