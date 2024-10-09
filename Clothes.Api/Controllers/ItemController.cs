using System.Net;
using Clothes.Api.Models;
using Clothes.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clothes.Api.Controllers;

[ApiController]
public class ItemController(IItemProvider itemProvider) : ControllerBase
{
    [HttpPost("items")]
    [ProducesResponseType(typeof(IEnumerable<Item>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItems([FromBody] FilterResource filter)

    {
        var items = await itemProvider.GetItems(filter);
        return Ok(items);
    }

    [HttpGet("item/{id}")]
    [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetItem(string id)
    {
        var item = await itemProvider.GetItem(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost("item/{id}/buy")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> BuyItem(string id)
    {
        var buyItem = await itemProvider.BuyItem(id);
        return buyItem ? Ok() : NotFound();
    }
}
