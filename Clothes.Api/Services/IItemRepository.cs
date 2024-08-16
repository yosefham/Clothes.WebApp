using Clothes.Api.Models;

namespace Clothes.Api.Services;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetItems(FilterResource filter);
}

public class ItemRepository : IItemRepository
{
    private static readonly List<Item> Items =
    [
        new Item
        {
            Id = Guid.NewGuid().ToString(), Title = "Shirt", Price = 10, Description = "A nice shirt",
            ImageUrls = ["https://img.fruugo.com/product/2/92/703522922_0340_0340.jpg"]
        },
        new Item
        {
            Id = Guid.NewGuid().ToString(), Title = "Pants", Price = 20, Description = "Some nice pants",
            ImageUrls = [ "https://img01.ztat.net/article/spp-media-p1/5934af3882ad351cab4b08853216ad4f/dcd6de0a553f49fea82089df52a1918f.jpg" ]
        },
        new Item
        {
            Id = Guid.NewGuid().ToString(), Title = "Shoes", Price = 30, Description = "Some nice shoes",
            ImageUrls = ["https://m.media-amazon.com/images/I/81s2ofLN6XL._AC_SL1500_.jpg"]
        }
    ];
    public Task<IEnumerable<Item>> GetItems(FilterResource filter)
    {
        return Task.FromResult(Items.AsEnumerable());
    }
}