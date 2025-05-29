using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SetecCSharp.Data.DTO.Base;
using SetecCSharp.Data.DTO.Implementations.Event;
using SetecCSharp.Data.VO.Implementations.Event;
using SetecCSharp.Services.Implements.Event;
using Swashbuckle.AspNetCore.Annotations;

namespace SetecCSharp.Controllers.Implements.Event
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class EventController(IEventService Service) : ControllerBase, IEventController
    {
        private readonly IEventService _Service = Service;



        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getAll")]
        [SwaggerOperation(Summary = "Obtem todos os eventos", Description = "Obtém todos os eventos")]
        public async Task<ActionResult<CursorPagedDTO<EventDTO>>> GetAll()
            => Ok(await _Service.FindAll());

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getById")]
        [SwaggerOperation(Summary = "Obtem um evento", Description = "Obtém um evento pelo id")]
        public async Task<ActionResult<EventDTO>> Get([FromQuery] long id)
            => Ok(await _Service.FindById(id));

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost("post")]
        [SwaggerOperation(Summary = "Cria um evento", Description = "Cria um novo evento")]
        public async Task<ActionResult<EventDTO>> Post([FromBody] EventVO VO)
            => Ok(await _Service.Create(VO));

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPut("put")]
        [SwaggerOperation(Summary = "Atualiza um evento", Description = "Atualiza um evento pelo id")]
        public async Task<ActionResult<EventDTO>> Put([FromBody] EventVO VO)
            => Ok(await _Service.Update(VO));

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpDelete("delete")]
        [SwaggerOperation(Summary = "deleta um evento")]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            await _Service.Delete(id);
            return NoContent();
        }

        [NonAction]
        public Task<ActionResult<CursorPagedDTO<EventDTO>>> GetAllPaged(
            [FromQuery] long? lastId, [FromQuery] int size = 10
        )
        {
            throw new NotImplementedException();
        }
    }
}