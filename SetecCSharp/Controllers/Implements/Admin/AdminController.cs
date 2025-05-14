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

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        // [Authorize(Roles = "admin")]
        [HttpPost("setClaimUserId/{uid}/{userId}/{role}")]
        [SwaggerOperation(Summary = "Seta o id na claim", Description = "Seta o id na claim do usuari do firebase")]
        public async Task<IActionResult> SetClaimUserId([FromRoute] string uid,
        [FromRoute] long userId, [FromRoute] string role)
        {
            await _service.SetClaims(uid, userId, role);
            return Ok();
        }

        [HttpGet("debug-token")]
        [SwaggerOperation(Summary = "obtem o token", Description = "uso apenas em developmente")]

        public async Task<IActionResult> DebugToken()
        {
            var authHeader = Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return Unauthorized("Token não fornecido.");

            var token = authHeader.Replace("Bearer ", "");

            try
            {
                var decoded = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);

                return Ok(new
                {
                    uid = decoded.Uid,
                    claims = decoded.Claims
                });
            }
            catch (Exception ex)
            {
                return Unauthorized("Token inválido: " + ex.Message);
            }
        }
    }
}