using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Pages.werknemer_aanmaken
{
    public class DeleteModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public DeleteModel(geoprofs.Data.geoprofsContext context)
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

            var werknemer = await _context.Werknemer.FirstOrDefaultAsync(m => m.Id == id);

            if (werknemer == null)
            {
                return NotFound();
            }
            else 
            {
                Werknemer = werknemer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Werknemer == null)
            {
                return NotFound();
            }
            var werknemer = await _context.Werknemer.FindAsync(id);

            if (werknemer != null)
            {
                Werknemer = werknemer;
                _context.Werknemer.Remove(Werknemer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
