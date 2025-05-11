using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SetecCSharp.Data.Dto.Implementations.Speaker;
using SetecCSharp.Data.DTO.Base;
using SetecCSharp.Data.VO.Implementations.Speaker;
using SetecCSharp.Services.Implements.Speaker;
using Swashbuckle.AspNetCore.Annotations;

namespace SetecCSharp.Controllers.Implements.Speaker
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class SpeakerController(ISpeakerService Service) : ControllerBase, ISpeakerController
    {
        private readonly ISpeakerService _Service = Service;

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getAllPaged")]
        [SwaggerOperation(Summary = "Obtem todos os usuários", Description = "Obtém todos os usuários")]
        public async Task<ActionResult<CursorPagedDTO<SpeakerDTO>>> GetAllPaged(
            [FromQuery] long? lastId, [FromQuery] int size = 10)
            => Ok(await _Service.FindAllPaged(lastId, size));

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getById")]
        [SwaggerOperation(Summary = "Obtem um usuário", Description = "Obtém um usuário pelo id")]
        public async Task<ActionResult<SpeakerDTO>> Get([FromQuery] long id)
            => Ok(await _Service.FindById(id));

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost("post")]
        [SwaggerOperation(Summary = "Cria um usuário", Description = "Cria um novo usuário")]
        public async Task<ActionResult<SpeakerDTO>> Post([FromBody] SpeakerVO VO)
            => Ok(await _Service.Create(VO));

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPut("put")]
        [SwaggerOperation(Summary = "Atualiza um usuário", Description = "Atualiza um usuário pelo id")]
        public async Task<ActionResult<SpeakerDTO>> Put([FromBody] SpeakerVO VO)
            => Ok(await _Service.Update(VO));

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpDelete("delete")]
        [SwaggerOperation(Summary = "deleta um usuário")]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            await _Service.Delete(id);
            return NoContent();
        }
    }
}