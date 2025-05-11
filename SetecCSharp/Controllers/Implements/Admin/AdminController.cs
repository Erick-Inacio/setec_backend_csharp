using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SetecCSharp.Services.Independents;
using Swashbuckle.AspNetCore.Annotations;

namespace SetecCSharp.Controllers.Implements.Admin
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{v:apiVersion}")]
    public class AdminController(AdminService service) : ControllerBase
    {
        private readonly AdminService _service = service;

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        // [Authorize(Roles = "admin")]
        [HttpPost("setrole/{uid}/{role}")]
        [SwaggerOperation(Summary = "Seta um role para um usuário", Description = "Seta um role para um usuário")]
        public async Task<IActionResult> SetRole([FromRoute] string uid, [FromRoute] string role)
        {
            await _service.SetRole(uid, role);
            return NoContent();
        }
    }
}