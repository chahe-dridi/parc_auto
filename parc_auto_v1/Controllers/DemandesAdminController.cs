using Microsoft.AspNetCore.Mvc;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;

namespace parc_auto_v1.Controllers
{
    public class DemandesAdminController : Controller
    {
        private readonly IDemandesService _demandesService;
        private readonly IVoitureService _voitureService;

        public DemandesAdminController(IDemandesService demandesService, IVoitureService voitureService)
        {
            _demandesService = demandesService;
            _voitureService = voitureService;
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

            var availableVoitures = await _voitureService.GetAvailableVoituresAsync(); // Use the new method to get available cars
            ViewBag.AvailableVoitures = availableVoitures;

            return View(demande);
        }

        /* [HttpPost]
         public async Task<IActionResult> ConfirmAcceptance(int id, int? voitureId, string action)
         {
             var demande = await _demandesService.GetDemandeByIdAsync(id);
             if (demande == null)
             {
                 return NotFound();
             }

             if (action == "Accept")
             {
                 demande.Etat = "Accepted"; // Update the state to Accepted
                 demande.VoitureId = voitureId; // Link the selected car
             }
             else if (action == "Refuse")
             {
                 demande.Etat = "Refused"; // Update the state to Refused
                 demande.VoitureId = null; // Unlink any car
             }

             await _demandesService.UpdateDemandeAsync(demande);
             return RedirectToAction(nameof(Index)); // Redirect after successful update
         }*/

        [HttpPost]
        public async Task<IActionResult> ConfirmAcceptance(int id, int? voitureId, string action)
        {
            var demande = await _demandesService.GetDemandeByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }

            if (action == "Accept")
            {
                demande.Etat = "Accepted"; // Update the state to Accepted
                demande.VoitureId = voitureId; // Link the selected car

                if (voitureId.HasValue)
                {
                    var voiture = await _voitureService.GetVoitureByIdAsync(voitureId.Value);
                    if (voiture != null)
                    {
                        voiture.Disponibilite = "Reserved"; // Update the availability status
                        await _voitureService.UpdateVoitureAsync(voiture);
                    }
                }
            }
            else if (action == "Refuse")
            {
                demande.Etat = "Refused"; // Update the state to Refused
                demande.VoitureId = null; // Unlink any car

                // Optionally handle availability update if needed
            }

            await _demandesService.UpdateDemandeAsync(demande);
            return RedirectToAction(nameof(Index)); // Redirect after successful update
        }





        public async Task<IActionResult> Edit(int id)
        {
            var demande = await _demandesService.GetDemandeByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }

            var availableVoitures = await _voitureService.GetAvailableVoituresAsync();
            ViewBag.AvailableVoitures = availableVoitures;

            return View(demande);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Demandes updatedDemande)
        {
            if (id != updatedDemande.Id)
            {
                return BadRequest();
            }

        //    if (ModelState.IsValid)
            {
                await _demandesService.UpdateDemandeAsync(updatedDemande);
                return RedirectToAction(nameof(Index));
            }

            var availableVoitures = await _voitureService.GetAvailableVoituresAsync();
            ViewBag.AvailableVoitures = availableVoitures;

            return View(updatedDemande);
        } 

       




    }
}
