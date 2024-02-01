using geoprofs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace geoprofs.Pages.VerlofAanvragen
{
    public class ApprovalModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public ApprovalModel(geoprofs.Data.geoprofsContext context)
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
            Aanvraag = aanvraag;
            ViewData["OndersteundDoorWerknemerId"] = new SelectList(_context.Set<Werknemer>(), "Id", "Achternaam");
            ViewData["WerknemerId"] = new SelectList(_context.Set<Werknemer>(), "Id", "Achternaam");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //  return Page();
            //            }

            _context.Attach(Aanvraag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AanvraagExists(Aanvraag.Id))
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

        private bool AanvraagExists(int id)
        {
            return (_context.Aanvraag?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
