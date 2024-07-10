using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public interface IAssuranceService
    {
        Task<List<Assurance>> GetAllAssurancesAsync();
        Task<Assurance> GetAssuranceByIdAsync(int id);
        Task AddAssuranceAsync(Assurance assurance);
        Task UpdateAssuranceAsync(Assurance assurance);
        Task DeleteAssuranceAsync(int id);
    }
}
