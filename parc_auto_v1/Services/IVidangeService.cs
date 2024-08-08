using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public interface IVidangeService
    {
        Task<IEnumerable<Vidange>> GetAllVidangesAsync();
        Task<Vidange> GetVidangeByIdAsync(int id);
        Task AddVidangeAsync(Vidange vidange);
        Task UpdateVidangeAsync(Vidange vidange);
        Task DeleteVidangeAsync(int id);
    }
}
