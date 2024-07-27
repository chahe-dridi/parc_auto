using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers
{
    [Authorize(Roles = "client,admin")]
    
    public class DemandesController : Controller
    {
        private readonly IDemandesService _demandesService;

        public DemandesController(IDemandesService demandesService)
        {
            _demandesService = demandesService;
        }

        public async Task<IActionResult> Index()
        {
            var demandes = await _demandesService.GetAllDemandesAsync();
            return View(demandes);
        }

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
