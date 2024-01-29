using geoprofs.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class WerknemersModel : PageModel
{
    private readonly geoprofs.Data.geoprofsContext _context;
    private readonly ILogger<WerknemersModel> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WerknemersModel(ILogger<WerknemersModel> logger, geoprofs.Data.geoprofsContext context, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId => _httpContextAccessor.HttpContext.Session.GetString("UserId");
    public IList<Aanvraag> Aanvraag { get; set; } = default!;
    public Werknemer CurrentUser { get; set; } // Add this property to hold the current user
    public Aanvraag CurrentAanvragen { get; set; }
    public async Task OnGetAsync()
    {
        if (_context.Aanvraag != null)
        {
            Aanvraag = await _context.Aanvraag
                .Include(a => a.OndersteundDoorWerknemer)
                .Include(a => a.Werknemer).ToListAsync();
        }

        // Retrieve the Werknemers record for the current user
        CurrentUser = await _context.Werknemer
            .FirstOrDefaultAsync(w => w.Id == int.Parse(UserId));

        CurrentAanvragen = await _context.aanvragen
           .FirstOrDefaultAsync(w => w.WerknemerId == int.Parse(UserId));
    }
}
