using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public interface IDemandesService
    {
        Task<List<Demandes>> GetAllDemandesAsync(); // Change return type to List
        Task<Demandes> GetDemandeByIdAsync(int id);
        Task AddDemandeAsync(Demandes demande);
        Task UpdateDemandeAsync(Demandes demande);
        Task DeleteDemandeAsync(int id);
    }
}
