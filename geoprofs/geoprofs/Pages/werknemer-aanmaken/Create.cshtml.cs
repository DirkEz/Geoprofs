using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Pages.werknemer_aanmaken
{
    public class CreateModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public CreateModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PositieId"] = new SelectList(_context.Set<Positie>(), "Id", "PositieNaam");
        ViewData["SupervisorId"] = new SelectList(_context.Set<Werknemer>(), "Id", "Voornaam");
            return Page();
        }

        [BindProperty]
        public Werknemer Werknemer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Werknemer == null || Werknemer == null)
            {
                return Page();
            }

            _context.Werknemer.Add(Werknemer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
