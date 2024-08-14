<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
=======
<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers
{
<<<<<<< HEAD
    [Authorize(Roles = "admin")]
=======
<<<<<<< HEAD
=======
    [Authorize(Roles = "admin")]
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
    public class VignetteController : Controller
    {
        private readonly IVignetteService _vignetteService;
        private readonly IVoitureService _voitureService;

        public VignetteController(IVignetteService vignetteService, IVoitureService voitureService)
        {
            _vignetteService = vignetteService;
            _voitureService = voitureService;
        }

        // GET: Vignette
        public async Task<IActionResult> Index()
        {
            var vignettes = await _vignetteService.GetAllVignettesAsync();
            return View(vignettes);
        }

<<<<<<< HEAD



        // GET: Vignette/Details/5
=======
        // GET: Vignette/Details/5
<<<<<<< HEAD
=======
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
      /*  public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vignette = await _vignetteService.GetVignetteByIdAsync(id.Value);
            if (vignette == null)
            {
                return NotFound();
            }

            return View(vignette);
        }
      */

<<<<<<< HEAD
=======
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vignette = await _vignetteService.GetVignetteByIdAsync(id.Value);
            if (vignette == null)
            {
                return NotFound();
            }

            return View(vignette);
<<<<<<< HEAD
=======
<<<<<<< HEAD


        }

=======
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
        }


      






<<<<<<< HEAD
=======
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
        // GET: Vignette/Create
        [HttpGet]
        public async Task<IActionResult> Create(int? voitureId)
        {
            var model = new Vignette
            {
                VoitureId = voitureId ?? 0 // Set the VoitureId in the model
            };

            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", voitureId);

            return View(model);
        }

        // POST: Vignette/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] Vignette vignette)
        {
          //  if (ModelState.IsValid)
            {
                await _vignetteService.AddVignetteAsync(vignette);
                TempData["SuccessMessage"] = "Vignette has been created successfully!";
                return RedirectToAction(nameof(Index));
            }
            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", vignette.VoitureId);
            return View(vignette);
        }

        // GET: Vignette/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vignette = await _vignetteService.GetVignetteByIdAsync(id.Value);
            if (vignette == null)
            {
                return NotFound();
            }
            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", vignette.VoitureId);
            return View(vignette);
        }

        // POST: Vignette/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] Vignette vignette)
        {
            if (id != vignette.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    await _vignetteService.UpdateVignetteAsync(vignette);
                    TempData["SuccessMessage"] = "Vignette has been updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await VignetteExists(vignette.Id))
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
            ViewData["VoitureId"] = new SelectList(voitures, "Id", "Matricule", vignette.VoitureId);
            return View(vignette);
        }

        // GET: Vignette/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vignette = await _vignetteService.GetVignetteByIdAsync(id.Value);
            if (vignette == null)
            {
                return NotFound();
            }

            return View(vignette);
        }

        // POST: Vignette/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vignetteService.DeleteVignetteAsync(id);
            TempData["SuccessMessage"] = "Vignette has been deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VignetteExists(int id)
        {
            var vignette = await _vignetteService.GetVignetteByIdAsync(id);
            return vignette != null;
        }
<<<<<<< HEAD













        public async Task<IActionResult> Search(string searchString)
        {
            var vignettes = await _vignetteService.GetAllVignettesAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                vignettes = vignettes
                    .Where(v => v.Voiture.Matricule.Contains(searchString))
                    .ToList();
            }

            return PartialView("_vignetteListPartial", vignettes);
        }



 







=======
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
    }
}
