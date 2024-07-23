using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public class ModeleService : IModeleService
    {
        private readonly ApplicationDbContext _context;

        public ModeleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Modele>> GetAllModelesAsync()
        {
            return await _context.Modeles.ToListAsync();
        }

        public async Task<Modele> GetModeleByIdAsync(int id)
        {
            return await _context.Modeles.FindAsync(id);
        }

        public async Task AddModeleAsync(Modele modele)
        {
            _context.Modeles.Add(modele);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateModeleAsync(Modele modele)
        {
            _context.Entry(modele).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteModeleAsync(int id)
        {
            var modele = await _context.Modeles.FindAsync(id);
            if (modele != null)
            {
                _context.Modeles.Remove(modele);
                await _context.SaveChangesAsync();
            }
        }
    }
}
