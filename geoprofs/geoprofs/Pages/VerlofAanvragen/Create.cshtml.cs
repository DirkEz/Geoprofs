using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Pages.VerlofAanvragen
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
        ViewData["OndersteundDoorWerknemerId"] = new SelectList(_context.Set<Werknemer>(), "Id", "Achternaam");
        ViewData["WerknemerId"] = new SelectList(_context.Set<Werknemer>(), "Id", "Achternaam");
            return Page();
        }

        [BindProperty]
        public Aanvraag Aanvraag { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Aanvraag == null || Aanvraag == null)
            {
                return Page();
            }

            _context.Aanvraag.Add(Aanvraag);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
