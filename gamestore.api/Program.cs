using gamestore.api.entities;

const string GetGameEndPointName = "GetGame";

//An instance of the game entity
List<Game> games = new() 
{
    new Game()
    {
        ID=1,
        Name="Farcry 6",
        Genre="Action",
        Price = 19.99M,
        releaseDate= new DateTime(1991,2,1),
        ImageURI = "https://placehold.co/100"
    },
    new Game()
    {
        ID=2,
        Name="FIFA 23",
        Genre="Sports",
        Price = 19.99M,
        releaseDate= new DateTime(2022,9,1),
        ImageURI = "https://placehold.co/100"
    }
};

//Create the builder object
var builder = WebApplication.CreateBuilder(args);

//create the app pipeline using the builder.build() method
var app = builder.Build();

//Define your endpoint with the app pipeline

//Get Request for all Games
app.MapGet("/games", () => games);

//Get Request for one Game
app.MapGet("/games/{id}",(int id)=> {
    Game? gameInQuestion = games.Find(game => game.ID == id);

    if(gameInQuestion is null){
        return Results.NotFound();
    }
    else{
        return Results.Ok(gameInQuestion);
    }
}).WithName(GetGameEndPointName);

app.MapPost("/games", (Game game)=>{
    game.ID = games.Max(game => game.ID) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new {ID = game.ID}, game);
});

app.Run();
