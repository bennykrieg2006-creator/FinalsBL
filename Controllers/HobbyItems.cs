using FinalsBL.Data;
using FinalsBL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalsBL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HobbyItemsController : ControllerBase
{
    private readonly DB _db;
    public HobbyItemsController(DB db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? id)
    {
        if (!id.HasValue || id.Value == 0)
        {
            var firstFive = await _db.HobbyItems
                .OrderBy(x => x.Id)
                .Take(5)
                .ToListAsync();
            return Ok(firstFive);
        }

        var item = await _db.HobbyItems.FindAsync(id.Value);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(HobbyItem model)
    {
        _db.HobbyItems.Add(model);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, HobbyItem model)
    {
        if (id != model.Id) return BadRequest("Route id must match body Id.");

        if (!await _db.HobbyItems.AnyAsync(x => x.Id == id))
            return NotFound();

        _db.Entry(model).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.HobbyItems.FindAsync(id);
        if (item is null) return NotFound();

        _db.HobbyItems.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}