using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using geoprofs.Data;
using geoprofs.Models;
using Microsoft.EntityFrameworkCore;

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
            // Verify that the WerknemerId exists in the database
            bool werknemerExists = await _context.Werknemer.AnyAsync(w => w.Id == Aanvraag.WerknemerId);
            if (!werknemerExists)
            {
                // Handle the case where WerknemerId does not exist by setting it to a known valid ID
                Aanvraag.WerknemerId = 1004; // Ensure this ID exists in your Werknemer table
            }

            // Additionally, verify that the OndersteundDoorWerknemerId exists in the database
            bool ondersteundDoorExists = await _context.Werknemer.AnyAsync(w => w.Id == Aanvraag.OndersteundDoorWerknemerId);
            if (!ondersteundDoorExists)
            {
                // Handle the case where OndersteundDoorWerknemerId does not exist
                // You could set it to the same default valid ID if appropriate, or another known valid ID
                Aanvraag.OndersteundDoorWerknemerId = 1004; // Adjust as necessary to a valid ID
            }

            _context.Aanvraag.Add(Aanvraag);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }



    }
}
