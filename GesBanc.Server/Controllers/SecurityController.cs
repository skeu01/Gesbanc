using System.Threading.Tasks;
using Gesbanc.Business.Contracts;
using Gesbanc.Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GesBanc.Server.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _service;
        private readonly AppSettings _appSettings;

        public SecurityController(ISecurityService service, IOptions<AppSettings> appSettings)
        {
            _service = service;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]string username, string password)
        {
            var user = await _service.AuthenticateAsync(username, password, _appSettings.Secret);

            if (user == null)
                return Unauthorized();

            return Ok(user);
        }
    }
}
