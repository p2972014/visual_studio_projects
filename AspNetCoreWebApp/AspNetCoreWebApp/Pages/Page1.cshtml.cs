using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace AspNetCoreWebApp.Pages
{
    [BindProperties]
    public class Page1Model : PageModel
    {
        private readonly IEnumerable<EndpointDataSource> _endpointSources;
        public Page1Model(IEnumerable<EndpointDataSource> endpointSources)
        {
            _endpointSources = endpointSources;
        }

        //---

        public string Message { get; set; } = "Initial Request";
        [BindProperty]
        public string m_input1 { get; set; }
        public void OnGet()
        {
            m_input1 = "OnGet. " + DateTime.Now;
        }

        //public void OnPost()
        public void OnPost()
        {
            Message = "Form Posted. " + DateTime.Now;
        }

        public void OnPut()
        { 
        }

        public void OnDelete()
        { 
        }

        public void OnPostMyhandler1(int id)
        {
            Message = "Myhandler1";
        }

        public void OnPostMyhandler3(int id)
        {
            //Message = "Myhandler3";

            var endpoints = _endpointSources
                .SelectMany(es => es.Endpoints)
                .OfType<RouteEndpoint>();
            var output = endpoints.Select(
                e =>
                {
                    var controller = e.Metadata
                        .OfType<ControllerActionDescriptor>()
                        .FirstOrDefault();
                    var action = controller != null
                        ? $"{controller.ControllerName}.{controller.ActionName}"
                        : null;
                    var controllerMethod = controller != null
                        ? $"{controller.ControllerTypeInfo.FullName}:{controller.MethodInfo.Name}"
                        : null;
                    return new
                    {
                        Route = (e.RoutePattern.RawText ?? @"").TrimStart('/'),
                        RequestDelegate = e.RequestDelegate == null ? @"" :
                            (e.RequestDelegate.Method + " " + e.RequestDelegate.Target)
                    };
                }
            );

            Message = JsonSerializer.Serialize(output);
        }
    }
}
