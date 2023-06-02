using System.ComponentModel.DataAnnotations;

namespace gamestore.api.entities;

public class Game
{
    public int ID { get; set; }

    //Validations with Data Annotations
    [Required]
    [StringLength(50)]
    public string Name {get; set;} 

    [Required]
    [StringLength(30)]
    public string Genre {get; set;}

    [Required]
    [Range(1,100)] //Range of this value is from 1 - 100
    public decimal Price { get; set; }

    [Required]
    public DateTime releaseDate { get; set; }

    [Url]
    [StringLength(100)]
    public string ImageURI { get; set; }
}