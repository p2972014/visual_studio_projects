using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text;

namespace AspNetCoreWebApp.Pages
{
    [BindProperties]
    public class PageExtCallModel : PageModel
    {        
        public string? m_url { get; set; }
        public string? m_url_content { get; set; }        
        public string? m_error { get; private set; }

        private readonly ILogger<PageExtCallModel> _iLogger;

        public PageExtCallModel(ILogger<PageExtCallModel> iLogger)
        {
            _iLogger = iLogger;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            try
            {
                var tmp = await (new HttpClient().GetAsync(m_url));
                var tmp3 = await tmp.Content.ReadAsStringAsync();
                m_url_content = tmp3;
            }
            catch (Exception ex)
            {
                m_error = ex.Message + ". " + ex.StackTrace;
                _iLogger.LogError(ex, @"PageExtCallModel.OnPost");
            }
        }
    }
}
