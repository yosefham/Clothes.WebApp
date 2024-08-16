using Clothes.Api.Models;
using FluentValidation;

namespace Clothes.Api.Services;

public interface IItemProvider
{
    Task<IEnumerable<Item>> GetItems(FilterResource filter);
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
}