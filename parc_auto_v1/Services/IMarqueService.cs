using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public interface IMarqueService
    {
        Task<IEnumerable<Marque>> GetAllMarquesAsync();
        Task<Marque> GetMarqueByIdAsync(int id);
        Task AddMarqueAsync(Marque marque);
        Task UpdateMarqueAsync(Marque marque);
        Task DeleteMarqueAsync(int id);
    }
}
