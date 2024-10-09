using Bogus;
using Clothes.Api.Models;

namespace Clothes.Api.Services;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetItems(FilterResource filter);
    Task<Item?> GetItem(string id);
}

public class ItemRepository : IItemRepository
{
    private readonly Faker<Item> _faker = new Faker<Item>()
        .RuleFor(x => x.Id, f => f.Random.Guid().ToString())
        .RuleFor(x => x.Title, f => f.Commerce.ProductName())
        .RuleFor(x => x.Price, f => f.Random.Decimal(1, 100))
        .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
        .RuleFor(x => x.ImageUrls,
            f => Enumerable.Range(0, f.Random.Number(1, 5))
                .Select(_ => f.Image.PicsumUrl())
                .ToArray());

    private readonly List<Item> _items;

    public ItemRepository()
    {
        _items = _faker.Generate(10);
    }

    public Task<IEnumerable<Item>> GetItems(FilterResource filter)
    {
        return Task.FromResult(_items.AsEnumerable());
    }

    public Task<Item?> GetItem(string id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(item);
    }
}
