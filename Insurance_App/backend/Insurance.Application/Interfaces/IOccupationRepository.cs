using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Application.Interfaces
{
    public interface IOccupationRepository
    {
        Task<IEnumerable<Occupation>> GetAllAsync();
        Task<Occupation> GetByIdAsync(int id);
    }
}
