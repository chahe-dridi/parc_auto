using Microsoft.AspNetCore.Mvc;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
using System.Threading.Tasks;


using System.IO;
using System.Threading.Tasks;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using PdfSharpCore.Drawing.Layout;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace parc_auto_v1.Controllers
{
    [Authorize(Roles = "admin")]
    public class DemandesAdminController : Controller
    {
        private readonly IDemandesService _demandesService;
        private readonly IVoitureService _voitureService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;


        public DemandesAdminController(IWebHostEnvironment webHostEnvironment, IDemandesService demandesService, IVoitureService voitureService  , ApplicationDbContext context)
        {
            _demandesService = demandesService;
            _voitureService = voitureService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;

        }

        /*    public async Task<IActionResult> Index()
             {
                var demandes = await _demandesService.GetAllDemandesAsync();
               //  var demandes = _context.Demandes.ToList();
                 return View(demandes);
             } */

        /*    public IActionResult Index()
            {
                // Example: Sorting by Id in descending order
                var demandes = _context.Demandes
                    .OrderByDescending(d => d.Id)  // Sorting by Id in descending order
                    .ToList();

                return View(demandes);
            }
        */

        public IActionResult Index()
        {
            // Retrieve and include the Voiture navigation property
            var demandes = _context.Demandes
                .Include(d => d.Voiture)  // Ensure the Voiture navigation property is included
                .OrderByDescending(d => d.Id)  // Sorting by Id in descending order
                .ToList();

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




        /* public IActionResult SearchDemandes(string searchString)
         {
             IEnumerable<Demandes> demandes;

             if (string.IsNullOrEmpty(searchString))
             {
                 // Return all records if the searchString is empty
                 demandes = _context.Demandes.ToList();
             }
             else
             {
                 // Perform the search with the provided searchString
                 demandes = _context.Demandes
                                    .Where(d => d.IdEmploye.Contains(searchString) || d.Voiture.Matricule.Contains(searchString))
                                    .ToList();
             }

             return PartialView("_DemandesListPartial", demandes);
         }
        */


        /* public IActionResult SearchDemandes(string searchString)
         {
             IEnumerable<Demandes> demandes;

             if (string.IsNullOrEmpty(searchString))
             {
                 // Return all records if the searchString is empty
                 demandes = _context.Demandes
                                    .Include(d => d.Voiture) // Include the Voiture navigation property
                                    .ToList();
             }
             else
             {
                 // Perform the search with the provided searchString
                 demandes = _context.Demandes
                                    .Include(d => d.Voiture) // Include the Voiture navigation property
                                    .Where(d => d.IdEmploye.Contains(searchString) ||
                                                (d.Voiture != null && d.Voiture.Matricule.Contains(searchString)))
                                    .ToList();
             }

             return PartialView("_DemandesListPartial", demandes);
         }
         */

        public IActionResult SearchDemandes(string searchString)
        {
            IQueryable<Demandes> demandesQuery;

            if (string.IsNullOrEmpty(searchString))
            {
                // Return all records if the searchString is empty
                demandesQuery = _context.Demandes
                                       .Include(d => d.Voiture) // Include the Voiture navigation property
                                       .OrderByDescending(d => d.Id); // Sort by Id in descending order
            }
            else
            {
                // Perform the search with the provided searchString
                demandesQuery = _context.Demandes
                                       .Include(d => d.Voiture) // Include the Voiture navigation property
                                       .Where(d => d.IdEmploye.Contains(searchString) ||
                                                   (d.Voiture != null && d.Voiture.Matricule.Contains(searchString)))
                                       .OrderByDescending(d => d.Id); // Sort by Id in descending order
            }

            var demandes = demandesQuery.ToList();

            return PartialView("_DemandesListPartial", demandes);
        }


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






 
        //pdf for one demande

        public async Task<IActionResult> DownloadPdf(int id)
        {
            var demande = await _demandesService.GetDemandeByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }

            var pdf = new PdfDocument();
            var page = pdf.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var fontBold = new XFont("Verdana", 12, XFontStyle.Bold);
            var fontTitle = new XFont("Verdana", 14, XFontStyle.Bold);
            var fontContent = new XFont("Verdana", 12, XFontStyle.Regular);


            var photoPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "Logo_Banque_de_Tunisie.png"); // Adjust the image file name if necessary
            var photo = XImage.FromFile(photoPath);

            // Set photo position and size
            var photoWidth = 100; // Adjust as needed
            var photoHeight = 75; // Adjust as needed
            var photoX = (page.Width - photoWidth) / 2;
            var photoY = 60; // Adjust based on the vertical spacing you need

            gfx.DrawImage(photo, photoX, photoY, photoWidth, photoHeight);



            // Top Left Corner
            gfx.DrawString("Direction des Moyens Généraux", fontBold, XBrushes.Black, new XRect(40, 40, page.Width - 80, 20), XStringFormats.TopLeft);

            // Underline for "Division PARC AUTOS"
            var divisionText = "Division PARC AUTOS";
            var divisionSize = gfx.MeasureString(divisionText, fontBold);
            var divisionX = 40;
            var divisionY = 60;
            gfx.DrawString(divisionText, fontBold, XBrushes.Black, new XRect(divisionX, divisionY, page.Width - 80, 20), XStringFormats.TopLeft);
            gfx.DrawLine(XPens.Black, divisionX, divisionY + 20, divisionX + divisionSize.Width, divisionY + 20);

            // Center the photo between "Division PARC AUTOS" and "ORDRE DE MISSION"
            var todayDate = DateTime.Now.ToString("dd/MM/yyyy");
            gfx.DrawString($"Tunis le : {todayDate}", fontBold, XBrushes.Black, new XRect(page.Width - 200, 40, 160, 20), XStringFormats.TopLeft);

            int yPosition = photoY + photoHeight + 60; // Starting y position for details
            int columnWidth = 200; // Width of each column


            // Middle - Centered Title with Underline
            var titleText = "ORDRE DE MISSION";
            var titleSize = gfx.MeasureString(titleText, fontTitle);
            var titleX = (page.Width - titleSize.Width) / 2; // Center the text horizontally
            gfx.DrawString(titleText, fontTitle, XBrushes.Black, new XRect(titleX, photoY + photoHeight + 20, titleSize.Width, titleSize.Height), XStringFormats.TopLeft);

            // Underline for "ORDRE DE MISSION"
            gfx.DrawLine(XPens.Black, titleX, photoY + photoHeight + 40, titleX + titleSize.Width, photoY + photoHeight + 40);

            // Structured Details
       
            // Define content labels and values
            var details = new (string label, string value)[]
            {
            ("Objet:", "Autorisation"),
            ("Destination:", demande.Destination),
            ("Mission:", demande.Mission),
            ("Voiture de service:", demande.Voiture?.Matricule),
            ("Date et/Ou Horaire:", $"{demande.DateDepart:dd/MM/yyyy} - {demande.DateArrivee:dd/MM/yyyy}")
            };

            // Draw each label and value in columns
            for (int i = 0; i < details.Length; i++)
            {
                gfx.DrawString(details[i].label, fontBold, XBrushes.Black, new XRect(40, yPosition + (i * 40), columnWidth, 20), XStringFormats.TopLeft);
                gfx.DrawString(details[i].value, fontContent, XBrushes.Black, new XRect(40 + columnWidth, yPosition + (i * 40), page.Width - 80 - columnWidth, 20), XStringFormats.TopLeft);
            }

            // Bottom
            
            gfx.DrawString("CHEF DE PARC", fontBold, XBrushes.Black, new XRect(page.Width - 160, yPosition + (details.Length * 40) + 40, 160, 20), XStringFormats.TopLeft);

            // Underline for "CHEF DE PARC"
            var chefDeParcSize = gfx.MeasureString("CHEF DE PARC", fontBold);
            var chefDeParcX = page.Width - 160;
            gfx.DrawLine(XPens.Black, chefDeParcX, yPosition + (details.Length * 40) + 60, chefDeParcX + chefDeParcSize.Width, yPosition + (details.Length * 40) + 60);

            using (var stream = new MemoryStream())
            {
                pdf.Save(stream, false);
                var fileBytes = stream.ToArray();
                return File(fileBytes, "application/pdf", "DemandeDetails.pdf");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var demande = await _demandesService.GetDemandeByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }

            await _demandesService.DeleteDemandeAsync(id);
            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> SearchByDate(DateTime? DateDebut, DateTime? DateFin)
        {
            if (!DateDebut.HasValue || !DateFin.HasValue)
            {
                // Return an error view or redirect to a different action if the dates are not provided
                return View("Error");
            }

            var demandes = _context.Demandes.AsQueryable();

            demandes = demandes.Where(d => d.DateDepart >= DateDebut && d.DateArrivee <= DateFin);

            var demandesList = await demandes.ToListAsync();

            // Pass the dates back to the view for display in the search form
            ViewData["DateDebut"] = DateDebut.Value.ToString("yyyy-MM-dd");
            ViewData["DateFin"] = DateFin.Value.ToString("yyyy-MM-dd");

            return View(demandesList);
        }







        public async Task<IActionResult> DownloadExcel(string searchString, string searchMatricule)
        {
            var demandes = await _demandesService.GetAllDemandesAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                demandes = demandes.Where(d => d.IdEmploye.Contains(searchString)).ToList();
            }

            if (!string.IsNullOrEmpty(searchMatricule))
            {
                demandes = demandes.Where(d => d.Voiture != null && d.Voiture.Matricule.Contains(searchMatricule)).ToList();
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Demandes Report");

                // Set headers
                var headers = new[]
                {
            "Nom & Prenom", "Id Employe", "Affectation Departement", "Type Voiture",
            "Destination", "Dates", "Description", "Mission", "Etat", "Matricule"
        };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Cells[1, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[1, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[1, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[1, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                // Populate data
                for (int row = 0; row < demandes.Count; row++)
                {
                    var demande = demandes[row];
                    worksheet.Cells[row + 2, 1].Value = $"{demande.Nom} {demande.Prenom}";
                    worksheet.Cells[row + 2, 2].Value = demande.IdEmploye;
                    worksheet.Cells[row + 2, 3].Value = demande.AffectationDepartement;
                    worksheet.Cells[row + 2, 4].Value = demande.TypeVoiture;
                    worksheet.Cells[row + 2, 5].Value = demande.Destination;
                    worksheet.Cells[row + 2, 6].Value = $"{demande.DateDepart.ToShortDateString()} - {demande.DateArrivee.ToShortDateString()}";
                    worksheet.Cells[row + 2, 7].Value = demande.Description;
                    worksheet.Cells[row + 2, 8].Value = demande.Mission;
                    worksheet.Cells[row + 2, 9].Value = demande.Etat;

                    if(demande.Etat == "Refused")
                    {
                        worksheet.Cells[row + 2, 10].Value = "Refuse";
                    }
                    else if (demande.Etat == "En attente")
                    {
                        worksheet.Cells[row + 2, 10].Value = "En attente";

                    }
                    else
                    {
                        worksheet.Cells[row + 2, 10].Value =   demande.Voiture.Matricule  ;
                    }
                    
                }

                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);
                    var fileBytes = stream.ToArray();
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Demandes.xlsx");
                }
            }
        }







    }
}
