using AspNetCoreRedis.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace AspNetCoreRedis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDistributedCache _cache;
        private readonly IConfiguration Configuration;
        public string? CachedTimeUTC { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            IDistributedCache cache,
            IConfiguration configuration
            )
        {
            _logger = logger;
            _cache = cache;
            Configuration = configuration;
        }

        //public void OnGet()
        //{
        //}

        public async Task OnGetAsync()
        {
            CachedTimeUTC = "Cached Time Expired";
            var encodedCachedTimeUTC = await Redis.Get_cachedTimeUTC(_cache);

            if (encodedCachedTimeUTC != null)
            {
                CachedTimeUTC = Encoding.UTF8.GetString(encodedCachedTimeUTC);
            }
        }

        public async Task<IActionResult> OnPostResetCachedTime()
        {            
            await Redis.Set_cachedTimeUTC(_cache, Configuration);

            return RedirectToPage();
        }
    }
}