using System.Net;
using Clothes.Api.Models;

namespace Clothes.WebApp.Services;

public interface IItemsProviderService
{
    Task<IEnumerable<Item>?> GetItems(FilterResource filter);
}

internal class ItemsProviderService(HttpClient client) : IItemsProviderService
{
    
    public async Task<IEnumerable<Item>?> GetItems(FilterResource filter)
    {
        var response = await client.PostAsJsonAsync("items", filter);
        if(response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Failed to get items");
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Item>>();
    }

}