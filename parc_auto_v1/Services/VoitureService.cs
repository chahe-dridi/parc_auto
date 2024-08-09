using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public class VoitureService : IVoitureService
    {
        private readonly ApplicationDbContext _context;

        public VoitureService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Voiture>> GetAllVoituresAsync()
        {
            return await _context.Voitures
                                 .Include(v => v.Marque)
                                 .Include(v => v.Modele)
                                 .ToListAsync();
        }

        public async Task<Voiture> GetVoitureByIdAsync(int id)
        {
            return await _context.Voitures
                                 .Include(v => v.Marque)
                                 .Include(v => v.Modele)
                                 .FirstOrDefaultAsync(v => v.Id == id);
        }

















<<<<<<< HEAD
      /*  public async Task<List<Voiture>> GetAllVoituresAsync()
        {
            return await _context.Voitures.ToListAsync();
        }

        public async Task<Voiture> GetVoitureByIdAsync(int id)
        {
            return await _context.Voitures.FindAsync(id);
        } */
=======
       
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84

        public async Task AddVoitureAsync(Voiture voiture)
        {
            _context.Add(voiture);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVoitureAsync(Voiture voiture)
        {
            _context.Update(voiture);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVoitureAsync(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);
            _context.Voitures.Remove(voiture);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VoitureExistsAsync(int id)
        {
            return await _context.Voitures.AnyAsync(e => e.Id == id);
        }

        // New method to get available cars
        public async Task<List<Voiture>> GetAvailableVoituresAsync()
        {
            return await _context.Voitures
                                 .Where(v => v.Disponibilite == "Disponible")
                                 .ToListAsync();
        }
    }
}
