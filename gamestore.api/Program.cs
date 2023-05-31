using gamestore.api.entities;

//An instance of the game entity
List<Game> games = new();
{
    new Game()
    {
        ID=1,
        Name="Farcry 6",
        Genre="Action",
        Price = 19.99M,
        releaseDate= new DateTime(1991,2,1),
        ImageURI = "https://placehold.co/100"
    };
};

//Create the builder object
var builder = WebApplication.CreateBuilder(args);

//create the app pipeline using the builder.build() method
var app = builder.Build();

//Define your endpoint with the app pipeline
app.MapGet("/", () => "Hello Worldd!");

app.Run();
