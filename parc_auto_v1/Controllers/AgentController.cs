using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers
{
    [Authorize(Roles = "agent")]
    public class AgentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agent/Index
        public async Task<IActionResult> Index()
        {
            var voitures = await _context.Voitures.ToListAsync();
            return View(voitures);
        }

        // POST: Agent/ChangeDisponibilite/5
        [HttpPost]
        public async Task<IActionResult> ChangeDisponibilite(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }

            voiture.Disponibilite = "Disponible";
            _context.Update(voiture);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
