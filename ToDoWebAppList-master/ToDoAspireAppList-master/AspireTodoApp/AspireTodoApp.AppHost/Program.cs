var builder = DistributedApplication.CreateBuilder(args);

// 1. Define the Database Container
// This defines a PostgreSQL database container managed by Aspire.
// Ensure Docker Desktop is running for this to work.
var db = builder.AddPostgres("postgres") // Logical name "postgres"
                 .AddDatabase("tododb"); // Specific database instance "tododb"

// 2. Define the API Service
// Using the full absolute path to the .csproj file as requested.
// "apiservice" is the logical name for service discovery.
var apiservice = builder.AddProject("apiservice", @"C:\Users\rishah\OneDrive\Pictures\Desktop\Microsoft ML.NET\ToDoWebAppList-master\ToDoAspireAppList-master\AspireTodoApp\AspireTodoApp.ApiService\AspireTodoApp.ApiService.csproj")
                        .WithReference(db)
                        .WithExternalHttpEndpoints();// Injects "tododb" connection string into ApiService

// 3. Define the Web Frontend Service
// Using the full absolute path to the .csproj file as requested.
// "webfrontend" is its logical name.
var webFrontend = builder.AddProject("webfrontend", @"C:\Users\rishah\OneDrive\Pictures\Desktop\Microsoft ML.NET\ToDoWebAppList-master\ToDoAspireAppList-master\AspireTodoApp\AspireTodoApp.Web\AspireTodoApp.Web.csproj")
       .WithReference(apiservice)// Injects "apiservice" endpoint into Web project's configuration
       .WithExternalHttpEndpoints(); // This allows the web frontend to be accessed externally


builder.Build().Run();