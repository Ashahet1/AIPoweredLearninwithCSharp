using PatentAnalyzer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Enables MVC controllers

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Register your services for Dependency Injection ---
builder.Services.AddHttpClient<IUSPTOApiClient, USPTOApiClient>(); // Register HttpClient for USPTOApiClient
builder.Services.AddSingleton<IPatentDataService, PatentDataService>(); // Register your service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Maps controller routes

app.Run();