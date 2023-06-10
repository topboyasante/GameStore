using gamestore.api.entities;
using gamestore.api.Repositories;

namespace gamestore.api.Endpoints;


//All Essential Methods should be static
public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";

   
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes){
        var group = routes.MapGroup("/games")
                .WithParameterValidation();
               

                //Get Request for all Games
                group.MapGet("/", (IGamesRepository repository) => repository.GetAll());

                //Get Request for one Game
                group.MapGet("/{id}",(int id,IGamesRepository repository)=> {
                    Game? gameInQuestion = repository.Get(id);

                    return gameInQuestion is not null? Results.Ok(gameInQuestion) : Results.NotFound();
                }).WithName(GetGameEndPointName);

                group.MapPost("/", (Game game,IGamesRepository repository)=>{
                   repository.Create(game);
                    return Results.CreatedAtRoute(GetGameEndPointName, new {ID = game.ID}, game);
                });

                group.MapPut("/{id}", (int id, Game updatedGame,IGamesRepository repository)=>
                {
                    Game? exisitngGame = repository.Get(id);
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

                        repository.Update(updatedGame);
                        return Results.NoContent();
                    }
                }
                );

                group.MapDelete("/{id}",(int id,IGamesRepository repository)=>{
                    Game? gameToBeDeleted = repository.Get(id);
                    repository.Delete(id);
                    return Results.NoContent();
                });
    return group;

    }

}