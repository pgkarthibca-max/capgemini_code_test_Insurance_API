using Microsoft.AspNetCore.Mvc;
using InsuranceApp.Data;
using InsuranceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PremiumController : ControllerBase
{
    private readonly AppDbContext _context;
    public PremiumController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet("occupations")]
    public async Task<IActionResult> GetOccupations()
    {
        var occupations = await _context.Occupations.ToListAsync();
        return Ok(occupations);
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> CalculatePremium([FromBody] PremiumRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("All fields are required.");

        var occupation = await _context.Occupations.FindAsync(request.OccupationId);
        if (occupation == null) return NotFound("Invalid occupation.");

        var premium = (request.DeathSumInsured * occupation.RatingFactor * request.AgeNextBirthday) / 1000 * 12;

        var member = new Member
        {
            Name = request.Name,
            AgeNextBirthday = request.AgeNextBirthday,
            DateOfBirth = request.DateOfBirth,
            OccupationId = request.OccupationId,
            DeathSumInsured = request.DeathSumInsured,
            MonthlyPremium = premium
        };
        Console.WriteLine(member);
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return Ok(new { monthlyPremium = premium });
    }
}