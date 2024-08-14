<<<<<<< HEAD
﻿/*
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122

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
<<<<<<< HEAD
*/


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Linq;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers
{
    [Authorize(Roles = "agent")]
    public class AgentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDemandesService _demandesService;
        private readonly IVoitureService _voitureService;

        public AgentController(ApplicationDbContext context, IDemandesService demandesService, IVoitureService voitureService)
        {
            _context = context;
            _demandesService = demandesService;
            _voitureService = voitureService;
        }

        // GET: Agent/Index
        public async Task<IActionResult> Index()
        {
            var demandes = await _demandesService.GetAllDemandesAsync();
            // Filter demandes to include only those with a reserved voiture
            var reservedDemandes = demandes.Where(d => d.Voiture != null && d.Voiture.Disponibilite == "Reserved").ToList();
            return View(reservedDemandes);
        }

        // POST: Agent/UpdateDemande
        [HttpPost]
        public async Task<IActionResult> UpdateDemande(int id, int kilometrage)
        {
            var demande = await _demandesService.GetDemandeByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }

            // Update the kilometrage and save
            demande.Kilometrage = kilometrage;
            await _demandesService.UpdateDemandeAsync(demande);

            // Make the associated voiture available
            if (demande.VoitureId.HasValue)
            {
                var voiture = await _voitureService.GetVoitureByIdAsync(demande.VoitureId.Value);
                if (voiture != null)
                {
                    voiture.Disponibilite = "Disponible";
                    await _voitureService.UpdateVoitureAsync(voiture);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
=======
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
