using System.ComponentModel.DataAnnotations;

namespace Model;

public class Product
{
    public int Id { get; set; }
    [MyCkRequired]
    public string? Title { get; set; }
    [Range(100, 10000000, ErrorMessage =$"El precio debe estar entre $100 y $10.000.000")]
    public decimal Price { get; set; }
    [MyCkRequired]
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Image { get; set; }
    public Rating? Rating { get; set; }
}
