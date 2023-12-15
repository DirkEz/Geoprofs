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
    public class DetailsModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public DetailsModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

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
    }
}
