using Microsoft.AspNetCore.Mvc;
using parc_auto_v1.Models;
using System.Diagnostics;

namespace parc_auto_v1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Test database connection
                var isConnected = await _context.Database.CanConnectAsync();
                _logger.LogInformation($"Database connection established: {isConnected}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error connecting to database: {ex.Message}");
            }

            ViewData["Title"] = "Hello Page";
            return View();
        }



        public IActionResult hello()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Action to display the demand form for 4 places cars
        public IActionResult DemandFormForFourPlaces()
        {
            var model = new Demandes
            {
                TypeVoiture = "4 places",
                  // Method to get the current client ID
            };
            ViewData["Title"] = "Demand Form";
            return View("DemandForm", model);
        }

        // Action to display the demand form for utility cars
        public IActionResult DemandFormForUtility()
        {
            var model = new Demandes
            {
                TypeVoiture = "utility",
                 // Method to get the current client ID
            };
            ViewData["Title"] = "Demand Form";
            return View("DemandForm", model);
        }

        // Action method to handle form submission
        [HttpPost]
        public IActionResult SubmitDemandForm(Demandes model)
        {
            // Process form submission logic here (save to database, etc.)
            // Redirect to a thank you page or another appropriate action
            return RedirectToAction("Index"); // Example: redirect to index page
        }

        // Mock method to get the current client ID
        private int GetCurrentClientId()
        {
            // Replace with actual logic to get the current client ID
            return 1;
        }
    }
}
