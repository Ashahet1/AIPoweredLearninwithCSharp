using AspireTodoApp.Web.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // For MVC support

const string ApiServiceName = "apiservice"; // Logical name for the API service


builder.Services.AddHttpClient(ApiServiceName, client =>
                client.BaseAddress = new Uri("https://localhost:7074")
                );

builder.Services.AddScoped<TodoApiClient>(sp =>
{
    // Resolve the named HttpClient
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var client = httpClientFactory.CreateClient(ApiServiceName);
    Console.WriteLine(">>> USING BASE ADDRESS " + client.BaseAddress);
    if (client.BaseAddress == null)
    {
        throw new Exception("BASE ADDRESS IS STILL NULL");
    }
    return new TodoApiClient(client);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles(); // For wwwroot content (CSS, JS)

app.UseRouting();

app.UseAuthorization();

// For Razor Pages applications:
//app.MapRazorPages();

//If you chose to use Controllers and Views (MVC), you'd typically have:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();