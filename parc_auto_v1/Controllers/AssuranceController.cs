﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers
{
    public class AssuranceController : Controller
    {
        private readonly IAssuranceService _assuranceService;
        private readonly ApplicationDbContext _context;

        public AssuranceController(IAssuranceService assuranceService, ApplicationDbContext context)
        {
            _assuranceService = assuranceService;
            _context = context;
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

        // GET: Assurance/Create

        public IActionResult Create()
        {
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Matricule");
            return View();
        }

        // POST: Assurance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] Assurance assurance)
        {
           // if (ModelState.IsValid)
            {
                await _assuranceService.AddAssuranceAsync(assurance);
                TempData["SuccessMessage"] = "Assurance has been created successfully!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Matricule", assurance.VoitureId);
            return View(assurance);
        }

        // GET: Assurance/Edit/5
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

            ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Matricule", assurance.VoitureId);
            return View(assurance);
        }

        // POST: Assurance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] Assurance assurance)
        {
            if (id != assurance.Id)
            {
                return NotFound();
            }

          //  if (ModelState.IsValid)
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
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Matricule", assurance.VoitureId);
            return View(assurance);
        }
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

        private async Task<bool> AssuranceExists(int id)
        {
            var assurance = await _assuranceService.GetAssuranceByIdAsync(id);
            return assurance != null;
        }
    }
}
