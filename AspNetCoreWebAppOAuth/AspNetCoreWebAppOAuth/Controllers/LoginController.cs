using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace AspNetCoreWebAppOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAuthController : ControllerBase
    {
        private const int m_remember_minutes_span_default = 10;

        [HttpGet]
        //[HttpPost]
        [Route("api/[controller]/login")]
        public async Task<IActionResult> LoginAsync(string LoginName, bool RememberLogin, int? remember_minutes_span)
        {
            var address = new
            {
                street_address = "One Hacker Way",
                locality = "Heidelberg",
                postal_code = 69118,
                country = "Germany"
            };

            var props = new AuthenticationProperties();
            //props.RedirectUri = callbackUrl;
            if (RememberLogin)
            {
                props = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(remember_minutes_span ?? m_remember_minutes_span_default))
                };
            };

            var user =
                new TestUser
                {
                    SubjectId = "88421113",
                    Username = "login_" + LoginName,
                    Password = "P123",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                };

            var isuser = new IdentityServerUser(user.SubjectId)
            {
                DisplayName = "DisplayName_Username_" + user.Username,
                AdditionalClaims = user.Claims
            };

            await HttpContext.SignInAsync(isuser, props);

            return RedirectToPage("Index");
        }

        [HttpGet]
        [Route("api/[controller]/logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();

            return RedirectToPage("Index");
        }
    }
}
