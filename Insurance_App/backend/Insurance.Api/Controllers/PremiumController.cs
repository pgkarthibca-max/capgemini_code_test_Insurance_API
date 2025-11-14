using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Insurance.Application.DTOs;
using Insurance.Application.Commands;
using Insurance.Application.Interfaces;


namespace Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PremiumController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PremiumController(IMediator mediator) => _mediator = mediator;


        [HttpGet("occupations")]
        public async Task<IActionResult> GetOccupations([FromServices] IOccupationRepository repo)
        {
            var list = await repo.GetAllAsync();
            return Ok(list);
        }


        [Authorize]
        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate([FromBody] PremiumRequest request)
        {
            var cmd = new CalculatePremiumCommand(request);
            var premium = await _mediator.Send(cmd);
            return Ok(new { monthlyPremium = premium });
        }
    }
}