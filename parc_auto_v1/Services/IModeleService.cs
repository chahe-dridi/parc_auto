using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public interface IModeleService
    {
        Task<IEnumerable<Modele>> GetAllModelesAsync();
        Task<Modele> GetModeleByIdAsync(int id);
        Task AddModeleAsync(Modele modele);
        Task UpdateModeleAsync(Modele modele);
        Task DeleteModeleAsync(int id);
    }
}
