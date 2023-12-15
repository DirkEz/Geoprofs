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

namespace geoprofs.Pages.positie_aanmaken
{
    public class EditModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public EditModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Positie Positie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Positie == null)
            {
                return NotFound();
            }

            var positie =  await _context.Positie.FirstOrDefaultAsync(m => m.Id == id);
            if (positie == null)
            {
                return NotFound();
            }
            Positie = positie;
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

            _context.Attach(Positie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositieExists(Positie.Id))
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

        private bool PositieExists(int id)
        {
          return (_context.Positie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
