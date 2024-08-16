using System.Net;
using Clothes.Api.Models;
using Clothes.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clothes.Api.Controllers;

[ApiController]
public class ItemController(IItemProvider itemProvider) : ControllerBase
{
    [HttpPost("items")]
    [ProducesResponseType(typeof(IEnumerable<Item>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetItems([FromBody] FilterResource filter)
    {
        var items = await itemProvider.GetItems(filter);
        return Ok(items);
    }
}