using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class VoitureService : IVoitureService
{
    private readonly ApplicationDbContext _context;

    public VoitureService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Voiture>> GetAllVoituresAsync()
    {
        return await _context.Voitures.ToListAsync();
    }

    public async Task<Voiture> GetVoitureByIdAsync(int id)
    {
        return await _context.Voitures.FindAsync(id);
    }

    public async Task AddVoitureAsync(Voiture voiture)
    {
        _context.Voitures.Add(voiture);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateVoitureAsync(Voiture voiture)
    {
        _context.Voitures.Update(voiture);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteVoitureAsync(int id)
    {
        var voiture = await _context.Voitures.FindAsync(id);
        if (voiture != null)
        {
            _context.Voitures.Remove(voiture);
            await _context.SaveChangesAsync();
        }
    }
}
