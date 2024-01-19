using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using geoprofs.Data;
using geoprofs.Models;

namespace geoprofs.Werknemers
{
    public class IndexModel : PageModel
    {
        private readonly geoprofs.Data.geoprofsContext _context;

        public IndexModel(geoprofs.Data.geoprofsContext context)
        {
            _context = context;
        }

        public IList<Aanvraag> Aanvraag { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Aanvraag != null)
            {
                Aanvraag = await _context.Aanvraag
                .Include(a => a.OndersteundDoorWerknemer)
                .Include(a => a.Werknemer).ToListAsync();
            }
        }
    }
}
