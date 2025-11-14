using Insurance.Domain.Entities;
using Insurance.Application.Data;
using Microsoft.EntityFrameworkCore;
using Insurance.Application.Interfaces;


namespace Insurance.Application.Repositories
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly AppDbContext _context;
        public OccupationRepository(AppDbContext context) => _context = context;


        public async Task<IEnumerable<Occupation>> GetAllAsync() => await _context.Occupations.AsNoTracking().ToListAsync();


        public async Task<Occupation?> GetByIdAsync(int id) => await _context.Occupations.FindAsync(id);


    }
}