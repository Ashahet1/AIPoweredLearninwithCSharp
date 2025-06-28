//Summary: You are telling the app: "Please use AppDbContext with a SQLite database."
using ToDoWebAppList.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllersWithViews();

//Register AppDbContect with SQLite
builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlite("Data Source = todo.db"));

var app = builder.Build();

app.MapDefaultControllerRoute();
app.Run();
