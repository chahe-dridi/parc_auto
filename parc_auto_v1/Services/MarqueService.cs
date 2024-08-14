using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parc_auto_v1.Services
{
    public class MarqueService : IMarqueService
    {
        private readonly ApplicationDbContext _context;

        public MarqueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marque>> GetAllMarquesAsync()
        {
            return await _context.Marques.ToListAsync();
        }

        public async Task<Marque> GetMarqueByIdAsync(int id)
        {
            return await _context.Marques.FindAsync(id);
        }

        public async Task AddMarqueAsync(Marque marque)
        {
            _context.Marques.Add(marque);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMarqueAsync(Marque marque)
        {
            _context.Entry(marque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMarqueAsync(int id)
        {
            var marque = await _context.Marques.FindAsync(id);
            if (marque != null)
            {
                _context.Marques.Remove(marque);
                await _context.SaveChangesAsync();
            }
        }
    }
}
