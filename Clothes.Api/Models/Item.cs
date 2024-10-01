namespace Clothes.Api.Models;

public class Item
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string[] ImageUrls { get; set; } = null!;
}