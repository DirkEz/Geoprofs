using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace geoprofs.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PrivacyModel(ILogger<PrivacyModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public string Username => _httpContextAccessor.HttpContext.Session.GetString("Username");

        public void OnGet()
        {
            _logger.LogInformation($"Username retrieved from session: {Username}");
        }
    }
}


