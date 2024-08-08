<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers
{
<<<<<<< HEAD
=======
    [Authorize(Roles = "admin")]
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
    public class VisiteTechniqueController : Controller
    {
        private readonly IVisiteTechniqueService _visiteTechniqueService;
        private readonly IVoitureService _voitureService;

        public VisiteTechniqueController(IVisiteTechniqueService visiteTechniqueService, IVoitureService voitureService)
        {
            _visiteTechniqueService = visiteTechniqueService;
            _voitureService = voitureService;
        }

        // GET: VisiteTechnique
        public async Task<IActionResult> Index()
        {
            var visiteTechniques = await _visiteTechniqueService.GetAllVisiteTechniquesAsync();
            return View(visiteTechniques);
        }

        // GET: VisiteTechnique/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visiteTechnique = await _visiteTechniqueService.GetVisiteTechniqueByIdAsync(id.Value);
            if (visiteTechnique == null)
            {
                return NotFound();
            }

            return View(visiteTechnique);
        }

        // GET: VisiteTechnique/Create/{voitureId}
        public async Task<IActionResult> Create(int voitureId)
        {
            var model = new VisiteTechnique
            {
                VoitureId = voitureId
            };

            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", voitureId);
            return View(model);
        }

        // POST: VisiteTechnique/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] VisiteTechnique visiteTechnique)
        {
            //if (ModelState.IsValid)
            {
                await _visiteTechniqueService.AddVisiteTechniqueAsync(visiteTechnique);
                TempData["SuccessMessage"] = "Visite technique has been created successfully!";
                return RedirectToAction(nameof(Index));
            }

            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", visiteTechnique.VoitureId);
            return View(visiteTechnique);
        }

        // GET: VisiteTechnique/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visiteTechnique = await _visiteTechniqueService.GetVisiteTechniqueByIdAsync(id.Value);
            if (visiteTechnique == null)
            {
                return NotFound();
            }
            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", visiteTechnique.VoitureId);
            return View(visiteTechnique);
        }

        // POST: VisiteTechnique/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] VisiteTechnique visiteTechnique)
        {
            if (id != visiteTechnique.Id)
            {
                return NotFound();
            }

         //   if (ModelState.IsValid)
            {
                try
                {
                    await _visiteTechniqueService.UpdateVisiteTechniqueAsync(visiteTechnique);
                    TempData["SuccessMessage"] = "Visite technique has been updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _visiteTechniqueService.VisiteTechniqueExistsAsync(visiteTechnique.Id))
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
            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", visiteTechnique.VoitureId);
            return View(visiteTechnique);
        }

        // GET: VisiteTechnique/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visiteTechnique = await _visiteTechniqueService.GetVisiteTechniqueByIdAsync(id.Value);
            if (visiteTechnique == null)
            {
                return NotFound();
            }

            return View(visiteTechnique);
        }

        // POST: VisiteTechnique/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _visiteTechniqueService.DeleteVisiteTechniqueAsync(id);
            TempData["SuccessMessage"] = "Visite technique has been deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
