using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SetecCSharp.Data.DTO.Base;
using SetecCSharp.Data.DTO.Implementations.Date;
using SetecCSharp.Data.VO.Implementations.Date;
using SetecCSharp.Services.Implements.Date;
using Swashbuckle.AspNetCore.Annotations;

namespace SetecCSharp.Controllers.Implements.Date
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class DateController(IDateService Service) : ControllerBase, IDateController
    {
        private readonly IDateService _Service = Service;

        [NonAction]
        public Task<ActionResult<CursorPagedDTO<DateDTO>>> GetAll()
            => throw new NotImplementedException();

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("getById")]
        [SwaggerOperation(Summary = "Obtem um tipo de date",
            Description = "Obtém um tipo de date pelo id")]
        public async Task<ActionResult<DateDTO>> Get([FromQuery] long id)
            => Ok(await _Service.FindById(id));

        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost("post")]
        [SwaggerOperation(Summary = "Cria um tipo de data",
            Description = "Cria uma nova data")]
        public async Task<ActionResult<DateDTO>> Post([FromBody] DateVO VO)
            => Ok(await _Service.Create(VO));

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPut("put")]
        [SwaggerOperation(Summary = "Atualiza um tipo de date",
            Description = "Atualiza um tipo de date pelo id")]
        public async Task<ActionResult<DateDTO>> Put([FromBody] DateVO VO)
            => Ok(await _Service.Update(VO));

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpDelete("delete")]
        [SwaggerOperation(Summary = "deleta um tipo de date")]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            await _Service.Delete(id);
            return NoContent();
        }

        [NonAction]
        public Task<ActionResult<CursorPagedDTO<DateDTO>>> GetAllPaged(long? lastId, int size)
        {
            throw new NotImplementedException();
        }
    }
}