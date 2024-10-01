using Clothes.Api.Models;
using FluentValidation;

namespace Clothes.Api.Services;

public interface IItemProvider
{
    Task<IEnumerable<Item>> GetItems(FilterResource filter);
    Task<Item?> GetItem(string id);
    Task<bool> BuyItem(string id);
}

public class ItemProvider(
    IItemRepository itemRepository,
    IValidator<FilterResource> validator,
    ILogger<ItemProvider> logger)
    : IItemProvider
{
    public async Task<IEnumerable<Item>> GetItems(FilterResource filter)
    {
        var validationResult = await validator.ValidateAsync(filter);
        if(validationResult.IsValid == false)
            logger.LogError("Invalid filter: {Filter}", validationResult.Errors);
        
        return await itemRepository.GetItems(filter);
    }

    public Task<Item?> GetItem(string id)
    {
        return itemRepository.GetItem(id);
    }

    public async Task<bool> BuyItem(string id)
    {
        var item = await itemRepository.GetItem(id);
        if(item is not null)
        {
            logger.LogInformation("Item bought: {ItemId}", id);
            return true;
        }

        logger.LogWarning("Item not found: {ItemId}", id);
        return false;
    }
    
}