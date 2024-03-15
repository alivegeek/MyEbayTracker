using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEbayTracker.Data;
using MyEbayTracker.ViewModels;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ItemsOfInterestController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ItemsOfInterestController> _logger;

    public ItemsOfInterestController(ApplicationDbContext context, ILogger<ItemsOfInterestController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/itemsofinterest
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemOfInterestViewModel>>> Get()
    {
        _logger.LogInformation("Retrieving items of interest for the user");
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        _logger.LogInformation("User ID: {UserId}", userId);

        var itemsOfInterest = await _context.ItemsOfInterest
            .Where(i => i.UserId == userId)
            .Select(i => new ItemOfInterestViewModel { EbayItemId = i.EbayItemId })
            .ToListAsync();

        _logger.LogInformation("Retrieved {Count} items of interest", itemsOfInterest.Count);
        return Ok(itemsOfInterest);
    }

    // POST: api/itemsofinterest
    [HttpPost]
    public async Task<ActionResult<ItemOfInterestViewModel>> Post(ItemOfInterestViewModel itemOfInterest)
    {
        _logger.LogInformation("Creating a new item of interest");

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state");
            return BadRequest(ModelState);
        }

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        _logger.LogInformation("User ID: {UserId}", userId);

        var newItem = new ItemOfInterest
        {
            EbayItemId = itemOfInterest.EbayItemId,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        _context.ItemsOfInterest.Add(newItem);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Item of interest created with ID: {ItemId}", newItem.Id);
        return CreatedAtAction(nameof(Get), new { id = newItem.EbayItemId }, itemOfInterest);
    }

    [HttpDelete("{ebayItemId}")]
    public async Task<IActionResult> Delete(string ebayItemId)
    {
        _logger.LogInformation("Deleting item of interest with EbayItemId: {EbayItemId}", ebayItemId);

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var itemOfInterest = await _context.ItemsOfInterest
            .FirstOrDefaultAsync(i => i.EbayItemId == ebayItemId && i.UserId == userId);

        if (itemOfInterest == null)
        {
            _logger.LogWarning("Item of interest with EbayItemId {EbayItemId} not found for user {UserId}", ebayItemId, userId);
            return NotFound();
        }

        _context.ItemsOfInterest.Remove(itemOfInterest);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Item of interest with EbayItemId {EbayItemId} deleted successfully for user {UserId}", ebayItemId, userId);
        return NoContent();
    }
}