using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenge.Adopet.WebAPI.Controllers
{
    [ApiController]
    [Route("api/adocao")]
    public class AdopetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdopetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AdopetPetCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromQuery] DeleteAdopetCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
