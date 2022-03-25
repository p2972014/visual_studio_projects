using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AspNetCoreUsersWindows.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var q = HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            var q2 = HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
            var q3 = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var q4 = HttpContext?.User?.FindFirst(ClaimTypes.Sid)?.Value;
        }
    }
}