using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface IRandevuService
    {
        Task<List<Randevu>> GetAllAsync();
        Task<Randevu> GetByIdAsync(Guid id);
        Task<bool> IsSlotAvailableAsync(DateTime date); // Business logic
        Task CreateAsync(Randevu randevu);
        Task UpdateAsync(Randevu randevu);
        Task DeleteAsync(Guid id);
    }
}
