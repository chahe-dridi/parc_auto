using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;  // Add this line
using System.Threading.Tasks;

public class VoitureController : Controller
{
    private readonly IVoitureService _voitureService;

    public VoitureController(IVoitureService voitureService)
    {
        _voitureService = voitureService;
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
    public IActionResult Create()
    {
        return View();
    }

    // POST: Voiture/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Matricule,TypeVoiture,Marque,Modele,Km,Carburant,Etat,Disponibilite")] Voiture voiture)
    {
      //  if (ModelState.IsValid)
        {
            await _voitureService.AddVoitureAsync(voiture);
            TempData["SuccessMessage"] = "Voiture has been added successfully!";
            return RedirectToAction(nameof(Index));
        }
        return View(voiture);
    }

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

        return View(voiture);
    }

    // POST: Voiture/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Matricule,TypeVoiture,Marque,Modele,Km,Carburant,Etat,Disponibilite")] Voiture voiture)
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
}
