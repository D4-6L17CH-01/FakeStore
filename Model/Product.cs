using System.ComponentModel.DataAnnotations;

namespace Model;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Image { get; set; }
    public Rating? Rating { get; set; }
}
