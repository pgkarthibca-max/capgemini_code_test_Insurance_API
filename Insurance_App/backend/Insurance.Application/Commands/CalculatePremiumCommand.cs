using MediatR;
using Insurance.Application.DTOs;


namespace Insurance.Application.Commands
{
    public record CalculatePremiumCommand(PremiumRequest Request) : IRequest<decimal>;
}