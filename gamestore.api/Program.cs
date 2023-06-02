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

//Using The Mapgroup
var group = app.MapGroup("/games")
                .WithParameterValidation();
               

//Get Request for all Games
group.MapGet("/", () => games);

//Get Request for one Game
group.MapGet("/{id}",(int id)=> {
    Game? gameInQuestion = games.Find(game => game.ID == id);

    if(gameInQuestion is null){
        return Results.NotFound();
    }
    else{
        return Results.Ok(gameInQuestion);
    }
}).WithName(GetGameEndPointName);

group.MapPost("/", (Game game)=>{
    game.ID = games.Max(game => game.ID) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new {ID = game.ID}, game);
});

group.MapPut("/{id}", (int id, Game updatedGame)=>
{
    Game? exisitngGame = games.Find(game => game.ID == id);
    if(exisitngGame is null){
        return Results.NotFound();
    }
    else{
        exisitngGame.Name = updatedGame.Name;
        exisitngGame.ID = updatedGame.ID;
        exisitngGame.Genre = updatedGame.Genre;
        exisitngGame.ImageURI = updatedGame.ImageURI;
        exisitngGame.Price = updatedGame.Price;
        exisitngGame.releaseDate = updatedGame.releaseDate;

        return Results.NoContent();
    }
}
);

group.MapDelete("/{id}",(int id)=>{
    Game? gameToBeDeleted = games.Find(game => game.ID == id);
    if(gameToBeDeleted is not null){
      games.Remove(gameToBeDeleted);
    }
    return Results.NoContent();
});

app.Run();
