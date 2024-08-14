<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
=======
<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers
{
<<<<<<< HEAD
    [Authorize(Roles = "utilisateur,admin")]
    
=======
<<<<<<< HEAD
=======
    [Authorize(Roles = "utilisateur,admin")]
    
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
    public class DemandesController : Controller
    {
        private readonly IDemandesService _demandesService;

        public DemandesController(IDemandesService demandesService)
        {
            _demandesService = demandesService;
        }

<<<<<<< HEAD
        /* public async Task<IActionResult> Index()
          {
              var demandes = await _demandesService.GetAllDemandesAsync();
              return View(demandes);
          }
         */

        public async Task<IActionResult> Index()
        {
            var demandes = await _demandesService.GetAllDemandesAsync();

            // Sorting by Id in descending order
            var sortedDemandes = demandes.OrderByDescending(d => d.Id);

            return View(sortedDemandes);
        }







=======
        public async Task<IActionResult> Index()
        {
            var demandes = await _demandesService.GetAllDemandesAsync();
            return View(demandes);
        }

>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
        public async Task<IActionResult> Details(int id)
        {
            var demande = await _demandesService.GetDemandeByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }
            return View(demande);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Demandes demande)
        {
           // if (ModelState.IsValid)
            {
                demande.Etat = "En attente"; // Set Etat to "En attente"
                await _demandesService.AddDemandeAsync(demande);
                return RedirectToAction(nameof(Index));
            }
            return View(demande);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var demande = await _demandesService.GetDemandeByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }
            return View(demande);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Demandes demande)
        {
            if (id != demande.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                await _demandesService.UpdateDemandeAsync(demande);
                return RedirectToAction(nameof(Index));
            }
            return View(demande);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var demande = await _demandesService.GetDemandeByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }
            return View(demande);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _demandesService.DeleteDemandeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
