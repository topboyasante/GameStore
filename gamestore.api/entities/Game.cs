namespace gamestore.api.entities;

public class Game
{
    public int ID { get; set; }
    public string Name {get; set;} 
    public string Genre {get; set;}
    public decimal Price { get; set; }
    public DateTime releaseDate { get; set; }
    public string ImageURI { get; set; }
}