using parc_auto_v1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public class DemandesService : IDemandesService
    {
        private readonly ApplicationDbContext _context;

        public DemandesService(ApplicationDbContext context)
        {
            _context = context;
        }

      /*  public async Task<List<Demandes>> GetAllDemandesAsync() // Change return type for consistency
        {
            return await _context.Demandes.ToListAsync();
        }*/

        public async Task<List<Demandes>> GetAllDemandesAsync()
        {
            return await _context.Demandes
                                 .Include(d => d.Voiture) // Include the Voiture navigation property
                                 .ToListAsync();
        }

        /*public async Task<Demandes> GetDemandeByIdAsync(int id)
        {
            return await _context.Demandes.FindAsync(id);
        }*/


        public async Task<Demandes> GetDemandeByIdAsync(int id)
        {
            return await _context.Demandes
                .Include(d => d.Voiture) // Ensure the related Voiture is included
                .FirstOrDefaultAsync(d => d.Id == id);
        }





        public async Task AddDemandeAsync(Demandes demande)
        {
            await _context.Demandes.AddAsync(demande); // Use AddAsync for consistency
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDemandeAsync(Demandes demande)
        {
            _context.Entry(demande).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDemandeAsync(int id)
        {
            var demande = await _context.Demandes.FindAsync(id);
            if (demande != null)
            {
                _context.Demandes.Remove(demande);
                await _context.SaveChangesAsync();
            }
        }
    }
}
