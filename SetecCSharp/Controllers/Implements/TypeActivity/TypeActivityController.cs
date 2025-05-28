using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SetecCSharp.Data.DTO.Base;
using SetecCSharp.Data.DTO.Implementations.TypeActivity;
using SetecCSharp.Data.VO.Implementations.TypeActivity;
using SetecCSharp.Services.Implements.TypeActivity;
using Swashbuckle.AspNetCore.Annotations;

namespace SetecCSharp.Controllers.Implements.TypeActivity
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class TypeActivityController(ITypeActivityService Service) : ControllerBase, ITypeActivityController
    {
        private readonly ITypeActivityService _Service = Service;


        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getAll")]
        [SwaggerOperation(Summary = "Obtem todos os tipo de atividades",
            Description = "Obtém todos os tipo de atividades")]
        public async Task<ActionResult<CursorPagedDTO<TypeActivityDTO>>> GetAll()
            => Ok(await _Service.FindAll());

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getById")]
        [SwaggerOperation(Summary = "Obtem um tipo de atividade",
            Description = "Obtém um tipo de atividade pelo id")]
        public async Task<ActionResult<TypeActivityDTO>> Get([FromQuery] long id)
            => Ok(await _Service.FindById(id));

        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost("post")]
        [SwaggerOperation(Summary = "Cria um tipo de atividade",
            Description = "Cria um novo tipo de atividade")]
        public async Task<ActionResult<TypeActivityDTO>> Post([FromBody] TypeActivityVO VO)
            => Ok(await _Service.Create(VO));

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPut("put")]
        [SwaggerOperation(Summary = "Atualiza um tipo de atividade",
            Description = "Atualiza um tipo de atividade pelo id")]
        public async Task<ActionResult<TypeActivityDTO>> Put([FromBody] TypeActivityVO VO)
            => Ok(await _Service.Update(VO));

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpDelete("delete")]
        [SwaggerOperation(Summary = "deleta um tipo de atividade")]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            await _Service.Delete(id);
            return NoContent();
        }

        [NonAction]
        public Task<ActionResult<CursorPagedDTO<TypeActivityDTO>>> GetAllPaged(long? lastId, int size)
        {
            throw new NotImplementedException();
        }
    }
}