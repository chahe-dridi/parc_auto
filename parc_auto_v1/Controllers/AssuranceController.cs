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
    public class AssuranceController : Controller
    {
        private readonly IAssuranceService _assuranceService;
        private readonly IVoitureService _voitureService;

        public AssuranceController(IAssuranceService assuranceService, IVoitureService voitureService)
        {
            _assuranceService = assuranceService;
            _voitureService = voitureService;
        }

        // GET: Assurance
        public async Task<IActionResult> Index()
        {
            var assurances = await _assuranceService.GetAllAssurancesAsync();
            return View(assurances);
        }

        // GET: Assurance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurance = await _assuranceService.GetAssuranceByIdAsync(id.Value);
            if (assurance == null)
            {
                return NotFound();
            }

            return View(assurance);
        }

        // GET: Assurance/Create/{voitureId}
        public async Task<IActionResult> Create(int voitureId)
        {
            var model = new Assurance
            {
                VoitureId = voitureId
            };

            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", voitureId);
            return View(model);
        }

        // POST: Assurance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] Assurance assurance)
        {
            //if (ModelState.IsValid)
            {
                await _assuranceService.AddAssuranceAsync(assurance);
                TempData["SuccessMessage"] = "Assurance has been created successfully!";
                return RedirectToAction(nameof(Index));
            }

            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", assurance.VoitureId);
            return View(assurance);
        }

<<<<<<< HEAD
        // GET: Assurance/Edit/5
=======












>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurance = await _assuranceService.GetAssuranceByIdAsync(id.Value);
            if (assurance == null)
            {
                return NotFound();
            }

            var voitures = await _voitureService.GetAllVoituresAsync();
<<<<<<< HEAD
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", assurance.VoitureId);
            return View(assurance);
        }

        // POST: Assurance/Edit/5
=======
            ViewBag.Voitures = voitures;

            return View(assurance);
        }

>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] Assurance assurance)
        {
            if (id != assurance.Id)
            {
                return NotFound();
            }

<<<<<<< HEAD
=======
            if (ModelState.IsValid)
            {
                try
                {
                    await _assuranceService.UpdateAssuranceAsync(assurance);
                    TempData["SuccessMessage"] = "Assurance has been updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _assuranceService.AssuranceExistsAsync(assurance.Id)) // Use the new method
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
            ViewBag.Voitures = voitures;

            return View(assurance);
        }


        private async Task<bool> AssuranceExists(int id)
        {
            var assurance = await _assuranceService.GetAssuranceByIdAsync(id);
            return assurance != null;
        }


        // GET: Assurance/Edit/5
        /* public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var assurance = await _assuranceService.GetAssuranceByIdAsync(id.Value);
             if (assurance == null)
             {
                 return NotFound();
             }

             var voitures = await _voitureService.GetAllVoituresAsync();
             ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", assurance.VoitureId);
             return View(assurance);
         }*/

        // POST: Assurance/Edit/5
      /*  [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] Assurance assurance)
        {
            if (id != assurance.Id)
            {
                return NotFound();
            }

>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
            //if (ModelState.IsValid)
            {
                try
                {
                    await _assuranceService.UpdateAssuranceAsync(assurance);
                    TempData["SuccessMessage"] = "Assurance has been updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AssuranceExists(assurance.Id))
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
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", assurance.VoitureId);
            return View(assurance);
<<<<<<< HEAD
        }
=======
        }*/
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84

        // GET: Assurance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurance = await _assuranceService.GetAssuranceByIdAsync(id.Value);
            if (assurance == null)
            {
                return NotFound();
            }

            return View(assurance);
        }

        // POST: Assurance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _assuranceService.DeleteAssuranceAsync(id);
            TempData["SuccessMessage"] = "Assurance has been deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

<<<<<<< HEAD
        private async Task<bool> AssuranceExists(int id)
        {
            var assurance = await _assuranceService.GetAssuranceByIdAsync(id);
            return assurance != null;
        }
=======
       
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
    }
}
