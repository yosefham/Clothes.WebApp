using System.Net;
using Clothes.Api.Models;

namespace Clothes.WebApp.Services;

public interface IItemsProviderService
{
    Task<IEnumerable<Item>?> GetItems(FilterResource filter);
    Task<Item?> GetItem(string id);
    Task<bool> BuyNow(string itemFieldId);
}

internal class ItemsProviderService(HttpClient client) : IItemsProviderService
{

    public async Task<IEnumerable<Item>?> GetItems(FilterResource filter)
    {
        var response = await client.PostAsJsonAsync("items", filter);
        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Failed to get items");

        return await response.Content.ReadFromJsonAsync<IEnumerable<Item>>();
    }

    public async Task<Item?> GetItem(string id)
    {
        var response = await client.GetAsync($"item/{id}");
        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Failed to get item");

        return await response.Content.ReadFromJsonAsync<Item>();
    }

    public async Task<bool> BuyNow(string itemFieldId)
    {
        var response = await client.PostAsync($"item/{itemFieldId}/buy", null);
        return response.StatusCode == HttpStatusCode.OK;
    }
}
