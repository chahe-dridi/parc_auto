    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using parc_auto_v1.Models;
    using System.Linq;
    using System.Threading.Tasks;

    namespace parc_auto_v1.Controllers
    {
        public class VisiteTechniqueController : Controller
        {
            private readonly ApplicationDbContext _context;

            public VisiteTechniqueController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: VisiteTechnique
            public async Task<IActionResult> Index()
            {
                var visiteTechniques = _context.VisiteTechniques.Include(vt => vt.Voiture);
                return View(await visiteTechniques.ToListAsync());
            }

            // GET: VisiteTechnique/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var visiteTechnique = await _context.VisiteTechniques
                    .Include(vt => vt.Voiture)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (visiteTechnique == null)
                {
                    return NotFound();
                }

                return View(visiteTechnique);
            }

            // GET: VisiteTechnique/Create
            public IActionResult Create()
            {
                ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Matricule");
                return View();
            }

            // POST: VisiteTechnique/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,DateEchance,DateValide,Alert,PrixUnitaire,VoitureId")] VisiteTechnique visiteTechnique)
            {
            //    if (ModelState.IsValid)
                {
                    _context.Add(visiteTechnique);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Matricule", visiteTechnique.VoitureId);
                return View(visiteTechnique);
            }

            // GET: VisiteTechnique/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var visiteTechnique = await _context.VisiteTechniques.FindAsync(id);
                if (visiteTechnique == null)
                {
                    return NotFound();
                }
                ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Matricule", visiteTechnique.VoitureId);
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

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(visiteTechnique);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VisiteTechniqueExists(visiteTechnique.Id))
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
                ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Matricule", visiteTechnique.VoitureId);
                return View(visiteTechnique);
            }

            // GET: VisiteTechnique/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var visiteTechnique = await _context.VisiteTechniques
                    .Include(vt => vt.Voiture)
                    .FirstOrDefaultAsync(m => m.Id == id);
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
                var visiteTechnique = await _context.VisiteTechniques.FindAsync(id);
                _context.VisiteTechniques.Remove(visiteTechnique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool VisiteTechniqueExists(int id)
            {
                return _context.VisiteTechniques.Any(e => e.Id == id);
            }
        }
    }
