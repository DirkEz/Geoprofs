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
    public class DetailsModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public DetailsModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

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
    }
}
