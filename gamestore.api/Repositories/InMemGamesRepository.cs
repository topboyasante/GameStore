using gamestore.api.entities;

namespace gamestore.api.Repositories;

public interface IGamesRepository
{
    void Create(Game game);
    void Delete(int id);
    Game? Get(int id);
    IEnumerable<Game> GetAll();
    void Update(Game updatedGame);
}

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()

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

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(game => game.ID == id);
    }

    public void Create(Game game)
    {
        game.ID = games.Max(game => game.ID) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.ID == updatedGame.ID);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.ID == id);
        games.RemoveAt(index);
    }
}