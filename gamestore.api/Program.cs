using gamestore.api.Endpoints;
using gamestore.api.Repositories;

//Create the builder object
var builder = WebApplication.CreateBuilder(args);

//Using the InScope Service Lifetime, a new instance of the repository is created when a request is made.
// builder.Services.AddScoped<IGamesRepository, InMemGamesRepository>();

//Using the Singleton Service Lifetime, one instance of the repository is created for all.
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();
//create the app pipeline using the builder.build() method
var app = builder.Build();

// Define Endpoints
app.MapGamesEndpoints();
               
app.Run();
