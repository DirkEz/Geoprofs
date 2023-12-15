using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Pages.VerlofAanvragen
{
    public class DeleteModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public DeleteModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Aanvraag Aanvraag { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Aanvraag == null)
            {
                return NotFound();
            }

            var aanvraag = await _context.Aanvraag.FirstOrDefaultAsync(m => m.Id == id);

            if (aanvraag == null)
            {
                return NotFound();
            }
            else 
            {
                Aanvraag = aanvraag;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Aanvraag == null)
            {
                return NotFound();
            }
            var aanvraag = await _context.Aanvraag.FindAsync(id);

            if (aanvraag != null)
            {
                Aanvraag = aanvraag;
                _context.Aanvraag.Remove(Aanvraag);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
