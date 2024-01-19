using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using geoprofs.Models;
using System.Linq;
using geoprofs.Data;

namespace geoprofs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly geoprofsContext _context;

        public IndexModel(ILogger<IndexModel> logger, geoprofsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string Voornaam { get; set; }

        [BindProperty]
        public string Achternaam { get; set; }

        [BindProperty]
        public string Wachtwoord { get; set; }

        [BindProperty]
        public string LoggedIn { get; set; }

        public IActionResult OnPost()
        {
            var voornaamValue = Voornaam;
            var achternaamValue = Achternaam;
            var wachtwoordValue = Wachtwoord;
            var LoggedInValue = LoggedIn;

            var userInDb = _context.Werknemer
                .FirstOrDefault(u => u.Voornaam == Voornaam && u.Achternaam == Achternaam && u.Wachtwoord == Wachtwoord);

            if (userInDb != null)
            {
                HttpContext.Session.SetString("UserId", userInDb.Id.ToString());
                HttpContext.Session.SetString("Username", userInDb.Voornaam);

                // Log successful login
                _logger.LogInformation($"User '{userInDb.Voornaam}' logged in.");

                return RedirectToPage("/Werknemers");
            }
            else
            {
                // Log failed login attempt
                _logger.LogWarning($"Failed login attempt for user '{Voornaam}'.");

                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }
        }
    }
}
