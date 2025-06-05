using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SetecCSharp.Data.DTO.Base;
using SetecCSharp.Data.DTO.Implementations.Activity;
using SetecCSharp.Data.VO.Implementations.Activity;
using SetecCSharp.Services.Implements.Activity;
using Swashbuckle.AspNetCore.Annotations;

namespace SetecCSharp.Controllers.Implements.Activity
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ActivityController(IActivityService Service) : ControllerBase, IActivityController
    {
        private readonly IActivityService _Service = Service;

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getAll")]
        [SwaggerOperation(Summary = "Obtem todos os tipo de atividades",
            Description = "Obtém todos os tipo de atividades")]
        public async Task<ActionResult<CursorPagedDTO<ActivityDTO>>> GetAll()
            => Ok(await _Service.FindAll());

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getById")]
        [SwaggerOperation(Summary = "Obtem um tipo de atividade",
            Description = "Obtém um tipo de atividade pelo id")]
        public async Task<ActionResult<ActivityDTO>> Get([FromQuery] long id)
            => Ok(await _Service.FindById(id));

        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost("post")]
        [SwaggerOperation(Summary = "Cria um tipo de atividade",
            Description = "Cria um novo tipo de atividade")]
        public async Task<ActionResult<ActivityDTO>> Post([FromBody] ActivityVO VO)
            => Ok(await _Service.Create(VO));

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPut("put")]
        [SwaggerOperation(Summary = "Atualiza um tipo de atividade",
            Description = "Atualiza um tipo de atividade pelo id")]
        public async Task<ActionResult<ActivityDTO>> Put([FromBody] ActivityVO VO)
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
        public Task<ActionResult<CursorPagedDTO<ActivityDTO>>> GetAllPaged(long? lastId, int size)
        {
            throw new NotImplementedException();
        }

        //Personalised Methods
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getByEventId/id={eventId}")]
        [SwaggerOperation(Summary = "Obtem uma lista de atividade",
            Description = "Obtém uma lista de atividade por evento")]
        public async Task<ActionResult<ActivityDTO>> GetByEventId([FromRoute] long eventId)
            => Ok(await _Service.FindActivitiesByEvent(eventId));

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getByTypeId/id={typeId}")]
        [SwaggerOperation(Summary = "Obtem uma lista de atividade",
        Description = "Obtém uma lista de atividade por tipo")]
        public async Task<ActionResult<ActivityDTO>> GetByType([FromRoute] long typeId)
        => Ok(await _Service.FindActivitiesByType(typeId));
    }
}