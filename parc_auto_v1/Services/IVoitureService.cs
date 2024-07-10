using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IVoitureService
{
    Task<List<Voiture>> GetAllVoituresAsync();
    Task<Voiture> GetVoitureByIdAsync(int id);
    Task AddVoitureAsync(Voiture voiture);
    Task UpdateVoitureAsync(Voiture voiture);
    Task DeleteVoitureAsync(int id);
}
