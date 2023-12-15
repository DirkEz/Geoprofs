using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Pages.werknemer_aanmaken
{
    public class EditModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public EditModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Werknemer Werknemer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Werknemer == null)
            {
                return NotFound();
            }

            var werknemer =  await _context.Werknemer.FirstOrDefaultAsync(m => m.Id == id);
            if (werknemer == null)
            {
                return NotFound();
            }
            Werknemer = werknemer;
           ViewData["PositieId"] = new SelectList(_context.Set<Positie>(), "Id", "PositieNaam");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Werknemer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WerknemerExists(Werknemer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WerknemerExists(int id)
        {
          return (_context.Werknemer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
