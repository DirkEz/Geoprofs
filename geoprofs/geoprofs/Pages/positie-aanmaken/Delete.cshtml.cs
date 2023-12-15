using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Pages.positie_aanmaken
{
    public class DeleteModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public DeleteModel(geoprofs.Data.geoprofsContext context)
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

            var positie = await _context.Positie.FirstOrDefaultAsync(m => m.Id == id);

            if (positie == null)
            {
                return NotFound();
            }
            else 
            {
                Positie = positie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Positie == null)
            {
                return NotFound();
            }
            var positie = await _context.Positie.FindAsync(id);

            if (positie != null)
            {
                Positie = positie;
                _context.Positie.Remove(Positie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
