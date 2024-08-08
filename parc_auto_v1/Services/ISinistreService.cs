using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public interface ISinistreService
    {
        Task<List<Sinistre>> GetAllSinistresAsync();
        Task<Sinistre> GetSinistreByIdAsync(int id);
        Task AddSinistreAsync(Sinistre sinistre);
        Task UpdateSinistreAsync(Sinistre sinistre);
        Task DeleteSinistreAsync(int id);
        Task<bool> SinistreExists(int id);
    }
}
