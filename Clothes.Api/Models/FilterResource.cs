namespace Clothes.Api.Models;

public class FilterResource
{
    public string Id { get; set; } = null!;
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
}