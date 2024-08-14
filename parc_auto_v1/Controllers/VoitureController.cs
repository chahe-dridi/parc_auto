<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
=======
<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Linq;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers // Change namespace to Controllers
{
<<<<<<< HEAD
    [Authorize(Roles="admin")]
=======
<<<<<<< HEAD
=======
    [Authorize(Roles="admin")]
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
    public class VoitureController : Controller
    {
        private readonly IVoitureService _voitureService;
        private readonly IMarqueService _marqueService;
        private readonly IModeleService _modeleService;

        public VoitureController(IVoitureService voitureService, IMarqueService marqueService, IModeleService modeleService)
        {
            _voitureService = voitureService;
            _marqueService = marqueService;
            _modeleService = modeleService;
        }

        // GET: Voiture
        public async Task<IActionResult> Index()
        {
            var voitures = await _voitureService.GetAllVoituresAsync();
            return View(voitures);
        }

        // GET: Voiture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _voitureService.GetVoitureByIdAsync(id.Value);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // GET: Voiture/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Marques = await _marqueService.GetAllMarquesAsync();
            return View();
        }

        // POST: Voiture/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricule,TypeVoiture,MarqueId,ModeleId,Km,Carburant,Etat,Disponibilite")] Voiture voiture)
        {
         //   if (ModelState.IsValid)
            {
                await _voitureService.AddVoitureAsync(voiture);
                TempData["SuccessMessage"] = "Voiture has been added successfully!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Marques = await _marqueService.GetAllMarquesAsync();
            return View(voiture);
        }

<<<<<<< HEAD
      
=======
<<<<<<< HEAD
        // GET: Voiture/Edit/5
=======
      
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
        // GET: Voiture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _voitureService.GetVoitureByIdAsync(id.Value);
            if (voiture == null)
            {
                return NotFound();
            }

            ViewBag.Marques = await _marqueService.GetAllMarquesAsync();
<<<<<<< HEAD
            ViewBag.Modeles = await _modeleService.GetModelesByMarqueIdAsync(voiture.MarqueId);
=======
<<<<<<< HEAD
            ViewBag.Modeles = await _modeleService.GetModelesByMarqueIdAsync(voiture.MarqueId); // Load modeles based on MarqueId
=======
            ViewBag.Modeles = await _modeleService.GetModelesByMarqueIdAsync(voiture.MarqueId);
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
            return View(voiture);
        }


<<<<<<< HEAD

=======
<<<<<<< HEAD
=======

>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
        // POST: Voiture/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricule,TypeVoiture,MarqueId,ModeleId,Km,Carburant,Etat,Disponibilite")] Voiture voiture)
        {
            if (id != voiture.Id)
            {
                return NotFound();
            }

           // if (ModelState.IsValid)
            {
                try
                {
                    await _voitureService.UpdateVoitureAsync(voiture);
                    TempData["SuccessMessage"] = "Voiture has been updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await VoitureExists(voiture.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Marques = await _marqueService.GetAllMarquesAsync();
            ViewBag.Modeles = await _modeleService.GetAllModelesAsync();
            return View(voiture);
        }

        // GET: Voiture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _voitureService.GetVoitureByIdAsync(id.Value);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // POST: Voiture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _voitureService.DeleteVoitureAsync(id);
            TempData["SuccessMessage"] = "Voiture has been deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VoitureExists(int id)
        {
            var voiture = await _voitureService.GetVoitureByIdAsync(id);
            return voiture != null;
        }

        [HttpPost]
        public async Task<IActionResult> AddMarque(string newMarque)
        {
            if (!string.IsNullOrWhiteSpace(newMarque))
            {
                await _marqueService.AddMarqueAsync(new Marque { Nom = newMarque });
                return Ok();
            }
            return BadRequest("Invalid marque name");
        }

        [HttpPost]
        public async Task<IActionResult> AddModele(string newModele, int marqueId)
        {
            if (!string.IsNullOrWhiteSpace(newModele))
            {
                await _modeleService.AddModeleAsync(new Modele { Nom = newModele, MarqueId = marqueId });
                return Ok();
            }
            return BadRequest("Invalid modele name or marque ID");
        }

        [HttpGet]
        public async Task<IActionResult> GetModelesByMarqueId(int marqueId)
        {
            var modeles = await _modeleService.GetAllModelesAsync();
            var filteredModeles = modeles.Where(m => m.MarqueId == marqueId).ToList();
            return Json(filteredModeles);
        }






<<<<<<< HEAD
        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            var voitures = await _voitureService.GetAllVoituresAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                voitures = voitures.Where(v => v.Matricule.Contains(searchString)).ToList();
            }

            return PartialView("_VoitureListPartial", voitures);
        }







=======



<<<<<<< HEAD

=======
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
    }
}
