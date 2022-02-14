using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace AspNetCoreWebApp.Pages
{
    public class Page_servicesModel : PageModel
    {
        private readonly ILogger<Page_servicesModel> _logger;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        public Page_servicesModel(
            ILogger<Page_servicesModel> logger,
            ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2
            )
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        public void OnGet()
        {
            tmp_UpdateServicesIds();
        }

        public void OnPost()
        {
            tmp_UpdateServicesIds();
        }

        void tmp_UpdateServicesIds()
        { 
             ViewData["transient1"] = _transientService1.GetOperationID().ToString();
            ViewData["transient2"] = _transientService2.GetOperationID().ToString();
            ViewData["scoped1"] = _scopedService1.GetOperationID().ToString();
            ViewData["scoped2"] = _scopedService2.GetOperationID().ToString();
            ViewData["singleton1"] = _singletonService1.GetOperationID().ToString();
            ViewData["singleton2"] = _singletonService2.GetOperationID().ToString();       
        }
    }
}
